using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState")]
public class GameState : ScriptableObject
{
    // Start is called before the first frame update
    public int RandomSeed = 20200419; 
    public int Month = 1;
    public decimal InfectionRate = .005m;
    public int MegaCredits = 60;
    public int MegaCreditProduction = 5;
    public int Science = 12;
    public int ScienceProduction = 1;
    public int Engineering = 12;
    public int EngineeringProduction = 1;
    public int Materials = 60;
    public int MaterialsProduction = 5;

    public bool GameOver = false;

    public string Destination = "Mars";
    public int TimeToDestination = 300;

    public List<CardBase> ResearchProjects = new List<CardBase>();
    public List<CardBase> ShipConstructionProjects = new List<CardBase>();
    internal decimal MassModifier;
    internal int ConstructiontimeModierFixed;

    public int MaterialsFixedModifier;
    public bool HasZeroGConstruction;
    public decimal InfectionRateDelta;
    internal bool HasDoubleDensityAeroponics;
    internal bool VirusCured;
    internal bool Launched;
}
