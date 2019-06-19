using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using myRestAPI.Controllers;
using myRestAPI.Models;
using myRestAPI.Services;

namespace myRestAPITests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TodoControllerTest_GetTodoList()
        {
            var mockTodoService = new Mock<ITodoService>();

            TodoListDTO todoListDTO = new TodoListDTO();
            mockTodoService.Setup(x => x.FindAll())
                .Returns(todoListDTO);

            TodoController todoController = new TodoController(mockTodoService.Object);

            // Act
            TodoListDTO actionResult = todoController.Get();

            // Assert
            Assert.AreEqual(todoListDTO, actionResult);
        }
    }
}
