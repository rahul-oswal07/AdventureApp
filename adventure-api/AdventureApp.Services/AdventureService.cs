using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;

namespace AdventureApp.Services
{
    public class AdventureService : IAdventureService
    {
        private Adventure dougnutAdventure = new Adventure()
        {
            Name = "Doughnut decision maker",
            RootQuestion = new Question()
            {
                Name = "Do I want an doughnut",
                Questions = new List<Question>
                    {
                        new Question()
                        {
                            Name = "Do I deserve it ?",
                            Value = true,
                            Questions = new List<Question>
                            {
                                new Question()
                                {
                                    Name = "Are you sure ?",
                                    Value = true,
                                    Questions = new List<Question>
                                    {
                                        new Question()
                                        {
                                            Name = "Get it",
                                            Value= true
                                        },
                                        new Question()
                                        {
                                            Name= "Do jumping jacks first.",
                                            Value = false

                                        }
                                    }
                                },
                                new Question()
                                {
                                    Name = "Is it a good doughnut?",
                                    Value = false,
                                    Questions = new List<Question>
                                    {
                                        new Question()
                                        {
                                            Name = "What are you waiting for ? ",
                                            Value = true
                                        },
                                        new Question()
                                        {
                                            Name = "Wait 'til you find a sinful, unforgettable doughnut",
                                            Value = false
                                        }
                                    }

                                }

                            }
                        },
                        new Question()
                        {
                            Name = "Maybe you want an apple",
                            Value = false
                        }
                    }
            }
        };

        private Adventure testAdventure = new Adventure()
        {
            Name = "Test Adventure",
            RootQuestion = new Question()
            {
                Name = "Question level 1",
                Questions = new List<Question>
                {
                    new Question()
                    {
                        Name = "Question Yes level 1",
                        Value = true,
                        Questions= new List<Question>
                        {
                            new Question()
                            {
                                 Name = "Question Yes level 2",
                                 Value = true,
                            },
                            new Question()
                            {
                                 Name = "Question No level 2",
                                 Value = false,
                            }
                        }
                    },
                    new Question()
                    {
                        Name = "Question No level 2",
                        Value = false
                    }
                }
            }
        };
        private readonly IAdventureRepository adventureRepository;

        public AdventureService(IAdventureRepository adventureRepository)
        {
            this.adventureRepository = adventureRepository;
        }

        public async Task<bool> CreateAdventure(Adventure adventure)
        {
            if (adventure == null)
            {
                throw new ArgumentNullException("Adventure cannot be null");
            }
            await adventureRepository.AddAdventure(adventure);
            return true;
        }

        public async Task<Adventure> GetAdventureById(int id)
        {
            return await adventureRepository.GetAdventure(id);
        }

        public async Task<IEnumerable<AdventureDto>> GetAdventures()
        {
            return await adventureRepository.GetAdventures();
        }

        public async Task<UserAdventure> SaveUserAdventure(int userId, int adventuerId, int questionId)
        {
            return await adventureRepository.SaveUserAdventure(userId, adventuerId, questionId);
        }
    }
}