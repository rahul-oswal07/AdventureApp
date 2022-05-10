using AdventureApp.DataAccess;
using AdventureApp.DataAccess.Entities;
using AdventureApp.Web;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureApp.ServiceTests
{
    public class BaseServiceTestData
    {
        public AdventureDbContext AdventureDbContext;

        public IMapper Mapper;

        public BaseServiceTestData(string? dbName = null)
        {
            AdventureDbContext = new AdventureDbContext(new DbContextOptionsBuilder<AdventureDbContext>()
                .UseInMemoryDatabase(databaseName: dbName ?? "Adventure").Options);
            AdventureDbContext.Database.EnsureDeleted();
            AdventureDbContext.Database.EnsureCreated();

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });
            Mapper = config.CreateMapper();
        }

        public Adventure CreateAdventure(string? name = null, Question? question = null)
        {
            string guid = Guid.NewGuid().ToString();
            Adventure adventure = new Adventure()
            {
                Name = name ?? "Test name" + guid,
                RootQuestion = question ?? CreateQuestion()
            };

            return adventure;
        }

        public Question CreateQuestion(string name = null, bool? value = null, Question? parentQuestion = null)
        {
            string guid = Guid.NewGuid().ToString();
            Question question = new Question()
            {
                Name = name ?? "Test title" + guid,
                ParentQuestion = parentQuestion ?? null
            };

            return question;
        }

        public Question CreateQuestionWithChildQuestions(string name = null, bool? value = null, Question? parentQuestion = null)
        {
            string guid = Guid.NewGuid().ToString();
            Question question = new Question()
            {
                Name = name ?? "Test title" + guid,
                ParentQuestion = parentQuestion ?? null,
                Questions = new List<Question>
                {
                    CreateQuestion(),
                    CreateQuestion()
                }
            };

            return question;
        }
    }
}
