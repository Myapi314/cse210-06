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
        public static int ROAD_LEFT = 200;
        public static int ROAD_RIGHT = 250;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";
        public static string START_SOUND = "Assets/Sounds/startup.mp3";

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
        public static string P2_THROW = "space";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";
        public static string P1_UP = "w";
        public static string P1_THROW = "e";
        public static string P1_LEFT = "a";
        public static string P1_RIGHT = "d";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string IN_PLAY = "in_play";
        public static string P1_FINISH_SCENE = "p1_finish_scene";
        public static string P2_FINISH_SCENE = "p2_finish_scene";
        public static string GAME_OVER = "game_over";

        // INDEXES
        public static int P1_INDEX = 0;
        public static int P2_INDEX = 1;
        public static int CAR_INDEX = 0;
        public static int BOOST_INDEX = 1;
        public static int FLAG_INDEX = 2;
        public static int LINE_INDEX = 3;
        public static int COIN_INDEX = 4;
        public static int WORMHOLE_INDEX = 5;
        public static int COMET_INDEX = 6;
        public static int BOX_INDEX = 7;
        public static int BULLET_INDEX = 8;

        // SPEED
        public static int MILES = 10;
        public static int SPEED = 8;
        public static int COIN_SPEED = 10;
        public static int SLOW = 1;
        public static int MAX_SPEED = 16;
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
        public static List<string> ITEMS = new List<string>(){
            "none", "bullet", "boost" , "slow"
        };

        public static int NO_ITEM_INDEX = 0;
        public static int BULL_ITEM_INDEX = 1;
        public static int SPEED_ITEM_INDEX = 2;
        public static int SLOW_ITEM_INDEX = 3;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string ITEMS_GROUP = "items";
        public static string COINS_GROUP = "coin_cnt";
        public static string TIME_GROUP = "time";
        public static string ITEMS_FORMAT = "ITEM: {0}";
        public static string COINS_FORMAT = "COINS: {0}";
        public static string TIME_FORMAT = "TIME: {0}";

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
        public static string P1_ASTEROIDS_GROUP = "p1_asteroids";
        public static string P2_ASTEROIDS_GROUP = "p2_asteroids";
        
        public static List<string> ASTEROID_IMAGES
            = new List<string>() {
                    "Assets/Images/010.png",
                    "Assets/Images/011.png",
                    "Assets/Images/012.png",
                    "Assets/Images/013.png",
                    "Assets/Images/014.png",
                    "Assets/Images/015.png",
                    "Assets/Images/016.png",
                    "Assets/Images/017.png",
                    "Assets/Images/018.png",
                    "Assets/Images/020.png",
                    "Assets/Images/021.png",
                    "Assets/Images/022.png"                
        };
        public static int ASTEROID_WIDTH = 25;
        public static int ASTEROID_HEIGHT = 30;
        public static int ASTEROID_RATE = 4;
        public static int DEFAULT_ASTEROIDS = 50;

         //SPEED BOOST
        public static string P1_BOOST_GROUP = "p1_boost";
        public static string P2_BOOST_GROUP = "p2_boost";
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
        public static double COIN_DELAY = 1;
        public static int COIN_RATE = 4;

        //WORMHOLE
        public static string P1_WORMHOLE_GROUP = "p1_wormhole";
        public static string P2_WORMHOLE_GROUP = "p2_wormhole";
        public static string WORMHOLE_IMAGE = "Assets/Images/311.png";
        public static int WORMHOLE_WIDTH = 75;
        public static int WORMHOLE_HEIGHT = 75; 
        
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
        public static string BULLET_IMAGE = "Assets/Images/313.png";
        public static int BULLET_WIDTH = 50;
        public static int BULLET_HEIGHT = 50;

        // BACKGROUND
        public static string BACKGROUND_GROUP = "background";
        public static int BACKGROUND_WIDTH = CENTER_X;
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