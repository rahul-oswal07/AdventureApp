using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        #region Private Variables

        private readonly AdventureDbContext adventureDbContext;

        #endregion

        #region Constructor

        public QuestionRepository(AdventureDbContext adventureDbContext)
        {
            this.adventureDbContext = adventureDbContext ?? throw new ArgumentNullException("adventureDbContext cannot be null");
        }

        #endregion

        #region Public Methods

        public async Task<QuestionDto> GetNextQuestion(int id, bool selectedValue)
        {
            Question result = await adventureDbContext.Question
                .Where(x => x.Id == id)
                .Include(item => item.Questions)
                .FirstOrDefaultAsync();

            var questionDto = result.Questions.Where(x => x.Value == selectedValue)
            .Select(item => new QuestionDto()
            {
                Id = item.Id,
                Name = item.Name,
                Questions = item.Questions?.Select(x => new QuestionDto() { Id = x.Id, Name = x.Name })
            }).FirstOrDefault();
            return questionDto;
        }

        public async Task<QuestionDto> GetQuestionById(int id)
        {
            var result = await adventureDbContext.Question
                .Where(question => question.Id == id)
                .Select(question => new QuestionDto { Id = question.Id, Name = question.Name, Value = question.Value })
                .FirstOrDefaultAsync();

            return result;
        }

        #endregion
    }
}