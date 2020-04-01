
using System.Threading.Tasks;
using Contracts.Services;
using res = Contracts.Dto.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Xunit;


namespace WebApi.Tests
{
    public class ContactsControllerTests
    {
        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidContactDto()
        {
            // Arrange & Act
            var mockRepo = new Mock<IContactService>();
            var controller = new ContactsController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "Invalid Contact Creation Dto");

            // Act
            var result = await controller.PostContact(contact: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Search_ReturnsHttpNoContent_ForInvalidID()
        {
            // Arrange
            int testId = -1;
            var mockRepo = new Mock<IContactService>();
            mockRepo.Setup(repo => repo.GetContactById(testId))
                .Returns((Task<res.ClientResponse<res.ContactDto>>)null);                
            var controller = new ContactsController(mockRepo.Object);

            // Act
            var result = await controller.GetContact(testId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Patch_ReturnsHttpBadRequest_ForInvalidModel()
        {

            // Arrange & Act
            var testId = 1;
            var mockRepo = new Mock<IContactService>();
            var controller = new ContactsController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "Invalid Patch Update");

            // Act
            var result = await controller.PatchContact(testId, updatedContact: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetByMail_ReturnsHttpBadRequest_ForInvalidMail()
        {

            // Arrange & Act
            var mail = "";
            var mockRepo = new Mock<IContactService>();
            var controller = new ContactsController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "Invalid Email");

            // Act
            var result = await controller.GetContactListByMail(mail, pagination : null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetByPhone_ReturnsHttpBadRequest_ForInvalidPhone()
        {

            // Arrange & Act            
            var mockRepo = new Mock<IContactService>();
            var controller = new ContactsController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "Invalid Email");

            // Act
            var result = await controller.GetContactListByPhone(phoneRequest : null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetByLocation_ReturnsHttpBadRequest_ForInvalidLocation()
        {

            // Arrange & Act
            var location = "wrong";
            var id = -1;
            var mockRepo = new Mock<IContactService>();
            var controller = new ContactsController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "Wrong Location");

            // Act
            var result = await controller.GetContactListByLocation(location, id, pagination : null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
