using System;

namespace Game.Events
{
    public class GameEvent
    {
        private Func<EVENT_RETURN> _event;
        private int _interval;
        private int _next;
        private string _identifier;
        private int _invocationCount;

        public GameEvent(Func<EVENT_RETURN> @event, int interval_ms, int delay_ms, string identifier = "") {
            this._event = @event;
            this._interval = interval_ms;
            this._next = delay_ms;
            this._identifier = identifier;
            this._invocationCount = 0;
        }

        public EVENT_RETURN Probe(int dif) {
            this._next -= dif;

            if (this._next < 0) {
                this._next += this._interval;
                var result = this._event.Invoke();
                this._invocationCount++;
                return result;
            }

            return EVENT_RETURN.NONE;
        }

        public void DisplayStatistics(int interval) {
            float runsPerInterval = interval / _interval;
            Console.WriteLine($"id:{this._identifier} - tar:{runsPerInterval} - act:{this._invocationCount} - per:{this._invocationCount/runsPerInterval}%");
            this._invocationCount = 0;
        }
    }
}