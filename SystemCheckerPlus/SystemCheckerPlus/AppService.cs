using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SystemCheckerPlus
{
    public static class AppService
    {
        public static string[] GetAllProp(Application[] appList, string propertyName)
        {
            PropertyInfo objProp = typeof(Application).GetProperty(propertyName);
            return appList.Select(x => objProp.GetValue(x, null) as string).ToArray();
        }
        public static Application[] GetElement(Application[] appList, Type objType, string refProp, string refValue)
        {
            PropertyInfo objProp = typeof(Application).GetProperty(refProp);
            return appList.Where(x => (string)objProp.GetValue(x, null) == refValue).ToArray();
        }
    }
}
