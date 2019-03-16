using Game.Patterns.Singleton;
using Game.UserInterface;
using Game.UserInterface.Scenes;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.Events
{
    public class EventQueue : Singleton
    {
        private List<GameEvent>[] queue = new List<GameEvent>[(int)PriorityTypes.END + 1];

        public EventQueue() {
            for (int i = (int)PriorityTypes.START; i <= (int)PriorityTypes.END; i++) {
                queue[i] = new List<GameEvent>();
            }
        }

        public void AddEvent(PriorityTypes type, GameEvent e) {
            queue[(int)type].Add(e);
        }

        public void AddEvent(PriorityTypes type, Func<EVENT_RETURN> e, int interval_ms, int delay_ms) {
            AddEvent(type, new GameEvent(e, interval_ms, delay_ms));
        }

        public void Run() {
            int tick;
            int lastTick = Environment.TickCount;
            var ui = Singleton.Get<UIManager>();

            while (ui._currentSceneID != typeof(Closing)) {
                tick = Environment.TickCount;
                int dif = tick - lastTick;
                lastTick = tick;

                if (dif == 0) {
                    Thread.Yield();
                    continue;
                }
                for (int i = (int)PriorityTypes.START; i <= (int)PriorityTypes.END; i++) {
                    foreach (var e in queue[i]) {
                        e.Probe(dif);
                    }
                }

                Thread.Yield();
            }
        }
    }
}
