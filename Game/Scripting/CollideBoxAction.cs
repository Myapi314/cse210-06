using System.Collections.Generic;
using System;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideBoxAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideBoxAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Point offScreen = new Point(0, Constants.BACKGROUND_HEIGHT);

            MysteryBox p1_actor = (MysteryBox)cast.GetFirstActor(Constants.P1_BOX_GROUP);
            Body p1_actorBody = p1_actor.GetBody();
            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body p1_carBody = p1_car.GetBody();
            List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);

            if (physicsService.HasCollided(p1_carBody, p1_actorBody))
            {
                p1_actorBody.SetPosition(offScreen);
                // p1_actor.StopMoving();
                Stats p1_stat = (Stats)stats[Constants.P1_INDEX];
                p1_stat.NewItem();
                p1_actor.SetTimeHit(p1_stat.GetTime());
            }

            MysteryBox p2_actor = (MysteryBox)cast.GetFirstActor(Constants.P2_BOX_GROUP);
            Body p2_actorBody = p2_actor.GetBody();
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body p2_carBody = p2_car.GetBody();

            if (physicsService.HasCollided(p2_carBody, p2_actorBody))
            {
                p2_actorBody.SetPosition(offScreen);
                // p2_actor.StopMoving();
                Stats p2_stat = (Stats)stats[Constants.P2_INDEX];
                p2_stat.NewItem();
            }
        }
    }
}