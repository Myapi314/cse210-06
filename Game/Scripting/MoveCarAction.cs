using MarioRacer.Game.Casting;

namespace MarioRacer.Game.Scripting
{
    public class MoveCarAction : Action
    {
        public MoveCarAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Car car = (Car)cast.GetFirstActor(Constants.CAR_GROUP);
            Body body = car.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            if (x < Constants.ROAD_LEFT)
            {
                position = new Point(Constants.ROAD_LEFT, position.GetY());
            }
            else if (x > Constants.SCREEN_WIDTH - (Constants.CAR_WIDTH + Constants.ROAD_RIGHT))
            {
                position = new Point(Constants.SCREEN_WIDTH - (Constants.CAR_WIDTH + Constants.ROAD_RIGHT), 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}