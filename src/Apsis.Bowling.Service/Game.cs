using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Newtonsoft.Json;

namespace Apsis.Bowling.Service
{
    public class Game : IGame
    {
        public Game(int numberOfFrames)
        {
            NumberOfRounds = numberOfFrames;

            Frames = new Frame[numberOfFrames];
        }

        public int NumberOfRounds { get; set; }

        [JsonProperty("frames")]
        public Frame[] Frames { get; set; }

        [JsonProperty("score")]
        public int Score => Frames.Where(x => x != null).Max(x => x.FrameScore);

        public Frame this[int index]
        {
            get
            {
                return (index < Frames.Count() && Frames[index] != null) ? Frames[index] : null;
            }
            set
            {
                Frames[index] = value;
            }
        }
    }
}