using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class AntimatterEngine : CardBase
    {

        public override string Id => "SHIP-013";
        public AntimatterEngine()
        {
            CardName = "Antimatter Engine";
            Description = "Thurst 5.5";
            CardType = 2;
            Mass = 20;
            Materials = 50;
            MegaCredits = 50;
            ResolutionTime = 12;
        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.Thrust = 5.5m;
            currentShip.CompleteModule(Id);

        }
    }
}
