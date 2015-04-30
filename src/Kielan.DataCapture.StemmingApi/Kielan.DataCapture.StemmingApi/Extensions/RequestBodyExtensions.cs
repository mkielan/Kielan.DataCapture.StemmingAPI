using System.IO;
using Nancy.IO;

namespace Kielan.DataCapture.StemmingApi.Extensions
{
    public static class RequestBodyExtensions
    {
        public static string ReadAsString(this RequestStream requestStream)
        {
            using (var reader = new StreamReader(requestStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}