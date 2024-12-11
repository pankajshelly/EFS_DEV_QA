using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CAPASFIDAS_EFS_SERVICE
{
    public class CAPASFIDAS_EFS_SERVICE : ICAPASFIDAS_EFS_SERVICE
    {
        /// <summary>
        /// GetContactData
        /// </summary>
        /// <returns></returns>
        public IList<ShowContact> GetContactData()
        {
            IList<ShowContact> lstShowContact = new List<ShowContact>();

            return lstShowContact;
        }
    }
}
