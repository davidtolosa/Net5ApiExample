using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Api.Infrastructure.Interfaces
{
    public interface IPassworService
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}
