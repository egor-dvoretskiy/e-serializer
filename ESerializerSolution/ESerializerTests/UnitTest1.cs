using ESerializerLib.Yaml;
using ESerializerTests.Models;
using NUnit.Framework;
using System.IO;

namespace ESerializerTests
{
    public class Tests
    {
        private YamlSerializer yamlSerializer;

        [SetUp]
        public void Setup()
        {
            this.yamlSerializer = new YamlSerializer();
        }

        [Test]
        public void YamlSaveToFileTest()
        {
            this.yamlSerializer.SaveToFile(Settings.Default, "EScope.yaml");

            if (!File.Exists("EScope.yaml"))
                Assert.Fail();

            Assert.Pass();
        }
    }
}