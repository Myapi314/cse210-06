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
            Boost p1_boost = (Boost)cast.GetFirstActor(Constants.P1_BOOST_GROUP);
            Body p1_boostBody = p1_boost.GetBody();
            if (p1_boost.IsDebug())
             {
                Rectangle rectangle = p1_boostBody.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
             }
            Image image = p1_boost.GetImage();
            Point position = p1_boostBody.GetPosition();
            videoService.DrawImage(image, position);

            Boost p2_boost = (Boost)cast.GetFirstActor(Constants.P2_BOOST_GROUP);
            Body p2_boostBody = p2_boost.GetBody();
            if (p2_boost.IsDebug())
             {
                Rectangle p2_rectangle = p2_boostBody.GetRectangle();
                Point p2_size = p2_rectangle.GetSize();
                Point p2_pos = p2_rectangle.GetPosition();
                videoService.DrawRectangle(p2_size, p2_pos, Constants.PURPLE, false);
             }
            Image p2_image = p2_boost.GetImage();
            Point p2_position = p2_boostBody.GetPosition();
            videoService.DrawImage(p2_image, p2_position);
        }


    }
}