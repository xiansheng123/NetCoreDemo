using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace webApiDemo.Services
{
    public class ApiDBContent:DbContext
    {
        public ApiDBContent(DbContextOptions<ApiDBContent> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}