using System.Collections.Generic;

namespace BlazorRades.State
{
    public interface IStateService
    {
        void AddOrReplace<T>(string key, T value);

        void Add<T>(string key, T value);

        T Get<T>(string key);

        List<T> GetAll<T>(string key);
    }
}