using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Cards.Preperation.ShipComponents
{
   public class AeroponicsBay : CardBase
    {

        public override string Id => "SHIP-004";
        public AeroponicsBay()
        {
            CardName = "Aeroponics Bay";
            Description = "Oxygen Production 10, Supplies Production 10, Power Consumption 2";
            CardType = 2;
            Mass = 50;
            Materials = 10;
            MegaCredits = 10;
            ResolutionTime = 1;
            Limit = -1;

        }

        public override void Resolve(GameState gameState, Ship currentShip)
        {
            currentShip.Mass += GetMassValue(gameState);
            currentShip.OxygenProduction += 10;
            currentShip.SuppliesProduction += 10;

            if(gameState.HasDoubleDensityAeroponics)
            {
                currentShip.OxygenProduction += 10;
                currentShip.SuppliesProduction += 10;
            }

            currentShip.PowerProduction -= 2;
            currentShip.CompleteModule(Id);

        }
    }
}
