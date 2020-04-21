using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ProjectDisplay : MonoBehaviour
{

    public CardBase Card;

    public TextMeshProUGUI CardName;
    public TextMeshProUGUI Description;

    public Sprite ScienceIcon;
    public Sprite EngineeringIcon;
    public Sprite MegaCreditIcon;
    public Sprite MaterialsIcon;

    public TextMeshProUGUI ResolutionTime;
    public TextMeshProUGUI Cost1Value;
    public Image Cost1Icon;

    public TextMeshProUGUI Cost2Value;
    public Image Cost2Icon;

    public TextMeshProUGUI Cost3Value;
    public Image Cost3Icon;

    public TextMeshProUGUI Cost4Value;
    public Image Cost4Icon;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay(null);
    }

    public void UpdateDisplay(GameState state)
    {
        if (Card != null)
        {
            CardName.text = Card.CardName;
            Description.text = Card.Description;
            if (Card.CardType == 2 && state != null)
            {
                var mass = Card.Mass;

                if ( state != null)
                {
                    mass = (int)Math.Floor(mass * (1 + state.MassModifier));
                }
                Description.text = $"Mass {mass}, {Card.Description}";
            }
            if (Card.InProgress)
            {
                ResolutionTime.text = Card.TimeRemaining.ToString();
            }
            else if( state == null)
            {
                ResolutionTime.text = Card.ResolutionTime.ToString();

            }
            else
            {
                ResolutionTime.text = (Card.ResolutionTime + state.ConstructiontimeModierFixed) .ToString();
            }

            var costUIElements = new List<Tuple<Image, TextMeshProUGUI>>
            {
                new Tuple<Image, TextMeshProUGUI>(Cost1Icon,Cost1Value),
                new Tuple<Image, TextMeshProUGUI>(Cost2Icon,Cost2Value),
                new Tuple<Image, TextMeshProUGUI>(Cost3Icon,Cost3Value),
                new Tuple<Image, TextMeshProUGUI>(Cost4Icon,Cost4Value),
            };

            if (Card.MegaCredits > 0)
            {

                var element = costUIElements[0];
                costUIElements.RemoveAt(0);
                SetCostUIElment(element.Item1, element.Item2, MegaCreditIcon, Card.MegaCredits.ToString());
            }
            if (Card.Materials > 0)
            {

                var element = costUIElements[0];
                costUIElements.RemoveAt(0);
                if (state == null)
                {
                    SetCostUIElment(element.Item1, element.Item2, MaterialsIcon, Card.Materials.ToString());
                }
                else
                {
                    SetCostUIElment(element.Item1, element.Item2, MaterialsIcon, (Card.Materials + state.MaterialsFixedModifier).ToString());
                }
            }
            if (Card.Science > 0)
            {
                var element = costUIElements[0];
                costUIElements.RemoveAt(0);
                SetCostUIElment(element.Item1, element.Item2, ScienceIcon, Card.Science.ToString());
            }

            if (Card.Engineering > 0)
            {

                var element = costUIElements[0];
                costUIElements.RemoveAt(0);
                SetCostUIElment(element.Item1, element.Item2, EngineeringIcon, Card.Engineering.ToString());
            }
        }
    }

    private void SetCostUIElment(Image image, TextMeshProUGUI text, Sprite sprite, string value)
    {
        image.enabled = true;
        image.sprite = sprite;
        text.enabled = true;
        text.text = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
