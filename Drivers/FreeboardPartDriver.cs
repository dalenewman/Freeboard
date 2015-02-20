using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Freeboard.Models;

namespace Freeboard.Drivers {
    public class FreeboardPartDriver : ContentPartDriver<FreeboardPart> {

        protected override string Prefix {
            get { return "Freeboard"; }
        }

        //GET
        protected override DriverResult Editor(FreeboardPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Freeboard_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/Freeboard", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(FreeboardPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(FreeboardPart part, string displayType, dynamic shapeHelper) {

            if (displayType.StartsWith("Summary")) {
                return Combined(
                    ContentShape("Parts_Freeboard_SummaryAdmin", () => shapeHelper.Parts_Freeboard_SummaryAdmin(Part: part))
                );
            }

            return null;
        }


    }
}
