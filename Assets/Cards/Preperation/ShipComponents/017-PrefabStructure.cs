using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class PrefabStructure : CardBase
    {

        public override string Id => "SHIP-017";
        public PrefabStructure()
        {
            CardName = "Prefab Structure";
            Description = "Need 1 for every 10 colonists";
            CardType = 2;
            Mass = 5;

            Materials = 2;
            MegaCredits = 2;
            ResolutionTime = 2;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.PrefabStrucutres +=1;
            currentShip.CompleteModule(Id);

        }
    }
}
