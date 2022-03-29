using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideCarAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideCarAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
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