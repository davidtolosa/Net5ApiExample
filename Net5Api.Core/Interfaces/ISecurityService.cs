using Net5Api.Core.Entities;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}