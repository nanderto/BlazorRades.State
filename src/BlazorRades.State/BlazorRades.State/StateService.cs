using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public class StateService : IStateService
    {
        private Dictionary<string, object> state = new Dictionary<string, object>();
        
        public void AddOrReplace<T>(string key, T value)
        {
            if (state.ContainsKey(key))
            {
                state[key] = value;
            }
            else 
            {
                state.Add(key, value);
            }
        }

        public void AddToCollection<T>(string key, T value)
        {
            if (state.ContainsKey(key))
            {
                List<T> list = (List<T>) state[key];
                list.Add(value);
                state[key] = list;
            }
            else
            {
                List<T> list = new List<T>();
                list.Add(value);
                state.Add(key, list);
            }
        }

        public T Get<T>(string key)
        {
            object value;
            if (state.TryGetValue(key, out value))
            {
                return (T)value;
            }

            return (T)value;
        }

        public List<T> GetAll<T>(string key)
        {
            object value;
            if (state.TryGetValue(key, out value))
            {
                return (List<T>)value;
            }

            return (List<T>)value;
        }

        public int GetCount<T>(string key)
        {
            object value;
            if (state.TryGetValue(key, out value))
            {
                return ((List<T>)value).Count;
            }

            return ((List<T>)value).Count;
        }
    }

    public class Count
    {

        public Count(int count)
        {
            Current = count;
        }

        public int Current { get; set; }
    }
}
