using System.Collections.Generic;

namespace Kielan.DataCapture.StemmingApi.Models
{
    public class StemmingModel
    {
        public List<string> Documents { get; set; }

        public StemmingModel()
        {
            Documents = new List<string>();
        }
    }
}