using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class Battery : CardBase
    {

        public override string Id => "SHIP-006";
        public Battery()
        {
            CardName = "Battery";
            Description = "Power Capacity 1000";
            CardType = 2;
            Mass = 2;

            Materials = 1;
            MegaCredits = 1;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.Power +=100;
            currentShip.CompleteModule(Id);

        }
    }
}
