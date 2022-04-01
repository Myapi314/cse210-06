using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawBulletAction : Action
    {
        private VideoService videoService;
        private string bulletGroup;
        
        public DrawBulletAction(VideoService videoService, string bulletGroup)
        {
            this.videoService = videoService;
            this.bulletGroup = bulletGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Bullet bullet = (Bullet)cast.GetFirstActor(bulletGroup);
            Body body = bullet.GetBody();
            if (bullet.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }
            Image image = bullet.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}