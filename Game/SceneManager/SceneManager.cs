using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
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
        private List<string> P1inPlayActors = new List<string>() {
            Constants.P1_FLAG_GROUP, Constants.P1_LINE_GROUP, Constants.P1_BOOST_GROUP, 
            Constants.P1_COIN_GROUP, Constants.P1_WORMHOLE_GROUP, Constants.P1_BOX_GROUP
        };
        private List<string> P2inPlayActors = new List<string>() {
            Constants.P2_FLAG_GROUP, Constants.P2_LINE_GROUP, Constants.P2_BOOST_GROUP,
            Constants.P2_COIN_GROUP, Constants.P2_WORMHOLE_GROUP, Constants.P2_BOX_GROUP
        };

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            InPlayScreen p1_inPlay_screen = new InPlayScreen(0, 0, 
                p1_cast_groups);
            InPlayScreen p2_inPlay_screen = new InPlayScreen(Constants.CENTER_X, 0, 
                p2_cast_groups);

            FinishScreen p1_finish_screen = new FinishScreen(0, 0, Constants.P1_LINE_GROUP);
            FinishScreen p2_finish_screen = new FinishScreen(Constants.CENTER_X, 0, Constants.P2_LINE_GROUP);
            
            
            if (scene == Constants.NEW_GAME)
            {
                Stopwatch p1_stopwatch = new Stopwatch();
                Stopwatch p2_stopwatch = new Stopwatch();
                StartScreen p1_start_screen = new StartScreen(0, 0, Constants.SCREEN_ONE_CENTER_X, 
                    Constants.P1_CAR_GROUP, Constants.BLUE_CAR_IMAGES, Constants.P1_LINE_GROUP, Constants.P1_ASTEROIDS_GROUP, p1_stopwatch);
                StartScreen p2_start_screen = new StartScreen(Constants.CENTER_X, 0, Constants.SCREEN_TWO_CENTER_X, 
                    Constants.P2_CAR_GROUP, Constants.YELLOW_CAR_IMAGES, Constants.P2_LINE_GROUP, Constants.P2_ASTEROIDS_GROUP, p2_stopwatch);

                p1_start_screen.PrepareNewScene(cast);
                p2_start_screen.PrepareNewScene(cast);
                AddDialog(cast, Constants.ENTER_TO_START);
                List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);
                foreach (Actor actor in stats)
                {
                    Stats stat = (Stats)actor;
                    stat.ResetTime();
                    stat.ResetCoins();
                    stat.ResetItem();
                }

                script.ClearAllActions();

                ChangeSceneAction a = new ChangeSceneAction(KeyboardService, AudioService, Constants.READY);
                script.AddAction(Constants.INPUT, a);
                script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P1_ASTEROIDS_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P2_ASTEROIDS_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P2_LINE_GROUP));
                AddInitActions(script);
                AddLoadActions(script);
                AddOutputActions(script);
                AddUnloadActions(script);
                AddReleaseActions(script);
            }
            else if (scene == Constants.READY)
            {
                Sound sound = new Sound(Constants.START_SOUND);
                AudioService.PlaySound(sound);
                AddDialog(cast, Constants.READY);
                TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.SET, 0.5, DateTime.Now);
                script.AddAction(Constants.INPUT, ta); 
            }
            else if (scene == Constants.SET)
            {
                AddDialog(cast, Constants.SET);
                TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.GO, 0.5, DateTime.Now);
                script.AddAction(Constants.INPUT, ta); 
            }
            else if (scene == Constants.GO)
            {
                AddDialog(cast, Constants.GO);
                TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 0.5, DateTime.Now);
                script.AddAction(Constants.INPUT, ta);
            }
            else if (scene == Constants.IN_PLAY)
            {
                List<Actor> actors = cast.GetActors(Constants.STATS_GROUP);
                foreach(Actor actor in actors)
                {
                    Stats stat = (Stats)actor;
                    stat.StartTime();
                }
                script.ClearAllActions();
                p1_inPlay_screen.PrepareInPlayScene(cast, script, 
                    VideoService, KeyboardService);
                p2_inPlay_screen.PrepareInPlayScene(cast, script, 
                    VideoService, KeyboardService);

                script.AddAction(Constants.INPUT, new ControlCarAction(KeyboardService));
                script.AddAction(Constants.INPUT, new ControlP1SpeedAction(KeyboardService, P1inPlayActors));
                script.AddAction(Constants.INPUT, new ControlP2SpeedAction(KeyboardService, P2inPlayActors));
                script.AddAction(Constants.INPUT, new UseItemAction(KeyboardService, P1inPlayActors, P2inPlayActors));

                // script.AddAction(Constants.UPDATE, new CollideSpecialItemsAction(PhysicsService, P1inPlayActors, P2inPlayActors));
                script.AddAction(Constants.UPDATE, new CollideBoostAction(PhysicsService, AudioService, P1inPlayActors, P2inPlayActors));
                script.AddAction(Constants.UPDATE, new CollideHoleAction(PhysicsService, AudioService, P1inPlayActors, P2inPlayActors));
                script.AddAction(Constants.UPDATE, new CollideCoinAction(PhysicsService, AudioService, P1inPlayActors, P2inPlayActors));
                script.AddAction(Constants.UPDATE, new CollideBoxAction(PhysicsService, AudioService));
                script.AddAction(Constants.UPDATE, new MoveP1CarAction());
                script.AddAction(Constants.UPDATE, new MoveP2CarAction());
                script.AddAction(Constants.UPDATE, new MoveFlagAction());
                script.AddAction(Constants.UPDATE, new MoveBoostAction());
                script.AddAction(Constants.UPDATE, new MoveBoxAction());
                script.AddAction(Constants.UPDATE, new MoveCoinAction());
                script.AddAction(Constants.UPDATE, new MoveHoleAction());
                script.AddAction(Constants.UPDATE, new MoveAsteroidsAction());
                script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P1_LINE_GROUP));
                script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.P2_LINE_GROUP));

                script.AddAction(Constants.UPDATE, new CollideBottomAction(PhysicsService, AudioService));
