using My_Books.Data.Models;

namespace My_Books.Models
{
    public class ApDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new Publisher()
                    {
                        name = "Ahmed"

                    }, new Publisher()
                    {
                        name = "Mohamed"
                    });
                    context.SaveChanges();
                }
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        title = "first",
                        description = "desc 1",
                        isRead = false,
                        dateAdded = DateTime.Now,
                        publisherId = 13
                    }, new Book()
                    {
                        title = "second",
                        description = "desc 2",
                        isRead = true,
                        dateRead = DateTime.Now.AddDays(-10),
                        rate = 9,
                        dateAdded = DateTime.Now,
                        publisherId = 14

                    }); ;
                    context.SaveChanges();
                }
            }
        }
    }
}
