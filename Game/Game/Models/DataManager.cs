using Game.IO;
using Game.Models.Entities;
using Game.Models.Rooms;
using Game.Patterns.Singleton;
using System.Collections.Generic;
using System.IO;

namespace Game.Models
{
    public class DataManager : Singleton
    {
        public Room CurrentRoom;
        public Player Player;

        private Dictionary<string, Room> _cachedRooms;

        public BabaYaga BabaYaga;

        public DataManager() {
            _cachedRooms = new Dictionary<string, Room>();
        }

        public void NewGame() {
            Player = new Player();
            _cachedRooms.Clear();
            Singleton.Get<Globals>().DisableUserInput = false;
            Singleton.Get<Globals>().DisableMovement = false;
            LoadRoom("Kitchen");
        }

        public void LoadRoom(string roomName) {

            if (_cachedRooms.ContainsKey(roomName)) {
                CurrentRoom.OnLeave();
                CurrentRoom = _cachedRooms[roomName];
                CurrentRoom.OnEnter();
                return;
            }

            string path = Room.GetPath(roomName);
            Debug.Assert(File.Exists(path));

            CurrentRoom?.OnLeave();
            CurrentRoom = XML.Deserialize<Room>(path, Room.GetRoomType(roomName));
            CurrentRoom.OnEnter();

            _cachedRooms[roomName] = CurrentRoom;
        }
    }
}
