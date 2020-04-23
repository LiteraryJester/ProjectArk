using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorporateEngineering : CardBase
{
    // Start is called before the first frame update
    public override string Id => "CORP-003";

    public CorporateEngineering()
    {
        CardName = "Corporate Engineering";
        Description = "+1 Engineering per month.  +1 Corporate Crew";
        ResolutionTime = 1;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.EngineeringProduction += 1;
        currentShip.AddCrewCorporate(1);
        if (gameState.ResearchProjects.Any(x => x.Id == "CORP-002" && x.Completed) && gameState.ResearchProjects.All(x=>x.Id != "CORP-010"))
        {
            gameState.ResearchProjects.Add(CreateInstance<CorporatePod>());
        }
    }
}
