using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;
using System;


namespace MarioRacer.Game.Scripting
{
    public class CollideBottomAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideBottomAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Flag flag = (Flag)cast.GetFirstActor(Constants.FLAG_GROUP);
            Body body = flag.GetBody();
            Point position = body.GetPosition();
            int x = position.GetX();
            int y = position.GetY();
            Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            Sound overSound = new Sound(Constants.OVER_SOUND);

            // if (x < Constants.ROAD_LEFT)
            // {
            //     ball.BounceX();
            //     audioService.PlaySound(bounceSound);
            // }
            // else if (x >= Constants.ROAD_RIGHT - Constants.FLAG_WIDTH)
            // {
            //     ball.BounceX();
            //     audioService.PlaySound(bounceSound);
            // }

            // if (y < Constants.ROAD_TOP)
            // {
            //     ball.BounceY();
            //     audioService.PlaySound(bounceSound);
            // }
            if (y >= (Constants.ROAD_BOTTOM - 2))
            {
                flag.AddMile();
                Console.WriteLine(flag.GetMileMarker());

                if (flag.GetMileMarker() > 40)
                {
                    callback.OnNext(Constants.GAME_OVER);
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