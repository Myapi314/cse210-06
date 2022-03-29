using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawBoostAction : Action
    {
        private VideoService videoService;

        public DrawBoostAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback){
            Boost boost = (Boost)cast.GetFirstActor(Constants.BOOST_GROUP);
            Body body = boost.GetBody();
            if (boost.IsDebug())
             {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
             }
            Image image = boost.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }


    }
}