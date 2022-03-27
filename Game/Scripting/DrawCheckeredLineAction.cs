using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawCheckeredLineAction : Action
    {
        private VideoService videoService;
        
        public DrawCheckeredLineAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            CheckeredLine finish = (CheckeredLine)cast.GetFirstActor(Constants.LINE_GROUP);
            Body body = finish.GetBody();
            if (finish.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = finish.GetImage();
            // Image image = animation.NextImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}