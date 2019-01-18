namespace WorkoutTracker.DataAccess
{
    public interface IBaseDao
    {
        void SerializeToFile<T>(string path, T obj);

        T DeserializeToObject<T>(string path);
    }
}
