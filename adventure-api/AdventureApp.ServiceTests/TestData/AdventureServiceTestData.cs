using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using System.Collections.Generic;

namespace AdventureApp.ServiceTests
{
    public class AdventureServiceTestData : BaseServiceTestData
    {
        public AdventureServiceTestData(string? dbName = null) : base(dbName)
        {
        }

        internal IEnumerable<Adventure> Test01_AdventureList;
        internal Adventure Test01_Adventure;
        internal Question Test01_Question;

        internal void GetAdventures_ReturnsListOfAllAdventures_TestData()
        {
            Test01_Question = CreateQuestion();

            Adventure adventure = CreateAdventure("Test1");
            Adventure adventure2 = CreateAdventure("Test2");
            Test01_Adventure = CreateAdventure("Test3", Test01_Question);
            Adventure adventure4 = CreateAdventure("Test4");

            Test01_AdventureList = new List<Adventure> { adventure, adventure2, Test01_Adventure, adventure4 };

            AdventureDbContext.Adventure.AddRange(Test01_AdventureList);
            AdventureDbContext.SaveChanges();
        }

        internal Adventure Test02_Adventure;
        internal Question Test02_Question;

        internal void GetAdventureById_ReturnsAdventure_TestData()
        {
            Test02_Question = CreateQuestion();

            Adventure adventure = CreateAdventure();
            Test02_Adventure = CreateAdventure(question: Test02_Question);
            Adventure adventure2 = CreateAdventure();
            Adventure adventure4 = CreateAdventure();

            AdventureDbContext.Adventure.AddRange(new List<Adventure> { adventure, adventure2, Test02_Adventure, adventure4 });
            AdventureDbContext.SaveChanges();
        }

        internal CreateAdventureDto Test03_CreataAdventureDto;
        internal void CreateAdventure_Success_TestData()
        {
            Test03_CreataAdventureDto = new CreateAdventureDto()
            {
                Name = "Test Adventure",
                RootQuestion = new QuestionDto()
                {
                    Name = "Test Name",
                    Value = false,
                    Questions = new List<QuestionDto>()
                    {
                         new QuestionDto() {Name ="Rahul"},
                         new QuestionDto {Name ="Test"}
                    }
                }
            };
        }
    }
}
