using System;
using System.Collections;
using System.Collections.Generic;
using Game.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Controller
{
    public class GameController
    {
        public enum BattleResult
        {
            NONE = 0,
            LOST_TIME = 1,
            LOST_CARDS = 2,
            WON = 3
        }

        public CardsController Cards { get; private set; }
        public PlayerController Player { get; private set; }
        public PlayerController Opponent { get; private set; }

        public class OnGameOverEvent : UnityEvent
        {
        }

        public OnGameOverEvent OnGameOver = new OnGameOverEvent();

        public class OnGamePauseEvent : UnityEvent
        {
        }

        public OnGamePauseEvent OnGamePaused = new OnGamePauseEvent();

        public class OnGameResumeEvent : UnityEvent
        {
        }

        public OnGameResumeEvent OnGameResumed = new OnGameResumeEvent();

        private bool _active = false;
        private BattleResult _result = BattleResult.NONE;


        public GameController()
        {
            Cards = new CardsController();
            Player = new PlayerController(Cards);
            Opponent = new PlayerController(Cards);

            Player.OnCardsOver.AddListener(OnCardsFinished);
            Opponent.OnCardsOver.AddListener(OnCardsFinished);
        }

        public void Start()
        {
            Cards.Restart();
            Player.Start();
            Opponent.Start();

            _active = true;
        }

        public void Pause()
        {
            OnGamePaused.Invoke();
        }

        public void Resume()
        {
            OnGameResumed.Invoke();
        }

        public void Finish(BattleResult result)
        {
            _result = result;
            _active = false;
            OnGameOver.Invoke();
        }

        public void DrawCard()
        {
            if (!_active)
            {
                return;
            }

            CardModel playerCard = Player.Draw();
            CardModel opponentCard = Opponent.Draw();

            if (playerCard == null || opponentCard == null)
            {
                // game has ended
                return;
            }

            // player won
            if (playerCard.Worth >= opponentCard.Worth)
            {
                Player.AddCard(playerCard);
                Player.AddCard(opponentCard);
            }
            else
            {
                Opponent.AddCard(opponentCard);
                Opponent.AddCard(playerCard);
            }
        }

        public bool IsActive()
        {
            return _active;
        }

        public BattleResult GetBattleResult()
        {
            return _result;
        }

        private void OnCardsFinished()
        {
            if (Player.GetCardsLeft() > 0)
            {
                Finish(BattleResult.WON);
            }
            else
            {
                Finish(BattleResult.LOST_CARDS);
            }
        }
    }
}
