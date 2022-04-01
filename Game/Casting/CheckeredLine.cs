namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class CheckeredLine : Actor
    {
        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public CheckeredLine(Body body, Image image, bool debug = false) : base(debug, body)
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
    }
}