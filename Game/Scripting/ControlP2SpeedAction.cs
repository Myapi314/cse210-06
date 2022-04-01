using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlP2SpeedAction : Action
    {
        private KeyboardService keyboardService;
        private Point velocity;
        private List<string> movingActorGroups = new List<string>();

        public ControlP2SpeedAction(KeyboardService keyboardService, List<string> movingActorGroups)
        {
            this.keyboardService = keyboardService;
            this.movingActorGroups = movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            // Speeds
            Point slow = new Point(0, Constants.SLOW);
            Point speed = new Point(0, Constants.SPEED);
            Point maxSpeed = new Point(0, Constants.MAX_SPEED);
            Point reverse = new Point(0, Constants.REVERSE);

            foreach(string group in movingActorGroups)
            {
                Actor actor = cast.GetFirstActor(group);
                Body body = actor.GetBody();
                if (keyboardService.IsKeyDown(Constants.P2_UP))
                {
                    velocity = speed;

                }
                // else if (keyboardService.IsKeyDown(Constants.DOWN))
                // {
                //     velocity = reverse;
                // }
                else
                {
                    velocity = slow;
                }

                body.SetVelocity(velocity);
            }
        }
    }
}