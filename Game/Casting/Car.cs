namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Car : Actor
    {
        private Body body;
        private Animation animation;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Car(Body body, Animation animation, bool debug) : base(debug, body)
        {
            this.body = body;
            this.animation = animation;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return animation;
        }

        /// <summary>
        /// Moves the car to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            Point newPosition = position.Add(velocity);
            body.SetPosition(newPosition);
        }

        /// <summary>
        /// Swings the car to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = new Point(-Constants.CAR_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the car to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.CAR_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the car from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            body.SetVelocity(velocity);
        }
        
    }
}