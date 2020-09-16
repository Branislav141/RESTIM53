using Common.CommunicationBus;
using Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestStringToJSON
    {
        [TestMethod]
        public void TestGet_Success()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("GET/Resources/1");
            
            Zahtev zahtev = new Zahtev("GET", "/Resources/1", null, null);
            string expectedJson = JsonConvert.SerializeObject(zahtev, Formatting.Indented);

            Assert.AreEqual(json, expectedJson);
        }

        [TestMethod]
        public void Test_Error()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("fqwef/Resources/1");

            Assert.IsNull(json);
        }

        [TestMethod]
        public void TestGet_Success2()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("GET/Resources/1/name='Pera'/name;surname");
            Zahtev zahtev = new Zahtev("GET", "/Resources/1", "name='Pera'", "name;surname");
            string expectedJson = JsonConvert.SerializeObject(zahtev, Formatting.Indented);

            Assert.AreEqual(json, expectedJson);
        }

        [TestMethod]
        public void TestDelete_Success()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("DELETE/Resources/1");
            Zahtev zahtev = new Zahtev("DELETE", "/Resources/1", null, null);
            string expectedJson = JsonConvert.SerializeObject(zahtev, Formatting.Indented);

            Assert.AreEqual(json, expectedJson);
        }

        [TestMethod]
        public void TestPOST_Success()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("POST/Resources/1");
            Zahtev zahtev = new Zahtev("POST", "/Resources", "1", null);
            string expectedJson = JsonConvert.SerializeObject(zahtev, Formatting.Indented);

            Assert.AreEqual(json, expectedJson);
        }

        [TestMethod]
        public void TestPATCH_Success()
        {
            StringToJSONConverter converter = new StringToJSONConverter();

            string json = converter.Convert("PATCH/Resources/1/query/fields");
            Zahtev zahtev = new Zahtev("PATCH", "/Resources/1", "query", "fields");
            string expectedJson = JsonConvert.SerializeObject(zahtev, Formatting.Indented);

            Assert.AreEqual(json, expectedJson);
        }
    }
}
