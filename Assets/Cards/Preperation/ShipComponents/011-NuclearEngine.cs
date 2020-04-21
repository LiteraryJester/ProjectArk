using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class NuclearEngine : CardBase
    {

        public override string Id => "SHIP-011";
        public NuclearEngine()
        {
            CardName = "Nuclear Engine";
            Description = "Thurst 1.2";
            CardType = 2;
            Mass = 20;

            Materials = 7;
            MegaCredits = 7;
            ResolutionTime = 6;
        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.Thrust =1.2m;
            currentShip.CompleteModule(Id);

        }
    }
}
