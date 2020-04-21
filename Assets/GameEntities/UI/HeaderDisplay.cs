using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderDisplay : MonoBehaviour
{
    public GameState State;
    public TextMeshProUGUI MegaCredits;
    public TextMeshProUGUI Science;
    public TextMeshProUGUI Engineering;
    public TextMeshProUGUI Materials;
    public TextMeshProUGUI InfectionRate;
    public TextMeshProUGUI Month;



    // Start is called before the first frame update
    void Start()
    {
    
}

    // Update is called once per frame
    void Update()
    {
        MegaCredits.text = State.MegaCredits.ToString();
        Science.text = State.Science.ToString();
        Engineering.text = State.Engineering.ToString();
        Materials.text = State.Materials.ToString();
        InfectionRate.text = State.InfectionRate.ToString("#0.00%");
        Month.text = State.Month.ToString();
    }
}
