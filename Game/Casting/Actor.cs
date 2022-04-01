namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Actor
    {
        private bool debug;
        private Body body;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Actor(bool debug, Body body)
        {
            this.debug = debug;
            this.body = body;
        }

        /// <summary>
        /// Whether or not the actor is being debugged.
        /// </summary>
        /// <returns>True if being debugged; false if othewise.</returns>
        public bool IsDebug()
        {
            return debug;
        }

        public Body GetBody()
        {
            return body;
        }
    }
}