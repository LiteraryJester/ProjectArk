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
        state.Init();

        currentShip.Init();
        currentShip.AddCrewVip(2);
        currentShip.AddCrewScientists(4);
        currentShip.AddCrewEngineers(4);
        currentShip.AddCrewCivilian(8);
        
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
