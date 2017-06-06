using System.Web.Script.Serialization;

namespace Common
{
    public static class ExtendFunc
    {
        public static string ToJson(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }
}