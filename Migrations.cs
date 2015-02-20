using System;
using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.UI.Notify;

namespace Freeboard {
    public class Migrations : DataMigrationImpl {
        private readonly INotifier _notifier;

        private ILogger Logger { get; set; }
        private Localizer T { get; set; }

        public Migrations(INotifier notifier) {
            _notifier = notifier;
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        public int Create() {

            try {
                SchemaBuilder.CreateTable("FreeboardPartRecord", table => table
                    .ContentPartRecord()
                    .Column("Configuration", DbType.String, column => column.Unlimited())
                );
            } catch (Exception e) {
                Logger.Error("Error creating Freeboard part record. Error Message: {0}", e.Message);
                _notifier.Add(NotifyType.Error, T(e.Message));
            }

            try {
                var type = new ContentTypeDefinition("Freeboard", "Freeboard");
                ContentDefinitionManager.StoreTypeDefinition(type);
                ContentDefinitionManager.AlterTypeDefinition("Freeboard", cfg => cfg.Creatable()
                    .WithPart("FreeboardPart")
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("IdentityPart")
                    .WithSetting("TypeIndexing.Indexes", "Default")
                    .WithPart("ContentPermissionsPart", builder => builder
                        .WithSetting("ContentPermissionsPartSettings.View", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Publish", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Edit", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Delete", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.DisplayedRoles", "Anonymous,Authenticated")
                    )
                );

            } catch (Exception ex) {
                Logger.Error("Error creating Freeboard content type. Error Message: {0}", ex.Message);
                _notifier.Add(NotifyType.Error, T(ex.Message));
            }

            return 1;
        }

        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("FreeboardPartRecord",
                table => table
                    .AddColumn("EditorTheme", DbType.String));
            return 2;
        }


    }
}