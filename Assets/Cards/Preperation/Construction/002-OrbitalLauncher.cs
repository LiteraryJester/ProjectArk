using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLauncher : CardBase
{
    public override string Id => "CONS-002";

    // Start is called before the first frame update
    public OrbitalLauncher()
    {
        CardName = "Orbital Launcher";
        Description = "Removes the 2 Meterials cost added by Zero G construction.";
        ResolutionTime = 3;
        MegaCredits = 10;
        Science = 6;
        Engineering = 6;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.MaterialsFixedModifier -= 2;
    }
}
