using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private CardsController _cards;
        public GameController()
        {
            _cards = new CardsController();
        }
    }
}
