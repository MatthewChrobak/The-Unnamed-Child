using SFML.Graphics;
using SFML.System;

namespace Game.Graphics.Cameras
{
    public class Camera
    {
        private View _view;
        private (float x, float y) _topLeft;
        private (float width, float height) _size;

        private float _currentZoom;

        public Camera(float left, float top) {
            this._view = new View();
            this._topLeft = (left, top);
            this._currentZoom = 1;
            this._size = (GameWindow.WINDOW_WIDTH, GameWindow.WINDOW_HEIGHT);
        }

        public View GetView() {
            this._view.Reset(new FloatRect(0, 0, 1, 1));
            this._view.Size = new Vector2f(_size.width, _size.height);
            this._view.Zoom(_currentZoom);
            this._view.Center = new Vector2f(
                _topLeft.x + _size.width / (_currentZoom * 2),
                _topLeft.y + _size.height / (_currentZoom * 2)
                );
            return this._view;
        }


        public void Resize(float newWidth, float newHeight) {
            float ratio1 = newWidth / _size.width;
            float ratio2 = newHeight / _size.height;
            Debug.Assert(ratio1 == ratio2);
            this._currentZoom = newHeight / GameWindow.WINDOW_HEIGHT;
            this._size = (newWidth, newHeight);
        }

        public void Move(float x, float y) {
            this._topLeft = (x, y);
        }
    }
}
