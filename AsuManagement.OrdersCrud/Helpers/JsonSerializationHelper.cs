using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AsuManagement.OrdersCrud.Helpers
{
    public static class JsonSerializationHelper
    {
        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string? Serialize(object? o)
        {
            if (o == null)
                return null;

            var serializedObject = JsonConvert.SerializeObject(o, SerializerSettings);
            return serializedObject;
        }
    }
}
