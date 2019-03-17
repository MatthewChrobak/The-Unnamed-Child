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
        private Globals _globals;

        public UIManager() {
            _scenes = new Dictionary<Type, Scene>();
            _globals = Singleton.Get<Globals>();
        }

        public Scene LoadScene<T>() where T : Scene, new() {
            if (!this._scenes.ContainsKey(typeof(T))) {
                _scenes.Add(typeof(T), new T());
            }
            this._currentSceneID = typeof(T);
            _scenes[typeof(T)].OnEnter();
            return _scenes[typeof(T)];
        }

        public void JoystickButtonPressed(object sender, JoystickButtonEventArgs e) {
            if (_globals.DisableUserInput) {
                return;
            }
            CurrentScene.OnJoystickButtonPressed((JoystickButton)e.Button);
        }
    }
}
