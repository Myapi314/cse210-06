namespace MarioRacer.Game.Casting{
    public class Coin : Actor 
    {
        private Body body;
        private Animation animation;
        public Coin(Body body, Animation animation, bool debug) : base(debug, body)
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

        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            body.SetVelocity(velocity);
        }
    }

}