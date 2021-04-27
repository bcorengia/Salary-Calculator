using System.Collections.Generic;

namespace BLL.DTOs
{
    public class PaginatedEmployees
    {
        public PaginatedEmployees(IEnumerable<BaseEmployee> employees, int page, int pageSize, int totalCount)
        {
            Employees = employees;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public IEnumerable<BaseEmployee> Employees { get; }

        //Pagination
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
    }
}
