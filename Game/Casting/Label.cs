namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A label to be displayed.
    /// </summary>
    public class Label : Actor
    {
        private Text text;
        private Point position;
        private static Point point = new Point(0, 0);
        private static Body body = new Body(point, point, point);

        /// <summary>
        /// Constructs a new instance of Label.
        /// </summary>
        public Label(Text text, Point position) : base(false, body)
        {
            this.text = text;
            this.position = position;
        }

        /// <summary>
        /// Gets the label's text.
        /// </summary>
        /// <returns>The text.</returns>
        public Text GetText()
        {
            return text;
        }

        /// <summary>
        /// Gets the label's position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return position;
        }
    }
}