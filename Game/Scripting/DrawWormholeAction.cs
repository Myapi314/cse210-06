using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawWormholeAction : Action
    {
        private VideoService videoService;
        private string wormholeGroup;
        
        public DrawWormholeAction(VideoService videoService, string wormholeGroup)
        {
            this.videoService = videoService;
            this.wormholeGroup = wormholeGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Wormhole wormhole = (Wormhole)cast.GetFirstActor(wormholeGroup);
            Body body = wormhole.GetBody();
            if (wormhole.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = wormhole.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}