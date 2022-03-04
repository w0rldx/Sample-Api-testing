using System;

namespace WebApplication1.Dto;

public class ProjectDto
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProjectOwner { get; set; }
    public DateTime CreateAt { get; set; }

    public ProjectDto(int id, string name, string description, string projectOwner)
    {
        Id = id;
        Name = name;
        Description = description;
        ProjectOwner = projectOwner;
        CreateAt = DateTime.Now;
    }
}