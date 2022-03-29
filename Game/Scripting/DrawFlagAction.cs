using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawFlagAction : Action
    {
        private VideoService videoService;
        private string flagGroup;
        
        public DrawFlagAction(VideoService videoService, string flagGroup)
        {
            this.videoService = videoService;
            this.flagGroup = flagGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Flag flag = (Flag)cast.GetFirstActor(flagGroup);
            Body body = flag.GetBody();
            if (flag.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = flag.GetImage();
            // Image image = animation.NextImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}