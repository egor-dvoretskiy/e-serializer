using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace ESerializerLib.Yaml
{
    public class YamlSerializer
    {
        IDeserializer _deserializer;
        ISerializer _serializer;

        public YamlSerializer()
        {
            _deserializer = new DeserializerBuilder().Build();
            _serializer = new SerializerBuilder().Build();
        }

        public T LoadFromFile<T>(string path) 
            where T : new()
        {
            string content = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }

                T output = new T();
                output = _deserializer.Deserialize<T>(content);

                return output;
            }
            catch (Exception) { }

            return new T();

        }

        public bool SaveToFile<T>(T box, string path)
            where T : new()
        {
            try
            {
                string content = _serializer.Serialize(box);
                using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    writer.WriteLine(content);
                }

                return true;
            }
            catch (Exception) { }

            return false;
        }
    }
}
