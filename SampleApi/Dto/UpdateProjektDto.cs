namespace WebApplication1.Dto;

public class UpdateProjektDto
{
    public string Name { get; set; }
    public string Beschreibung { get; set; }
    public string ProjektLeiter { get; set; }

    public UpdateProjektDto(string name, string beschreibung, string projektLeiter)
    {
        Name = name;
        Beschreibung = beschreibung;
        ProjektLeiter = projektLeiter;
    }
}