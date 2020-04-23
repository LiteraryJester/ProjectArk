using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Ship")]
public class Ship : ScriptableObject
{
    public int Mass { get; set; }
    public decimal Thrust { get; set; }
    public int Fuel { get; set; }
    public int Oxygen { get; set; }

    public int OxygenProduction { get; set; }
    public int Supplies { get; set; }
    public int SuppliesProduction { get; set; }
    public int Power { get; set; }
    public int PowerProduction { get; set; }
    public int PrefabStrucutres { get; set; }
    public int CrewCapacity { get; set; }
    public int CrewVip { get; set; }
    public int CrewCorporate { get; set; }
    public int CrewScientists { get; set; }
    public int CrewEngineers { get; set; }
    public int CrewCivilian { get; set; }

    public int FuelRequiredForLaunch { get; set; }
    public int FuelRequiredForJourney { get; set; }

    public int TotalCrew => CrewVip + CrewCorporate + CrewScientists + CrewEngineers + CrewCivilian;

    public decimal SolarThrust { get; set; }

    public void Init(int crewVip = 0, int crewCorporate = 0, int crewScientists = 0, int crewEngineers = 0, int crewCivilian = 0)
    {
        Mass = 0;
        Thrust = 0m;
        Fuel = 0;
        Oxygen = 0;

        OxygenProduction = 0;
        Supplies = 0;
        SuppliesProduction = 0;
        Power = 0;
        PowerProduction = 0;
        PrefabStrucutres = 0;
        CrewCapacity = 0;
        CrewVip = 0;
        CrewCorporate = 0;
        CrewScientists = 0;
        CrewEngineers = 0;
        CrewCivilian = 0;

        FuelRequiredForLaunch = 0;
        FuelRequiredForJourney = 0;
        Modules = new Dictionary<string, Tuple<string, int, int>>();

        AddCrewVip(crewVip);
        AddCrewCorporate(crewCorporate);
        AddCrewScientists(crewScientists);
        AddCrewEngineers(crewEngineers);
        AddCrewCivilian(crewCivilian);
    }

    public Dictionary<string, Tuple<string, int, int>> Modules = new Dictionary<string, Tuple<string, int, int>>();

    public void AddCrewVip(int count)
    {
        CrewVip += count;
        OxygenProduction -= count;
        SuppliesProduction -= count;
        Mass += count;
    }

    public void AddCrewCorporate(int count)
    {
        CrewCorporate += count;
        OxygenProduction -= count;
        SuppliesProduction -= count;
        Mass += count;
    }

    public void AddCrewScientists(int count)
    {
        CrewScientists += count;
        OxygenProduction -= count;
        SuppliesProduction -= count;
        Mass += count;
    }

    public void AddCrewEngineers(int count)
    {
        CrewEngineers += count;
        OxygenProduction -= count;
        SuppliesProduction -= count;
        Mass += count;
    }

    public void AddCrewCivilian(int count)
    {
        CrewCivilian += count;
        OxygenProduction -= count;
        SuppliesProduction -= count;
        Mass += count;
    }
  
    internal void CompleteModule(string id)
    {
        if (Modules.ContainsKey(id))
        {
            var mod = Modules[id];
            Modules[id] = new Tuple<string, int, int>(mod.Item1, mod.Item2 + 1, mod.Item3);
        }
    }

    internal void AddModule(string id, string name)
    {
        if (Modules.ContainsKey(id))
        {
            var mod = Modules[id];
            Modules[id] = new Tuple<string, int, int>(mod.Item1, mod.Item2, mod.Item3 + 1);
        }
        else
        {
            Modules.Add(id, new Tuple<string, int, int>(name, 0, 1));
        }
    }
}
