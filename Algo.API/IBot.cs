using System;

namespace Algo.API
{
    public interface IBot
    {
        /// <summary>
        /// Returns the name of the bot to be displayed on the leaderboard.
        /// </summary>
        string GetName();

        /// <summary>
        /// Called every game tick to determine the bot's next action.
        /// </summary>
        /// <param name="context">A read-only snapshot of the current game state.</param>
        /// <returns>The action the bot wants to take.</returns>
        BotAction Update(IGameContext context);
    }
}
