using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlSpeedAction : Action
    {
        private List<Body> p1_movingActors = new List<Body>();
        private List<Body> p2_movingActors = new List<Body>();
        private KeyboardService keyboardService;
        private Point p1_velocity;
        private Point p2_velocity;

        public ControlSpeedAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            // Speeds
            Point slow = new Point(0, Constants.SLOW);
            Point speed = new Point(0, Constants.SPEED);
            Point maxSpeed = new Point(0, Constants.MAX_SPEED);
            Point reverse = new Point(0, Constants.REVERSE);

            // P1 Moving Actors
            Flag p1_flag = (Flag)cast.GetFirstActor(Constants.P1_FLAG_GROUP);
            Body p1_flagBody = p1_flag.GetBody();

            CheckeredLine p1_line = (CheckeredLine)cast.GetFirstActor(Constants.P1_LINE_GROUP);
            Body p1_lineBody = p1_line.GetBody();

            p1_movingActors.Add(p1_flagBody);
            p1_movingActors.Add(p1_lineBody);

            // P2 Moving Actors
            Flag p2_flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);
            Body p2_flagBody = p2_flag.GetBody();

            CheckeredLine p2_line = (CheckeredLine)cast.GetFirstActor(Constants.P2_LINE_GROUP);
            Body p2_lineBody = p2_line.GetBody();

            p2_movingActors.Add(p2_flagBody);
            p2_movingActors.Add(p2_lineBody);
            
            foreach (Body body in p1_movingActors)
            {
                if (keyboardService.IsKeyDown(Constants.P1_UP))
                {
                    p1_velocity = speed;

                }
                // else if (keyboardService.IsKeyDown(Constants.DOWN))
                // {
                //     velocity = reverse;
                // }
                else
                {
                    p1_velocity = slow;
                }

                body.SetVelocity(p1_velocity);
            
            }

            // P2 Adjust Spped
            foreach (Body body in p2_movingActors)
            {
                if (keyboardService.IsKeyDown(Constants.P2_UP))
                {
                    p2_velocity = speed;

                }
                // else if (keyboardService.IsKeyDown(Constants.DOWN))
                // {
                //     velocity = reverse;
                // }
                else
                {
                    p2_velocity = slow;
                }

                body.SetVelocity(p2_velocity);
            
            }
        }
    }
}