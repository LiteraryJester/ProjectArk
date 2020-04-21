using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearProplusion : CardBase
{
    public override string Id => "PROP-001";

    // Start is called before the first frame update
    public NuclearProplusion()
    {
        CardName = "Nuclear Proplusion";
        Description = "Thrust 1.2";
        ResolutionTime = 3;
        Science = 2;
        Engineering = 2;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ShipConstructionProjects.Add(CreateInstance<Assets.Cards.Preperation.ShipComponents.NuclearEngine>());

    }
}
