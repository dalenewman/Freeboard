using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Freeboard.Models {
    public class FreeboardPartRecord : ContentPartRecord {

        [StringLengthMax]
        public virtual string Configuration { get; set; }

        [StringLength(128)]
        public virtual string EditorTheme { get; set; }
    }
}