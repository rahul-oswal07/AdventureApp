﻿using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess.Repositories
{
    public class UserAdventureRepository : IUserAdventureRepository
    {
        #region Private Fields

        private readonly AdventureDbContext adventureDbContext;
        private readonly IMapper mapper;

        #endregion

        #region Public Constructor
        public UserAdventureRepository(AdventureDbContext adventureDbContext, IMapper mapper)
        {
            this.adventureDbContext = adventureDbContext;
            this.mapper = mapper;

        }

        #endregion

        #region Public Methods

        public async Task<UserAdventureDto> GetUserAdventure(int userId, int adventureId)
        {
            UserAdventure userAdventure = adventureDbContext.UserAdventure
                .Where(item => item.UserId == userId && item.AdventureId == adventureId)
                .Include(item => item.Adventure)
                .FirstOrDefault();

            Question question = adventureDbContext.Question.AsEnumerable()
                .Where(x => x.Id == userAdventure.QuestionId)
                .FirstOrDefault();
            IEnumerable<int> selectedQuestions = GetAllSelectedQuestionIds(question);

            var result = adventureDbContext.Question.ToList()
                .Where(item => item.Id == userAdventure.Adventure.RootQuestionId)
                .FirstOrDefault();

            QuestionDto questionDto = mapper.Map<QuestionDto>(result);
            questionDto.IsSelected = selectedQuestions.Any(item => item == result.Id);
            UpdateQuestionsValue(questionDto, selectedQuestions);

            return new UserAdventureDto
            {
                Name = userAdventure.Adventure.Name,
                Question = questionDto
            };
        }

        public async Task<IEnumerable<UserAdventureDto>> GetUserAdventures(int userId)
        {
            return await adventureDbContext.UserAdventure
                .Where(item => item.UserId == userId)
                .Select(item => new UserAdventureDto
                {
                    AdventureId = item.AdventureId,
                    Name = item.Adventure.Name
                }).ToListAsync();
        }

        #endregion

        #region Private Methods

        private void UpdateQuestionsValue(QuestionDto question, IEnumerable<int> selectedQuestions)
        {
            if (question == null)
                return;

            if (question.Questions != null && question.Questions.Any())
            {
                foreach (var item in question.Questions)
                {
                    item.IsSelected = selectedQuestions.Any(t => t == item.Id);
                    UpdateQuestionsValue(item, selectedQuestions);
                }
            }
        }

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

        #endregion
    }
}
