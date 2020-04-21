using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGConstruction : CardBase
{
    public override string Id => "CONS-001";

    // Start is called before the first frame update
    public ZeroGConstruction()
    {
        CardName = "Zero G Construction";
        Description = "Increase cost of all ship parts by 2 materials.  But no fuel cost to launch. Unlocks future Zero G Technology and scraps all existing ship components.";
        ResolutionTime = 3;
        MegaCredits = 10;
        Science = 6;
        Engineering = 6;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.MaterialsFixedModifier += 2;
        currentShip.CrewCapacity = 0;
        currentShip.Fuel = 0;
        currentShip.Mass = 0;
        currentShip.Modules = new Dictionary<string, System.Tuple<string, int, int>>();
        currentShip.Oxygen = 0;
        currentShip.OxygenProduction = currentShip.TotalCrew * -1;
        currentShip.Power = 0;
        currentShip.PowerProduction = 0;
        currentShip.SuppliesProduction = currentShip.TotalCrew * -1;
        currentShip.Supplies = 0;
        currentShip.Thrust = 0;


        gameState.HasZeroGConstruction = true;
        for (int i = 0; i < gameState.ShipConstructionProjects.Count; i++)
        {
            gameState.ShipConstructionProjects[i].InProgress = false;
            gameState.ShipConstructionProjects[i].Completed = false;
            gameState.ShipConstructionProjects[i].TimeRemaining = 0;
        }

        gameState.ResearchProjects.Add(CreateInstance<OrbitalLauncher>());
        gameState.ResearchProjects.Add(CreateInstance<UltraLightMaterials>());
        gameState.ResearchProjects.Add(CreateInstance<ConstructionDrones>());
        gameState.ResearchProjects.Add(CreateInstance<DoubleDensityAeroponics>());



    }
}
