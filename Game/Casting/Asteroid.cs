namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Asteroid : Actor
    {
        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Asteroid(Body body, Image image, bool debug) : base(debug, body)
        {
            this.body = body;
            this.image = image;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Image GetImage()
        {
            return image;
        }        
    }
}