namespace CodingTestLuizaLabs.Repository.Generic
{
    public interface IUserRepository
    {
        bool Exists(string email);
    }
}
