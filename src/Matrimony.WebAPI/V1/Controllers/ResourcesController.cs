using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.V1.Controllers
{
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Route("PortfolioTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _resourceService.GetPortfolioTypes();
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}