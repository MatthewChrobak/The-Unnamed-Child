using System;
using System.Collections.Generic;

namespace Game.Patterns.Singleton
{
    public abstract class Singleton
    {
        private static Dictionary<Type, Singleton> _singletons;

        static Singleton() {
            _singletons = new Dictionary<Type, Singleton>();
        }

        public static T Get<T>() where T : Singleton {
            Debug.Assert(_singletons.ContainsKey(typeof(T)));
            return (T)_singletons[typeof(T)];
        }

        public static T Create<T>() where T: Singleton, new() {
            Debug.Assert(!_singletons.ContainsKey(typeof(T)));
            _singletons.Add(typeof(T), new T());
            return (T)_singletons[typeof(T)];
        }


        public Singleton() {

        }
    }
}
