using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace FareManagement.Web.Api.IntegrationTests.Helpers
{
    public static class Extensions
    {
        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }

        public static string ToQueryString(this object model)
        {
            var serialized = JsonConvert.SerializeObject(model);
            var deserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);
            var result = deserialized.Select((kvp) => kvp.Key.ToString() + "=" + Uri.EscapeDataString(kvp.Value)).Aggregate((p1, p2) => p1 + "&" + p2);
            return result;
        }
    }
}
