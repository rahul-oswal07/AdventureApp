using AdventureApp.DataAccess.Entities;
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
        private readonly IAdventureRepository adventureRepository;
        public AdventureService(IAdventureRepository adventureRepository)
        {
            this.adventureRepository = adventureRepository;
        }

        public bool CreateAdventure(Adventure adventure)
        {

            return true;
        }

        public Adventure GetAdventureById(int id)
        {
            return dougnutAdventure;
        }

        public async  Task<IEnumerable<Adventure>> GetAdventures()
        {
            return await adventureRepository.GetAdventures();
        }
    }
}