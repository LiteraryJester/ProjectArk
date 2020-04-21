using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinningContract : CardBase
{
    // Start is called before the first frame update
    public override string Id => "CORP-004";

    public MinningContract()
    {
        CardName = "MinningContract";
        Description = "+2 Materials per Month, -1 Mega Credits per Month";
        ResolutionTime = 1;
        MegaCredits = 2;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.MaterialsProduction += 2;
        gameState.MegaCreditProduction -= 1;
    }
}
