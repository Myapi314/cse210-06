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
        private List<string> groups = new List<string>();
        private Random random = new Random();
        private int roadleft;
        private int roadRight;

        public InPlayScreen(int start_x, int start_y, List<string> groups)
        {
            this.start_x = start_x;
            this.start_y = start_y;
            this.groups = groups;

            roadleft = start_x + Constants.ROAD_LEFT;
            roadRight = (start_x + Constants.BACKGROUND_WIDTH) - Constants.ROAD_RIGHT;
        }

        public void PrepareInPlayScene(Cast cast, Script script, VideoService videoService, KeyboardService keyboardService)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);
            AddFlag(cast);
            AddBoost(cast);
            AddCoin(cast);
            // AddInputActions(script, keyboardService);
            // AddOutputActions(script, videoService);
            // AddUpdateActions(script);
        }

        private void AddFlag(Cast cast)
        {
            string flagGroup = groups[Constants.FLAG_INDEX];
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
            string boostGroup = groups[Constants.BOOST_INDEX];
            // cast.ClearActors(boostGroup);

            int x = random.Next(roadleft, roadRight);
            int y = 50;
            
            Point position = new Point(x, y);
            Point size = new Point(Constants.BOOST_WIDTH, Constants.BOOST_HEIGHT);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.BOOST_IMAGE);
            Boost boost = new Boost(body, image, false);
        
            cast.AddActor(boostGroup, boost);
        }

        private void AddCoin(Cast cast)
        {
            string coinGroup = groups[Constants.COIN_INDEX];

            int x = random.Next(roadleft, roadRight);
            int y = 0;
            
            Point position = new Point(x, y);
            Point size = new Point(Constants.COIN_WIDTH, Constants.COIN_HEIGHT);
            
            Animation animation = new Animation(Constants.COIN_IMAGES, Constants.COIN_RATE, 0);
            Body body = new Body(position, size, velocity);

            Coin coin = new Coin(body, animation, false);

            cast.AddActor(coinGroup, coin);

        }
        private void AddInputActions(Script script, KeyboardService keyboardService)
        {
            script.AddAction(Constants.INPUT, new ControlCarAction(keyboardService));
            // script.AddAction(Constants.INPUT, new ControlP1SpeedAction(keyboardService));
        }

        private void AddOutputActions(Script script, VideoService videoService)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawFlagAction(videoService, groups[Constants.FLAG_INDEX]));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(videoService, groups[Constants.LINE_INDEX]));
            script.AddAction(Constants.OUTPUT, new DrawCarAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawBoostAction(videoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(videoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(videoService));
        }
        
        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MoveP1CarAction());
            script.AddAction(Constants.UPDATE, new MoveP2CarAction());
            script.AddAction(Constants.UPDATE, new MoveFlagAction());
            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(groups[Constants.LINE_INDEX]));
        }
    }
}