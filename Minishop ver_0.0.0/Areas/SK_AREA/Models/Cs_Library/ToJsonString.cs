using System;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Common.Extentions
{
    public static class ObjectExtentions
    {
        public static string ToJsonString(this Object obj)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, jsSettings);
        }
    }
}