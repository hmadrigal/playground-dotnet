namespace DataTableSample.Services
{
    using System.Data.Entity;
    using Models;

    public partial class CompanyModel : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public CompanyModel()
            : base("name=CompanyModel")
        {
        }
    }
}
