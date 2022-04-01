using MarioRacer.Game.Casting;
using MarioRacer.Game.Scripting;

namespace MarioRacer.Game.SceneManaging
{
    public class FinishScreen
    {
        private int start_x;
        private int start_y;
        private string lineGroup;
        private Point velocity = new Point(0, 0);
        public FinishScreen(int x, int y, string lineGroup)
        {
            this.start_x = x;
            this.start_y = y;
            this.lineGroup = lineGroup;
        }

        public void PrepareFinishScene(Cast cast)
        {
            // cast.ClearActors(Constants.P1_FLAG_GROUP);
            // cast.ClearActors(Constants.P2_FLAG_GROUP);
            // cast.ClearActors(Constants.P1_BOOST_GROUP);
            // cast.ClearActors(Constants.P2_BOOST_GROUP);

            AddFinish(cast);
        }

        private void AddFinish(Cast cast)
        {
            cast.ClearActors(lineGroup);

            Point position = new Point(start_x, start_y);
            Point size = new Point(Constants.CHECKERED_WIDTH, Constants.CHECKERED_HEIGHT);

            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.FINISH_IMAGE);

            CheckeredLine checkeredLine = new CheckeredLine(body, image, false);

            cast.AddActor(lineGroup, checkeredLine);
        }
    }
}