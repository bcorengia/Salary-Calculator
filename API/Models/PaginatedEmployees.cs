using System.Collections.Generic;

namespace Api.Models
{
    public class PaginatedEmployees
    {
        public PaginatedEmployees(IEnumerable<Employee> employees, int page, int pageSize, int totalCount)
        {
            Employees = employees;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public IEnumerable<Employee> Employees { get; }
        //Pagination
        public int TotalCount { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalPages => (PageSize == 0) ? 1 : (TotalCount + PageSize - 1) / PageSize;
        public bool HasNext => Page < TotalPages;
        public bool HasPrevius => Page > 1;
    }
}
