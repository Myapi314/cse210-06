using System;
using System.Collections.Generic;
using System.IO;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Scripting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.FINISH_SCENE)
            {
                PrepareFinishScene(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddBackground(cast);
            AddStats(cast);
            AddLevel(cast);
            AddScore(cast);
            AddLives(cast);
            AddCar(cast);
            AddStart(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);


            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.START_GROUP));

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void ActivateBall(Cast cast)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            ball.Release();
        }

        private void PrepareNextLevel(Cast cast, Script script)
        {
            // AddBall(cast);
            // AddBricks(cast);
            AddFlag(cast);
            AddCar(cast);
            AddStart(cast);
            AddDialog(cast, Constants.READY);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.START_GROUP));

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PrepareTryAgain(Cast cast, Script script)
        {
            // AddBall(cast);
            AddFlag(cast);
            AddCar(cast);
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
            // ActivateBall(cast);
            AddStart(cast);
            AddFlag(cast);
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            ControlCarAction action = new ControlCarAction(KeyboardService);
            script.AddAction(Constants.INPUT, action);

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));

            script.AddAction(Constants.UPDATE, new MoveFlagAction());
            script.AddAction(Constants.OUTPUT, new DrawFlagAction(VideoService));
            script.AddAction(Constants.UPDATE, new CollideBottomAction(PhysicsService, AudioService));

            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.START_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawCheckeredLineAction(VideoService, Constants.START_GROUP));

            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareFinishScene(Cast cast, Script script)
        {
            script.ClearAllActions();

            AddFinish(cast);
            
            CollideFinishLineAction finishAction = new CollideFinishLineAction(PhysicsService, AudioService);
            script.AddAction(Constants.UPDATE, finishAction);

            ControlCarAction carAction = new ControlCarAction(KeyboardService);
            script.AddAction(Constants.INPUT, carAction);

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));

            DrawCheckeredLineAction drawAction = new DrawCheckeredLineAction(VideoService, Constants.FINISH_GROUP);
            script.AddAction(Constants.OUTPUT, drawAction);

            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.FINISH_GROUP));

            AddUpdateActions(script);    
            AddOutputActions(script);

        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            // AddBall(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            script.AddAction(Constants.OUTPUT, new DrawBackgroundAction(VideoService));

            DrawCheckeredLineAction drawAction = new DrawCheckeredLineAction(VideoService, Constants.FINISH_GROUP);
            script.AddAction(Constants.OUTPUT, drawAction);

            script.AddAction(Constants.UPDATE, new MoveCheckeredLineAction(Constants.FINISH_GROUP));
            script.AddAction(Constants.INPUT, new ControlCarAction(KeyboardService));

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
            AddUpdateActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddBall(Cast cast)
        {
            cast.ClearActors(Constants.BALL_GROUP);
        
            int x = Constants.CENTER_X - Constants.BALL_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.CAR_HEIGHT - Constants.BALL_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.BALL_WIDTH, Constants.BALL_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.BALL_IMAGE);
            Ball ball = new Ball(body, image, false);
        
            cast.AddActor(Constants.BALL_GROUP, ball);
        }

        private void AddBackground(Cast cast)
        {
            cast.ClearActors(Constants.BACKGROUND_GROUP);
        
            int x = 0;
            int y = 0;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.BACKGROUND_IMAGE);
            Background background = new Background(body, image, false);
        
            cast.AddActor(Constants.BACKGROUND_GROUP, background);
        }


        private void AddFlag(Cast cast)
        {
            cast.ClearActors(Constants.FLAG_GROUP);
        
            int x = 0;
            int y = 0;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.FLAG_WIDTH, Constants.FLAG_HEIGHT);
            Point velocity = new Point(0, 2);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.FLAG_IMAGE);
            Flag flag = new Flag(body, image, 0, false);
        
            cast.AddActor(Constants.FLAG_GROUP, flag);
        }

        private void AddBricks(Cast cast)
        {
            cast.ClearActors(Constants.BRICK_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            int level = stats.GetLevel() % Constants.BASE_LEVELS;
            string filename = string.Format(Constants.LEVEL_FILE, level);
            List<List<string>> rows = LoadLevel(filename);

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    int x = Constants.ROAD_LEFT + c * Constants.BRICK_WIDTH;
                    int y = Constants.ROAD_TOP + r * Constants.BRICK_HEIGHT;

                    string color = rows[r][c][0].ToString();
                    int frames = (int)Char.GetNumericValue(rows[r][c][1]);
                    int points = Constants.BRICK_POINTS;

                    Point position = new Point(x, y);
                    Point size = new Point(Constants.BRICK_WIDTH, Constants.BRICK_HEIGHT);
                    Point velocity = new Point(0, 0);
                    List<string> images = Constants.BRICK_IMAGES[color].GetRange(0, frames);

                    Body body = new Body(position, size, velocity);
                    Animation animation = new Animation(images, Constants.BRICK_RATE, 1);
                    
                    Brick brick = new Brick(body, animation, points, false);
                    cast.AddActor(Constants.BRICK_GROUP, brick);
                }
            }
        }

        private void AddFinish(Cast cast)
        {
            cast.ClearActors(Constants.FLAG_GROUP);
            cast.ClearActors(Constants.FINISH_GROUP);
            int x = 0;
            int y = 0;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.CHECKERED_WIDTH, Constants.CHECKERED_HEIGHT);
            Point velocity = new Point(0, 2);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.FINISH_IMAGE);
            CheckeredLine finish = new CheckeredLine(body, image, false);
        
            cast.AddActor(Constants.FINISH_GROUP, finish);
        }

        private void AddStart(Cast cast)
        {
            cast.ClearActors(Constants.FLAG_GROUP);
            cast.ClearActors(Constants.START_GROUP);
            int x = 0;
        
            Point position = new Point(x, Constants.CENTER_Y);
            Point size = new Point(Constants.CHECKERED_WIDTH, Constants.CHECKERED_HEIGHT);
            Point velocity = new Point(0, 2);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.START_IMAGE);
            CheckeredLine finish = new CheckeredLine(body, image, false);
        
            cast.AddActor(Constants.START_GROUP, finish);
        }

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

        private void AddCar(Cast cast)
        {
            cast.ClearActors(Constants.CAR_GROUP);
        
            int x = Constants.CENTER_X - Constants.CAR_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.CAR_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.CAR_WIDTH, Constants.CAR_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Animation animation = new Animation(Constants.CAR_IMAGES, Constants.CAR_RATE, 0);
            Car car = new Car(body, animation, false);
        
            cast.AddActor(Constants.CAR_GROUP, car);
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

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            // script.AddAction(Constants.OUTPUT, new DrawBallAction(VideoService));
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
            script.AddAction(Constants.UPDATE, new MoveCarAction());
            // script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideCarAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}