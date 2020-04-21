using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UltraLightRespirators : CardBase
{
    public override string Id => "VIRUS-003";

    // Start is called before the first frame update
    public UltraLightRespirators()
    {
        CardName = "Ultra Light Respirators";
        Description = "Slows growth of infection by 35%";
        ResolutionTime = 2;
        MegaCredits = 6;
        Science = 6;
        Engineering = 6;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .35m;
        if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-002" && x.Completed))
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
