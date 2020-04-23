using Assets.GameEntities.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeperationLogic : MonoBehaviour
{
    public GameObject ProjectListContainer;
    public GameObject BuildListContainer;
    public GameObject ModuleListContainer;

    public GameObject ProjectPrefab;
    public GameObject ModuleLinePrefab;


    public Button EndMonthButton;
    public Button LaunchButton;

    public Button ResearchButton;
    public Button BuildButton;

    public TextMeshProUGUI ViableLabel;

    public Button VirusWinRestartButton;
    public Button VirusWinQuitButton;
    public Button VirusLoseRestartButton;
    public Button VirusLoseQuitButton;
    public Button LaunchWinRestartButton;
    public Button LaunchLoseQuitButton;

    public GameObject VirusWinDialog;
    public GameObject VirusLoseDialog;
    public GameObject LaunchWinDialog;

    public Scrollbar ContentScroller;
    public GameState State;
    public Ship CurrentShip;

    public List<CardBase> ResearchProjects = new List<CardBase>();
    public List<CardBase> ShipConstructionProjects = new List<CardBase>();

    // Start is called before the first frame update
    void Start()
    {
        var initGame = new InitializeNewGame();
        initGame.Init(State, CurrentShip, ResearchProjects, ShipConstructionProjects);

        EndMonthButton.onClick.AddListener(ResolveTurn);
        LaunchButton.onClick.AddListener(Launch);
        ResearchButton.onClick.AddListener(SwitchToResearchTab);
        BuildButton.onClick.AddListener(SwitchToBuildTab);

        VirusWinRestartButton.onClick.AddListener(Restart);
        VirusWinQuitButton.onClick.AddListener(QuitGame);
        VirusLoseRestartButton.onClick.AddListener(Restart);
        VirusLoseQuitButton.onClick.AddListener(QuitGame);
        LaunchWinRestartButton.onClick.AddListener(Restart);
        LaunchLoseQuitButton.onClick.AddListener(QuitGame);

        UpdateDisplay();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void SwitchToResearchTab()
    {
        ProjectListContainer.SetActive(true);
        BuildListContainer.SetActive(false);
        ContentScroller.value = 1;
    }
    private void SwitchToBuildTab()
    {
        ProjectListContainer.SetActive(false);
        BuildListContainer.SetActive(true);
        ContentScroller.value = 1;
    }

    private void Launch()
    {
        LaunchWinDialog.SetActive(true);
    }

   


    private void HandleBuyProjectClick(Button buyButton, CardBase project, int cardType)
    {
        if (project.InProgress && project.Limit != -1)
            return;
        if (State.MegaCredits < project.MegaCredits)
            return;
        if (State.Science < project.Science)
            return;
        if (State.Engineering < project.Engineering)
            return;
        if (State.Materials < project.GetMaterialCost(State))
            return;

        project.InProgress = true;
        State.MegaCredits -= project.MegaCredits;
        State.Science -= project.Science;
        State.Engineering -= project.Engineering;
        State.Materials -= (project.Materials + State.MaterialsFixedModifier);
        project.TimeRemaining += project.GetResolutionTimeValue(State);

        if (cardType == 2)
        {
            CurrentShip.AddModule(project.Id, project.CardName);
        }
        else
        {
            buyButton.gameObject.SetActive(false);
        }
        if (project.Limit == -1 && cardType == 2)
        {
            // ShipConstructionProjects.Add(ScriptableObject.CreateInstance(project.GetType()) as CardBase);
        }
        UpdateDisplay();
    }

    private void ResolveTurn()
    {
        State.Month++;
        
        State.MegaCredits += State.MegaCreditProduction;
        State.Engineering += State.EngineeringProduction;
        State.Science += State.ScienceProduction;
        State.Materials += State.MaterialsProduction;

        for (int i = 0; i < ResearchProjects.Count; i++)
        {
            var project = ResearchProjects[i];
            if (project.InProgress)
            {
                project.TimeRemaining--;
                if (project.TimeRemaining == 0)
                {
                    project.Completed = true;
                    project.InProgress = false;
                    project.Resolve(State, CurrentShip);
                }
            }
        }

        for (int i = 0; i < ShipConstructionProjects.Count; i++)
        {
            var project = ShipConstructionProjects[i];
            if (project.InProgress)
            {
                project.TimeRemaining--;
                if (project.TimeRemaining % project.GetResolutionTimeValue(State) == 0)
                {
                    project.Resolve(State, CurrentShip);
                }
                if (project.TimeRemaining == 0)
                {
                    project.Completed = true;
                    project.InProgress = false;
                }
            }
        }
        if (CurrentShip.Thrust > 0)
        {
            State.TimeToDestination = (int)Math.Ceiling(250 / (CurrentShip.Thrust + CurrentShip.SolarThrust));
            if (State.HasZeroGConstruction)
            {
                CurrentShip.FuelRequiredForLaunch = 0;
            }
            else
            {
                CurrentShip.FuelRequiredForLaunch = (int)Math.Ceiling(CurrentShip.Mass * (20m / CurrentShip.Thrust));

            }
            CurrentShip.FuelRequiredForJourney = (int)Math.Ceiling(CurrentShip.Mass * (7m / (CurrentShip.Thrust + CurrentShip.SolarThrust)));

        }
       else if(CurrentShip.SolarThrust >0)
        {
            State.TimeToDestination = (int)Math.Ceiling(250 /  CurrentShip.SolarThrust);
            CurrentShip.FuelRequiredForLaunch = 0;
            CurrentShip.FuelRequiredForJourney = 0;
        }
        else
        {
            State.TimeToDestination = 0;
            CurrentShip.FuelRequiredForLaunch = 0;
            CurrentShip.FuelRequiredForJourney = 0;
        }
        UpdateDisplay();

        if (State.InfectionRateDelta <= -1)
        {
            VirusWinDialog.SetActive(true);
            State.VirusCured = true;
        }
        else
        {
            System.Random random = new System.Random(State.RandomSeed);
            int min = (int)(((.05m * (1m + State.InfectionRateDelta)) + 1m) * 100m);
            int max = (int)(((.20m * (1m + State.InfectionRateDelta)) + 1m) * 100m);
            var infectionDelta = random.Next(min, max) / 100m;
            State.InfectionRate *= infectionDelta;
            State.InfectionRate = Math.Min(1, State.InfectionRate);

            if (State.InfectionRate >= 1)
            {
                VirusLoseDialog.SetActive(true);

                State.GameOver = true;
            }
        }

        CheckShipViability();
    }

    private void CheckShipViability()
    {
        var viable = true;
        if (CurrentShip.Thrust == 0 && CurrentShip.SolarThrust == 0)
        {
            viable = false;
        }
        var crew = CurrentShip.TotalCrew;
        if (crew > CurrentShip.CrewCapacity)
        {
            viable = false;
        }

        if (CurrentShip.PowerProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.PowerProduction * -1;
            if (CurrentShip.Power < daysRemaining)
            {
                viable = false;
            }
        }

        if (CurrentShip.OxygenProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.OxygenProduction * -1;
            if (CurrentShip.Oxygen < daysRemaining)
            {
                viable = false;
            }
        }

        if (CurrentShip.SuppliesProduction < 0)
        {
            var daysRemaining = State.TimeToDestination * CurrentShip.SuppliesProduction * -1;
            if (CurrentShip.Supplies < daysRemaining)
            {
                viable = false;
            }
        }

        if (State.HasZeroGConstruction)
        {
            if (CurrentShip.FuelRequiredForJourney > CurrentShip.Fuel)
            {
                viable = false;
            }
        }
        else
        {
            if ((CurrentShip.FuelRequiredForJourney + CurrentShip.FuelRequiredForLaunch) > CurrentShip.Fuel)
            {
                viable = false;
            }
        }

        if (viable)
        {
            ViableLabel.gameObject.SetActive(false);
            LaunchButton.interactable = true;
        }
        else
        {
            ViableLabel.gameObject.SetActive(true);
            LaunchButton.interactable = false;
        }

    }

    private void UpdateDisplay()
    {
        var count = 0;
        var existingProject = ProjectListContainer.GetComponentsInChildren<ProjectDisplay>();
        //  for(int i=0;i<existingProject.Length;i++)
        //  {
        //       Destroy(existingProject[i]);
        //  }

        //  for(int i=0; i< ResearchProjects.Count; i++)
        foreach (var project in ResearchProjects)
        {
            GameObject projectUI;

            var match = existingProject.FirstOrDefault(x => x.Card == project);
            if (match == null)
            {
                projectUI = Instantiate(ProjectPrefab) as GameObject;
                projectUI.GetComponent<ProjectDisplay>().Card = project;
            }
            else
            {
                projectUI = match.gameObject;
                projectUI.GetComponent<ProjectDisplay>().UpdateDisplay(State);
            }


            if (project.Completed)
            {
                projectUI.SetActive(false);
                continue;
            }
            var transform = (RectTransform)projectUI.transform;
            transform.SetParent(ProjectListContainer.transform);


            transform.localScale = Vector3.one;
            transform.anchorMin = new Vector2(0, 1);
            transform.anchorMax = new Vector2(1, 1);
         //   transform.anchoredPosition = new Vector2(0, (128 * count + 64) * -1);
            transform.sizeDelta = new Vector2(0, 128);
            // transform.localPosition = new Vector3(0, -64 * count, 0);



            //var buyButton = projectUI.GetComponents<Button>()[0];
            var buyButton = projectUI.GetComponentInChildren<Button>();
            if (buyButton != null)
            {
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(() => HandleBuyProjectClick(buyButton, project, 1));
                //    buyButton.GetComponent<TextMeshProUGUI>().text = "Build";

                if (project.InProgress)
                    buyButton.gameObject.SetActive(false);
                else
                    buyButton.gameObject.SetActive(true);


                if (State.MegaCredits < project.MegaCredits)
                    buyButton.interactable = false;
                else if (State.Science < project.Science)
                    buyButton.interactable = false;
                else if (State.Engineering < project.Engineering)
                    buyButton.interactable = false;
                else if (State.Materials < project.GetMaterialCost(State))
                    buyButton.interactable = false;
                else
                    buyButton.interactable = true;
            }
            count++;

        }


        count = 0;
        existingProject = BuildListContainer.GetComponentsInChildren<ProjectDisplay>();
        //  for(int i=0;i<existingProject.Length;i++)
        //  {
        //       Destroy(existingProject[i]);
        //  }

        //  for(int i=0; i< ResearchProjects.Count; i++)
        foreach (var project in ShipConstructionProjects)
        {
            GameObject projectUI;

            var match = existingProject.FirstOrDefault(x => x.Card == project);
            if (match == null)
            {
                projectUI = Instantiate(ProjectPrefab) as GameObject;
                projectUI.GetComponent<ProjectDisplay>().Card = project;
            }
            else
            {
                projectUI = match.gameObject;
                projectUI.GetComponent<ProjectDisplay>().UpdateDisplay(State);
            }

            if (project.Completed && project.Limit != -1)
            {
                projectUI.SetActive(false);
                continue;
            }
            var transform = (RectTransform)projectUI.transform;
            transform.SetParent(BuildListContainer.transform);


            transform.localScale = Vector3.one;
            transform.anchorMin = new Vector2(0, 1);
            transform.anchorMax = new Vector2(1, 1);
          //  transform.anchoredPosition = new Vector2(0, (128 * count + 64) * -1);
            transform.sizeDelta = new Vector2(0, 128);
            // transform.localPosition = new Vector3(0, -64 * count, 0);



            //var buyButton = projectUI.GetComponents<Button>()[0];
            var buyButton = projectUI.GetComponentInChildren<Button>();
            if (buyButton != null)
            {
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(() => HandleBuyProjectClick(buyButton, project, 2));

                if (project.InProgress && project.Limit != -1)
                    buyButton.gameObject.SetActive(false);
                else
                    buyButton.gameObject.SetActive(true);


                if (State.MegaCredits < project.MegaCredits)
                    buyButton.interactable = false;
                else if (State.Science < project.Science)
                    buyButton.interactable = false;
                else if (State.Engineering < project.Engineering)
                    buyButton.interactable = false;
                else if (State.Materials < project.GetMaterialCost(State))
                    buyButton.interactable = false;
                else
                    buyButton.interactable = true;
            }
            count++;

        }

        count = 0;
        var existingModules = ModuleListContainer.GetComponentsInChildren<ModuleLineDisplay>();

        foreach(var moduleUI in existingModules)
        {
            moduleUI.GetComponent<ModuleLineDisplay>().ModuleValue.text = "0";
            moduleUI.GetComponent<ModuleLineDisplay>().ModuleInProductionValue.text = "0";
        }

        foreach (var module in CurrentShip.Modules)
        {
            GameObject moduleUI;

            var match = existingModules.FirstOrDefault(x => x.Id == module.Key);
            if (match == null)
            {
                moduleUI = Instantiate(ModuleLinePrefab) as GameObject;
                moduleUI.GetComponent<ModuleLineDisplay>().Id = module.Key;
                moduleUI.GetComponent<ModuleLineDisplay>().Init(module.Value.Item1);
                moduleUI.GetComponent<ModuleLineDisplay>().ModuleName.text = module.Value.Item1;
            }
            else
            {
                moduleUI = match.gameObject;
            }
            moduleUI.GetComponent<ModuleLineDisplay>().ModuleName.text = module.Value.Item1;
            moduleUI.GetComponent<ModuleLineDisplay>().ModuleValue.text = module.Value.Item2.ToString();
            moduleUI.GetComponent<ModuleLineDisplay>().ModuleInProductionValue.text =( module.Value.Item3- module.Value.Item2).ToString();
            
            var transform = (RectTransform)moduleUI.transform;
            transform.SetParent(ModuleListContainer.transform);


            transform.localScale = Vector3.one;
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

}
