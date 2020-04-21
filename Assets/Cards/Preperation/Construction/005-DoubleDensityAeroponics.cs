using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDensityAeroponics : CardBase
{
    public override string Id => "CONS-004";

    // Start is called before the first frame update
    public DoubleDensityAeroponics()
    {
        CardName = "Double Density Aeroponics";
        Description = "Doubles out of Aeroponics Bays";
        ResolutionTime = 4;
        MegaCredits = 5;
        Science = 4;
        Engineering = 4;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        if (currentShip.Modules.ContainsKey("SHIP-004"))
        {
            var unitCount = currentShip.Modules["SHIP-004"].Item2;
            currentShip.OxygenProduction += (unitCount * 10);
            currentShip.SuppliesProduction += (unitCount * 10);
        }
        gameState.HasDoubleDensityAeroponics = true;

        gameState.ResearchProjects.Add(CreateInstance<HomeAeroponicsUnits>());

    }
}
