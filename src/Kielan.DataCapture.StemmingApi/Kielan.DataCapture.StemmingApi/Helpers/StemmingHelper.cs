using System.Collections.Generic;
using System.Linq;
using System.Web;
using ikvm.extensions;
using java.util;
using morfologik.stemming;

namespace Kielan.DataCapture.StemmingApi.Helpers
{
    public class StemmingHelper
    {
        static StemmingHelper()
        {
            var toSet = HttpContext.Current.Server.MapPath("~\\");
            java.lang.System.setProperty("user.dir", toSet);
        }

        public const string Delimeter = " ";

        public  static string StemmText(string text)
        {
            var result = new List<string>();
            var stemmer = new PolishStemmer();

            foreach (var t in text.toLowerCase(new Locale("pl")).split("[\\s\\.\\,]+"))
            {
                var word = stemmer.lookup(t).toArray().FirstOrDefault() as WordData;
                result.Add(word != null ? word.getStem().toString() : t);
            }

            return result.Aggregate((i, j) => i + Delimeter + j);
        }
    }
}