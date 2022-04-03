using System;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveBoxAction : Action
    {
        public MoveBoxAction()
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

            // Flag
            Flag p1_flag = (Flag)cast.GetFirstActor(Constants.P1_FLAG_GROUP);
            Flag p2_flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);
            int p1_miles = p1_flag.GetMileMarker();
            int p2_miles = p2_flag.GetMileMarker();

            // Box
            MysteryBox p1_box = (MysteryBox)cast.GetFirstActor(Constants.P1_BOX_GROUP);
            MysteryBox p2_box = (MysteryBox)cast.GetFirstActor(Constants.P2_BOX_GROUP);
            Body p1_boxBody = p1_box.GetBody();
            Body p2_boxBody = p2_box.GetBody();
            
            Point p1_boxPosition = p1_boxBody.GetPosition();
            Point p1_boxVelocity = p1_boxBody.GetVelocity();
            Point p2_boxPosition = p2_boxBody.GetPosition();
            Point p2_boxVelocity = p2_boxBody.GetVelocity();
            
            int p1_boxY = p1_boxPosition.GetY();
            int p2_boxY = p2_boxPosition.GetY();

            // Move Box
            if(p1_miles % 2 == 0 && p1_boxY > Constants.BACKGROUND_HEIGHT)
            {
                int x1 = random.Next(p1_roadLeft, p1_roadRight);
                int y1 = 0;
                p1_boxPosition = new Point(x1, y1);
            }
            // else{
            //     p1_coin.StopMoving();
            // }
            if(p2_miles % 2 == 0 && p2_boxY > Constants.BACKGROUND_HEIGHT)
            {
                int x2 = random.Next(p2_roadLeft, p2_roadRight);
                int y2 = 0;
                p2_boxPosition = new Point(x2, y2);
            }
            // else
            // {
            //     p1_coin.StopMoving();
            // }
            p1_boxPosition = p1_boxPosition.Add(p1_boxVelocity);
            p2_boxPosition = p2_boxPosition.Add(p2_boxVelocity);

            p1_boxBody.SetPosition(p1_boxPosition);
            p2_boxBody.SetPosition(p2_boxPosition);
        }
    }
}