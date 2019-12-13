using AnimalCrossing;
using AnimalCrossing.Controllers;
using AnimalCrossing.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AnimalCrossingTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddMethodWithTwoPositiveNumbers()
        {
            DataTestService testService = new DataTestService();

            int result = testService.Add(2, 5);

            Assert.Equal(7, result);
        }

        [Fact]
        public void TestIndexMethodReturnsObjects()
        {
            
            var mockRepo = new Mock<ISpeciesRepository>(); 
            mockRepo.Setup(repo => repo.Get())
                .Returns(DataTestService.GetTestSpecies()); 
            var controller = new SpeciesController(mockRepo.Object); 


            // Act
            var result = controller.Index(); 

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); 
            var model = Assert.IsAssignableFrom<IEnumerable<Species>>( 
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count()); 

        }

        [Fact]
        public void Create_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            
            var mockRepo = new Mock<ISpeciesRepository>();
            
            var controller = new SpeciesController(mockRepo.Object);

            controller.ModelState.AddModelError("Name", "Required"); 
            var species = new Species() 
            {
                SpeciesId = 1,
                Name = "", 
                Description = "Dette er en test"
            };

            
            var result = controller.Create(species); 

           
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Species>(
                viewResult.ViewData.Model);
            Assert.IsType<Species>(model); 
        }

        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            
            var mockRepo = new Mock<ISpeciesRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<Species>())) 
                .Verifiable(); 
            var controller = new SpeciesController(mockRepo.Object);
            Species species = new Species()
            {
                Name = "Test",
                Description = "Test species"
            };

            
            var result = controller.Create(species);

            
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName); 
            Assert.Equal("Index", redirectToActionResult.ActionName); 
            mockRepo.Verify(); 
        }

        [Fact]
        public void AddNewCatToDatabase()
        {
            

            IAnimalRepository testRepo = DataTestService.GetInMemoryRepo(); 

            var cat = new Cat() 
            {
                Name = "TestKitty",
                Description = "A fine test candidate"
            };

            

            testRepo.Save(cat);

            

            Assert.Single(testRepo.Get()); 
            Assert.Equal(cat.Name, testRepo.Get(1).Name); 

        }

        [Fact]
        public void CatWithSameIDOverWritesCurrentCatInDB()
        {
            
            IAnimalRepository testrepo = DataTestService.GetInMemoryRepo();

            var cat = new Cat()
            {
                Name = "TestKitty",
                Description = "A fine test candidate"
            };

            testrepo.Save(cat);

            var sameCat = testrepo.Get(1);

            sameCat.Name = "TestKitty2";

            
            testrepo.Save(sameCat);

            

            Assert.Single(testrepo.Get()); 
            Assert.Equal(sameCat.Name, testrepo.Get(1).Name); 
        }

        [Fact]
        public void DeleteCatFromDatabase()
        {
            
            IAnimalRepository testrepo = DataTestService.GetInMemoryRepo();

            var cat = new Cat()
            {
                Name = "TestKitty",
                Description = "A fine test candidate"
            };

            testrepo.Save(cat);

            
            testrepo.Delete(testrepo.Get(1).CatId); 

            
            Assert.Empty(testrepo.Get()); 
        }

 /*  
    }
}

