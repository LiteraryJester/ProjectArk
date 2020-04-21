using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class FuelMediumStorage : CardBase
    {

        public override string Id => "SHIP-015";
        public FuelMediumStorage()
        {
            CardName = "Medium Fuel Storage";
            Description = "Fuel Capacity 400";
            CardType = 2;
            Materials = 4;
            Mass = 8;

            MegaCredits = 4;
            ResolutionTime = 2;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.Fuel += 400;
            currentShip.CompleteModule(Id);
        }
    }
}
