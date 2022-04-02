using System.Diagnostics;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (keyboardService.IsKeyPressed(Constants.ENTER))
            {
                List<Actor> actors = cast.GetActors(Constants.STATS_GROUP);
                foreach(Actor actor in actors)
                {
                    Stats stat = (Stats)actor;
                    stat.StartTime();
                }
                callback.OnNext(nextScene);
            }
        }
    }
}