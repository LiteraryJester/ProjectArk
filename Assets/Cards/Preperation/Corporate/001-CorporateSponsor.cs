using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorporateSponsor : CardBase
{
    public override string Id => "CORP-001";
    public CorporateSponsor()
    {
        CardName = "Corporate Sponsor";
        Description = "Increase Mega Credit production by 2 per month. Unlocks future Corporate Partnerships";
        ResolutionTime = 1;
        MegaCredits = 6;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {

        Completed = true;

        gameState.MegaCreditProduction += 2;
        gameState.ResearchProjects.Add(CreateInstance<GeniusCEO>());
        gameState.ResearchProjects.Add(CreateInstance<CorporateEngineering>());
        gameState.ResearchProjects.Add(CreateInstance<MinningContract>());
    }
}
