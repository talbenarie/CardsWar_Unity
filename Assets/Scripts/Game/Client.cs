using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;

namespace Game
{
    public class Client
    {
        private GameController _game;
        public Client()
        {
            _game = new GameController();
        }
    }
}
