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
        public Background(Body body, Image image, bool debug = false) : base(debug, body)
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

        public int GetRoadLeft()
        {
            Point position = body.GetPosition();
            int xLeft = position.GetX();

            int roadLeft = xLeft + Constants.ROAD_LEFT;

            return roadLeft;
        }

        public int GetRoadRight()
        {
            Point position = body.GetPosition();
            int xLeft = position.GetX();

            int xRight = xLeft + Constants.BACKGROUND_WIDTH;
            int roadRight = xRight - Constants.ROAD_RIGHT;

            return roadRight;
        }
    }
}