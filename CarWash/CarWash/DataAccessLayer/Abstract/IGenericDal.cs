namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        T Get(int id);
        bool Insert(T p);
        bool Delete(int id);
        bool Update(T p);
        List<T> GetList();

    }
}
