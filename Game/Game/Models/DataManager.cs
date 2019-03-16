using Game.IO;
using Game.Models.Entities;
using Game.Models.Rooms;
using Game.Patterns.Singleton;
using System.IO;

namespace Game.Models
{
    public class DataManager : Singleton
    {
        public Room CurrentRoom;
        public Player Player;

        public DataManager() {
            Player = new Player();
        }

        public void LoadRoom(string roomName) {
            string path = Room.GetPath(roomName);
            Debug.Assert(File.Exists(path));

            CurrentRoom?.OnLeave();
            CurrentRoom = XML.Deserialize<Room>(path, Room.GetRoomType(roomName));
            CurrentRoom.OnEnter();
        }
    }
}
