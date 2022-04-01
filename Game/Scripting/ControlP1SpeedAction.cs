using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ControlP1SpeedAction : Action
    {
        private KeyboardService keyboardService;
        private PhysicsService physicsService;
        private Point velocity;
        private List<string> movingActorGroups = new List<string>();

        public ControlP1SpeedAction(KeyboardService keyboardService, PhysicsService physicsService, List<string> movingActorGroups)
        {
            this.keyboardService = keyboardService;
            this.physicsService =physicsService;
            this.movingActorGroups = movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            // Speeds
            Point slow = new Point(0, Constants.SLOW);
            Point speed = new Point(0, Constants.SPEED);
            Point maxSpeed = new Point(0, Constants.MAX_SPEED);
            Point reverse = new Point(0, Constants.REVERSE);

            Car car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body carBody = car.GetBody();

            foreach(string group in movingActorGroups)
            {
                Actor actor = cast.GetFirstActor(group);
                Body body = actor.GetBody();
                if (keyboardService.IsKeyDown(Constants.P1_UP))
                {
                    velocity = speed;

                }
                // else if (keyboardService.IsKeyDown(Constants.DOWN))
                // {
                //     velocity = reverse;
                // }
                else if (!physicsService.HasCollided(carBody, body))
                {
                    velocity = slow;
                }

                body.SetVelocity(velocity);
            }
        }
    }
}