using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlCarAction : Action
    {
        private KeyboardService keyboardService;

        public ControlCarAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);

            if (keyboardService.IsKeyDown(Constants.P1_LEFT))
            {
                p1_car.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.P1_RIGHT))
            {
                p1_car.SwingRight();
            }
            else
            {
                p1_car.StopMoving();
            }

            if (keyboardService.IsKeyDown(Constants.P2_LEFT))
            {
                p2_car.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.P2_RIGHT))
            {
                p2_car.SwingRight();
            }
            else
            {
                p2_car.StopMoving();
            }
        }
    }
}