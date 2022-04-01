using System;
using System.Collections.Generic;
using System.IO;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Scripting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.SceneManaging
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        private List<string> p1_cast_groups = new List<string>() {
            Constants.P1_CAR_GROUP, Constants.P1_BOOST_GROUP, Constants.P1_FLAG_GROUP, Constants.P1_LINE_GROUP, 
            Constants.P1_COIN_GROUP, Constants.P1_WORMHOLE_GROUP, Constants.P1_COMET_GROUP, 
            Constants.P1_BOX_GROUP, Constants.P1_BULLET_GROUP
        };
        private List<string> p2_cast_groups = new List<string>() {
            Constants.P2_CAR_GROUP, Constants.P2_BOOST_GROUP, Constants.P2_FLAG_GROUP, Constants.P2_LINE_GROUP,
            Constants.P2_COIN_GROUP, Constants.P2_WORMHOLE_GROUP, Constants.P2_COMET_GROUP, 
            Constants.P2_BOX_GROUP, Constants.P2_BULLET_GROUP
        };

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            StartScreen p1_start_screen = new StartScreen(0, 0, Constants.SCREEN_ONE_CENTER_X, 
                Constants.P1_CAR_GROUP, Constants.BLUE_CAR_IMAGES, Constants.P1_LINE_GROUP);
            StartScreen p2_start_screen = new StartScreen(Constants.CENTER_X, 0, Constants.SCREEN_TWO_CENTER_X, 
                Constants.P2_CAR_GROUP, Constants.YELLOW_CAR_IMAGES, Constants.P2_LINE_GROUP);

            InPlayScreen p1_inPlay_screen = new InPlayScreen(0, 0, 
                p1_cast_groups);
            InPlayScreen p2_inPlay_screen = new InPlayScreen(Constants.CENTER_X, 0, 
                p2_cast_groups);

            FinishScreen p1_finish_screen = new FinishScreen(0, 0, Constants.P1_LINE_GROUP);
            FinishScreen p2_finish_screen = new FinishScreen(Constants.CENTER_X, 0, Constants.P2_LINE_GROUP);
            
            
            if (scene == Constants.NEW_GAME)
            {
                p1_start_screen.PrepareNewScene(cast);
                p2_start_screen.PrepareNewScene(cast);
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                List<string> P1inPlayActors = new List<string>() {
                    Constants.P1_FLAG_GROUP, Constants.P1_LINE_GROUP, Constants.P1_BOOST_GROUP, 
                    Constants.P1_COIN_GROUP
                };
                List<string> P2inPlayActors = new List<string>() {
                    Constants.P2_FLAG_GROUP, Constants.P2_LINE_GROUP, Constants.P2_BOOST_GROUP,
                    Constants.P2_COIN_GROUP
                };
                script.ClearAllActions();
                p1_inPlay_screen.PrepareInPlayScene(cast, script, 
                    VideoService, KeyboardService);
                p2_inPlay_screen.PrepareInPlayScene(cast, script, 
                    VideoService, KeyboardService);

                script.AddAction(Constants.INPUT, new ControlCarAction(KeyboardService));
                script.AddAction(Constants.INPUT, new ControlP1SpeedAction(KeyboardService, P1inPlayActors));
                script.AddAction(Constants.INPUT, new ControlP2SpeedAction(KeyboardService, P2inPlayActors));

                script.AddAction(Constants.UPDATE, new MoveP1CarAction());

                script.AddAction(Constants.UPDATE, new MoveP2CarAction());
                script.AddAction(Constants.UPDATE, new CollideBoostAction(PhysicsService, AudioService, P1inPlayActors, P2inPlayActors));
                script.AddAction(Constants.UPDATE, new MoveFlagAction());
                script.AddAction(Constants.UPDATE, new MoveBoostAction());
                script.AddAction(Constants.UPDATE, new MoveCoinAction());
                script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P1_LINE_GROUP));
                script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P2_LINE_GROUP));

                script.AddAction(Constants.UPDATE, new CollideBottomAction(PhysicsService, AudioService));
;


                script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawFlagAction(VideoService, Constants.P1_FLAG_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawFlagAction(VideoService, Constants.P2_FLAG_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawBoostAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawCoinAction(VideoService, Constants.P1_COIN_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCoinAction(VideoService, Constants.P2_COIN_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P2_LINE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCarAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
                script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));


            }
            else if (scene == Constants.P1_FINISH_SCENE || scene == Constants.P2_FINISH_SCENE)
            {
                if (scene == Constants.P1_FINISH_SCENE)
                {
                    p1_finish_screen.PrepareFinishScene(cast);
                    script.AddAction(Constants.UPDATE, 
                        new CollideFinishLineAction(PhysicsService, AudioService, Constants.P1_LINE_GROUP, Constants.P1_CAR_GROUP));

                }
                if (scene == Constants.P2_FINISH_SCENE)
                {
                    p2_finish_screen.PrepareFinishScene(cast);
                    script.AddAction(Constants.UPDATE, 
                        new CollideFinishLineAction(PhysicsService, AudioService, Constants.P2_LINE_GROUP, Constants.P2_CAR_GROUP));
                }            
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddStats(cast);
            AddLevel(cast);
            AddScore(cast);
            AddLives(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.IN_PLAY);
            script.AddAction(Constants.INPUT, a);


            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P2_LINE_GROUP));
            AddInitActions(script);
            AddLoadActions(script);
            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }
        private void PrepareTryAgain(Cast cast, Script script)
        {
            AddDialog(cast, Constants.READY);
            AddDialog(cast, Constants.SET);
            AddDialog(cast, Constants.GO);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            
            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            script.AddAction(Constants.UPDATE, new CollideBottomAction(PhysicsService, AudioService));
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            // AddBall(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));

            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P2_LINE_GROUP));

            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P1_LINE_GROUP));
            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P2_LINE_GROUP));


            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddInputActions(script);
            AddOutputActions(script);
            AddUpdateActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------


        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y - 60);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }
        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddInputActions(Script script)
        {
            script.AddAction(Constants.INPUT, new ControlCarAction(KeyboardService));
            // script.AddAction(Constants.INPUT, new ControlSpeedAction(KeyboardService));
        }
        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            //script.AddAction(Constants.OUTPUT, new DrawBoostAction(VideoService));
            // script.AddAction(Constants.OUTPUT, new DrawBricksAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawCarAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            // script.AddAction(Constants.UPDATE, new MoveBallAction());
            script.AddAction(Constants.UPDATE, new MoveP1CarAction());
            script.AddAction(Constants.UPDATE, new MoveP2CarAction());
            // script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideCarAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}