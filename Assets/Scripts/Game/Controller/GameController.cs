using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        public CardsController Cards { get; private set; }
        public PlayerController Player  { get; private set; }
        public PlayerController Opponent  { get; private set; }

        private bool _active = false;
        
        public GameController()
        {
            Cards = new CardsController();
            Player = new PlayerController(Cards);
            Opponent = new PlayerController(Cards);
        }

        public void Start()
        {
            Cards.Restart();
            Player.Start();
            Opponent.Start();

            // game has started
            _active = true;
        }

        public void DrawCard()
        {
            Player.Draw();
            Opponent.Draw();
        }

        public bool IsActive()
        {
            return _active;
        }
    }
}
