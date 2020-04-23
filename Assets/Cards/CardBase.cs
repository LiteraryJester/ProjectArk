using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class CardBase : ScriptableObject
{
    public string CardName { get; set; }
    public string Description { get; set; }
    public int CardType { get; set; } = 1;

    public Sprite Image { get; set; }

    public int ResolutionTime { get; set; }
    public int TimeRemaining { get; set; }

    public int MegaCredits { get; set; }
    public int Science { get; set; }
    public int Engineering { get; set; }
    public int Populartity { get; set; }
    public int Materials { get; set; }

    public bool InProgress { get; set; }
    public bool Completed { get; set; }
    public int Limit { get; set; } = 1;
    public int Mass { get; set; }

    public virtual string Id { get; private set; }

    public virtual int GetMaterialCost(GameState state)
    {
        if (Materials == 0)
        {
            return 0;
        }
        if (state != null)
        {
            return Math.Max(1, Materials + state.MaterialsFixedModifier);
        }

        return Materials;
    }

    public virtual int GetMassValue(GameState state)
    {
        if (Mass == 0)
        {
            return 0;
        }
        if (state != null)
        {
            return (int)Math.Floor(Mass * (1 + state.MassModifier));
        }
        return Mass;
    }

    public virtual int GetResolutionTimeValue(GameState state)
    {
        if (ResolutionTime == 0)
        {
            return 0;
        }
        else if (CardType == 2 && state != null)
        {
            return Math.Max(1, ResolutionTime + state.ConstructiontimeModierFixed);
        }

        return ResolutionTime;
    }


    public virtual void Resolve(GameState gameState, Ship currentShip) { }
}