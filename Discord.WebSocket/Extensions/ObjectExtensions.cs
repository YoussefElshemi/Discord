using Newtonsoft.Json;

namespace Discord.Extensions;

public static class ObjectExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}