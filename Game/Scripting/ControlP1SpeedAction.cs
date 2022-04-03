using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlP1SpeedAction : Action
    {
        private KeyboardService keyboardService;
        private Point velocity;
        private List<string> movingActorGroups = new List<string>();

        public ControlP1SpeedAction(KeyboardService keyboardService, List<string> movingActorGroups)
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

            Car car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body carBody = car.GetBody();

            List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);
            Stats p1_stat = (Stats)stats[Constants.P1_INDEX];
            string item = p1_stat.GetItem();
            int coins = p1_stat.GetCoinNum();

            foreach(string group in movingActorGroups)
            {
                Actor actor = cast.GetFirstActor(group);
                Body body = actor.GetBody();
                if (keyboardService.IsKeyDown(Constants.P1_UP))
                {
                    velocity = speed;
                }
                else
                {
                    velocity = slow;
                }

                body.SetVelocity(velocity);
            }
        }
    }
}