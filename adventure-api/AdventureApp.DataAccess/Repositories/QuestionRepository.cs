using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AdventureDbContext adventureDbContext;

        public QuestionRepository(AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext ?? throw new ArgumentNullException("adventureDbContext cannot be null");
        }

        public async Task<QuestionDto> GetNextQuestion(int id, bool selectedValue)
        {
            Question result = await adventureDbContext.Question
                .Where(x => x.Id == id)
                .Include(item => item.Questions)
                .FirstOrDefaultAsync();

            try
            {
                var test = result.Questions.Where(x => x.Value == selectedValue)
               .Select(item => new QuestionDto()
               {
                   Id = item.Id,
                   Name = item.Name,
                   Questions = item.Questions?.Select(x => new QuestionDto() { Id = x.Id, Name = x.Name })
               }).FirstOrDefault();
                return test;
            }

            catch (Exception ex)
            {
                return null;
            }



        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await adventureDbContext.Question.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
