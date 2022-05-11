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

        internal UserAdventureDto Test01_UserAdventureDto;
        internal Adventure Test01_Adventure;
        internal Question Test01_Question;
        internal User Test01_User;

        internal void GetAdventures_ReturnsListOfAllUserAdventures_TestData()
        {
            Test01_Adventure = CreateAdventure();
            Test01_Question = CreateQuestion();
            Test01_User = CreateUser();
            UserAdventure userAdventure = CreateUserAdventure(Test01_Adventure, Test01_User, Test01_Question);
            UserAdventure userAdventure2 = CreateUserAdventure();
            UserAdventure userAdventure3 = CreateUserAdventure(user: Test01_User);

            IEnumerable<UserAdventure> userAdventures = new List<UserAdventure> { userAdventure, userAdventure2, userAdventure3 };

            AdventureDbContext.UserAdventure.AddRange(userAdventures);
            AdventureDbContext.SaveChanges();
        }
    }
}
