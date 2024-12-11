<#
About:
This PowerShell script will scan for .SLN projects and send the information to our BlackDuck cloud portal (https://elections-ny.app.blackduck.com/) using the settings provided by the file 'BlackDuck_Scan_Properties.txt'. 
The script is written to observe the best practices for managing projects. In our case this means:
	* Using a common location name ($ProjectGenericLocation) to ensure we overwrite and not aggregate to existing projects in the database.
	* Using the project .SLN ($ProjectName) name as identifier we ensure we don't accidentally create project copies.
	* Assigning user groups during scan ($UserGroups) to ensure accurate access.

How to use:
	1) Users of this script must run this script at the root of their projects directory where Project .sln resides.
	2) Users also need the file 'BlackDuck_Scan_Properties.txt' in the same directory. That file contains properties for this.
		a) If this is your first time open the'BlackDuck_Scan_Properties.txt' file and review the Distribution is set appropriately.
		b) You want 'SAAS' (without the quotes) if it's an external site or 'INTERNAL' (again without the quotes) if it's just used internally.
		c) Once this is set for an application you shouldn't need to do it again.
		NOTE: If you fail to do this step. The Distribution will default to 'EXTERNAL' and will need to be manually changed from on the hosted portal.
	3) Right click on the file and select the option "Run with PowerShell".
	4) Follow the prompts on the command line and pay attention to any errors.
	5) You're done.
	
Additional Notes:
	* BlackDuck access is granted by the BlackDuck administrator.
	* The script uses a shared token contained in the properties file therefore any user can execute a scan.
	* If that shared token is revoked the file will need to be modified.
	* Do not modified you properties file as it can lead to scan issues.
#>
$ScriptVersion = "1.0.0"
#Feedback is Key
$ProjectFolder = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
"
================================================================
 Gathering Variables from BlackDuck_Scan_Properties.txt SCRIPT 
================================================================
"
Get-Content BlackDuck_Scan_Properties.txt | Foreach-Object{	
	$var = $_.Split(':')
	"Fetching ='"+$var[0]+"' with value='"+$var[1]+"'."
	if ($var[0].ToLower() -eq "usergroups"){
		New-Variable -Name $var[0] -Value $var[1].Split(',')
	} else {
		New-Variable -Name $var[0] -Value $var[1]
	}
}
if ($ProjectToken -and $ProjectFolder -and $UserGroups -and $Distribution) { 
	$ProjectName = (Get-ChildItem -Path $ProjectFolder\\* -file *.sln).BaseName
	$ProjectGenericLocation = $ProjectName+"_CurrentCode"
}

if ($ProjectToken -and $ProjectFolder -and $UserGroups -and $ProjectName -and $ProjectGenericLocation -and $Distribution) { 
	"
	======================================================
	 STARTING " + $ProjectName + " SCRIPT Version " + $ScriptVersion + "
	======================================================
	"
	"Script File: " + $MyInvocation.MyCommand.Path
	#Set the location to run command from.
	"Pushing location to " + $ProjectFolder
	Push-Location -EA Stop $ProjectFolder

	#Request confirmation.
	$Begin = Read-Host "Do you want to scan the project '"$ProjectName"'? (y/n)"
	if($Begin.ToLower() -eq "y" ){
		
		"User entered: '"+$Begin+"'."
		
		$LoginLevelQuestion = Read-Host "Do you want to scan without debug output? (y/n)"

		"User entered: '"+$LoginLevelQuestion+"'."

		if($LoginLevelQuestion.ToLower() -eq "n" ){		
			$LoginLevel = "DEBUG"		
		} else {		
			$LoginLevel = "INFO"	
		}
		"Login level set to : '"+$LoginLevel+"'."
		
		#Check to see if we have a project name (not equal null)
		if($ProjectName -ne $null ){
			"User Groups are : '"+$UserGroups+"'."
			#Run the command.
			powershell "[Net.ServicePointManager]::SecurityProtocol = 'tls12'; irm https://detect.synopsys.com/detect.ps1?$(Get-Random) | iex; detect" --blackduck.url=https://elections-ny.app.blackduck.com --blackduck.api.token=$ProjectToken --detect.detector.search.depth=3 --detect.trust.cert=true --detect.project.name=$ProjectName --detect.project.version.name=Current --detect.code.location.name=$ProjectGenericLocation --logging.level.detect=$LoginLevel --detect.project.user.groups=$UserGroups --detect.project.version.distribution=$Distribution
			
		} else {
			
			#Provide feedback by throwing an error.
			Write-Error -Message 'Unable to locate project .sln file in the path ["'$ProjectFolder'"].' -Category InvalidArgument
		}
	} else {
		
		"User entered: '"+$Begin+"'."
	}
} else {
	"Unable to set variables"
	"
	======================================================
	 ERROR UNABLE TO SET VARIABLES! 
	======================================================
	"
	if($ProjectToken -eq $null){ "Unable to set 'ProjectToken'!"}
	if($ProjectFolder -eq $null){ "Unable to set 'ProjectFolder'!"}
	if($UserGroups -eq $null){ "Unable to set 'UserGroups'!"}
	if($ProjectName -eq $null){ "Unable to set 'ProjectName'!"}	
	if($ProjectGenericLocation -eq $null){ "Unable to set 'ProjectGenericLocation'!"}
	
}
#Wait for input
Read-Host -Prompt "Press Enter to exit"
Pop-Location 