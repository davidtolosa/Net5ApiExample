using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Api.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

    }
}
