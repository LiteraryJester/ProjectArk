using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class OxygenStorage : CardBase
    {

        public override string Id => "SHIP-009";
        public OxygenStorage()
        {
            CardName = "Oxygen Storage";
            Description = "Oxygen Capacity 500";
            CardType = 2;
            Mass = 5;
            Materials = 1;
            MegaCredits = 1;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.Oxygen +=500;
            currentShip.CompleteModule(Id);

        }
    }
}
