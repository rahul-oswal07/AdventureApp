using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;

namespace AdventureApp.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<QuestionDto> GetNextQuestion(int id, bool value)
        {
            return await _questionRepository.GetNextQuestion(id, value);
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _questionRepository.GetQuestionById(id);
        }
    }
}
