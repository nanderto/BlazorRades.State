namespace BlazorRades.State
{
    public interface IStateService
    {
        void AddOrReplace<T>(string key, T value);

        T Get<T>(string key);
    }
}