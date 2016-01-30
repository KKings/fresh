
namespace Sitecore.Feature.Indicator.Controllers
{
    using System;
    using System.Globalization;
    using System.Web.Mvc;
    using Data;
    using Data.Fields;
    using Data.Items;
    using Mvc.Controllers;
    using Pipelines.Freshness;
    using SecurityModel;
    using Services;
    using Sitecore.Pipelines;

    public class TestController : SitecoreController
    {

        public ActionResult Freshy(Guid id, DateTime dt)
        {
            var database = Sitecore.Configuration.Factory.GetDatabase("master");

            var item = database.GetItem(ID.Parse(id));

            using (new SecurityDisabler())
            {
                using (new EditContext(item, false, false))
                {
                    item[FieldIDs.Updated] = DateUtil.ToIsoDate(dt);
                }
            }

            var args = new FreshnessArgs(database.GetItem(ID.Parse(id)));
            CorePipeline.Run("freshness", args, false);

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = args.FreshnessRating
            };
        }
    }
}
