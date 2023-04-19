using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Enum;
using WorkoutWarriors.Models;
using WorkoutWarriors.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WorkoutWarriors.Tests.Repository
{
    public class GymRepositoryTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Gyms.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Gyms.Add(
                      new Gym()
                      {
                          Title = "Jim's Gym",
                          Image = "https://tse3.mm.bing.net/th?id=OIP.p-aZsNRUiC7FilHb3hnEYgHaE8&pid=Api&P=0",
                          Description = "This is a fake gym",
                          GymType = GymType.GoldGym,
                          Address = new Address()
                          {
                              Street = "123 Main St",
                              City = "Wesley Chapel",
                              State = "FL"
                          }
                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void Gymrepository_Add_ReturnsBool()
        {
            //Arrange
            var gym = new Gym()
            {
                Title = "Jim's Gym",
                Image = "https://tse3.mm.bing.net/th?id=OIP.p-aZsNRUiC7FilHb3hnEYgHaE8&pid=Api&P=0",
                Description = "This is a fake gym",
                GymType = GymType.GoldGym,
                Address = new Address()
                {
                    Street = "123 Main St",
                    City = "Wesley Chapel",
                    State = "FL"
                }
            };
            var dbContext = await GetDbContext();
            var gymRespository = new GymRepository(dbContext);

            //Act
            var result = gymRespository.Add(gym);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void GymRepository_GetByIdAsync_ReturnsGym()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var gymRepository = new GymRepository(dbContext);

            //Act
            var result = gymRepository.GetByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Gym>>();
        }

        [Fact]
        public async void GymRepository_GetAll_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var gymRepository = new GymRepository(dbContext);

            //Act
            var result = await gymRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Gym>>();
        }

        [Fact]
        public async void GymRepository_SuccessfulDelete_ReturnsTrue()
        {
            //Arrange
            var gym = new Gym()
            {
                Title = "Jim's Gym",
                Image = "https://tse3.mm.bing.net/th?id=OIP.p-aZsNRUiC7FilHb3hnEYgHaE8&pid=Api&P=0",
                Description = "This is a fake gym",
                GymType = GymType.GoldGym,
                Address = new Address()
                {
                    Street = "123 Main St",
                    City = "Wesley Chapel",
                    State = "FL"
                }
            };
            var dbContext = await GetDbContext();
            var gymRepository = new GymRepository(dbContext);

            //Act
            gymRepository.Add(gym);
            var result = gymRepository.Delete(gym);
            var count = await gymRepository.GetByIdAsync(gym.Id);

            //Assert
            result.Should().BeTrue();
            count.Should().Be(0);
        }

    
      
    }
}

