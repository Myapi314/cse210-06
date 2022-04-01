namespace MarioRacer.Game.Casting{

    public class Comet : Actor
    {
         private Body body;
        private Image image;
        public Comet(Body body, Image image, bool debug) : base(debug, body){
            this.body = body;
            this.image = image;
        }

        public Image GetImage(){
            return image;
        }
    }
}