﻿using System;

namespace WalkingGame
{
    /// <summary>
    /// Event loop class
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Perpetual program run loop
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                EmulatePress(key.Key);
            }
        }

        /// <summary>
        /// Analyzes and handles key presses and key press emulations
        /// </summary>
        /// <param name="key">Keyboard or emulated input</param>
        public void EmulatePress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        RightHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        UpHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        DownHandler(this, EventArgs.Empty);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
