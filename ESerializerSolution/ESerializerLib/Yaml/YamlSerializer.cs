using ESerializerLib.Services;
using ESerializerLib.Services.Interfaces;
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
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        private readonly IDebugger _debugger;

        public YamlSerializer()
        {
            this._deserializer = new DeserializerBuilder().Build();
            this._serializer = new SerializerBuilder().Build();

            this._debugger = new Debugger();
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
                output = this._deserializer.Deserialize<T>(content);

                return output;
            }
            catch (Exception exception)
            {
                this._debugger.Print(string.Concat(exception.Source, " ", exception.Message), ConsoleColor.Red);
            }

            return new T();
        }

        public T LoadFromFile<T>(string path, T defaultValue) 
            where T : new()
        {
            if (!File.Exists(path))
            {
                this.SaveToFile(defaultValue, path);

                return defaultValue;
            }

            T loadResult = this.LoadFromFile<T>(path);

            return loadResult;
        }

        public bool SaveToFile<T>(T box, string path)
            where T : new()
        {
            try
            {
                string content = this._serializer.Serialize(box);
                using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    writer.WriteLine(content);
                }

                return true;
            }
            catch (Exception exception) 
            {
                this._debugger.Print(string.Concat(exception.Source, " ", exception.Message), ConsoleColor.Red);
            }

            return false;
        }
    }
}
