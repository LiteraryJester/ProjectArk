using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class SmallHabitatModule : CardBase
    {

        public override string Id => "SHIP-001";
        public SmallHabitatModule()
        {
            CardName = "Small Habitat Module";
            Description = "Crew Capcity 4, Power Consumption 2";
            CardType = 2;
            Mass = 20;
            Materials = 10;
            MegaCredits = 10;
            ResolutionTime = 1;
            Limit = -1;
        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.AddMass(Mass, gameState.MassModifier);
            currentShip.CrewCapacity += 4;
            currentShip.PowerProduction -= 2;
            currentShip.CompleteModule(Id);

        }
    }
}
