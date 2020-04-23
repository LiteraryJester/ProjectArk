using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class SolarSail : CardBase
    {

        public override string Id => "SHIP-016";
        public SolarSail()
        {
            CardName = "Solar Sail";
            Description = "Solar Thrust +2";
            CardType = 2;
            Mass = 2;

            Materials = 10;
            MegaCredits = 10;
            ResolutionTime = 3;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.SolarThrust +=2m;

            currentShip.CompleteModule(Id);

        }
    }
}
