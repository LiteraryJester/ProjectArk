using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeniusCEO : CardBase
{
    // Start is called before the first frame update
    public override string Id => "CORP-002";

    public GeniusCEO()
    {
        CardName = "Genius CEO";
        Description = "+1 Science per month.  +1 Corporate Crew";
        ResolutionTime = 1;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.ScienceProduction += 1;
        currentShip.AddCrewCorporate(1);
        if(gameState.ResearchProjects.Any(x=> x.Id == "CORP-003" && x.Completed) && gameState.ResearchProjects.All(x => x.Id != "CORP-010"))
        {
            gameState.ResearchProjects.Add(CreateInstance<CorporatePod>());
        }
    }
}
