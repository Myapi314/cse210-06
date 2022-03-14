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
            Flag flag = (Flag)cast.GetFirstActor(Constants.FLAG_GROUP);
            Body body = flag.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
        }
    }
}