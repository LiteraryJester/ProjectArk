using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Card")]
public class CardBase : ScriptableObject
{
    public string CardName;
    public string Description;
    public int CardType = 1;

    public Sprite Image;
    
    public int ResolutionTime;
    public int TimeRemaining;

    public int MegaCredits;
    public int Science;
    public int Engineering;
    public int Populartity;
    public int Materials;

    public bool InProgress;
    public bool Completed;
    public int Limit=1;
    public int Mass;

    public virtual string Id { get; private set; }
    public bool Created { get; internal set; }

    public virtual void Resolve(GameState gameState, Ship currentShip) { }
}