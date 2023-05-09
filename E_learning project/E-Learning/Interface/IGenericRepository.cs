namespace E_Learning.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(object id);
        public void Insert (T obj);
        public void Update (T obj);
        public void Delete (T obj);
    }
}
