using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace MarioRacer.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Stats : Actor
    {
        private List<string> items = Constants.ITEMS;
        private string item;
        private int coins;
        private Stopwatch stopwatch;
        private static Point point = new Point(0,0);
        private static Body body = new Body(point, point, point);

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Stats(Stopwatch stopwatch, int coins = 0,
                bool debug = false) : base(debug, body)
        {
            this.item = items[Constants.NO_ITEM_INDEX];
            this.coins = coins;
            this.stopwatch = stopwatch;
        }

        /// <summary>
        /// Adds one coin.
        /// </summary>
        public void IncCoins()
        {
            coins++;
        }

        /// <summary>
        /// Adds an extra life.
        /// </summary>
        public void StartTime()
        {
            stopwatch.Start();
        }

        public void StopTime()
        {
            stopwatch.Stop();
        }

        public void ResetTime()
        {
            stopwatch.Reset();
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The given points.</param>
        public void NewItem()
        {
            Random random = new Random();
            int item_index = random.Next(items.Count);
            while (item_index == 0)
            {
                item_index = random.Next(items.Count);
            }
            item = items[item_index];
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns>The level.</returns>
        public string GetCoins()
        {
            string str_coin = coins.ToString();
            return str_coin;
        }

        public int GetCoinNum()
        {
            return coins;
        }

        /// <summary>
        /// Gets the lives.
        /// </summary>
        /// <returns>The lives.</returns>
        public string GetStopwatch()
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            string time = timeSpan.ToString();
            return time;
        }

        public TimeSpan GetTime()
        {
            TimeSpan time = stopwatch.Elapsed;
            return time;
        }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <returns>The score.</returns>
        public string GetItem()
        {
            return item;
        }

        /// <summary>
        /// Removes a life.
        /// </summary>
        public void ResetCoins()
        {
            coins = 0;
        }

        public void ResetItem()
        {
            item = Constants.ITEMS[Constants.NO_ITEM_INDEX];
        }
        
    }
}