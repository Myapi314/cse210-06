using System;
using System.Collections.Generic;
using System.Diagnostics;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class UseItemAction : Action
    {
        private KeyboardService keyboardService;
        private double speedDelay = 1;
        private double bulletDelay = 3;
        private List<string> p1_movingActorGroups = new List<string>();
        private List<string> p2_movingActorGroups = new List<string>();

        public UseItemAction(KeyboardService keyboardService, List<string> p1_movingActorGroups, List<string> p2_movingActorGroups)
        {
            this.keyboardService = keyboardService;
            this.p1_movingActorGroups = p1_movingActorGroups;
            this.p2_movingActorGroups = p2_movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> stats = cast.GetActors(Constants.STATS_GROUP);
            Stats p1_stat = (Stats)stats[Constants.P1_INDEX];
            Stats p2_stat = (Stats)stats[Constants.P2_INDEX];

            MysteryBox p1_box = (MysteryBox)cast.GetFirstActor(Constants.P1_BOX_GROUP);
            MysteryBox p2_box = (MysteryBox)cast.GetFirstActor(Constants.P2_BOX_GROUP);

            List<Actor> p1_asteroids = cast.GetActors(Constants.P1_ASTEROIDS_GROUP);
            List<Actor> p2_asteroids = cast.GetActors(Constants.P2_ASTEROIDS_GROUP);

            Point slow = new Point(0, Constants.SLOW);
            Point maxSpeed = new Point(0, Constants.MAX_SPEED);

            if (keyboardService.IsKeyDown(Constants.P1_THROW))
            {
                TimeSpan currTime = p1_stat.GetTime();
                string item = p1_stat.GetItem();
                TimeSpan timeBoxHit = p1_box.GetTimeHit();
                TimeSpan elapsed = currTime - timeBoxHit;

                if (item == Constants.ITEMS[Constants.SPEED_ITEM_INDEX])
                {
                    foreach(String group in p1_movingActorGroups)
                    {
                        Actor actor = cast.GetFirstActor(group);
                        Body body = actor.GetBody();
                        body.SetVelocity(maxSpeed);
                    }
                    foreach(Actor asteroid in p1_asteroids)
                    {
                        Body body = asteroid.GetBody();
                        body.SetVelocity(maxSpeed);   
                    }

                    if (elapsed.Seconds > speedDelay)
                    {
                        Console.WriteLine(elapsed);
                        Console.WriteLine("USED SPEED");
                        p1_stat.ResetItem();
                    }
                }
                else if (item == Constants.ITEMS[Constants.BULL_ITEM_INDEX])
                {
                    if (elapsed.Seconds > bulletDelay)
                    {
                        Console.WriteLine("USED BULLET");
                        p1_stat.ResetItem();
                    }
                }
                else if (item == Constants.ITEMS[Constants.SLOW_ITEM_INDEX])
                {                    
                    foreach(String group in p2_movingActorGroups)
                    {
                        Actor actor = cast.GetFirstActor(group);
                        Body body = actor.GetBody();
                        body.SetVelocity(slow);
                    }
                    foreach(Actor asteroid in p1_asteroids)
                    {
                        Body body = asteroid.GetBody();
                        body.SetVelocity(slow);   
                    }
                    if (elapsed.Seconds > speedDelay)
                    {
                        Console.WriteLine("USED SLOW");
                        p1_stat.ResetItem();
                    }
                }
            }

            if (keyboardService.IsKeyDown(Constants.P2_THROW))
            {
                TimeSpan currTime = p2_stat.GetTime();
                string item = p2_stat.GetItem();
                TimeSpan timeBoxHit = p2_box.GetTimeHit();
                TimeSpan elapsed = currTime - timeBoxHit;

                if (item == Constants.ITEMS[Constants.SPEED_ITEM_INDEX])
                {
                    foreach(String group in p2_movingActorGroups)
                    {
                        Actor actor = cast.GetFirstActor(group);
                        Body body = actor.GetBody();
                        body.SetVelocity(maxSpeed);
                    }
                    foreach(Actor asteroid in p2_asteroids)
                    {
                        Body body = asteroid.GetBody();
                        body.SetVelocity(maxSpeed);   
                    }
                    if (elapsed.Seconds > speedDelay)
                    {
                        Console.WriteLine("USED SPEED");
                        p1_stat.ResetItem();
                    }
                }
                else if (item == Constants.ITEMS[Constants.BULL_ITEM_INDEX])
                {
                    if (elapsed.Seconds > bulletDelay)
                    {
                        Console.WriteLine("USED BULLET");
                        p1_stat.ResetItem();
                    }
                }
                else if (item == Constants.ITEMS[Constants.SLOW_ITEM_INDEX])
                {                    
                    foreach(String group in p1_movingActorGroups)
                    {
                        Actor actor = cast.GetFirstActor(group);
                        Body body = actor.GetBody();
                        body.SetVelocity(slow);
                    }
                    foreach(Actor asteroid in p2_asteroids)
                    {
                        Body body = asteroid.GetBody();
                        body.SetVelocity(slow);   
                    }
                    if (elapsed.Seconds > speedDelay)
                    {
                        Console.WriteLine("USED SLOW");
                        p1_stat.ResetItem();
                    }
                }
            }
        }
    }
}