using System;
using System.Collections.Generic;
namespace MarioRacer.Game.Casting
{
    public class Boost : Actor {
        private Body body;
        private Image image;

    public Boost(Body body, Image image, bool debug = false) : base(debug, body){
        this.body = body;
        this.image = image;
    }
    public Image GetImage()
        {
            return image;
        }

}
}