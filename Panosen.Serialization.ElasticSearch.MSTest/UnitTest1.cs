using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Panosen.Serialization.ElasticSearch.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testCase = GetTestCase();

            JsonSerializerSettings readSettings = new JsonSerializerSettings();
            readSettings.NullValueHandling = NullValueHandling.Ignore;
            readSettings.Converters.Add(new TermsConverter());
            readSettings.Converters.Add(new TermConverter());
            readSettings.Converters.Add(new MatchPhraseConverter());
            readSettings.Converters.Add(new MatchConverter());
            readSettings.Converters.Add(new RangeConvertor());
            readSettings.Converters.Add(new ConditionCollectionConvertor());

            JsonSerializerSettings writeSettings = new JsonSerializerSettings();
            writeSettings.NullValueHandling = NullValueHandling.Ignore;
            writeSettings.Converters.Add(new ConditionCollectionConvertor());

            var request2 = JsonConvert.DeserializeObject<Request>(testCase, readSettings);

            var actual = JsonConvert.SerializeObject(request2, Formatting.Indented, writeSettings);

            var expected = GetExpected();

            Assert.AreEqual(expected, actual);
        }

        private string GetTestCase()
        {
            return @"
{
  ""query"": {
    ""bool"": {
      ""must"": [
        {
          ""ids"": {
            ""type"": [],
            ""values"": [
              ""18527664"",
              ""2365168"",
              ""24783445""
            ],
            ""boost"": 1
          }
        }
      ],
      ""disable_coord"": false,
      ""adjust_pure_negative"": true,
      ""boost"": 1
    }
  }
}
";
        }

        private string GetExpected()
        {
            return @"{
  ""query"": {
    ""bool"": {
      ""must"": [
        {
          ""ids"": {
            ""values"": [
              ""18527664"",
              ""2365168"",
              ""24783445""
            ],
            ""boost"": 1
          }
        }
      ],
      ""disable_coord"": false,
      ""adjust_pure_negative"": true,
      ""boost"": 1
    }
  }
}";
        }
    }
}