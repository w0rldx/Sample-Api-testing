namespace WebApplication1.Dto;

public class UpdateProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProjectOwner { get; set; }

    public UpdateProjectDto(string name, string description, string projectOwner)
    {
        Name = name;
        Description = description;
        ProjectOwner = projectOwner;
    }
}