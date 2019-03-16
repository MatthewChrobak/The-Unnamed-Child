using SFML.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Game.Graphics.Content
{
    public class TextureManager
    {
        private Dictionary<string, Texture> _textures;

        public TextureManager() {
            this._textures = new Dictionary<string, Texture>();
        }

        public Sprite Get(string id) {
            id = id.ToLower();
            if (!this._textures.ContainsKey(id)) {
                Debug.Assert(File.Exists(id));
                this._textures.Add(id, new Texture(id));
            }
            return new Sprite(this._textures[id]);
        }
    }
}
