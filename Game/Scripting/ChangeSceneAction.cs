using System;
using System.Diagnostics;
using System.Collections.Generic;
using MarioRacer.Game.Casting;
using MarioRacer.Game.Services;


namespace MarioRacer.Game.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private AudioService audioService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService,AudioService audioService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.audioService = audioService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Sound sound = new Sound(Constants.START_SOUND);
            if (keyboardService.IsKeyPressed(Constants.ENTER))
            {
                audioService.PlaySound(sound);
                callback.OnNext(nextScene);
            }
        }
    }
}