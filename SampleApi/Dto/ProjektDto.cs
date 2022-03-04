namespace WebApplication1.Dto;

public class ProjektDto
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Beschreibung { get; set; }
    public string ProjektLeiter { get; set; }

    public ProjektDto(int id, string name, string beschreibung, string projektLeiter)
    {
        Id = id;
        Name = name;
        Beschreibung = beschreibung;
        ProjektLeiter = projektLeiter;
    }
}