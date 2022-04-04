using System.Collections.Generic;
using System;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideHoleAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private List<string> p1_movingActorGroups = new List<string>();
        private List<string> p2_movingActorGroups = new List<string>();
        
        public CollideHoleAction(PhysicsService physicsService, AudioService audioService, 
            List<string> p1_movingActorGroups, List<string> p2_movingActorGroups)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.p1_movingActorGroups = p1_movingActorGroups;
            this.p2_movingActorGroups = p2_movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Point velocity = new Point(0, Constants.SLOW);

            Actor p1_actor = cast.GetFirstActor(Constants.P1_WORMHOLE_GROUP);
            Body p1_actorBody = p1_actor.GetBody();
            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body p1_carBody = p1_car.GetBody();

            List<Actor> p1_asteroids = cast.GetActors(Constants.P1_ASTEROIDS_GROUP);

            if (physicsService.HasCollided(p1_carBody, p1_actorBody))
            {
                foreach(string group in p1_movingActorGroups)
                {
                    Actor actor = cast.GetFirstActor(group);
                    Body body = actor.GetBody();
                    body.SetVelocity(velocity);
                }
                foreach(Actor asteroid in p1_asteroids)
                {
                    Body body = asteroid.GetBody();
                    body.SetVelocity(velocity);   
                }
            }

            Actor p2_actor = cast.GetFirstActor(Constants.P2_WORMHOLE_GROUP);
            Body p2_actorBody = p2_actor.GetBody();
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body p2_carBody = p2_car.GetBody();

            List<Actor> p2_asteroids = cast.GetActors(Constants.P2_ASTEROIDS_GROUP);

            if (physicsService.HasCollided(p2_carBody, p2_actorBody))
            {
                foreach(string group in p2_movingActorGroups)
                {
                    Actor actor = cast.GetFirstActor(group);
                    Body body = actor.GetBody();
                    body.SetVelocity(velocity);
                }
                foreach(Actor asteroid in p2_asteroids)
                {
                    Body body = asteroid.GetBody();
                    body.SetVelocity(velocity);   
                }
            }
        }
    }
}