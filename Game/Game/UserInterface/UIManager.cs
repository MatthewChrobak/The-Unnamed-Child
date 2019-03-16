using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Game.UserInterface
{
    public class UIManager : Singleton
    {
        private Dictionary<Type, Scene> _scenes;
        public Type _currentSceneID { get; private set; }
        public Scene CurrentScene => _scenes[_currentSceneID];

        public UIManager() {
            _scenes = new Dictionary<Type, Scene>();
        }

        public Scene LoadScene<T>() where T : Scene, new() {
            if (!this._scenes.ContainsKey(typeof(T))) {
                _scenes.Add(typeof(T), new T());
            }
            this._currentSceneID = typeof(T);
            return _scenes[typeof(T)];
        }

        public void JoystickButtonPressed(object sender, JoystickButtonEventArgs e) {
            CurrentScene.OnJoystickButtonPressed((JoystickButton)e.Button);
        }
    }
}
