namespace BlazorRades.State
{
    public interface IStateService
    {
        void AddOrUpdate<T>(string key, T value);

        T Get<T>(string key);
    }
}