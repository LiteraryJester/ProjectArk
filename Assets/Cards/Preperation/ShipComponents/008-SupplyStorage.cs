using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class SupplyStorage : CardBase
    {

        public override string Id => "SHIP-008";
        public SupplyStorage()
        {
            CardName = "Supply Storage";
            Description = "Supply Capacity 500";
            CardType = 2;
            Mass = 5;
            Materials = 1;
            MegaCredits = 1;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.Supplies +=500;
            currentShip.CompleteModule(Id);

        }
    }
}
