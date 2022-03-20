using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveFinishAction : Action
    {
        public MoveFinishAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            CheckeredLine finish = (CheckeredLine)cast.GetFirstActor(Constants.FINISH_GROUP);
            Body body = finish.GetBody();
            body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            // Point position = body.GetPosition();
            // Point velocity = body.GetVelocity();
            // position = position.Add(velocity);
            // body.SetPosition(position);
        }
    }
}