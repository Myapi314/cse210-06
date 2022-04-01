namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Flag : Actor
    {
        private Body body;
        private Image image;
        private int mileMarker;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Flag(Body body, Image image, int mileMarker, bool debug = false) : base(debug, body)
        {
            this.body = body;
            this.image = image;
            this.mileMarker = mileMarker;
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
        /// Gets the points.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetMileMarker()
        {
            return mileMarker;
        }
        
        public void AddMile()
        {
            this.mileMarker += 1;
        }

        public void SetMileMarker(int mile)
        {
            this.mileMarker = mile;
        }
    }
}