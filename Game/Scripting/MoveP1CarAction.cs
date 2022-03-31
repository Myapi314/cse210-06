using MarioRacer.Game.Casting;

namespace MarioRacer.Game.Scripting
{
    public class MoveP1CarAction : Action
    {
        public MoveP1CarAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Background p1_background = (Background)cast.GetFirstActor(Constants.BACKGROUND_GROUP);

            Car car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body body = car.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            int roadLeft = p1_background.GetRoadLeft();
            int roadRight = p1_background.GetRoadRight();

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