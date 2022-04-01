namespace MarioRacer.Game.Casting{

    /// <summary>
    /// A projectile to destroy obstacles.
    /// </summary>
    public class Bullet : Actor 
    {
        private Body body;
        private Image image;
        public Bullet(Body body, Image image, bool debug) : base(debug, body){
            this.body = body;
            this.image = image;
        }

        public Image GetImage(){
            return image;
        }
    }

}