;


                script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService, Constants.P1_INDEX));
                script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService, Constants.P2_INDEX));
                script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P1_ASTEROIDS_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P2_ASTEROIDS_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawFlagAction(VideoService, Constants.P1_FLAG_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawFlagAction(VideoService, Constants.P2_FLAG_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawBoostAction(VideoService));
                script.AddAction(Constants.OUTPUT, new DrawWormholeAction(VideoService, Constants.P1_WORMHOLE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawWormholeAction(VideoService, Constants.P2_WORMHOLE_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawBoxAction(VideoService, Constants.P1_BOX_GROUP));
                script.AddAction(Constants.OUTPUT, new DrawBoxAction(VideoService, Constants.P2_BOX_GROUP));
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
                foreach(string castGroup in P1inPlayActors)
                {
                    if(castGroup != Constants.P1_LINE_GROUP)
                    {
                        cast.ClearActors(castGroup);
                    }
                }
                foreach(string castGroup in P2inPlayActors)
                {
                    if(castGroup != Constants.P2_LINE_GROUP)
                    {
                        cast.ClearActors(castGroup);
                    }
                }
                PrepareGameOver(cast, script);
                script.AddAction(Constants.INPUT, new ControlP1SpeedAction(KeyboardService, new List<string>(){Constants.P1_LINE_GROUP}));
                script.AddAction(Constants.INPUT, new ControlP2SpeedAction(KeyboardService, new List<string>(){Constants.P2_LINE_GROUP}));
            }
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            // AddBall(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P1_ASTEROIDS_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawAsteroidsAction(VideoService, Constants.P2_ASTEROIDS_GROUP));

            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P1_LINE_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.P2_LINE_GROUP));

            script.AddAction(Constants.UPDATE, new CollideFinishLineAction(PhysicsService, AudioService, Constants.P1_LINE_GROUP, Constants.P1_CAR_GROUP));
            script.AddAction(Constants.UPDATE, new CollideFinishLineAction(PhysicsService, AudioService, Constants.P2_LINE_GROUP, Constants.P2_CAR_GROUP));
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
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService, Constants.P1_INDEX));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService, Constants.P2_INDEX));
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