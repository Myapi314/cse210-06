namespace MarioRacer.Game.Casting{

    public class Wormhole : Actor
    {
         private Body body;
        private Image image;
        public Wormhole(Body body, Image image, bool debug) : base(debug, body){
            this.body = body;
            this.image = image;
        }

        public Image GetImage(){
            return image;
        }
    }
}