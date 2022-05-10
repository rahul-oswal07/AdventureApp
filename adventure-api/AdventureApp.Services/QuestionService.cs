using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;

namespace AdventureApp.Services
{
    public class QuestionService : IQuestionService
    {
        #region Private Methods

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region Constructor 

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        #endregion

        #region Public Methods

        public async Task<QuestionDto> GetNextQuestion(int id, bool value)
        {
            return await _questionRepository.GetNextQuestion(id, value);
        }

        public async Task<QuestionDto> GetQuestionById(int id)
        {
            return await _questionRepository.GetQuestionById(id);
        }

        #endregion

    }
}
