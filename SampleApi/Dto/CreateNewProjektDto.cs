namespace WebApplication1.Dto;

public class CreateNewProjektDto
{
    public string Name { get; set; }
    public string Beschreibung { get; set; }
    public string ProjektLeiter { get; set; }

    public CreateNewProjektDto(string name, string beschreibung, string projektLeiter)
    {
        Name = name;
        Beschreibung = beschreibung;
        ProjektLeiter = projektLeiter;
    }
}