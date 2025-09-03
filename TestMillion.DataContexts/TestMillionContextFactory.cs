using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace TestMillion.DataContexts
{

 public class TestMillionContextFactory : IDesignTimeDbContextFactory<TestMillionContext>
    {
        
        public TestMillionContext CreateDbContext(string[] args)
        {
                DbContextOptionsBuilder<TestMillionContext> OptionsBuilder = new DbContextOptionsBuilder<TestMillionContext>();
               OptionsBuilder.UseSqlServer("Data Source=20.29.51.178,1414;Initial Catalog=TestMillionDB;User=UserBase;password=Diaz.15171399%;Connection Timeout=200; pooling=true;MultipleActiveResultSets=True;TrustServerCertificate=True");
            return new TestMillionContext(OptionsBuilder.Options);
        }
    }

}
