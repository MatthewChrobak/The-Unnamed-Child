using Game.Patterns.Singleton;
using SFML.Audio;
using System.IO;
using System.Timers;


/*
  - Unless stated otherwise, all sounds obtained from freeSound.org
  - bird_whistling, wind_chimes, thunder_rain from InspectorJ @ freeSound.org
  - soft_wind_blowing from Aeonemi @ freeSound.org
  - rock_sliding from Jan Schulze @ freeSound.org
*/

namespace Game.Sounds
{
    public class SoundManager: Singleton
    {

        public static System.Timers.Timer aTimer;

        //Get current directory
        public string directory = Directory.GetCurrentDirectory();

        //Music themes
        public string mainTheme1Celeste = "/sounds/music/theme_1_unnamed_child_celeste.wav";
        public string mainTheme2Slow = "/sounds/music/theme_2_unnamed_child_piano.wav";

        //Random Piano Sounds
        public string randomPianoSound1 = "/sounds/music/random_piano_sounds_1";
        public string randomPianoSound2 = "/sounds/music/random_piano_sounds_2";
        public string randomPianoSound3 = "/sounds/music/random_piano_sounds_3";
        public string randomPianoSound4 = "/sounds/music/random_piano_sounds_4";
        public string randomPianoSound5 = "/sounds/music/random_piano_sounds_5";

        //Character
        public string woodHitting = "/sounds/pebble_hit_wood.wav";
        public string keyPickup = "/sounds/keys_pickup.wav";
        public string crushedBones = "/sounds/crushed_bones.wav";
        public string crushedGuts = "/sounds/crushed_guts.wav";

        //FootSteps
        public string footstepStoneFloor1 = "/sounds/footstep_stone_1.wav";        
        public string footstepDirt1 = "/sounds/footstep_dirt_1.wav";
        public string footstepGrass1 = "/sounds/footstep_grass_1.wav";
        public string footstepGrass2 = "/sounds/footstep_grass_2.wav";
        public string footstepWood1 = "/sounds/footstep_soft_wood1.wav";
        public string footstepWood2 = "/sounds/footstep_soft_wood2.wav";

        //Environment
        /*
         * bucket sound
         * boiler sound
         * 
        */
        public string clothShuffling = "/sounds/cloth_shuffling.wav";
        public string movingRock = "/sounds/rock_sliding.wav";
        public string woodenDoorOpen = "/sounds/creaking_door_opening.wav";
        public string woodCreaking = "/sounds/creaking_wood_floor.wav";
        public string pansClanking = "/sounds/pots_and_pans.wav";
        public string saucepan = "/sounds/saucepan.wav";
        public string windStrong = "/sounds/strong_wind.wav";
        public string windSoft = "/sounds/soft_wind_blowing.wav";
        public string windChimes = "/sounds/wind_chimes.wav";
        public string windChimesSoft = "/sounds/soft_windchimes.wav";
        public string chirpingBirds = "/sounds/bird_whistling.wav";
        public string crowCawing = "/sounds/crow_cawing_1.wav";
        public string rainModerate = "/sounds/moderate_rain.wav";
        public string rainSoftLong = "/sounds/soft_rain_long.wav";
        public string rainThunder = "/sounds/thunder_rain.wav";
        public string pillowFluff = "/sounds/pillow_fluffing.wav";
        public string stoneFall = "/sounds/stone_fall.wav";

        //Enemy - Minion - Monster
        public string laughFemale = "/sounds/female_evil_laugh.wav";
        public string laughEvilWhispered = "/sounds/evil_laugh_whispered.wav";

        //Checking rather or not it is the first time the sound play
        public bool isFirstTimeSound = true;

        //To play music
        public string PlayMusic(string musicInput)
        {
            return directory + musicInput;
        }

        //Set a timer if necessary, to prevent early stop
        public void StopSound(Sound sound, int interval = 0)
        {
            if (interval > 0)
            {
                aTimer = new System.Timers.Timer();
                aTimer.Interval = interval;
                aTimer.Elapsed += (o, e) => sound.Stop();
                aTimer.Start();
            }
            else
            {
                sound.Stop();
            }
        }

        //To play a sound
        public void PlaySound(Sound soundInput, float volume = 0f, float offset = 0f)
        {
            if(volume > 0)
            {
                soundInput.Volume = volume;
            }

            //Not working at the moment
            if(offset > 0)
            {
                soundInput.PlayingOffset.AsSeconds();               
            }

            soundInput.Play();
        }   
    }
}
