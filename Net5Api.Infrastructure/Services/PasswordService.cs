using Microsoft.Extensions.Options;
using Net5Api.Infrastructure.Interfaces;
using Net5Api.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Net5Api.Infrastructure.Services
{
    class PasswordService : IPasswordHasher
    {

        private readonly PasswordOptions _passwordOptions;

        public PasswordService(IOptions<PasswordOptions> passwordOptions)
        {
            _passwordOptions = passwordOptions.Value;
        }

        public bool Check(string hash, string password)
        {
            throw new NotImplementedException();
        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, _passwordOptions.SaltSize,_passwordOptions.Iterations,HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_passwordOptions.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_passwordOptions.Iterations}.{salt}.{key}";
            }
        }
    }
}
