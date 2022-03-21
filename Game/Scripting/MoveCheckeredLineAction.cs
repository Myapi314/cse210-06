using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveCheckeredLineAction : Action
    {
        private string lineGroup;
        public MoveCheckeredLineAction(string lineGroup)
        {
            this.lineGroup = lineGroup;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            CheckeredLine checkeredLine = (CheckeredLine)cast.GetFirstActor(lineGroup);
            Body body = checkeredLine.GetBody();
            // Point position = body.GetPosition();
            // Point velocity = body.GetVelocity();
            // position = position.Add(velocity);
            // body.SetPosition(position);

            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
        }
    }
}