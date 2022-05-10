using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;

namespace AdventureApp.Services
{
    public interface IQuestionService
    {
        Task<QuestionDto> GetQuestionById(int id);

        Task<QuestionDto> GetNextQuestion(int id, bool value);
    }
}
