using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutWarriors.Controllers;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WorkoutWarriors.Controllers;
using WorkoutWarriors.Data.Interfaces;

namespace WorkoutWarriorsWebApp.Tests.Controller
{
    public class GymControllerTests
    {
        private GymController _gymController;
        private IGymRepository _gymRepository;

        private IHttpContextAccessor _httpContextAccessor;
        public GymControllerTests()
        {
            //Dependencies
            _gymRepository = A.Fake<IGymRepository>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _gymController = new GymController(_gymRepository, _httpContextAccessor);
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

      


    }
}
