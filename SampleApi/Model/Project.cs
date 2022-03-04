using System;
using WebApplication1.Helper;

namespace WebApplication1.Model;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProjectOwner { get; set; }

    public Project(string name, string description, string projectOwner)
    {
        Id = RandomHelper.GetRandomNumber();
        Name = name;
        Description = description;
        ProjectOwner = projectOwner;
    }
}