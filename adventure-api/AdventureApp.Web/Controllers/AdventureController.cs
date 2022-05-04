using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AdventureApp.Web.ViewModels;
using AdventureApp.Services;

namespace AdventureApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet(Name = "adventures")]
        public async Task<IEnumerable<AdventureViewModel>> Get()
        {
            var result = await _adventureService.GetAdventures();
            IEnumerable<AdventureViewModel> adventures = Mapper.Map<IEnumerable<AdventureViewModel>>(result);
            return adventures;
        }
    }
}