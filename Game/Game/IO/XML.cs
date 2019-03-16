using System;
using System.IO;
using System.Xml.Serialization;

namespace Game.IO
{
    public static class XML
    {
        public static void Serialize(string path, object obj, Type type) {
            var xml = new XmlSerializer(type);

            using (var fs = new FileStream(path, FileMode.OpenOrCreate)) {
                xml.Serialize(fs, obj);
            }
        }

        public static T Deserialize<T>(string path, Type type) {
            var xml = new XmlSerializer(type);

            using (var fs = new FileStream(path, FileMode.Open)) {
                return (T)xml.Deserialize(fs);
            }
        }
    }
}
