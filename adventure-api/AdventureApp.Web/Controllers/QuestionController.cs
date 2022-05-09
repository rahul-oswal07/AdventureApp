using AdventureApp.DataAccess.Entities;
using AdventureApp.DataAccess.Models;
using AdventureApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureApp.Web.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionController : BaseController
    {
        public readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<Question> Get(int id)
        {
            return await questionService.GetQuestionById(id);
        }

        [HttpGet]
        [Route("nextQuestion/{id}/{selectedValue}")]
        public async Task<QuestionDto> Get(int id, bool selectedValue)
        {
            return await questionService.GetNextQuestion(id, selectedValue);
        }
    }
}
