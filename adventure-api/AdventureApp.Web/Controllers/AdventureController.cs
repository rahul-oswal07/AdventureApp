using AdventureApp.DataAccess.Models;
using AdventureApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureApp.Web.Controllers
{
    [ApiController]
    [Route("api/adventures")]
    public class AdventureController : BaseController
    {
        public readonly IAdventureService _adventureService;

        public AdventureController(IAdventureService adventureService)
        {
            _adventureService = adventureService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AdventureDto>> Get()
        {
            var result = await _adventureService.GetAdventures();
            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AdventureDto> GetAdventureById(int id)
        {
            AdventureDto result = await _adventureService.GetAdventureById(id);
            return result;
        }

        [HttpPost]
        [Route("")]
        public async Task<AdventureDto> CreateAdventure(CreateAdventureDto adventure)
        {
            AdventureDto result = await _adventureService.CreateAdventure(adventure);
            return result;
        }
    }
}