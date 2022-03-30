using System;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Scripting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.SceneManaging
{
    public class InPlayScreen
    {
        private int start_x;
        private int start_y;
        // private int center_x;
        private Point velocity = new Point(0, 0);
        private string flagGroup;
        private string lineGroup;

        public InPlayScreen(int x, int y, string flagGroup, string lineGroup)
        {
            this.start_x = x;
            this.start_y = y;
            this.flagGroup = flagGroup;
            this.lineGroup = lineGroup;
        }

        public void PrepareInPlayScene(Cast cast, Script script, VideoService videoService, KeyboardService keyboardService)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);
            AddFlag(cast);
            // AddInputActions(script, keyboardService);
            // AddOutputActions(script, videoService);
            // AddUpdateActions(script);
        }

        private void AddFlag(Cast cast)
        {
            cast.ClearActors(flagGroup);
            Point position = new Point(start_x, start_y);
            Point size = new Point(Constants.FLAG_WIDTH, Constants.FLAG_HEIGHT);
            
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.FLAG_IMAGE);

            Flag flag = new Flag(body, image, 0, false);

            cast.AddActor(flagGroup, flag);
        }

        private void AddBoost(Cast cast)
        {
            cast.ClearActors(Constants.BOOST_GROUP);
            
            int x = Constants.CENTER_X - Constants.BOOST_WIDTH / 2;
            int y = 50;
            
            Point position = new Point(x, y);
            Point size = new Point(Constants.BOOST_WIDTH, Constants.BOOST_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.BOOST_IMAGE);
            Boost boost = new Boost(body, image, false);
        
            cast.AddActor(Constants.BOOST_GROUP, boost);
        }
        private void AddInputActions(Script script, KeyboardService keyboardService)
        {
            script.AddAction(Constants.INPUT, new ControlCarAction(keyboardService));
            script.AddAction(Constants.INPUT, new ControlSpeedAction(keyboardService));
        }

        private void AddOutputActions(Script script, VideoService videoService)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawFlagAction(videoService, flagGroup));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(videoService, lineGroup));
            script.AddAction(Constants.OUTPUT, new DrawCarAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(videoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(videoService));
        }
        
        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MoveP1CarAction());
            script.AddAction(Constants.UPDATE, new MoveP2CarAction());
            script.AddAction(Constants.UPDATE, new MoveFlagAction());
            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(lineGroup));
        }
    }
}