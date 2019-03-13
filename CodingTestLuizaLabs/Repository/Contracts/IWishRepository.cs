using CodingTestLuizaLabs.Model;

namespace CodingTestLuizaLabs.Repository.Generic
{
    public interface IWishRepository
    {
        void Create(Wish entity);
        void Delete(long userId, long productId);
        void Save();
    }
}
