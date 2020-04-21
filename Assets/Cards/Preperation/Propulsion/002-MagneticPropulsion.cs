using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPropulsion : CardBase
{

    public override string Id => "PROP-002";

    // Start is called before the first frame update
    public MagneticPropulsion()
    {
        CardName = "Magnetic Propulsion";
        Description = "Thrust 1.7";
        ResolutionTime = 6;
        Science = 4;
        Engineering = 4;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ResearchProjects.Add(CreateInstance<SolarSails>());
        gameState.ShipConstructionProjects.Add(CreateInstance<Assets.Cards.Preperation.ShipComponents.MagneticEngine>());

    }
}
