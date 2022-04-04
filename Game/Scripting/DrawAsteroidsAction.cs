using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawAsteroidsAction : Action
    {
        private VideoService videoService;
        private string asteroidGroup;
        
        public DrawAsteroidsAction(VideoService videoService, string asteroidGroup)
        {
            this.videoService = videoService;
            this.asteroidGroup = asteroidGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> asteroids = cast.GetActors(asteroidGroup);
            foreach (Actor actor in asteroids)
            {
                Asteroid asteroid = (Asteroid)actor;
                Body body = asteroid.GetBody();

                if (asteroid.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = asteroid.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}