using System.Collections.Generic;
using MarioRacer.Game.Casting;

namespace MarioRacer.Game.Scripting
{
    public class MoveP2CarAction : Action
    {
        public MoveP2CarAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> actors = cast.GetActors(Constants.BACKGROUND_GROUP);
            Background p2_background = (Background)actors[1];

            Car car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body body = car.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            int roadLeft = p2_background.GetRoadLeft();
            int roadRight = p2_background.GetRoadRight();

            position = position.Add(velocity);
            if (x < roadLeft)
            {
                position = new Point(roadLeft, position.GetY());
            }
            else if (x > roadRight)
            {
                position = new Point(roadRight, 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}