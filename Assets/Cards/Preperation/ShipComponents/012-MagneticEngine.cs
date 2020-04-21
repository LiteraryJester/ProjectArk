using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class MagneticEngine : CardBase
    {

        public override string Id => "SHIP-012";
        public MagneticEngine()
        {
            CardName = "Magnetic Engine";
            Description = "Thurst 1.7";
            CardType = 2;
            Mass = 50;

            Materials = 20;
            MegaCredits = 20;
            ResolutionTime = 6;
        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.Thrust =1.7m;
            currentShip.CompleteModule(Id);

        }
    }
}
