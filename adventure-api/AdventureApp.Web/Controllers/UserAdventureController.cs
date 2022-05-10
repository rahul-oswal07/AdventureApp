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
        [Route("user/{userId}")]
        public async Task<IEnumerable<UserAdventureDto>> GetAll(int userId)
        {
            return await userAdventureService.GetUserAdventures(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserAdventureDto> Get(int id)
        {
            return await userAdventureService.GetUserAdventure(id);
        }

        [HttpPost]
        [Route("")]
        public async Task<UserAdventureDto> SaveUserAdventure(CreateUserAdventureDto createUserAdventureDto)
        {
            UserAdventureDto result = await userAdventureService.SaveUserAdventure(createUserAdventureDto);
            return result;
        }

        #endregion
    }
}
