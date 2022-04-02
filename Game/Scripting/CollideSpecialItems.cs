using System.Collections.Generic;
using System;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class CollideSpecialItemsAction : Action
    {
        private PhysicsService physicsService;
        private List<string> p1_movingActorGroups = new List<string>();
        private List<string> p2_movingActorGroups = new List<string>();
        
        public CollideSpecialItemsAction(PhysicsService physicsService,  
            List<string> p1_movingActorGroups, List<string> p2_movingActorGroups)
        {
            this.physicsService = physicsService;
            this.p1_movingActorGroups = p1_movingActorGroups;
            this.p2_movingActorGroups = p2_movingActorGroups;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            foreach(string group in p1_movingActorGroups)
                {
                    Actor actor = cast.GetFirstActor(group);
                    Body mainBody = actor.GetBody();
                    foreach(string group1 in p1_movingActorGroups)
                    {
                        Actor actor1 = cast.GetFirstActor(group1);
                        Body secondBody = actor1.GetBody();
                        if (physicsService.HasCollided(mainBody, secondBody))
                        {
                            Point pos = secondBody.GetPosition();
                            int x = pos.GetX();
                            int y = pos.GetY();
                            int n = x + 100;
                            pos = new Point(n, y);
                            secondBody.SetPosition(pos);
                        }
                    }
                }

            foreach(string group in p2_movingActorGroups)
                {
                    Actor actor = cast.GetFirstActor(group);
                    Body mainBody = actor.GetBody();
                    foreach(string group1 in p2_movingActorGroups)
                    {
                        Actor actor1 = cast.GetFirstActor(group1);
                        Body secondBody = actor1.GetBody();
                        if (physicsService.HasCollided(mainBody, secondBody))
                        {
                            Point pos = secondBody.GetPosition();
                            int x = pos.GetX();
                            int y = pos.GetY();
                            x = x + 100;
                            pos = new Point(x, y);
                            secondBody.SetPosition(pos);
                        }
                    }
                }
        }
    }
}