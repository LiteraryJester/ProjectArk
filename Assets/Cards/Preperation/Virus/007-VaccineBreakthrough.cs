using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineBreakthrough : CardBase
{
    public override string Id => "VIRUS-007";

    // Start is called before the first frame update
    public VaccineBreakthrough()
    {
        CardName = "Vaccine Breakthrough";
        Description = "Slows growth of infection by 50%";
        ResolutionTime = 12;
        MegaCredits = 30;
        Science = 12;
        Engineering = 12;
        Materials = 30;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .5m;
    }
}
