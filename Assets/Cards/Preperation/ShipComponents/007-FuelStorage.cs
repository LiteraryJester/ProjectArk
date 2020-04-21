using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class FuelStorage : CardBase
    {

        public override string Id => "SHIP-007";
        public FuelStorage()
        {
            CardName = "Fuel Storage";
            Description = "Fuel Capacity 100";
            CardType = 2;
            Mass = 2;

            Materials = 1;
            MegaCredits = 1;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.Fuel += 100;
            currentShip.CompleteModule(Id);

        }
    }
}
