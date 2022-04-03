using System;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveCoinAction : Action
    {
        public MoveCoinAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Random random = new Random();

            // Background
            List<Actor> backgrounds = cast.GetActors(Constants.BACKGROUND_GROUP);
            Background p1_background = (Background)backgrounds[Constants.P1_INDEX];
            Background p2_background = (Background)backgrounds[Constants.P2_INDEX];
            int p1_roadLeft = p1_background.GetRoadLeft();
            int p1_roadRight = p1_background.GetRoadRight();
            int p2_roadLeft = p2_background.GetRoadLeft();
            int p2_roadRight = p2_background.GetRoadRight();

            // Coin
            Coin p1_coin = (Coin)cast.GetFirstActor(Constants.P1_COIN_GROUP);
            Coin p2_coin = (Coin)cast.GetFirstActor(Constants.P2_COIN_GROUP);
            Body p1_coinBody = p1_coin.GetBody();
            Body p2_coinBody = p2_coin.GetBody();
            
            Point p1_coinPosition = p1_coinBody.GetPosition();
            Point p1_coinVelocity = p1_coinBody.GetVelocity();
            Point p2_coinPosition = p2_coinBody.GetPosition();
            Point p2_coinVelocity = p2_coinBody.GetVelocity();
            
            int p1_coinY = p1_coinPosition.GetY();
            int p2_coinY = p2_coinPosition.GetY();

            // Move Coin
            int coin_var = random.Next(0, 60);
            if(coin_var == 1 && p1_coinY > Constants.BACKGROUND_HEIGHT)
            {
                int x1 = random.Next(p1_roadLeft, p1_roadRight);
                int y1 = 0;
                p1_coinPosition = new Point(x1, y1);
            }
            else{
                p1_coin.StopMoving();
            }
            if(coin_var == 1 && p2_coinY > Constants.BACKGROUND_HEIGHT)
            {
                int x2 = random.Next(p2_roadLeft, p2_roadRight);
                int y2 = 0;
                p2_coinPosition = new Point(x2, y2);
            }
            else
            {
                p1_coin.StopMoving();
            }
            p1_coinPosition = p1_coinPosition.Add(p1_coinVelocity);
            p2_coinPosition = p2_coinPosition.Add(p2_coinVelocity);

            p1_coinBody.SetPosition(p1_coinPosition);
            p2_coinBody.SetPosition(p2_coinPosition);
        }
    }
}