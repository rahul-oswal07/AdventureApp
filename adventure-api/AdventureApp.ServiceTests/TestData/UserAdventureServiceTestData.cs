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

        internal Adventure Test01_Adventure;
        internal Question Test01_Question;
        internal User Test01_User;

        internal void GetUserAdventures_ReturnsListOfAllUserAdventures_TestData()
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

        internal User Test02_User;
        internal void GetUserAdventures_ReturnsEmptyList_TestData()
        {
            UserAdventure userAdventure = CreateUserAdventure();
            UserAdventure userAdventure2 = CreateUserAdventure();
            UserAdventure userAdventure3 = CreateUserAdventure();
            Test02_User = CreateUser();

            IEnumerable<UserAdventure> userAdventures = new List<UserAdventure> { userAdventure, userAdventure2, userAdventure3 };

            AdventureDbContext.UserAdventure.AddRange(userAdventures);
            AdventureDbContext.User.Add(Test02_User);
            AdventureDbContext.SaveChanges();
        }


        internal User Test03_User;
        internal Question Test03_RootQuestion;
        internal Adventure Test03_Adventure;
        internal UserAdventure Test03_UserAdventure;
        internal Question Test03_LeafQuestion;
        internal Question Test03_SelectedQuestion;

        internal void GetUserAdventure_ReturnsUserAdventure_TestData()
        {
            UserAdventure userAdventure = CreateUserAdventure();
            UserAdventure userAdventure2 = CreateUserAdventure();
            UserAdventure userAdventure3 = CreateUserAdventure();

            Question yesQuestionLevel3 = CreateQuestion("Yes Question Level 3", true);
            Test03_LeafQuestion = CreateQuestion("No Question Level 3", false);
            IEnumerable<Question> questionslevel3 = new List<Question> { yesQuestionLevel3, Test03_LeafQuestion };

            Question yesQuestionLevel2 = CreateQuestionWithChildQuestions("Yes Question Level 2", true, questionslevel3);
            Question noQuestionLevel2 = CreateQuestion("No Question Level 2", false);
            IEnumerable<Question> questionslevel2 = new List<Question> { yesQuestionLevel2, noQuestionLevel2 };

            Test03_SelectedQuestion = CreateQuestionWithChildQuestions("Yes Question Level 1", true, questionslevel2);
            Question noQuestionLevel1 = CreateQuestion("No Question Level 1", false);
            IEnumerable<Question> questionslevel1 = new List<Question> { Test03_SelectedQuestion, noQuestionLevel1 };

            Test03_RootQuestion = CreateQuestionWithChildQuestions("RootQuestion", false, questionslevel1);
            Test03_Adventure = CreateAdventure("Test Adventure", Test03_RootQuestion);
            Test03_User = CreateUser();
            Test03_UserAdventure = CreateUserAdventure(Test03_Adventure, Test03_User, Test03_LeafQuestion);

            IEnumerable<UserAdventure> userAdventures = new List<UserAdventure> { userAdventure, Test03_UserAdventure, userAdventure2, userAdventure3 };

            AdventureDbContext.UserAdventure.AddRange(userAdventures);
            AdventureDbContext.SaveChanges();
        }

        internal CreateUserAdventureDto Test04_CreateUserAdventureDto;
        internal User Test04_User;
        internal Adventure Test04_Adventure;
        internal Question Test04_SelectedQuestion;

        internal void SaveUserAdventure_Success_TestData()
        {
            Test04_SelectedQuestion = CreateQuestionWithChildQuestions("Yes Question Level 1", true);
            Question noQuestionLevel1 = CreateQuestion("No Question Level 1", false);
            IEnumerable<Question> questionslevel1 = new List<Question> { Test04_SelectedQuestion, noQuestionLevel1 };

            Question rootQuestion = CreateQuestionWithChildQuestions("RootQuestion", false, questionslevel1);

            Test04_Adventure = CreateAdventure(question: rootQuestion);

            Test04_User = CreateUser();
            
            AdventureDbContext.User.Add(Test04_User);
            AdventureDbContext.Adventure.Add(Test04_Adventure);
            
            AdventureDbContext.SaveChanges();

            Test04_CreateUserAdventureDto = new CreateUserAdventureDto
            {
                AdventureId = Test04_Adventure.Id,
                QuestionId = Test04_SelectedQuestion.Id,
                UserId = Test04_User.Id,
            };
        }
    }
}
