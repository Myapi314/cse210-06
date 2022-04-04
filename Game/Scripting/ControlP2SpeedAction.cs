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

            if (keyboardService.IsKeyDown(Constants.P2_UP))
            {
                velocity = speed;

            }
            else
            {
                velocity = slow;
            }
            
            foreach(string group in movingActorGroups)
            {
                Actor actor = cast.GetFirstActor(group);
                Body body = actor.GetBody();
                body.SetVelocity(velocity);
            }
            
            List<Actor> asteroids = cast.GetActors(Constants.P2_ASTEROIDS_GROUP);
            foreach(Actor asteroid in asteroids)
            {
                Body body = asteroid.GetBody();
                body.SetVelocity(velocity);   
            }
        }
    }
}