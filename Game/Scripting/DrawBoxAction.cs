using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawBoxAction : Action
    {
        private VideoService videoService;
        private string boxGroup;
        
        public DrawBoxAction(VideoService videoService, string boxGroup)
        {
            this.videoService = videoService;
            this.boxGroup = boxGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MysteryBox box = (MysteryBox)cast.GetFirstActor(boxGroup);
            Body body = box.GetBody();
            if (box.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = box.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}