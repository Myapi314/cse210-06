using System.Collections.Generic;
using System;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideBoostAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private List<string> p1_movingActorGroups = new List<string>();
        private List<string> p2_movingActorGroups = new List<string>();
        
        public CollideBoostAction(PhysicsService physicsService, AudioService audioService, 
            List<string> p1_movingActorGroups, List<string> p2_movingActorGroups)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.p1_movingActorGroups = p1_movingActorGroups;
            this.p2_movingActorGroups = p2_movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Point velocity = new Point(0, Constants.MAX_SPEED);

            Boost p1_boost = (Boost)cast.GetFirstActor(Constants.P1_BOOST_GROUP);
            Body p1_boostBody = p1_boost.GetBody();
            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body p1_carBody = p1_car.GetBody();
            
            List<Actor> p1_asteroids = cast.GetActors(Constants.P1_ASTEROIDS_GROUP);

            if (physicsService.HasCollided(p1_carBody, p1_boostBody))
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

            Boost p2_boost = (Boost)cast.GetFirstActor(Constants.P2_BOOST_GROUP);
            Body p2_boostBody = p2_boost.GetBody();
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body p2_carBody = p2_car.GetBody();

            List<Actor> p2_asteroids = cast.GetActors(Constants.P2_ASTEROIDS_GROUP);

            if (physicsService.HasCollided(p2_carBody, p2_boostBody))
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
            // Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            // Car car = (Car)cast.GetFirstActor(Constants.CAR_GROUP);
            // Body ballBody = ball.GetBody();
            // Body carBody = car.GetBody();

            // if (physicsService.HasCollided(carBody, ballBody))
            // {
            //     ball.BounceY();
            //     Sound sound = new Sound(Constants.BOUNCE_SOUND);
            //     audioService.PlaySound(sound);
            // }
        }
    }
}