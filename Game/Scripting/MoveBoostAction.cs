using System;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
namespace MarioRacer.Game.Scripting
{
    public class MoveBoostAction : Action
    {
        public MoveBoostAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Random random = new Random();

            // Background
            List<Actor> backgrounds = cast.GetActors(Constants.BACKGROUND_GROUP);
            Background p1_background = (Background)backgrounds[Constants.P1_BACKGROUND];
            Background p2_background = (Background)backgrounds[Constants.P2_BACKGROUND];
            int p1_roadLeft = p1_background.GetRoadLeft();
            int p1_roadRight = p1_background.GetRoadRight();
            int p2_roadLeft = p2_background.GetRoadLeft();
            int p2_roadRight = p2_background.GetRoadRight();

            // Flag
            Flag p1_flag = (Flag)cast.GetFirstActor(Constants.P1_FLAG_GROUP);
            Flag p2_flag = (Flag)cast.GetFirstActor(Constants.P2_FLAG_GROUP);
            int p1_mileMarker = p1_flag.GetMileMarker();
            int p2_mileMarker = p2_flag.GetMileMarker();

            // Boost
            Boost p1_boost = (Boost)cast.GetFirstActor(Constants.P1_BOOST_GROUP);
            Boost p2_boost = (Boost)cast.GetFirstActor(Constants.P2_BOOST_GROUP);
            Body p1_body = p1_boost.GetBody();
            Body p2_body = p2_boost.GetBody();

            Point p1_position = p1_body.GetPosition();
            Point p1_velocity = p1_body.GetVelocity();
            Point p2_position = p2_body.GetPosition();
            Point p2_velocity = p2_body.GetVelocity();
            
            int p1_boostY = p1_position.GetY();
            int p2_boostY = p2_position.GetY();

            // Move Boost
            if(p1_mileMarker % 2 == 0 && p1_boostY > Constants.BACKGROUND_HEIGHT)
            {
                int p1_NextX = random.Next(p1_roadLeft, p1_roadRight);
                int y1 = 0;
                p1_position = new Point(p1_NextX, y1);
            }
            if(p2_mileMarker % 2 == 0 && p2_boostY > Constants.BACKGROUND_HEIGHT)
            {
                int p2_NextX = random.Next(p2_roadLeft, p2_roadRight);
                int y2 = 0;
                p2_position = new Point(p2_NextX, y2);
            }
            p1_position = p1_position.Add(p1_velocity);
            p2_position = p2_position.Add(p2_velocity);

            p1_body.SetPosition(p1_position);
            p2_body.SetPosition(p2_position);
        }
    }
}