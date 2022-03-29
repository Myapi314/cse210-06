using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveFlagAction : Action
    {
        public MoveFlagAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Flag p1_flag = (Flag)cast.GetFirstActor(Constants.P1_FLAG_GROUP);
            Flag p2_flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);

            Body p1_body = p1_flag.GetBody();
            Body p2_body = p2_flag.GetBody();
            p1_body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            p2_body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            // Point position = body.GetPosition();
            // Point velocity = body.GetVelocity();
            // position = position.Add(velocity);
            // body.SetPosition(position);
        }
    }
}