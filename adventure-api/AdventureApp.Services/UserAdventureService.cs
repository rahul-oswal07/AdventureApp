using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.DataAccess.Repositories;
using AutoMapper;

namespace AdventureApp.Services
{
    public class UserAdventureService : IUserAdventureService
    {
        #region Private Fields

        private readonly IUserAdventureRepository userAdventureRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        #endregion

        #region Public Constructor

        public UserAdventureService(IUserAdventureRepository userAdventureRepository, 
            IQuestionRepository questionRepository, IMapper mapper)
        {
            this.userAdventureRepository = userAdventureRepository;
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<UserAdventureDto> GetUserAdventure(int id)
        {
            UserAdventureDto userAdventureDto = await userAdventureRepository.GetUserAdventure(id);
            Question leafQuestion = await questionRepository.GetQuestionById(userAdventureDto.LeafQuestionId);

            IEnumerable<int> selectedQuestions = GetAllSelectedQuestionIds(leafQuestion);

            Question question = await questionRepository.GetQuestionById(userAdventureDto.RootQuestionId.Value);

            QuestionDto questionDto = mapper.Map<QuestionDto>(question);
            questionDto.IsSelected = selectedQuestions.Any(item => item == question.Id);
            UpdateQuestionsValue(questionDto, selectedQuestions);

            userAdventureDto.Question = questionDto;

            return userAdventureDto;

        }

        public async Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId)
        {
            return await userAdventureRepository.GetUserAdventures(userId);
        }

        public async Task<UserAdventureDto> SaveUserAdventure(CreateUserAdventureDto createUserAdventureDto)
        {
            return await userAdventureRepository.AddUserAdventure(createUserAdventureDto);
        }

        #endregion

        #region Private Region

        private IEnumerable<int> GetAllSelectedQuestionIds(Question? question)
        {
            List<int> selectedQuestionIds = new List<int>();
            Question currentQuestion = question;
            selectedQuestionIds.Add(currentQuestion.Id);
            while (currentQuestion?.ParentQuestionId != null)
            {
                selectedQuestionIds.Add(currentQuestion.ParentQuestionId.Value);
                currentQuestion = currentQuestion?.ParentQuestion;
            }

            return selectedQuestionIds;
        }

        private void UpdateQuestionsValue(QuestionDto question, IEnumerable<int> selectedQuestions)
        {
            if (question == null)
                return;

            if (question.Questions != null && question.Questions.Any())
            {
                foreach (var item in question.Questions)
                {
                    item.IsSelected = selectedQuestions.Any(id => id == item.Id);
                    UpdateQuestionsValue(item, selectedQuestions);
                }
            }
        }

        #endregion
    }
}
