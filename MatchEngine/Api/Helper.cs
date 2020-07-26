using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public class Helper
    {
        public static JsonSerializerSettings GetJsonSerializer()
        {
            var js = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };

            return js;
        }
    }
}
