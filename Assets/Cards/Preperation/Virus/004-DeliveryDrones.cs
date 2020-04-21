using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryDrones : CardBase
{
    public override string Id => "VIRUS-004";

    // Start is called before the first frame update
    public DeliveryDrones()
    {
        CardName = "Delivery Drones";
        Description = "Slows growth of infection by 10%";
        ResolutionTime = 1;
        MegaCredits = 8;
        Science = 3;
        Engineering = 3;
        Materials = 8;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .10m;
        if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-003" && x.Completed))
        {
            if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-002" && x.Completed))
            {
                if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-005" && x.Completed))
                {
                    if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-006" && x.Completed))
                    {
                        if (gameState.ResearchProjects.All(x => x.Id != "VIRUS-007"))
                        {
                            gameState.ResearchProjects.Add(CreateInstance<VaccineBreakthrough>());
                        }
                    }
                }
            }
        }
    }
}
