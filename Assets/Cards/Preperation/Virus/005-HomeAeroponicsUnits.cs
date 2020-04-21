using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HomeAeroponicsUnits : CardBase
{
    public override string Id => "VIRUS-005";

    // Start is called before the first frame update
    public HomeAeroponicsUnits()
    {
        CardName = "Home Aeroponics Units";
        Description = "Slows growth of infection by 5%";
        ResolutionTime = 1;
        MegaCredits = 1;
        Science = 0;
        Engineering = 3;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .05m;
        if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-003" && x.Completed))
        {
            if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-004" && x.Completed))
            {
                if (gameState.ResearchProjects.Any(x => x.Id == "VIRUS-002" && x.Completed))
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
