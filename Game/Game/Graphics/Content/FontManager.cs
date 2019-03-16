using SFML.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Game.Graphics.Content
{
    public class FontManager
    {
        private Dictionary<string, Font> _fonts;

        public FontManager() {
            this._fonts = new Dictionary<string, Font>();
        }

        public Font Get(string id) {
            id = id.ToLower();
            if (!this._fonts.ContainsKey(id)) {
                Debug.Assert(File.Exists(id));
                this._fonts.Add(id, new Font(id));
            }
            return this._fonts[id];
        }
    }
}
