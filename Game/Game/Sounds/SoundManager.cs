using Game.Patterns.Singleton;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Sounds
{
    public class SoundManager: Singleton
    {

        public SoundBuffer buffer;
        
        public string getSound()
        {
            {
                buffer->loadFromFile();
                
                Sound sound1 = "sound.wav";
                sound1.setBuffer(buffer);
                sound1.Play;


                if (!buffer.loadFromFile("sound.wav"))
                {


                }

                return sound1;
             
        }

        public void useSound()
        {
            //sf::SoundBuffer buffer;
        }
    }
}
