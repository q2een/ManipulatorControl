using Newtonsoft.Json;
using System.IO;

namespace ManipulatorControl.BL.Settings
{
    public static class JSONSettingsSaver
    {
        public static void SaveAsJSONFile<T>(this T obj, string path, params JsonConverter[] converters)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            foreach (var converter in converters)
                settings.Converters.Add(converter);

            File.WriteAllText(path, JsonConvert.SerializeObject(obj, settings));       
        }

        public static T Load<T>(string path, params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path), converters);
        }
    }
}
