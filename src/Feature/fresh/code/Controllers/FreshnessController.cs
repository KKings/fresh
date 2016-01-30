namespace Sitecore.Feature.Indicator.Controllers
{
    using System.Web.Mvc;
    using Mvc.Controllers;
    using Pipelines.Freshness;
    using Sitecore.Pipelines;

    public class FreshnessController : SitecoreController
    {
        public ActionResult Freshometer()
        {
            var args = new FreshnessArgs(Sitecore.Context.Item);
            CorePipeline.Run("freshness", args, false);

            return View(args.FreshnessRating);
        }
    }
}
