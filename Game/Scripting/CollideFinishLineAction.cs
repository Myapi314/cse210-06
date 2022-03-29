using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;
using System;


namespace MarioRacer.Game.Scripting
{
    public class CollideFinishLineAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideFinishLineAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            CheckeredLine p1_line = (CheckeredLine)cast.GetFirstActor(Constants.P1_LINE_GROUP);
            CheckeredLine p2_line = (CheckeredLine)cast.GetFirstActor(Constants.P2_LINE_GROUP);
            
            Body p1_body = p1_line.GetBody();
            Body p2_body = p2_line.GetBody();

            // Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            // Sound overSound = new Sound(Constants.OVER_SOUND);

            Car p1_car = (Car)cast.GetFirstActor(Constants.P1_CAR_GROUP);
            Car p2_car = (Car)cast.GetFirstActor(Constants.P2_CAR_GROUP);
  
            Body p1_car_body = p1_car.GetBody();
            Body p2_car_body = p2_car.GetBody();

            
            if(physicsService.HasCollided(p1_body, p1_car_body))
            {
                callback.OnNext(Constants.GAME_OVER);
            }
            if(physicsService.HasCollided(p2_body, p2_car_body))
            {
                callback.OnNext(Constants.GAME_OVER);
            }

        }
    }
}