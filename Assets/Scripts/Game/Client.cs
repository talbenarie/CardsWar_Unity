using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;

namespace Game
{
    public class Client
    {
        public GameController Game { get; private set; }
        
        public Client()
        {
            Game = new GameController();
        }
    }
}
