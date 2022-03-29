using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;
using System;


namespace MarioRacer.Game.Scripting
{
    public class CollideBottomAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private string flagGroup;

        public CollideBottomAction(PhysicsService physicsService, AudioService audioService, string flagGroup)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.flagGroup = flagGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Flag flag = (Flag)cast.GetFirstActor(flagGroup);
            
            Body body = flag.GetBody();
            Point position = body.GetPosition();
            int x = position.GetX();
            int y = position.GetY();
            Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            Sound overSound = new Sound(Constants.OVER_SOUND);

            Point velocity = body.GetVelocity();
            int speed = velocity.GetY();

            if (y >= (Constants.ROAD_BOTTOM - speed))
            {
                Console.WriteLine(speed);
                flag.AddMile();
                Console.WriteLine(flag.GetMileMarker());

                if (flag.GetMileMarker() > Constants.MILES)
                {
                    callback.OnNext(Constants.FINISH_SCENE);
                    audioService.PlaySound(overSound);
                }
                // else
                // {
                //     callback.OnNext(Constants.TRY_AGAIN);
                // }
            }
        }
    }
}