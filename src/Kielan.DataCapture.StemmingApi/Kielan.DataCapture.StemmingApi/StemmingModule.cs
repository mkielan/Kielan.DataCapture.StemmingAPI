using System.Collections.Generic;
using System.Diagnostics;
using Kielan.DataCapture.StemmingApi.Extensions;
using Kielan.DataCapture.StemmingApi.Helpers;
using Kielan.DataCapture.StemmingApi.Models;
using Nancy;
using Nancy.ModelBinding;

namespace Kielan.DataCapture.StemmingApi
{
    public class StemmingModule : NancyModule
    {
        public StemmingModule()
        {
            Post["/stemmingMany"] = parameters =>
            {
                var model = this.Bind<StemmingModel>();
                var list = new List<string>();

                if (model != null)
                    model.Documents.ForEach(x => list.Add(StemmingHelper.StemmText(x)));

                return Response.AsJson(list);
            };

            Post["/stemming"] = parameters =>
            {
                var inText = Request.Body.ReadAsString();
                var result = StemmingHelper.StemmText(inText);
                return Response.AsJson(result);
            };
        }
    }
}