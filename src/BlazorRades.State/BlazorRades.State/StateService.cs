using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State
{
    public class StateService
    {
        private Dictionary<string, object> state = new Dictionary<string, object>();
        public void Add<T>(string key, T value)
        {
            state.Add(key, value);
        }

        public T Get<T>(string key)
        {
            object value;
            if(state.TryGetValue(key, out value))
            {
                return (T) value;
            }

            return (T) value;
        }
    }
}
