using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorporatePod : CardBase
{
    // Start is called before the first frame update
    public override string Id => "CORP-010";

    public CorporatePod()
    {
        CardName = "Corporate Pod";
        Description = "A corporation wants to add Corporate Habit Module to ship which houses 10 Corporate Crew.  +50 Mega Credits and +50 Materials";
        ResolutionTime = 1;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        currentShip.CrewCorporate += 10;
        currentShip.CrewCapacity += 10;
        currentShip.Mass = 60;
        currentShip.OxygenProduction-=10;
        currentShip.SuppliesProduction-=10;
        currentShip.PowerProduction -= 5;
        gameState.MegaCredits += 50;
        gameState.Materials += 50;
    }
}
