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
                .Where(question => question.Id == id)
                .Include(question => question.Questions)
                .FirstOrDefaultAsync();

            var questionDto = result.Questions.Where(x => x.Value == selectedValue)
            .Select(question => new QuestionDto()
            {
                Id = question.Id,
                Name = question.Name,
                Value = question.Value,
                Questions = question.Questions?.Select(x => new QuestionDto() { Id = x.Id, Name = x.Name, Value = x.Value })
            }).FirstOrDefault();
            return questionDto;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var result = adventureDbContext.Question.ToList()
                .FirstOrDefault(question => question.Id == id);
            return result;
        }

        #endregion
    }
}