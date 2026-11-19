using System.Collections.Generic;

namespace Algo.API
{
    public interface IGameContext
    {
        /// <summary>
        /// Gets the bot's current X position.
        /// </summary>
        float GetMyX();

        /// <summary>
        /// Gets the bot's current Y position.
        /// </summary>
        float GetMyY();

        /// <summary>
        /// Gets the bot's current mass (score).
        /// </summary>
        float GetMyMass();

        /// <summary>
        /// Gets all food entities within the specified radius.
        /// Accounts for map wrap-around.
        /// </summary>
        IEnumerable<EntityInfo> GetFoodInRange(float radius);

        /// <summary>
        /// Gets all opponent bots within the specified radius.
        /// Accounts for map wrap-around.
        /// </summary>
        IEnumerable<EntityInfo> GetOpponentsInRange(float radius);

        /// <summary>
        /// Returns the maximum distance your bot can see (currently 500 units).
        /// Use this instead of guessing numbers!
        /// </summary>
        float GetSightRadius();

        /// <summary>
        /// Calculates the true distance from your bot to the target (accounts for map wrapping).
        /// </summary>
        float GetDistanceTo(EntityInfo target);

        /// <summary>
        /// Returns a steering direction pointing exactly at the target.
        /// </summary>
        Algo.API.Vector2 GetDirectionTo(EntityInfo target);

        /// <summary>
        /// Pass in a list of scary giants, and this returns the single safest steering direction to run away from all of them!
        /// </summary>
        Algo.API.Vector2 GetEscapeDirection(IEnumerable<EntityInfo> threats);

        /// <summary>
        /// Evaluates a list of food and returns the single piece of food that is sitting inside the biggest cluster.
        /// </summary>
        EntityInfo? GetDensestFoodTarget(IEnumerable<EntityInfo> foodList, float clusterRadius = 50f);
    }
}
