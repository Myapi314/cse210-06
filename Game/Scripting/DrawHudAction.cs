using System.Diagnostics;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class DrawHudAction : Action
    {
        private VideoService videoService;
        private int playerIndex;
        
        public DrawHudAction(VideoService videoService, int playerIndex)
        {
            this.videoService = videoService;
            this.playerIndex = playerIndex;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);
            Stats player_stat = (Stats)stats[playerIndex];
            DrawLabel(cast, Constants.COINS_GROUP, Constants.COINS_FORMAT, player_stat.GetCoins());
            DrawLabel(cast, Constants.ITEMS_GROUP, Constants.ITEMS_FORMAT, player_stat.GetItem());
            DrawLabel(cast, Constants.TIME_GROUP, Constants.TIME_FORMAT, player_stat.GetStopwatch());
        }

        private void DrawLabel(Cast cast, string group, string format, string data)
        { 
            List<Actor> labels = cast.GetActors(group);           
            Label label = (Label)labels[playerIndex];
            Text text = label.GetText();
            text.SetValue(string.Format(format, data));
            Point position = label.GetPosition();
            videoService.DrawText(text, position);
        }
    }
}