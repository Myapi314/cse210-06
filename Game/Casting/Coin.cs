namespace MarioRacer.Game.Casting{
    public class Coin : Actor 
    {
        private Body body;
        private Animation animation;
        public Coin(Body body, Animation animation, bool debug) : base(debug)
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
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }


    }

}