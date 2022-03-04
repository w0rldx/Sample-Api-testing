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

        [HttpGet("GetSingleProjekt")]
        public IActionResult GetSingleProjekt(string name)
        {
            return Ok(_projektService.GetSingleProjekt(name));
        }

        [HttpPut("CreateNewProject")]
        public IActionResult AddProjekt(CreateNewProjektDto projekt)
        {
            var result = _projektService.AddProjekt(projekt);
            return Created("", result);
        }

        [HttpDelete("DeleteProject")]
        public IActionResult RemoveProjekt(string name)
        {
            _projektService.RemoveProjekt(name);
            return Ok();
        }

        [HttpPost("UpdateProject")]
        public IActionResult UpdateProjekt(UpdateProjektDto updatedProjekt)
        {
            var result = _projektService.UpdateProjekt(updatedProjekt.Name, updatedProjekt);
            return Ok(result);
        }
    }
}
