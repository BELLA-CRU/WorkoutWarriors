using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutWarriorsWebApp.Controllers;
using WorkoutWarriorsWebApp.Interfaces;
using WorkoutWarriorsWebApp.Models;
using WorkoutWarriorsWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WorkoutWarriorsWebApp.Tests.Controller
{
    public class GymControllerTests
    {
        private GymController _gymController;
        private IGymRepository _gymRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;
        public GymControllerTests()
        {
            //Dependencies
            _gymRepository = A.Fake<IGymRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _gymController = new GymController(_gymRepository, _photoService);
        }

        [Fact]
        public void GymController_Index_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var gyms = A.Fake<IEnumerable<Gym>>();
            A.CallTo(() => _gymRepository.GetAll()).Returns(gyms);
            //Act
            var result = _gymController.Index();
            //Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WarriorsController_Detail_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var gym = A.Fake<Gym>();
            A.CallTo(() => _gymRepository.GetByIdAsync(id)).Returns(gym);
            //Act
            var result = _gymController.DetailGym(id, "Gym");
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }


    }
}
