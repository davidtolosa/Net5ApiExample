using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using System.Threading.Tasks;

namespace Net5Api.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitofWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitofWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitofWork.SecurityRepository.Add(security);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
