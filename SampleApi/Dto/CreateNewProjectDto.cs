namespace WebApplication1.Dto;

public class CreateNewProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProjectOwner { get; set; }

    public CreateNewProjectDto(string name, string description, string projectOwner)
    {
        Name = name;
        Description = description;
        ProjectOwner = projectOwner;
    }
}