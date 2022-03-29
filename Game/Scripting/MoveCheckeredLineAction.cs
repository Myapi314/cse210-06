using System.Collections.Generic;
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
            List<Actor> lines = cast.GetActors(lineGroup);

            foreach(Actor actor in lines)
            {
                CheckeredLine line = (CheckeredLine)actor;
                Body body = line.GetBody();
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
}