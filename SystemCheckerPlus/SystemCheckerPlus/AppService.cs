using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SystemCheckerPlus
{
    public class AppService
    {
        private Application[] _appList;

        public AppService(Application[] appList)
        {
            if (appList.Length < 1)
                _appList = new Application[] { new Application("No Applications Present") };
            else
            _appList = appList;
        }
        public string[] GetAllProp(string propertyName)
        {
            PropertyInfo objProp = typeof(Application).GetProperty(propertyName);
            return _appList.Select(x => objProp.GetValue(x, null) as string).ToArray();
        }
        public Application[] GetElement(Type objType, string refProp, string refValue)
        {
            PropertyInfo objProp = typeof(Application).GetProperty(refProp);
            return _appList.Where(x => (string)objProp.GetValue(x, null) == refValue).ToArray();
        }
    }
}
