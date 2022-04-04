using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveAsteroidsAction : Action
    {
        public MoveAsteroidsAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> p1_asteroids = cast.GetActors(Constants.P1_ASTEROIDS_GROUP);
            List<Actor> p2_asteroids = cast.GetActors(Constants.P2_ASTEROIDS_GROUP);
            foreach(Actor asteroid in p1_asteroids)
            {
                Body body = asteroid.GetBody();
                body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
            foreach(Actor asteroid in p2_asteroids)   
            {
                Body body = asteroid.GetBody();
                body.MoveNext(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
        }
    }
}