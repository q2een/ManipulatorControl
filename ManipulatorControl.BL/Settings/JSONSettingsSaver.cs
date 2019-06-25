using Newtonsoft.Json;
using System.IO;

namespace ManipulatorControl.BL.Settings
{
    /// <summary>
    /// Предоставляет статический класс, содержащий методы для сохранения параметров в JSON.
    /// </summary>
    public static class JSONSettingsSaver
    {
        /// <summary>
        /// Сериализует объект и сохраняет его в файл.
        /// </summary>
        /// <typeparam name="T">Тип для сериализации</typeparam>
        /// <param name="obj">Объект для сериализации</param>
        /// <param name="path">Путь к файлу для сохранения</param>
        /// <param name="converters">Коллекция конвертеров</param>
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

        /// <summary>
        /// Загружает объект из файла.
        /// </summary>
        /// <typeparam name="T">Тип для десериализации</typeparam>
        /// <param name="path">Путь с данными в JSON для десериализации</param>
        /// <param name="converters">Коллекция конвертеров</param>
        /// <returns>Объект, загруженный из файла</returns>
        public static T Load<T>(string path, params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path), converters);
        }
    }
}
