using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using myRestAPI;
using myRestAPI.Models;
using myRestAPI.Profiles;
using myRestAPI.Services;
using NUnit.Framework;

namespace myRestAPITests
{
    [TestClass]
    public class TodoServiceTest
    {
        [TestMethod]
        public void FindAll()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new ApplicationContext(options))
            {
                context.Todos.Add(new Todo { Name = "testTodo1" });
                context.Todos.Add(new Todo { Name = "testTodo2" });
                context.Todos.Add(new Todo { Name = "testTodo3" });
                context.SaveChanges();
            }

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var _mapper = mockMapper.CreateMapper();

            var _todoService = new TodoService(new ApplicationContext(options), _mapper);

            // Act
            var actual = _todoService.FindAll();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, actual.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("testTodo2", actual[1].Name);
        }
    }
}
