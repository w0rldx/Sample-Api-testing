using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly ProjektService _projektService;

        public ProjektController(ProjektService projektService)
        {
            _projektService = projektService;
        }

        [HttpGet("GetProjectList")]
        public IActionResult GetAllProjekts()
        {
            return Ok(_projektService.GetAllProjekt());
        }

        [HttpGet("GetSingleProjekt/{id}")]
        public IActionResult GetSingleProjekt(int id)
        {
            return Ok(_projektService.GetSingleProjekt(id));
        }

        [HttpPost("CreateNewProject")]
        public IActionResult AddProjekt(CreateNewProjektDto projekt)
        {
            var result = _projektService.AddProjekt(projekt);
            return Created("", result);
        }

        [HttpDelete("DeleteProject/{id}")]
        public IActionResult RemoveProjekt(int id)
        {
            var result = _projektService.GetSingleProjekt(id);
            if (result == null)
            {
                return BadRequest();
            }

            _projektService.RemoveProjekt(id);
            return NoContent();
        }

        [HttpPut("UpdateProject/{id}")]
        public IActionResult UpdateProjekt(int id, UpdateProjektDto updatedProjekt)
        {
            var result = _projektService.GetSingleProjekt(id);
            if (result != null)
            {
                _projektService.UpdateProjekt(id, updatedProjekt);
                result = _projektService.GetSingleProjekt(id);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
