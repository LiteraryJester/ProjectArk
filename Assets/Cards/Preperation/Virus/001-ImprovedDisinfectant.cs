using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedDisinfectant : CardBase
{
    public override string Id => "VIRUS-001";

    // Start is called before the first frame update
    public ImprovedDisinfectant()
    {
        CardName = "Improved Disinfectant";
        Description = "Slows growth of infection by 5%";
        ResolutionTime = 1;
        MegaCredits = 1;
        Science = 3;
        Engineering = 0;
    }

    public override void Resolve(GameState gameState, Ship currentShip)
    {
        Completed = true;
        gameState.InfectionRateDelta -= .05m;
        gameState.ResearchProjects.Add(CreateInstance<EducationCampagin>());
        gameState.ResearchProjects.Add(CreateInstance<CheapTestingKits>());


    }
}
