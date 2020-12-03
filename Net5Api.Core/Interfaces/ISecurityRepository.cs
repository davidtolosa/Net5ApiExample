using Net5Api.Core.Entities;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
    }
}