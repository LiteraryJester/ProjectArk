using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class LargeHabitatModule : CardBase
    {

        public override string Id => "SHIP-003";
        public LargeHabitatModule()
        {
            CardName = "Large Habitat Module";
            Description = "Crew Capcity 25, Power Consumption 13";
            CardType = 2;
            Mass = 120;

            Materials = 40;
            MegaCredits = 40;
            ResolutionTime = 6;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.CrewCapacity += 25;
            currentShip.PowerProduction -= 13;
            currentShip.CompleteModule(Id);

        }
    }
}
