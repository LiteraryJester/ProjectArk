using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class ConventionalEngine : CardBase
    {

        public override string Id => "SHIP-010";
        public ConventionalEngine()
        {
            CardName = "Conventional Engine";
            Description = "Thurst 1";
            CardType = 2;
            Mass = 20;
            Materials = 5;
            MegaCredits = 5;
            ResolutionTime = 3;
        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.Thrust = 1;
            currentShip.CompleteModule(Id);

        }
    }
}
