using System;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveHoleAction : Action
    {
        public MoveHoleAction()
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
            int p1_mileMarker = p1_flag.GetMileMarker();
            int p2_mileMarker = p2_flag.GetMileMarker();

            // Wormhole
            Wormhole p1_hole = (Wormhole)cast.GetFirstActor(Constants.P1_WORMHOLE_GROUP);
            Wormhole p2_hole = (Wormhole)cast.GetFirstActor(Constants.P2_WORMHOLE_GROUP);
            Body p1_body = p1_hole.GetBody();
            Body p2_body = p2_hole.GetBody();

            Point p1_position = p1_body.GetPosition();
            Point p1_velocity = p1_body.GetVelocity();
            Point p2_position = p2_body.GetPosition();
            Point p2_velocity = p2_body.GetVelocity();
            
            int p1_y = p1_position.GetY();
            int p2_y = p2_position.GetY();

            // Move Boost
            int place = random.Next(1, 3);
            if(p1_mileMarker % place == 0 && p1_y > Constants.BACKGROUND_HEIGHT)
            {
                int x = random.Next(p1_roadLeft, p1_roadRight);
                int y = 0;
                p1_position = new Point(x, y);
            }
            if(p2_mileMarker % place == 0 && p2_y > Constants.BACKGROUND_HEIGHT)
            {
                int x = random.Next(p2_roadLeft, p2_roadRight);
                int y = 0;
                p2_position = new Point(x, y);
            }
            p1_position = p1_position.Add(p1_velocity);
            p2_position = p2_position.Add(p2_velocity);

            p1_body.SetPosition(p1_position);
            p2_body.SetPosition(p2_position);
        }
    }
}