using System;
using System.Collections.Generic;
using Orchard.ContentManagement;

namespace Freeboard.Models {
    public class FreeboardPart : ContentPart<FreeboardPartRecord> {

        public string Configuration {
            get { return Record.Configuration; }
            set { Record.Configuration = value; }
        }

        public string EditorTheme {
            get {
                if (string.IsNullOrEmpty(Record.EditorTheme)) {
                    return "solarized";
                }
                return Record.EditorTheme;
            }
            set { Record.EditorTheme = value; }
        }

        public bool IsValid() {
            return !String.IsNullOrEmpty(Configuration);
        }

        public IEnumerable<string> AvailableThemes {
            get { return new[] { "3024-day", "3024-night", "ambiance-mobile", "ambiance", "base16-dark", "base16-light", "blackboard", "cobalt", "eclipse", "elegant", "erlang-dark", "lesser-dark", "mbo", "mdn-like", "midnight", "monokai", "neat", "neo", "night", "paraiso-dark", "paraiso-light", "pastel-on-dark", "rubyblue", "solarized", "the-matrix", "tomorrow-night-eighties", "twilight", "vibrant-ink", "xq-dark", "xq-light" }; }
        }

        public bool Editable { get; set; }

    }
}