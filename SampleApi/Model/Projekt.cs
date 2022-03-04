using System;
using WebApplication1.Helper;

namespace WebApplication1.Model;

public class Projekt
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Beschreibung { get; set; }
    public string ProjektLeiter { get; set; }

    public Projekt(string name, string beschreibung, string projektleiter)
    {
        Id = RandomHelper.GetRandomNumber();
        Name = name;
        Beschreibung = beschreibung;
        ProjektLeiter = projektleiter;
    }
}