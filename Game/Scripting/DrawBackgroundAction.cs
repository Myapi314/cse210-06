using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawBackgroundAction : Action
    {
        private VideoService videoService;
        
        public DrawBackgroundAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> backgrounds = cast.GetActors(Constants.BACKGROUND_GROUP);

            foreach(Actor actor in backgrounds)
            {
                Background background = (Background)actor;
                Body body = background.GetBody();

                if (background.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }
                Image image = background.GetImage();
                // Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}