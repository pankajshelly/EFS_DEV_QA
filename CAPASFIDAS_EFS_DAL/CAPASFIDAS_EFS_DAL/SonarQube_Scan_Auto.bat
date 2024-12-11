:: About:
:: This batch file script will scan for .SLN projects and send the information to our SonarQube cloud portal (http://psqcs1s1.nysboelan.elections.ny.gov:9000/).
:: The script is written to observe the best practices for managing projects. In our case this means:
::		* Using a ServiceAccount shared token to create / execute scans.
::		* Using the batch file location to define scanner path and adding it to TFS so the path conforms to users working folders.
::		* Created permission templates in the server that apply to any project key by using regex .* .
:: How to use:
:: 	1) Users of this script must run it at the root of their project directory where Project .sln resides.
::	2) Users also need the file 'SonarQube_Scan_Properties.txt' in the same directory. That file contains properties for this.
::		a) If this is your first time open the'BlackDuck_Scan_Properties.txt' file.
::			i. Usually you don't need to configure this file but the first time you have to mae sure the appkey is that of the project. 
::			ii. Reseting the token requires the administrator to create a unique service account token.
::			iii. You'll notice the variables are separated by a comma (,) in the format <key>,<value>.
:: 	2) Double click on the "SonarQube_Scan_Auto.bat" file to load the command prompt.
:: 	3) Follow the prompts on the command line and pay attention to any errors.
:: 	4) You're done.
::
:: Additional Notes:
::		* SonarQube access is granted by the SonarQube administrator.
::		* The script uses a shared token contained therefore any user can execute a scan but not every user can log into SonarQube and review code.
::		* If that shared token is revoked the file will need to be modified.
::		* Do not modified you properties file as it can lead to scan issues.

@ECHO OFF
:: Set the variables
SET "scripVersion=1.0.2"
TITLE SonarQube Scan Auto batch Version %scripVersion%
ECHO --------------------------------------------------------------------------
ECHO --------------------------------------------------------------------------
ECHO Starting Sonar Scanner in automatic mode script version %scripVersion%
ECHO --------------------------------------------------------------------------
ECHO --------------------------------------------------------------------------

:: Find the path where this file recides.
SET "slnpathFull="%~dp0""
:: SonarQube needs the path minus the last "/" although it doesn't ECHO well.
SET "slnpath=%slnpathFull:~0,-1%

ECHO 1) Attempting to to locate and read 'SonarQube_Scan_Properties.txt'.

:: Find the "SonarQube_Scan_Properties.txt" and try to set variables based on that.
IF EXIST %~dp0\SonarQube_Scan_Properties.txt (
	FOR /F "tokens=1,2 delims=," %%A IN (SonarQube_Scan_Properties.txt) DO (
		SET "%%A=%%B"
	)
) ELSE (
	ECHO The file "SonarQube_Scan_Properties.txt" is not found in the directory from which this batch file is executed  & ECHO ^(%slnpathFull%^).
)

ECHO:
ECHO:
ECHO 2) Reviewing variables.
SET "runscan=true"
IF "%appkey%"=="" (
	SET "runscan=false"
	ECHO -  ERROR: Unable to locate appkey!
) ELSE (
	ECHO -  Validated appkey.
)

IF "%token%"=="" (
	SET "runscan=false"
	ECHO -  ERROR: Unable to locate token!
) ELSE (
	ECHO -  Validated appkey.
)

IF "%server%"=="" (
	SET "runscan=false"
	ECHO -  ERROR: Unable to locate server!
) ELSE (
	ECHO -  Validated server.
)

IF "%runscan%"=="false" (
	ECHO -  ERROR: Unable to start scanner with the available variables!
	ECHO -  Skipping to End.
	GOTO end
) 

ECHO:
ECHO:
ECHO 3) Starting Sonar Scanner on '%appkey%' in automatic mode.
:start
	SET /P begin1=" -  Type 'y' to start an entire scanner operation (begin/build/submit) or type 'q' to quit."
	ECHO -  You typed "%begin1%"!
	ECHO:
	ECHO ----------------------
	ECHO -  appkey = "%appkey%"
	ECHO -  server = "%server%"
	ECHO -  token = "%token%"
	ECHO -  slnpathFull = %slnpathFull%
	ECHO ----------------------
	ECHO:
	IF "%begin1%" == "y" (
		GOTO prep
	)

	IF "%begin1%" == "q" (
	 	GOTO end
	)	
	
	IF NOT "%begin1%" == "y" IF NOT "%begin1%" == "q"(	
		ECHO Please enter 'y' to start or 'q' to quit.
		GOTO start
	)

:prep
	ECHO:
	ECHO:
	ECHO 4) Deleting old '.sonarqube' folder to avoid issues.
	SET "deletePath=%slnpathFull%.sonarqube"
	ECHO -  Deleting folder "%deletePath%".
	:: Folders can be locked by the old token/creator therefore we delete any existing folders.
	:: /S Removes all directories and files in the specified directory in addition to the directory itself. 
	:: Used to remove a directory tree.
	:: /Q Quiet mode, do not ask if ok to remove a directory tree with /S
	@RD /S /Q %deletePath%
	GOTO begin

:begin
	ECHO:
	ECHO:
	ECHO 5) Begining.
	ECHO -  MsBuild.exe %slnpath% /t:Rebuild 
	ECHO -  SonarScanner.MSBuild.exe begin /k:"%appkey%" /d:sonar.host.url="%server%" /d:sonar.login="%token%"
	SonarScanner.MSBuild.exe begin /k:"%appkey%" /d:sonar.host.url="%server%" /d:sonar.login="%token%"
	GOTO scan

:scan
	ECHO:
	ECHO:
	ECHO 6) Scanning.
	ECHO -  MsBuild.exe %slnpath% /t:Rebuild 
	MsBuild.exe %slnpath% /t:Rebuild 
	GOTO submit

:submit
	ECHO:
	ECHO:
	ECHO 7) Submitting..
	ECHO -  SonarScanner.MSBuild.exe end /d:sonar.login="%token%"
	SonarScanner.MSBuild.exe end /d:sonar.login="%token%"
	GOTO end

:end
	ECHO:
	ECHO:
	ECHO 8) Ending.
	ECHO  -  Batch file complete.
	PAUSE

