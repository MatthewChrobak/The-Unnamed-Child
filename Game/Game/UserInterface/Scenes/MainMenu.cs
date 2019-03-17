using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Models;
using Game.Patterns.Singleton;
using Game.Sounds;
using Game.UserInterface.Components;
using SFML.Audio;
using SFML.Graphics;
using System;
using System.IO;

namespace Game.UserInterface.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu() {
            int x = 300;
            int y = 300;
            int width = 100;
            int height = 100;
            var sound = Singleton.Get<SoundManager>();

            var music = new Music(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.mainTheme1Celeste));

            music.Loop = true;

            music.Play();

            this.OnJoystickButtonPressed += (button) => {
                if (Singleton.Get<Globals>().DisableUserInput) {
                    return;
                }
                if (button == JoystickButton.A) {
                    music.Stop();
                    Singleton.Get<DataManager>().NewGame();
                    Singleton.Get<UIManager>().LoadScene<InGame>();
                }
            };

            this.OnJoystickButtonPressed += (button) => {
                if (Singleton.Get<Globals>().DisableUserInput) {
                    return;
                }
                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<Closing>();
                }
            };
        }

        public override void OnEnter() {
            Singleton.Get<Globals>().DisableUserInput = false;
        }

        public override void Draw(IDrawableSurface surface) {

            surface.Draw("The Unnamed Child", new TextContext() {
                FontSize = 42,
                FontColor = Color.White,
                HorizontalCenter_Width = GameWindow.WINDOW_WIDTH,
                VerticalCenter_Height = GameWindow.WINDOW_HEIGHT
            });

            surface.Draw("Hit A to Play", new TextContext() {
                FontSize = 24,
                FontColor = Color.White,
                HorizontalCenter_Width = GameWindow.WINDOW_WIDTH,
                VerticalCenter_Height = GameWindow.WINDOW_HEIGHT * 1.125f
            });
        }
    }
}
