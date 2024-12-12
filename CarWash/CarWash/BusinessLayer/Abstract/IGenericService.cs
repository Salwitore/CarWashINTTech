using BusinessLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        public Model InsertBL(T p);
        public Model DeleteBL(int id);
        public Model UpdateBL(T p);
        public Model GetBL(int id);
        public Model GetAllListBL();
    }
}
