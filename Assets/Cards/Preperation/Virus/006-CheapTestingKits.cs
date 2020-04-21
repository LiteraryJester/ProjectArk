using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheapTestingKits : CardBase
{
    public override string Id => "VIRUS-006";

    // Start is called before the first frame update
    public CheapTestingKits()
    {
        CardName = "Cheap Testing Kits";
        Description = "Slows growth of infection by 15%";
        ResolutionTime = 4;
        MegaCredits = 10;
        Science = 4;
        Engineering = 4;
        Materials = 10;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .15m;
        if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-003" && x.Completed))
        {
            if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-004" && x.Completed))
            {
                if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-005" && x.Completed))
                {
                    if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-002" && x.Completed))
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
