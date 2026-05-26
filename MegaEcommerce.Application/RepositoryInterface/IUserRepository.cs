
namespace MegaEcommerce.Application.RepositoryInterface
{
    public interface IUserRepository
    {
        public Task<bool> IsUserExist(string email);
    }
}
