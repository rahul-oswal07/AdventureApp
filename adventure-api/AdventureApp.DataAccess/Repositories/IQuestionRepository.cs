using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.DataAccess.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionById(int id);

        Task<QuestionDto> GetNextQuestion(int id, bool selectedValue);
    }
}
