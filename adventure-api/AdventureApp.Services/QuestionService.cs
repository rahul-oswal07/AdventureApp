using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AutoMapper;

namespace AdventureApp.Services
{
    public class QuestionService : IQuestionService
    {
        #region Private Methods

        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper mapper;

        #endregion

        #region Constructor 

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            this.mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<QuestionDto> GetNextQuestion(int id, bool value)
        {
            return await _questionRepository.GetNextQuestion(id, value);
        }

        public async Task<QuestionDto> GetQuestionById(int id)
        {
            var result = await _questionRepository.GetQuestionById(id);
            return mapper.Map<QuestionDto>(result);
        }

        #endregion

    }
}
