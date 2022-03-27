using System;
using MarioRacer.Game.Directing;
using MarioRacer.Game.Services;
using MarioRacer.Game.SceneManaging;

namespace MarioRacer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
