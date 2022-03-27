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
            CheckeredLine finish = (CheckeredLine)cast.GetFirstActor(Constants.LINE_GROUP);
            Body finishBody = finish.GetBody();

            // Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            // Sound overSound = new Sound(Constants.OVER_SOUND);

            Car car = (Car)cast.GetFirstActor(Constants.CAR_GROUP);
            Body carBody = car.GetBody();

            
            if(physicsService.HasCollided(finishBody, carBody))
            {
                callback.OnNext(Constants.GAME_OVER);
            }
        }
    }
}