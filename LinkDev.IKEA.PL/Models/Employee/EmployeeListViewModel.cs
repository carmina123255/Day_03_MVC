namespace LinkDev.IKEA.PL.Models.Employee
{
    public class EmployeeListViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
       public int age { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public string? SearchTerm { get; set; }
        public string? SortedBy { get; set; }
        public bool SortedAscending { get;set; }
      


    }
}
