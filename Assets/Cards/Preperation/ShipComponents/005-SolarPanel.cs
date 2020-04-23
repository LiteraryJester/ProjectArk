using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class SolarPanel : CardBase
    {

        public override string Id => "SHIP-005";
        public SolarPanel()
        {
            CardName = "Solar Panel";
            Description = "Power Production 5";
            CardType = 2;
            Mass = 5;
            Materials = 5;
            MegaCredits = 5;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.PowerProduction += 5;
            currentShip.CompleteModule(Id);

        }
    }
}
