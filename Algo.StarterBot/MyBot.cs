using System;
using System.Linq;
using Algo.API;

namespace Algo.StarterBot
{
    public class MyBot : IBot
    {
        public string GetName()
        {
            return "Starter Bot"; // Verander dit naar je eigen naam of teamnaam!
        }

        public BotAction Update(IGameContext context)
        {
            float myX = context.GetMyX();
            float myY = context.GetMyY();
            float myMass = context.GetMyMass();
            float mySight = context.GetSightRadius(); // Hoe ver we kunnen kijken (500f)

            // Dit is een simpele Starter Bot. Hij doet maar één ding: zoeken naar eten (food).
            // Hij rent nog NIET weg voor grotere spelers en jaagt nog NIET op kleinere spelers.
            
            var food = context.GetFoodInRange(mySight);
            
            // Als we eten zien...
            if (food.Any())
            {
                // Pak het eerste stukje eten uit de lijst en loop erheen!
                return new BotAction(context.GetDirectionTo(food.First()));
            }

            // Als we helemaal niets zien, loop dan schuin naar rechtsonder
            return new BotAction(new Vector2(1, 1));
        }
    }
}
