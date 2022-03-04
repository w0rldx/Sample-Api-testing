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
            projektDtosList.Add(new ProjektDto(projekt.Id ,projekt.Name, projekt.Beschreibung, projekt.ProjektLeiter));
        }

        return projektDtosList;
    }

    public ProjektDto GetSingleProjekt(int id)
    {
        var result = _projektList.SingleOrDefault(x => x.Id == id);
        if (result != null)
        {
            return new ProjektDto(result.Id ,result.Name, result.Beschreibung, result.ProjektLeiter);
        }

        return null;
    }

    public ProjektDto AddProjekt(CreateNewProjektDto projekt)
    {
        Projekt projektToAdd = new Projekt(projekt.Name, projekt.Beschreibung, projekt.ProjektLeiter);
        _projektList.Add(projektToAdd);
        return new ProjektDto(projektToAdd.Id, projektToAdd.Name, projektToAdd.Beschreibung, projektToAdd.ProjektLeiter);
    }

    public void RemoveProjekt(int id)
    {
        var projektToRemove = _projektList.SingleOrDefault(x => x.Id == id);
        _projektList.Remove(projektToRemove);
    }

    public ProjektDto UpdateProjekt(int id, UpdateProjektDto updatedProjekt)
    {
        var projektToUpdate = _projektList.SingleOrDefault(x => x.Id == id);

        if (projektToUpdate != null)
        {
            projektToUpdate.Name = updatedProjekt.Name;
            projektToUpdate.Beschreibung = updatedProjekt.Beschreibung;
            projektToUpdate.ProjektLeiter = updatedProjekt.ProjektLeiter;

            return new ProjektDto(projektToUpdate.Id, projektToUpdate.Name, projektToUpdate.Beschreibung, projektToUpdate.ProjektLeiter);
        }

        return null;
    }


}