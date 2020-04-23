using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class MediumHabitatModule : CardBase
    {

        public override string Id => "SHIP-002";
        public MediumHabitatModule()
        {
            CardName = "Medium Habitat Module";
            Description = "Crew Capcity 10, Power Consumption 5";
            CardType = 2;
            Mass = 50;

            Materials = 20;
            MegaCredits = 20;
            ResolutionTime = 3;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.CrewCapacity += 10;
            currentShip.PowerProduction -= 5;
            currentShip.CompleteModule(Id);

        }
    }
}
