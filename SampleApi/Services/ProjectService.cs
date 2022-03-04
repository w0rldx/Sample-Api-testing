using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.Services;

public class ProjectService
{
    private List<Project> _projectList;

    public ProjectService()
    {
        _projectList = new List<Project>() {
            new Project("Test Projekt 1", "Description fehlt", "Thomas"), 
            new Project("Hardware Projekt", "Neues Hardware Forum", "Dennis"),
            new Project("Azubi Projekt 3", "Azubi Projekt", "Michael")
        };
    }

    public List<ProjectDto> GetAllProject()
    {
        List<ProjectDto> projectDtosList = new List<ProjectDto>();
        foreach (Project project in _projectList)
        {
            projectDtosList.Add(new ProjectDto(project.Id ,project.Name, project.Description, project.ProjectOwner));
        }

        return projectDtosList;
    }

    public ProjectDto GetSingleProject(int id)
    {
        var result = _projectList.SingleOrDefault(x => x.Id == id);
        if (result != null)
        {
            return new ProjectDto(result.Id ,result.Name, result.Description, result.ProjectOwner);
        }

        return null;
    }

    public ProjectDto AddProject(CreateNewProjectDto project)
    {
        Project projectToAdd = new Project(project.Name, project.Description, project.ProjectOwner);
        _projectList.Add(projectToAdd);
        return new ProjectDto(projectToAdd.Id, projectToAdd.Name, projectToAdd.Description, projectToAdd.ProjectOwner);
    }

    public void RemoveProject(int id)
    {
        var projectToRemove = _projectList.SingleOrDefault(x => x.Id == id);
        _projectList.Remove(projectToRemove);
    }

    public ProjectDto UpdateProject(int id, UpdateProjectDto updatedProject)
    {
        var projectToUpdate = _projectList.SingleOrDefault(x => x.Id == id);

        if (projectToUpdate != null)
        {
            projectToUpdate.Name = updatedProject.Name;
            projectToUpdate.Description = updatedProject.Description;
            projectToUpdate.ProjectOwner = updatedProject.ProjectOwner;

            return new ProjectDto(projectToUpdate.Id, projectToUpdate.Name, projectToUpdate.Description, projectToUpdate.ProjectOwner);
        }

        return null;
    }


}