using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveBoostAction : Action
    {
        public MoveBoostAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> p1_boosts = cast.GetActors(Constants.P1_BOOST_GROUP);
            List<Actor> p2_boosts = cast.GetActors(Constants.P2_BOOST_GROUP);

            foreach(Actor actor in p1_boosts)
            {
                Boost boost = (Boost)actor;
                Body body = boost.GetBody();
                body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
            foreach(Actor actor in p2_boosts)
            {
                Boost boost = (Boost)actor;
                Body body = boost.GetBody();
                body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }

            // Point position = body.GetPosition();
            // Point velocity = body.GetVelocity();
            // position = position.Add(velocity);
            // body.SetPosition(position);
        }
    }
}