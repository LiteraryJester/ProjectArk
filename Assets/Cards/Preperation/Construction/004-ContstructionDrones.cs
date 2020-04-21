using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionDrones : CardBase
{
    public override string Id => "CONS-004";

    // Start is called before the first frame update
    public ConstructionDrones()
    {
        CardName = "Construction Drones";
        Description = "Decreases construction time of ship parts by 1 month to a minium of 1";
        ResolutionTime = 3;
        MegaCredits = 5;
        Science = 2;
        Engineering = 2;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ConstructiontimeModierFixed -= 1;
        gameState.ResearchProjects.Add(CreateInstance<DeliveryDrones>());

    }
}
