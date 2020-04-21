using Assets.Cards.Preperation.ShipComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeNewGame 
{
    public void Init(GameState state, Ship currentShip, List<CardBase> researchProjects, List<CardBase> shipConstructionProjects)
    {
     //   state = ScriptableObject.CreateInstance<GameState>();
    //    currentShip = ScriptableObject.CreateInstance<Ship>();

        state.RandomSeed = 20200419;
        state.Month = 1;
        state.InfectionRate = .005m;
        state.MegaCredits = 60;
        state.MegaCreditProduction = 2;
        state.Science = 12;
        state.ScienceProduction = 1;
        state.Engineering = 12;
        state.EngineeringProduction = 1;
        state.Materials = 60;
        state.MaterialsProduction = 2;
        state.Destination = "Mars";
        state.TimeToDestination = 0;
        state.HasZeroGConstruction = false;
        state.HasDoubleDensityAeroponics = false;
        state.MaterialsFixedModifier = 0;
        state.InfectionRateDelta = 0;
        state.ConstructiontimeModierFixed = 0;
        state.MassModifier = 1;
        state.VirusCured = false;
        state.GameOver = false;
        state.Launched = false;

        currentShip.Mass = 0;
        currentShip.Thrust = 0m;
        currentShip.Fuel = 0;
        currentShip.Oxygen = 0;
        currentShip.Supplies = 0;

        currentShip.OxygenProduction = -18;
        currentShip.SuppliesProduction = -18;
        currentShip.Power = 0;
        currentShip.PowerProduction = 0;
        currentShip.PrefabStrucutres = 0;
        currentShip.CrewCapacity = 0;
        currentShip.CrewVip = 2;
        currentShip.CrewCorporate = 0;
        currentShip.CrewScientists = 4;
        currentShip.CrewEngineers = 4;
        currentShip.CrewCivilian = 8;
        currentShip.FuelRequiredForJourney = 0;
        currentShip.FuelRequiredForLaunch = 0;
        currentShip.SolarThrust = 0m;

        currentShip.Modules = new Dictionary<string, Tuple<string, int, int>>();
        state.ResearchProjects = researchProjects;
        researchProjects.Add(ScriptableObject.CreateInstance<CorporateSponsor>());
        researchProjects.Add(ScriptableObject.CreateInstance<ZeroGConstruction>());
        researchProjects.Add(ScriptableObject.CreateInstance<NuclearProplusion>());
        researchProjects.Add(ScriptableObject.CreateInstance<MagneticPropulsion>());
        researchProjects.Add(ScriptableObject.CreateInstance<AntimatterPropolusion>());
        researchProjects.Add(ScriptableObject.CreateInstance<ImprovedDisinfectant>());


        state.ShipConstructionProjects = shipConstructionProjects;
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<ConventionalEngine>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<SmallHabitatModule>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<MediumHabitatModule>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<LargeHabitatModule>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<AeroponicsBay>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<SolarPanel>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<Battery>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<FuelStorage>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<FuelMediumStorage>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<FuelLargeStorage>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<SupplyStorage>());
        shipConstructionProjects.Add(ScriptableObject.CreateInstance<OxygenStorage>());
    }
}
