using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.WebAPI.V1.Controllers
{
    //[Authorize]
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class PorfoliosController : ControllerBase
    {

        private readonly IPortfolioService _portfolioService;
        public PorfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest("{id} is missing");

            var result = await _portfolioService.GetPortfolioById(id);

            if (result == null)
                return NotFound("Your portfolio is not created");

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreatePortfolioDto portfolioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(portfolioDto);

            var result = await _portfolioService.CreatePortfolio(portfolioDto);
            if(result > 0)
                return Ok(new { portfolioId = result });

            return BadRequest();
        }
    }
}