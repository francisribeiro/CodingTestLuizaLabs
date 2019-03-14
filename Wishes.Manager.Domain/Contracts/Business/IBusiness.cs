namespace CodingTestLuizaLabs.Business
{
    public interface IBusiness<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(long id);
    }
}
