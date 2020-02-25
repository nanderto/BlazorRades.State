using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public class StateService : IStateService
    {
        private Dictionary<string, object> state = new Dictionary<string, object>();
        
        public void AddOrUpdate<T>(string key, T value)
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

        public T Get<T>(string key)
        {
            object value;
            if (state.TryGetValue(key, out value))
            {
                return (T)value;
            }

            return (T)value;
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
