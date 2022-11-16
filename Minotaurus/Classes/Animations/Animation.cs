using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

        public List<AnimationFrame> frames;

        private double secondCounter;
        public int counter;
        private int fps { get; set; }

        public Animation(int fps)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void FrameCheck(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1d / this.fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
