using Newtonsoft.Json;

namespace Apsis.Bowling.Service
{
    [JsonObject("frames")]
    public class Frame
    {
        private int _first;
        private int _second;

        [JsonProperty("first")]
        public int First
        {
            get { return _first; }
            set
            {
                if (value > 10)
                {
                    _first = 0;
                    return;
                }
                _first = value;
            }
        }

        [JsonProperty("second")]
        public int Second
        {
            get { return _second; }
            set
            {
                if (value > 10)
                {
                    _second = 0;
                    return;
                }

                _second = value;
            }
        }

        [JsonProperty("third")]
        public int Third { get; set; }

        [JsonProperty("isFinished")]
        public bool IsFinished { get; set; }

        [JsonProperty("frametype")]
        public FrameType FrameType
        {
            get
            {
                if (First == 10)
                {
                    return FrameType.Strike;
                }

                if (First + Second >= 10)
                {
                    return FrameType.Spare;
                }

                return FrameType.Open;
            }
        }


        [JsonProperty("framescore")]
        public int FrameScore { get; set; }

    }
}