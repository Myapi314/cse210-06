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
            // P1 Flag
            Flag p1_flag = (Flag)cast.GetFirstActor(Constants.P1_FLAG_GROUP);
            
            Body p1_body = p1_flag.GetBody();
            Point p1_position = p1_body.GetPosition();
            int y1 = p1_position.GetY();

            Point p1_velocity = p1_body.GetVelocity();
            int p1_speed = p1_velocity.GetY();

            // P2 Flag
            Flag p2_flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);
            
            Body p2_body = p2_flag.GetBody();
            Point p2_position = p2_body.GetPosition();
            int y2 = p2_position.GetY();

            Point p2_velocity = p2_body.GetVelocity();
            int p2_speed = p2_velocity.GetY();

            Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            Sound overSound = new Sound(Constants.OVER_SOUND);

            if (y1 >= (Constants.ROAD_BOTTOM - p1_speed))
            {
                Console.WriteLine(p1_speed);
                p1_flag.AddMile();
                Console.WriteLine(p1_flag.GetMileMarker());

                if (p1_flag.GetMileMarker() > Constants.MILES)
                {
                    callback.OnNext(Constants.P1_FINISH_SCENE);
                    audioService.PlaySound(overSound);
                }
            }

            if (y2 >= (Constants.ROAD_BOTTOM - p2_speed))
            {
                Console.WriteLine(p2_speed);
                p2_flag.AddMile();
                Console.WriteLine(p2_flag.GetMileMarker());

                if (p2_flag.GetMileMarker() > Constants.MILES)
                {
                    callback.OnNext(Constants.P2_FINISH_SCENE);
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