using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawCometAction : Action
    {
        private VideoService videoService;
        private string cometGroup;
        
        public DrawCometAction(VideoService videoService, string cometGroup)
        {
            this.videoService = videoService;
            this.cometGroup = cometGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Comet comet = (Comet)cast.GetFirstActor(cometGroup);
            Body body = comet.GetBody();
            if (comet.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = comet.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}