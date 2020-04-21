using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSails : CardBase
{
    public override string Id => "PROP-003";

    // Start is called before the first frame update
    public SolarSails()
    {
        CardName = "Solar Sails";
        Description = "+2 Solar Thrust requires no fuel, Doesn't aid launch";
        ResolutionTime = 6;
        Science = 4;
        Engineering = 4;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ShipConstructionProjects.Add(CreateInstance<Assets.Cards.Preperation.ShipComponents.SolarSail>());
    }
}
