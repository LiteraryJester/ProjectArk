using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipInfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI Mass ;
    public TextMeshProUGUI Thrust;
    public TextMeshProUGUI Fuel ;
    public TextMeshProUGUI FuelRequiedForLaunch;
    public TextMeshProUGUI FuelRequiredForJourney;


    public TextMeshProUGUI Oxygen ;

    public TextMeshProUGUI OxygenProduction ;
    public TextMeshProUGUI Supplies ;
    public TextMeshProUGUI SuppliesProduction ;
    public TextMeshProUGUI Power ;
    public TextMeshProUGUI PowerProduction ;
    public TextMeshProUGUI PrefabStrucutres ;
    public TextMeshProUGUI CrewCapacity ;
    public TextMeshProUGUI CrewVip ;
    public TextMeshProUGUI CrewCorporate ;
    public TextMeshProUGUI CrewScientists ;
    public TextMeshProUGUI CrewEngineers ;
    public TextMeshProUGUI CrewCivilian ;

    public TextMeshProUGUI Destination;
    public TextMeshProUGUI TimeToDestination;


    public Ship CurrentShip;
    public GameState State;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destination.text = State.Destination;
        TimeToDestination.text = $"{State.TimeToDestination} Days"; 
        Mass.text = CurrentShip.Mass.ToString();
        Thrust.text = (CurrentShip.Thrust + CurrentShip.SolarThrust).ToString();
        Fuel.text = CurrentShip.Fuel.ToString();
        FuelRequiedForLaunch.text = CurrentShip.FuelRequiredForLaunch.ToString();
        FuelRequiredForJourney.text = CurrentShip.FuelRequiredForJourney.ToString();
        OxygenProduction.text = CurrentShip.OxygenProduction.ToString();
        SuppliesProduction.text = CurrentShip.SuppliesProduction.ToString();
       
        PowerProduction.text = CurrentShip.PowerProduction.ToString();
        PrefabStrucutres.text = CurrentShip.PrefabStrucutres.ToString();
        CrewCapacity.text = $"{CurrentShip.TotalCrew } / {CurrentShip.CrewCapacity}";
        CrewVip.text = CurrentShip.CrewVip.ToString();
        CrewCorporate.text = CurrentShip.CrewCorporate.ToString();
        CrewScientists.text = CurrentShip.CrewScientists.ToString();
        CrewEngineers.text = CurrentShip.CrewEngineers.ToString();
        CrewCivilian.text = CurrentShip.CrewCivilian.ToString();


        var text = CurrentShip.Power.ToString();
        if (CurrentShip.PowerProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.PowerProduction * -1;
            text = $"{CurrentShip.Power} / {daysRemaining}";
        }
        Power.text = text;

        text = CurrentShip.Oxygen.ToString();
        if (CurrentShip.OxygenProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.OxygenProduction * -1;
            text = $"{CurrentShip.Oxygen} / {daysRemaining}";
        }

        Oxygen.text = text;

        text = CurrentShip.Supplies.ToString();

        if (CurrentShip.SuppliesProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.SuppliesProduction * -1;
            text = $"{CurrentShip.Supplies} / {daysRemaining}";
        }
        Supplies.text = text;

    }
}
