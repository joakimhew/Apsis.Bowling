using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apsis.Bowling.Service;
using Newtonsoft.Json;

namespace Apsis.Bowling.Web.Controllers
{
    public class ScoreController : Controller
    {
        private readonly IGameHandler _gameHandler;

        public ScoreController(IGameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("score/submit")]
        public string SubmitFrames(Frame[] frames)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];

                _gameHandler.Game.Frames[i] = new Frame
                {
                    First = frame.First,
                    Second = frame.Second,
                    IsFinished = frame.IsFinished,
                    Third = frame.Third
                };
            }

            _gameHandler.CalculateFrameScore();

            var json = JsonConvert.SerializeObject(_gameHandler.Game);

            return json;
        }
    }
}