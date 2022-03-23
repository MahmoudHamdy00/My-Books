using Microsoft.EntityFrameworkCore;
using My_Books.Data.Models;
using My_Books.Data.Services;
using My_Books.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    public class Tests
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;
        AppDbContext dbContext;
        PublishersService publishersService;

        [OneTimeSetUp]
        public void Setup()
        {
            dbContext = new AppDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();
            SeedDatabae();
            publishersService = new PublishersService(dbContext);
        }
        [Test]
        public void GetPublisherByID_Exist()
        {
            var result = publishersService.GetPublisherByID(1);
            Assert.That(result.name, Is.EqualTo("P1"));
        }
        [Test]
        public void GetPublisherByID_Null()
        {
            var result = publishersService.GetPublisherByID(10);
            Assert.That(result, Is.Null);
        }
        [Test]
        public void GetPublishers()
        {
            var result = publishersService.GetPublishers(null);
            Assert.That(result.Count, Is.EqualTo(5));
        }
        [Test]
        public void GetPublishersWithPage()
        {
            var result = publishersService.GetPublishers(2);
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.FirstOrDefault().name, Is.EqualTo("P6"));
            Assert.That(result.LastOrDefault().name, Is.EqualTo("P9"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }

        private void SeedDatabae()
        {
            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    id = 1,
                    name ="P1"
                },
                new Publisher()
                {
                    id = 2,
                    name ="P2"
                },
                new Publisher()
                {
                    id = 3,
                    name ="P3"
                },
                new Publisher()
                {
                    id = 4,
                    name ="P4"
                },
                new Publisher()
                {
                    id = 5,
                    name ="P5"
                },
                new Publisher()
                {
                    id = 6,
                    name ="P6"
                },
                new Publisher()
                {
                    id = 7,
                    name ="P7"
                },
                new Publisher()
                {
                    id = 8,
                    name ="P8"
                },
                new Publisher()
                {
                    id = 9,
                    name ="P9"
                }
            };
            dbContext.Publishers.AddRange(publishers);
            dbContext.SaveChanges();
        }
    }
}