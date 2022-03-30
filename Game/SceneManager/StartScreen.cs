using System;
using System.Collections.Generic;
// using System.IO;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Scripting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.SceneManaging
{
    public class StartScreen
    {
        private int start_x;
        private int start_y;
        private int center_x;
        private Point velocity = new Point(0, 0);
        private List<string> carImages = new List<string>();
        private string carGroup;
        private string lineGroup;
        public StartScreen(int x, int y, int center_x, string carGroup, List<string> carImages, string lineGroup)
        {
            this.start_x = x;
            this.start_y = y;
            this.center_x = center_x;
            this.carGroup = carGroup;
            this.carImages = carImages;
            this.lineGroup = lineGroup;
        }

        public void PrepareNewScene(Cast cast)
        {
            AddBackground(cast);
            AddCar(cast, carGroup, carImages);
            AddStartLine(cast);
        }

        // Casting Methods
        private void AddBackground(Cast cast)
        {
            Point position = new Point(start_x, start_y);
            Point size = new Point(Constants.BACKGROUND_WIDTH, Constants.BACKGROUND_HEIGHT);
            
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.BACKGROUND_IMAGE);

            Background background = new Background(body, image, false);

            cast.AddActor(Constants.BACKGROUND_GROUP, background);
        }

        private void AddCar(Cast cast, string carGroup, List<string> carImages)
        {
            cast.ClearActors(carGroup);
            int x = center_x - Constants.CAR_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.CAR_HEIGHT;

            Point position = new Point(x, y);
            Point size = new Point(Constants.CAR_WIDTH, Constants.CAR_HEIGHT);
            
            Body body = new Body(position, size, velocity);
            Animation animation = new Animation(carImages, Constants.CAR_RATE, 0);
            Car car = new Car(body, animation, false);

            cast.AddActor(carGroup, car);
        }

        private void AddStartLine(Cast cast)
        {
            cast.ClearActors(lineGroup);
            int y = (Constants.SCREEN_HEIGHT - (Constants.CAR_HEIGHT + Constants.CHECKERED_HEIGHT));
        
            Point position = new Point(start_x, y);
            Point size = new Point(Constants.CHECKERED_WIDTH, Constants.CHECKERED_HEIGHT);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.START_IMAGE);
            CheckeredLine checkeredLine = new CheckeredLine(body, image, false);
        
            cast.AddActor(lineGroup, checkeredLine);
        }

        // Scripting Methods
    }
}