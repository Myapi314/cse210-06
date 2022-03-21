namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Background : Actor
    {
        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Background(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }
    }
}