using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntimatterPropolusion : CardBase
{
    public override string Id => "PROP-004";

    // Start is called before the first frame update
    public AntimatterPropolusion()
    {
        CardName = "Antimatter Propolusion";
        Description = "Thrust 5.5";
        ResolutionTime = 12;
        Science = 10;
        Engineering = 10;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ShipConstructionProjects.Add(CreateInstance<Assets.Cards.Preperation.ShipComponents.AntimatterEngine>());

    }
}
