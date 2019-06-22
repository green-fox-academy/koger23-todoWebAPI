using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using myRestAPI.Controllers;
using myRestAPI.Models;
using myRestAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myRestAPITests
{
    [TestClass]
    public class TodoControllerTest
    {
        [TestMethod]
        public void TodoControllerTest_GetTodoList()
        {
            var mockTodoService = new Mock<ITodoService>();

            var todoListDTO = new List<TodoGetDTO>();
            mockTodoService.Setup(x => x.FindAll())
                .Returns(todoListDTO);

            TodoController todoController = new TodoController(mockTodoService.Object);

            // Act
            List<TodoGetDTO> actionResult = todoController.Get();

            // Assert
            Assert.AreEqual(todoListDTO, actionResult);
        }

        [TestMethod]
        public void TodoControllerTest_AddTodo()
        {
            // Arrange
            var mockTodoService = new Mock<ITodoService>();
            TodoDTO todoDTO = new TodoDTO {
                Name = "test",
                AssigneeId = 1,
                Description = "test add todo endpoint",
                Done = false,
                UserId = 1
            };
            mockTodoService.Setup(x => x.CreateTodo(todoDTO))
                .ReturnsAsync(new OkResult());

            TodoController todoController = new TodoController(mockTodoService.Object);

            // Act
            Task<IActionResult> addTodoResult = todoController.Post(todoDTO);

            // Assert
            var expected = new OkResult();
            Assert.IsNotNull(addTodoResult);
            Assert.AreEqual(expected.GetType(), addTodoResult.Result.GetType());
        }
    }
}
