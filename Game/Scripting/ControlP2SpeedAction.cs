using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlP2SpeedAction : Action
    {
        private List<Body> movingActors = new List<Body>();
        private KeyboardService keyboardService;
        private Point velocity;

        public ControlP2SpeedAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Flag flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);
            Body flagBody = flag.GetBody();

            CheckeredLine startLine = (CheckeredLine)cast.GetFirstActor(Constants.P2_LINE_GROUP);
            Body startBody = startLine.GetBody();

            movingActors.Add(flagBody);
            movingActors.Add(startBody);

            Point slow = new Point(0, Constants.SLOW);
            Point speed = new Point(0, Constants.SPEED);
            Point maxSpeed = new Point(0, Constants.MAX_SPEED);
            Point reverse = new Point(0, Constants.REVERSE);
            
            foreach (Body body in movingActors)
            {
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