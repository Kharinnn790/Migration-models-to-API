using DataAccess.Models;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class UserRepository(AppDbContext DbContext) : RepositoryBase<User>(DbContext), IUserRepository
    {
    }
}
