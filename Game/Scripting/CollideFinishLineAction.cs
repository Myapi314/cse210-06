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
        private string lineGroup;
        private string carGroup;
        
        public CollideFinishLineAction(PhysicsService physicsService, AudioService audioService, string lineGroup, string carGroup)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.lineGroup = lineGroup;
            this.carGroup = carGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            CheckeredLine line = (CheckeredLine)cast.GetFirstActor(lineGroup);
            
            Body body = line.GetBody();

            // Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            // Sound overSound = new Sound(Constants.OVER_SOUND);

            Car car = (Car)cast.GetFirstActor(carGroup);
  
            Body car_body = car.GetBody();

            
            if(physicsService.HasCollided(body, car_body))
            {
                callback.OnNext(Constants.GAME_OVER);
            }
        }
    }
}