using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraLightMaterials : CardBase
{
    public override string Id => "CONS-003";

    // Start is called before the first frame update
    public UltraLightMaterials()
    {
        CardName = "Ultra Light Materials";
        Description = "Decreases Weight of all future ship components by 10-50%.";
        ResolutionTime = 3;
        MegaCredits = 2;
        Science = 2;
        Engineering = 2;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.MaterialsFixedModifier += 2;
        gameState.MassModifier += .1m;
        gameState.ResearchProjects.Add(CreateInstance<UltraLightRespirators>());

    }
}
