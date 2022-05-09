using AdventureApp.DataAccess.Models;
using AdventureApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureApp.Web.Controllers
{
    [ApiController]
    [Route("api/useradventures")]
    public class UserAdventureController : BaseController
    {
        #region Private Methods

        private readonly IUserAdventureService userAdventureService;

        #endregion

        #region Constructor

        public UserAdventureController(IUserAdventureService userAdventureService)
        {
            this.userAdventureService = userAdventureService;
        }

        #endregion

        #region Action Methods

        [HttpGet]
        [Route("{userId}")]
        public async Task<IEnumerable<UserAdventureDto>> Get(int userId)
        {
            return await userAdventureService.GetUserAdventures(userId);
        }

        [HttpGet]
        [Route("{userId}/{adventureId}")]
        public async Task<UserAdventureDto> Get(int userId, int adventureId)
        {
            return await userAdventureService.GetUserAdventure(userId, adventureId);
        }

        #endregion
    }
}
