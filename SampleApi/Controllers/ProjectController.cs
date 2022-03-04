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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projektService;

        public ProjectController(ProjectService projektService)
        {
            _projektService = projektService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var result = _projektService.GetAllProject();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleProject(int id)
        {
            var result = _projektService.GetSingleProject(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProject(CreateNewProjectDto project)
        {
            var result = _projektService.AddProject(project);
            return Created("", result);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProject(int id)
        {
            var result = _projektService.GetSingleProject(id);
            if (result == null)
            {
                return BadRequest();
            }

            _projektService.RemoveProject(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, UpdateProjectDto updatedProject)
        {
            var result = _projektService.GetSingleProject(id);
            if (result != null)
            {
                _projektService.UpdateProject(id, updatedProject);
                result = _projektService.GetSingleProject(id);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
