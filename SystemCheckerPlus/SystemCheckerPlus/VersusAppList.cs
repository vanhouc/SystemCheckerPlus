using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SystemCheckerPlus
{
    public class VersusAppList
    {
        private VersusApplication[] _appList;

        public VersusAppList(VersusApplication[] appList)
        {
            if (appList.Length < 1)
                _appList = new VersusApplication[] { new VersusApplication("No Applications Present") };
            else
            _appList = appList;
        }
        public string[] GetAllProp(string propertyName)
        {
            PropertyInfo objProp = typeof(VersusApplication).GetProperty(propertyName);
            return _appList.Select(x => objProp.GetValue(x, null) as string).ToArray();
        }
        public VersusApplication[] GetElement(Type objType, string refProp, string refValue)
        {
            PropertyInfo objProp = typeof(VersusApplication).GetProperty(refProp);
            return _appList.Where(x => (string)objProp.GetValue(x, null) == refValue).ToArray();
        }
    }
}
