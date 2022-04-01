namespace MarioRacer.Game.Casting{

    /// <summary>
    /// A MysterBox to be displayed.
    /// </summary>
    public class MysteryBox : Actor{
        private Body body;
        private Image image;
        public MysteryBox(Body body, Image image, bool debug) : base(debug, body){
            this.body = body;
            this.image = image;
        }
        public Image GetImage(){
            return image;
        }
    }
}