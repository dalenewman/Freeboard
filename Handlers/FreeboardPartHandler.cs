using System;
using System.Web.Routing;
using Freeboard.Models;
using Newtonsoft.Json;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.UI.Notify;

namespace Freeboard.Handlers {
    public class FreeboardPartHandler : ContentHandler {

        private readonly INotifier _notifier;

        public new ILogger Logger { get; set; }
        public Localizer T { get; set; }


        public FreeboardPartHandler(IRepository<FreeboardPartRecord> repository, INotifier notifier) {
            _notifier = notifier;
            Filters.Add(StorageFilter.For(repository));
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var item = context.ContentItem.As<FreeboardPart>();

            if (item == null)
                return;

            base.GetItemMetadata(context);
            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Freeboard"},
                {"Controller", "Freeboard"},
                {"Action", "Index"},
                {"id", context.ContentItem.Id}
            };
        }

        protected override void Updated(UpdateContentContext context) {
            var part = context.ContentItem.As<FreeboardPart>();
            if (part == null)
                return;
            try {
                //test and format configuration
                dynamic parsedJson = JsonConvert.DeserializeObject(part.Configuration);
                part.Configuration = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            } catch (Exception ex) {
                _notifier.Add(NotifyType.Warning, T(ex.Message));
                Logger.Warning(ex.Message);
            }
        }

    }
}
