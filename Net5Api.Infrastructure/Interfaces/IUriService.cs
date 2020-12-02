using Net5Api.Core.QueryFilters;
using System;

namespace Net5Api.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}