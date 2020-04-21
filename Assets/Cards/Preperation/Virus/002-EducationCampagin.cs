using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EducationCampagin : CardBase
{
    public override string Id => "VIRUS-002";

    // Start is called before the first frame update
    public EducationCampagin()
    {
        CardName = "Education Campagin";
        Description = "Slows growth of infection by 20%";
        ResolutionTime = 3;
        MegaCredits = 10;
        Materials = 10;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .2m;

        if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-003" && x.Completed))
        {
            if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-004" && x.Completed))
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
