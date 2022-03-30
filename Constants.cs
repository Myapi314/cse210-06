using System.Collections.Generic;
using MarioRacer.Game.Casting;


namespace MarioRacer
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Drag Race Mario";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1800;
        public static int SCREEN_HEIGHT = 1000;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;
        public static int SCREEN_ONE_CENTER_X = CENTER_X / 2;
        public static int SCREEN_TWO_CENTER_X = SCREEN_ONE_CENTER_X + CENTER_X;

        // ROAD
        public static int ROAD_BOTTOM = SCREEN_HEIGHT;
        public static int P1_ROAD_LEFT = 200;
        public static int P1_ROAD_RIGHT = CENTER_X - 250;
        public static int P2_ROAD_LEFT = CENTER_X + 200;
        public static int P2_ROAD_RIGHT = SCREEN_WIDTH - 250;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string P2_LEFT = "left";
        public static string P2_RIGHT = "right";
        public static string P2_UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";
        public static string P1_UP = "w";
        public static string P1_LEFT = "a";
        public static string P1_RIGHT = "d";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string P1_FINISH_SCENE = "p1_finish_scene";
        public static string P2_FINISH_SCENE = "p2_finish_scene";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;
        public static int MILES = 1;
        public static int SPEED = 8;
        public static int SLOW = 1;
        public static int MAX_SPEED = 8;
        public static int REVERSE = -2;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // BALL
        public static string BALL_GROUP = "balls";
        public static string BALL_IMAGE = "Assets/Images/000.png";
        public static int BALL_WIDTH = 28;
        public static int BALL_HEIGHT = 28;
        public static int BALL_VELOCITY = 6;

        // CAR
        public static string P1_CAR_GROUP = "playerOneCar";
        public static string P2_CAR_GROUP = "playerTwoCar";
        
        public static List<string> YELLOW_CAR_IMAGES
            = new List<string>() {
                "Assets/Images/100.png",
                "Assets/Images/101.png",
                "Assets/Images/102.png"
            };

        public static List<string> GREEN_CAR_IMAGES
            = new List<string>() {
                "Assets/Images/110.png",
                "Assets/Images/111.png",
                "Assets/Images/112.png"
            };

        public static List<string> BLUE_CAR_IMAGES
            = new List<string>() {
                "Assets/Images/120.png",
                "Assets/Images/121.png",
                "Assets/Images/122.png"
            };

        public static List<string> RED_CAR_IMAGES
            = new List<string>() {
                "Assets/Images/130.png",
                "Assets/Images/131.png",
                "Assets/Images/132.png"
            };
        public static int CAR_WIDTH = 106;
        public static int CAR_HEIGHT = 200;
        public static int CAR_RATE = 6;
        public static int CAR_VELOCITY = 7;

        // BRICK
        public static string BRICK_GROUP = "bricks";
        
        public static Dictionary<string, List<string>> BRICK_IMAGES
            = new Dictionary<string, List<string>>() {
                { "b", new List<string>() {
                    "Assets/Images/010.png",
                    "Assets/Images/011.png",
                    "Assets/Images/012.png",
                    "Assets/Images/013.png",
                    "Assets/Images/014.png",
                    "Assets/Images/015.png",
                    "Assets/Images/016.png",
                    "Assets/Images/017.png",
                    "Assets/Images/018.png"
                } },
                { "g", new List<string>() {
                    "Assets/Images/020.png",
                    "Assets/Images/021.png",
                    "Assets/Images/022.png",
                    "Assets/Images/023.png",
                    "Assets/Images/024.png",
                    "Assets/Images/025.png",
                    "Assets/Images/026.png",
                    "Assets/Images/027.png",
                    "Assets/Images/028.png"
                } },
                { "p", new List<string>() {
                    "Assets/Images/030.png",
                    "Assets/Images/031.png",
                    "Assets/Images/032.png",
                    "Assets/Images/033.png",
                    "Assets/Images/034.png",
                    "Assets/Images/035.png",
                    "Assets/Images/036.png",
                    "Assets/Images/037.png",
                    "Assets/Images/038.png"
                } },
                { "y", new List<string>() {
                    "Assets/Images/040.png",
                    "Assets/Images/041.png",
                    "Assets/Images/042.png",
                    "Assets/Images/043.png",
                    "Assets/Images/044.png",
                    "Assets/Images/045.png",
                    "Assets/Images/046.png",
                    "Assets/Images/047.png",
                    "Assets/Images/048.png"
                } }
        };
        public static int BRICK_WIDTH = 80;
        public static int BRICK_HEIGHT = 28;
        public static double BRICK_DELAY = 0.5;
        public static int BRICK_RATE = 4;
        public static int BRICK_POINTS = 50;
         
         //COIN
        public static string P1_COIN_GROUP = "p1_coins";
        public static string P2_COIN_GROUP = "p2_coins";

        public static List<string> COIN_IMAGES
            = new List<string>(){
                "Assets/Images/300.png",
                "Assets/Images/301.png",
                "Assets/Images/302.png",
                "Assets/Images/303.png",

            };
            public static int COIN_WIDTH = 85;
            public static int COIN_HEIGHT = 85;
            public static double COIN_DELAY = 0.5;
            public static int COIN_RATE = 4;

        //WORMHOLE
            public static string P1_WORMHOLE_GROUP = "p1_wormhole";
            public static string P2_WORMHOLE_GROUP = "p2_wormhole";
            public static string WORMHOLE_IMAGE = "Assets/Images/311.png";
            public static int WORMHOLE_WIDTH = 85;
            public static int WORMHOLE_HEIGHT = 85; 
        
        //COMET
            public static string P1_COMET_GROUP = "p1_comet";
            public static string P2_COMET_GROUP = "p2_comet";
            public static string COMET_IMAGE = "Assets/Images/312.png";
            public static int COMET_WIDTH = 95;
            public static int COMET_HEIGHT = 95; 
        
        //MYSTERY BOX
            public static string P1_BOX_GROUP = "p1_box";
            public static string P2_BOX_GROUP = "p2_box";
            public static string BOX_IMAGE = "Assets/Images/310.png";
            public static int BOX_WIDTH = 85;
            public static int BOX_HEIGHT = 85;
        
        //BULLET
            public static string P1_BULLET_GROUP = "p1_bullet";
            public static string P2_BULLET_GROUP = "p2_bullet";
            public static string BULLET_IMAGE = "Assets/Images/310.png";
            public static int BULLET_WIDTH = 50;
            public static int BULLET_HEIGHT = 50;

         //SPEED BOOST
        public static string BOOST_GROUP = "boost";
        public static string BOOST_IMAGE = "Assets/Images/000.png";
        public static int BOOST_WIDTH = 85;
        public static int BOOST_HEIGHT = 85;

        // FLAG
        public static string P1_FLAG_GROUP = "p1_flag";
        public static string P2_FLAG_GROUP = "p2_flag";
        public static string FLAG_IMAGE = "Assets/Images/flag.png";
        public static int FLAG_WIDTH = 100;
        public static int FLAG_HEIGHT = 35;
        public static double FLAG_DELAY = 0.5;
        public static int FLAG_RATE = 4;

        // CHECKERED LINE
        public static string P1_LINE_GROUP = "p1_line";
        public static string P2_LINE_GROUP = "p2_line";
        public static string FINISH_IMAGE = "Assets/Images/200.png";
        public static int FINISH_POSITION = 0;
        public static int CHECKERED_WIDTH = 900;
        public static int CHECKERED_HEIGHT = 100;

        // START LINE
        public static string START_IMAGE = "Assets/Images/201.png";

        // BACKGROUND
        public static string BACKGROUND_GROUP = "background";
        public static int BACKGROUND_WIDTH = 900;
        public static int BACKGROUND_HEIGHT = SCREEN_HEIGHT;
        public static string BACKGROUND_IMAGE = "Assets/Images/203.png";

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string READY = "READY...";
        public static string SET = "SET...";
        public static string GO = "GO!";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}