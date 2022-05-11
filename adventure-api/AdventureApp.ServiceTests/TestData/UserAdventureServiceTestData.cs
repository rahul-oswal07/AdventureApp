using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using System.Collections.Generic;

namespace AdventureApp.ServiceTests
{
    public class UserAdventureServiceTestData : BaseServiceTestData
    {
        public UserAdventureServiceTestData(string? dbName = null) : base(dbName)
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
    }
}
