using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawCarAction : Action
    {
        private VideoService videoService;
        
        public DrawCarAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> cars = new List<Actor>();
            cars.Add(cast.GetFirstActor(Constants.P1_CAR_GROUP));
            cars.Add(cast.GetFirstActor(Constants.P2_CAR_GROUP));
            foreach(Actor actor in cars)
            {
                Car car = (Car)actor;
                Body body = car.GetBody();

                if (car.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = car.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
            
        }
    }
}