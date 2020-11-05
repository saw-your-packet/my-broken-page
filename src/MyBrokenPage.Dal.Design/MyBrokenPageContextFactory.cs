using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyBrokenPage.Dal.Design
{
    public class MyBrokenPageContextFactory : IDesignTimeDbContextFactory<MyBrokenPageContext>
    {
        public MyBrokenPageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyBrokenPageContext>();
            optionsBuilder.UseSqlServer(@"Data Source=db;Initial Catalog=MyBrokenPage;User=sa;Password=MyBr0kenPag3!", b => b.MigrationsAssembly("MyBrokenPage.Dal.Design"));

            return new MyBrokenPageContext(optionsBuilder.Options);
        }
    }
}
