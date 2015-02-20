using System;
using System.Text;
using System.Web.Mvc;
using Freeboard.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Services;

namespace Freeboard.Controllers {

    public class FreeboardController : Controller {

        protected Localizer T { get; set; }
        private readonly IOrchardServices _services;
        private readonly IJsonConverter _jsonConverter;

        public FreeboardController(IOrchardServices services, IJsonConverter jsonConverter) {
            _services = services;
            _jsonConverter = jsonConverter;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index(int id) {
            var item = _services.ContentManager.Get(id).As<FreeboardPart>();

            if (item == null) {
                return new HttpNotFoundResult();
            }

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.ViewContent, item, T("Access to this dashboard is controlled"))) {
                if (!User.Identity.IsAuthenticated) {
                    System.Web.Security.FormsAuthentication.RedirectToLoginPage(Request.RawUrl);
                }
                return new HttpUnauthorizedResult();
            }

            item.Editable = _services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.EditContent);

            return View("Index", item);
        }

        [HttpGet]
        public string Load(int id) {
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;

            var item = _services.ContentManager.Get(id).As<FreeboardPart>();
            if (item == null) {
                return "{\"status\":404}";
            }

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.ViewContent, item)) {
                return "{\"status\":401}";
            }

            try {
                dynamic parsedJson = _jsonConverter.Deserialize(item.Configuration);
                parsedJson.status = 200;
                return _jsonConverter.Serialize(parsedJson, JsonFormat.Indented);
            }
            catch (Exception) {
                return "{\"status\":500}";
            }
        }

        [HttpPost]
        public string Save() {
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;

            int id;
            if (!int.TryParse((Request.Form["id"] ?? "0"), out id)) {
                return "{\"status\":400}";
            }

            var item = _services.ContentManager.Get(id).As<FreeboardPart>();
            if (item == null) {
                return "{\"status\":404}";
            }

            var data = Request.Form["data"];
            if (data == null) {
                return "{\"status\":400}";
            }

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.EditContent, item)) {
                return "{\"status\":401}";
            }

            try {
                dynamic parsedJson = _jsonConverter.Deserialize(data);
                item.Configuration = _jsonConverter.Serialize(parsedJson, JsonFormat.Indented);
            } catch (Exception) {
                return "{\"status\":500}";
            }

            return "{\"status\":200}";
        }
    }

}