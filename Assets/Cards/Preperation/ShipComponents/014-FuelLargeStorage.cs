using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class FuelLargeStorage : CardBase
    {

        public override string Id => "SHIP-014";
        public FuelLargeStorage()
        {
            CardName = "Large Fuel Storage";
            Description = "Fuel Capacity 1000";
            CardType = 2;
            Mass = 20;

            Materials = 10;
            MegaCredits = 10;
            ResolutionTime = 3;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.Fuel += 1000;
            currentShip.CompleteModule(Id);

        }
    }
}
