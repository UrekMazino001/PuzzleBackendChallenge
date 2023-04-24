using Moq;
using ReservationProject.Controllers;
using ReservationProject.DTO;
using ReservationProject.Entities;
using ReservationProject.Enums;
using ReservationProject.EnumExtensions;
using ReservationProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReservationProject.Test.Controllers
{
    public class ClientControllerTest
    {
        private readonly Mock<IClientService> _mockClientService;
        private readonly ClientController _controller;

        public ClientControllerTest()
        {
            _mockClientService = new Mock<IClientService>();
            _controller = new ClientController(_mockClientService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var mockClients = new List<ClientDTO>
            {
               new ClientDTO("Client 1", DateTime.Now, "Col Smith", "999999", ClientType.Person.ConvertToString(), ClientStatus.Available.ConvertToString()),
               new ClientDTO("Client 2", DateTime.Now, "Col Smith", "999999", ClientType.Person.ConvertToString(), ClientStatus.Available.ConvertToString())
            };
            _mockClientService.Setup(repo => repo.GetClients()).ReturnsAsync(mockClients);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var clients = Assert.IsAssignableFrom<IEnumerable<Client>>(okResult.Value);

            Assert.Equal(2, clients.Count());
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult()
        {
            // Arrange
            var mockClient = new ClientDTO("Client 1", DateTime.Now, "Col Smith", "999999",
                                            ClientType.Person.ConvertToString(), ClientStatus.Available.ConvertToString());


            _mockClientService.Setup(repo => repo.GetClientById(It.IsAny<int>()))
                .ReturnsAsync(mockClient);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var client = Assert.IsAssignableFrom<Client>(okResult.Value);

            //Assert.Equal("Client 1", client.Name);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound()
        {
            // Arrange
            _mockClientService.Setup(repo => repo.GetClientById(It.IsAny<int>()))
                .ReturnsAsync((ClientDTO?)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest()
        {
            // Arrange
            var clientDto = new ClientCreationDTO("Client 1", DateTime.Now, "Col Smith", "999999",
                                            ClientType.Person.ConvertToString());
);
            //Client client = new Client();

            //_mockClientService.Setup(repo => repo.Add(clientDto)).ReturnsAsync(client);

            // Act
            var result = await _controller.Post(It.IsAny<ClientCreationDTO>());

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
            //Assert.IsAssignableFrom<Client>(result.Value);
        }

        [Fact]
        public async Task Post_ReturnsOkResult()
        {
            // Arrange
            var clientDto = new ClientCreationDTO("New Client", DateTime.Now, "Col Smith", "999999",
                                                 ClientType.Person.ConvertToString());
            var NewClient = new Client { Id = 1, Name = "New Client" };

            _mockClientService.Setup(repo => repo.Add(clientDto)).ReturnsAsync(NewClient);

            // Act
            var result = await _controller.Post(clientDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            //var client = Assert.IsAssignableFrom<Client>(okResult.Value);
            Assert.Equal("New Client", NewClient.Name);
        }


        [Fact]
        public async Task Update_ReturnsBadRequest()
        {
            // Arrange
            var clientDto = new ClientUpdateDTO();

            // Act
            var result = await _controller.Update(clientDto);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact(Skip = "Incompleted")]
        public async Task Update_ReturnsOkResult()
        {
            // Arrange
            var clientDto = new ClientUpdateDTO { Id = 1, Name = "Updated Client" };
            _mockClientService.Setup(repo => repo.Update(clientDto))
                .ReturnsAsync(new Client { Id = 1, Name = "Updated Client" });

            // Act
            var result = await _controller.Update(clientDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var client = Assert.IsAssignableFrom<Client>(okResult.Value);
            Assert.Equal("Updated Client", client.Name);
        }

        //[InlineData(-1, 0)
        [Fact(Skip = "Incompleted")]
        public async Task Delete_ReturnsBadRequest()
        {
            // Arrange

            // Act
            var result = await _controller.Delete(0);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);

        }
    }
}
