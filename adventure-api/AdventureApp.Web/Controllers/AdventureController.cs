using AdventureApp.DataAccess.Entities;
using AdventureApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdventureApp.Web.Controllers
{
    [ApiController]
    [Route("api/adventures")]
    public class AdventureController : BaseController
    {
        private readonly ILogger<AdventureController> _logger;
        private readonly IAdventureService _adventureService;

        public AdventureController(ILogger<AdventureController> logger, IMapper mapper, IAdventureService adventureService)
        {
            _logger = logger;
            _adventureService = adventureService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var result = await _adventureService.GetAdventures();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Adventure> GetAdventureById(int id)
        {
            Adventure result = await _adventureService.GetAdventureById(id);
            return result;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> GetAdventureById(Adventure adventure)
        {
            bool result = await _adventureService.CreateAdventure(adventure);
            return Ok(result);
        }
    }
}