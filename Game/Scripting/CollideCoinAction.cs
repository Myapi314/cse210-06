using System.Collections.Generic;
using System;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideCoinAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private List<string> p1_movingActorGroups = new List<string>();
        private List<string> p2_movingActorGroups = new List<string>();
        
        public CollideCoinAction(PhysicsService physicsService, AudioService audioService, 
            List<string> p1_movingActorGroups, List<string> p2_movingActorGroups)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.p1_movingActorGroups = p1_movingActorGroups;
            this.p2_movingActorGroups = p2_movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Point velocity = new Point(0, Constants.COIN_SPEED);
            Point offScreen = new Point(0, Constants.BACKGROUND_HEIGHT);

            Coin p1_actor = (Coin)cast.GetFirstActor(Constants.P1_COIN_GROUP);
            Body p1_actorBody = p1_actor.GetBody();
            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Body p1_carBody = p1_car.GetBody();
            List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);

            if (physicsService.HasCollided(p1_carBody, p1_actorBody))
            {
                p1_actorBody.SetPosition(offScreen);
                p1_actor.StopMoving();
                Stats p1_stat = (Stats)stats[Constants.P1_INDEX];
                p1_stat.IncCoins();
                int coins = p1_stat.GetCoinNum();
            }

            Coin p2_actor = (Coin)cast.GetFirstActor(Constants.P2_COIN_GROUP);
            Body p2_actorBody = p2_actor.GetBody();
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
            Body p2_carBody = p2_car.GetBody();

            if (physicsService.HasCollided(p2_carBody, p2_actorBody))
            {
                p2_actorBody.SetPosition(offScreen);
                p2_actor.StopMoving();
                Stats p2_stat = (Stats)stats[Constants.P2_INDEX];
                p2_stat.IncCoins();
                int coins = p2_stat.GetCoinNum();
            }
        }
    }
}