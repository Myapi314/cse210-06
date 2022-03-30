using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawCoinAction : Action
    {
        private VideoService videoService;

        private string coingroup;
        
        public DrawCoinAction(VideoService videoService, string coingroup)
        {
            this.videoService = videoService;
            this.coingroup = coingroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> coins = new List<Actor>();
            Coin coin = (Coin)cast.GetFirstActor(coingroup);
            Body body = coin.GetBody();

                if (coin.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = coin.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            
        }
    }
}