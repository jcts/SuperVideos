using Newtonsoft.Json;

namespace SuperVideos.Crosscutting.Utils
{
    public static class Extensions
    {
        public static string ToJsonString(this object obj)
         => JsonConvert.SerializeObject(obj);

        public static object ToJsonObject(this string str)
            => JsonConvert.DeserializeObject(str);
    }
}
