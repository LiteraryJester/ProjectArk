using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState")]
public class GameState : ScriptableObject
{
    // Start is called before the first frame update
    public int RandomSeed { get; set; }
    public int Month { get; set; }
    public decimal InfectionRate { get; set; }
    public int MegaCredits { get; set; }
    public int MegaCreditProduction { get; set; }
    public int Science { get; set; }
    public int ScienceProduction { get; set; }
    public int Engineering { get; set; }
    public int EngineeringProduction { get; set; }
    public int Materials { get; set; }
    public int MaterialsProduction { get; set; }

    public bool GameOver { get; set; }

    public string Destination { get; set; }
    public int TimeToDestination { get; set; }

    public List<CardBase> ResearchProjects { get; set; }
    public List<CardBase> ShipConstructionProjects { get; set; }
    internal decimal MassModifier { get; set; }
    internal int ConstructiontimeModierFixed { get; set; }

    public int MaterialsFixedModifier { get; set; }
    public bool HasZeroGConstruction { get; set; }
    public decimal InfectionRateDelta { get; set; }
    internal bool HasDoubleDensityAeroponics { get; set; }
    internal bool VirusCured { get; set; }
    internal bool Launched { get; set; }

    public void Init()
    {
        RandomSeed = 20200419;
        Month = 1;
        InfectionRate = .005m;
        MegaCredits = 60;
        MegaCreditProduction = 5;
        Science = 12;
        ScienceProduction = 1;
        Engineering = 12;
        EngineeringProduction = 1;
        Materials = 60;
        MaterialsProduction = 5;

        GameOver = false;

        Destination = "Mars";
        TimeToDestination = 0;

        ResearchProjects = new List<CardBase>();
        ShipConstructionProjects = new List<CardBase>();
        MassModifier = 0;
        ConstructiontimeModierFixed = 0;

        MaterialsFixedModifier = 0;
        HasZeroGConstruction = false;
        InfectionRateDelta = 0;
        HasDoubleDensityAeroponics = false;
        VirusCured = false;
        Launched = false;
    }
}
