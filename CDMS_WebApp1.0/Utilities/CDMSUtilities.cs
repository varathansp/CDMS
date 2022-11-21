using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDMS_WebApp1._0.Utilities
{
    public static class CDMSUtilities
    {
        public static int strRight(string strValue, int intLength)
        {
            int ret = 0;
            try
            {
                ret = Convert.ToInt32( strValue.Substring(strValue.Length - intLength));
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        public static int strLeft(string strValue, int intLength)
        {
            string strRet = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(strValue)) strRet = strValue;
                intLength = Math.Abs(intLength);
                strRet = strValue.Length <= intLength ? strValue : strValue.Substring(0, intLength);
                return Convert.ToInt32(strRet);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}