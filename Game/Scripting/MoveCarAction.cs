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
            if (x < 0)
            {
                position = new Point(0, position.GetY());
            }
            else if (x > Constants.SCREEN_WIDTH - Constants.CAR_WIDTH)
            {
                position = new Point(Constants.SCREEN_WIDTH - Constants.CAR_WIDTH, 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}