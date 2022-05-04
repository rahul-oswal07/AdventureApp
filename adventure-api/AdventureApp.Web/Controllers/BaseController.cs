using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdventureApp.Web.Controllers
{
    public class BaseController : ControllerBase
    {
		#region Public Properties

		/// <summary>
		/// Mapper for mapping entities
		/// </summary>
		public IMapper Mapper;


		#endregion
	}
}
