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
            Car car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body body = car.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            if (x < Constants.P2_ROAD_LEFT)
            {
                position = new Point(Constants.P2_ROAD_LEFT, position.GetY());
            }
            else if (x > Constants.P2_ROAD_RIGHT)
            {
                position = new Point(Constants.P2_ROAD_RIGHT, 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}