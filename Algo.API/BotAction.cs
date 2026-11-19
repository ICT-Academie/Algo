namespace Algo.API
{
    public class BotAction
    {
        /// <summary>
        /// The direction the bot wants to move in.
        /// </summary>
        public Vector2 MoveDirection { get; set; }

        public BotAction(Vector2 moveDirection)
        {
            MoveDirection = moveDirection;
        }
    }
}
