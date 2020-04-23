using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipInfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI Mass;
    public TextMeshProUGUI Thrust;
    public TextMeshProUGUI Fuel;
    public TextMeshProUGUI FuelRequiedForLaunch;
    public TextMeshProUGUI FuelRequiredForJourney;
    public TextMeshProUGUI FuelRequired;
    public TextMeshProUGUI FuelRequiredLabel;

    public TextMeshProUGUI Oxygen;
    public TextMeshProUGUI OxygenRequired;
    public TextMeshProUGUI OxygenRequiredLabel;



    public TextMeshProUGUI OxygenProduction;
    public TextMeshProUGUI Supplies;
    public TextMeshProUGUI SuppliesRequired;
    public TextMeshProUGUI SuppliesRequiredLabel;


    public TextMeshProUGUI SuppliesProduction;
    public TextMeshProUGUI Power;
    public TextMeshProUGUI PowerRequired;
    public TextMeshProUGUI PowerRequiredLabel;


    public TextMeshProUGUI PowerProduction;
    public TextMeshProUGUI PrefabStrucutres;
    public TextMeshProUGUI CrewCapacity;
    public TextMeshProUGUI CrewTotal;

    public TextMeshProUGUI CrewVip;
    public TextMeshProUGUI CrewCorporate;
    public TextMeshProUGUI CrewScientists;
    public TextMeshProUGUI CrewEngineers;
    public TextMeshProUGUI CrewCivilian;

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
        OxygenProduction.text = $"{CurrentShip.OxygenProduction} per day";
        SuppliesProduction.text = $"{CurrentShip.SuppliesProduction} per day"; 

        PowerProduction.text = $"{CurrentShip.PowerProduction} per day"; 
        PrefabStrucutres.text = CurrentShip.PrefabStrucutres.ToString();
        CrewTotal.text = CurrentShip.TotalCrew.ToString();
        CrewCapacity.text = CurrentShip.CrewCapacity.ToString();
        CrewVip.text = CurrentShip.CrewVip.ToString();
        CrewCorporate.text = CurrentShip.CrewCorporate.ToString();
        CrewScientists.text = CurrentShip.CrewScientists.ToString();
        CrewEngineers.text = CurrentShip.CrewEngineers.ToString();
        CrewCivilian.text = CurrentShip.CrewCivilian.ToString();

        var neededFuel = (CurrentShip.FuelRequiredForLaunch + CurrentShip.FuelRequiredForJourney - CurrentShip.Fuel);
        FuelRequired.text = neededFuel.ToString();
        if(neededFuel > 0)
        {
            FuelRequired.gameObject.SetActive(true);
            FuelRequiredLabel.gameObject.SetActive(true);
        }
        else
        {
            FuelRequired.gameObject.SetActive(false);
            FuelRequiredLabel.gameObject.SetActive(false);
        }

        Power.text = CurrentShip.Power.ToString();
        if (CurrentShip.PowerProduction < 0)
        {
            var required = State.TimeToDestination * CurrentShip.PowerProduction * -1;
            if (required > CurrentShip.Power)
            {
               PowerRequired.text = required.ToString();
                PowerRequired.gameObject.SetActive(true);
                PowerRequiredLabel.gameObject.SetActive(true);

            }
            else
            {
                PowerRequired.gameObject.SetActive(false);
                PowerRequiredLabel.gameObject.SetActive(true);


            }
        }
        else
        {
            PowerRequired.gameObject.SetActive(false);
            PowerRequiredLabel.gameObject.SetActive(false);


        }

        Oxygen.text = CurrentShip.Oxygen.ToString();
        if (CurrentShip.OxygenProduction < 0)
        {
            var required = State.TimeToDestination * CurrentShip.OxygenProduction * -1;
            if (required > CurrentShip.Oxygen)
            {
                OxygenRequired.text = required.ToString();
                OxygenRequired.gameObject.SetActive(true);
                OxygenRequiredLabel.gameObject.SetActive(true);

            }
            else
            {
                OxygenRequiredLabel.gameObject.SetActive(false);
                OxygenRequired.gameObject.SetActive(false);
            }
        }
        else
        {
                OxygenRequiredLabel.gameObject.SetActive(false);
            OxygenRequired.gameObject.SetActive(false);
        }

        Supplies.text = CurrentShip.Supplies.ToString();
        if (CurrentShip.SuppliesProduction < 0)
        {
            var required = State.TimeToDestination * CurrentShip.SuppliesProduction * -1;
            if (required > CurrentShip.Supplies)
            {
                SuppliesRequired.text = required.ToString();
                SuppliesRequired.gameObject.SetActive(true);
                SuppliesRequiredLabel.gameObject.SetActive(true);

            }
            else
            {
                SuppliesRequired.gameObject.SetActive(false);
                SuppliesRequiredLabel.gameObject.SetActive(false);


            }
        }
        else
        {
            SuppliesRequired.gameObject.SetActive(false);
            SuppliesRequiredLabel.gameObject.SetActive(false);

        }
    }
}
