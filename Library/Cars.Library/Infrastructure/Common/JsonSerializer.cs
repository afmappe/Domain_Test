using Newtonsoft.Json;
using System.IO;
using Serializer = Newtonsoft.Json.JsonSerializer;

namespace Cars.Library.Infrastructure.Common
{
    /// <summary>
    ///
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream)
        {
            T result;

            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(sr))
                {
                    Serializer serializer = new Serializer();
                    result = serializer.Deserialize<T>(jsonReader);
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Serialize(object input)
        {
            return JsonConvert.SerializeObject(input);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <param name="stream"></param>
        public static void Serialize(object input, Stream stream)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    Serializer serializer = new Serializer();
                    serializer.Serialize(jsonWriter, input);
                    jsonWriter.Flush();
                }
            }
        }
    }
}