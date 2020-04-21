using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Ship")]
public class Ship : ScriptableObject
{
    public int Mass = 0;
    public decimal Thrust = 0m;
    public int Fuel = 0;
    public int Oxygen = 0;

    public int OxygenProduction = 0;
    public int Supplies = 0;
    public int SuppliesProduction = 0;
    public int Power = 0;
    public int PowerProduction = 0;
    public int PrefabStrucutres = 0;
    public int CrewCapacity = 0;
    public int CrewVip = 0;
    public int CrewCorporate = 0;
    public int CrewScientists = 0;
    public int CrewEngineers = 0;
    public int CrewCivilian = 0;

    public int FuelRequiredForLaunch = 0;
    public int FuelRequiredForJourney = 0;

    public int TotalCrew => CrewVip + CrewCorporate + CrewScientists + CrewEngineers + CrewCivilian;

    public decimal SolarThrust { get; internal set; }

    public Dictionary<string, Tuple<string, int, int>> Modules = new Dictionary<string, Tuple<string, int, int>>();

    public void AddMass(int mass, decimal massModifier)
    {
        Mass += (int) Math.Floor( mass*(1+ massModifier));
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
            Modules[id] = new Tuple<string, int, int>(mod.Item1, mod.Item2, mod.Item3+1);
        }
        else
        {
            Modules.Add(id, new Tuple<string, int, int>(name, 0, 1));
        }
    }
}
