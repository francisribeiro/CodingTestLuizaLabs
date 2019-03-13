using CodingTestLuizaLabs.Model;

namespace CodingTestLuizaLabs.Repository.Generic
{
    public interface IWishRepository
    {
        void Delete(long userId, long productId);
    }
}
