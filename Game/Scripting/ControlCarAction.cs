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
            Car car = (Car)cast.GetFirstActor(Constants.CAR_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                car.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                car.SwingRight();
            }
            else
            {
                car.StopMoving();
            }
        }
    }
}