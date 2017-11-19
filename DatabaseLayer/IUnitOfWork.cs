namespace DatabaseLayer
{
    public interface IUnitOfWork
    {
        GenericRepository<T> Repository<T>() where T : class;
        void Save();
    }
}
