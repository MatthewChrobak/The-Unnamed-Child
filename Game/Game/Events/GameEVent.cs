using System;

namespace Game.Events
{
    public class GameEvent
    {
        private Func<EVENT_RETURN> _event;
        private int _interval;
        private int _next;

        public GameEvent(Func<EVENT_RETURN> @event, int interval_ms, int delay_ms) {
            this._event = @event;
            this._interval = interval_ms;
            this._next = delay_ms;
        }

        public EVENT_RETURN Probe(int dif) {
            this._next -= dif;

            if (this._next < 0) {
                this._next += this._interval;
                return this._event.Invoke();
            }

            return EVENT_RETURN.NONE;
        }
    }
}