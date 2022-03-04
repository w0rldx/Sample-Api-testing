using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.Services;

public class ProjektService
{
    private List<Projekt> _projektList;

    public ProjektService()
    {
        _projektList = new List<Projekt>() {
            new Projekt("Test Projekt 1", "Beschreibung fehlt", "Thomas"), 
            new Projekt("Hardware Projekt", "Neues Hardware Forum", "Dennis"),
            new Projekt("Azubi Projekt 3", "Azubi Projekt", "Michael")
        };
    }

    public List<ProjektDto> GetAllProjekt()
    {
        List<ProjektDto> projektDtosList = new List<ProjektDto>();
        foreach (Projekt projekt in _projektList)
        {
            projektDtosList.Add(new ProjektDto(projekt.Name, projekt.Beschreibung, projekt.ProjektLeiter));
        }

        return projektDtosList;
    }

    public ProjektDto GetSingleProjekt(string name)
    {
        var result = _projektList.SingleOrDefault(x => x.Name == name);
        if (result != null)
        {
            return new ProjektDto(result.Name, result.Beschreibung, result.ProjektLeiter);
        }

        return null;
    }

    public ProjektDto AddProjekt(CreateNewProjektDto projekt)
    {
        Projekt projektToAdd = new Projekt(projekt.Name, projekt.Beschreibung, projekt.ProjektLeiter);
        _projektList.Add(projektToAdd);
        return new ProjektDto(projektToAdd.Name, projektToAdd.Beschreibung, projektToAdd.ProjektLeiter);
    }

    public void RemoveProjekt(string projektName)
    {
        // Fehler wenn mehr als ein Element mit dem Gleichen Namen im Projekt vorhanden ist
        var projektToRemove = _projektList.SingleOrDefault(x => x.Name == projektName);

        if (projektToRemove != null)
        {
            _projektList.Remove(projektToRemove);
        }
    }

    public ProjektDto UpdateProjekt(string projektName, UpdateProjektDto updatedProjekt)
    {
        var projektToUpdate = _projektList.SingleOrDefault(x => x.Name == projektName);

        if (projektToUpdate != null)
        {
            projektToUpdate.Name = updatedProjekt.Name;
            projektToUpdate.Beschreibung = updatedProjekt.Beschreibung;
            projektToUpdate.ProjektLeiter = updatedProjekt.ProjektLeiter;

            return new ProjektDto(projektToUpdate.Name, projektToUpdate.Beschreibung, projektToUpdate.ProjektLeiter);
        }

        return null;
    }


}