using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.View.Addons;
using Game.View.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class PlayView : MonoBehaviour
    {
        [SerializeField] private Button _drawBtn;
        [SerializeField] private CardView _playerCard;
        [SerializeField] private CardView _enemyCard;
        [SerializeField] private CardCounterView _playerCounter;
        [SerializeField] private CardCounterView _enemyCounter;
        [SerializeField] private TimerTextFieldView _timer;
        [SerializeField] private Button _menuBtn;
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private ResultPopup _lostPopupTime;
        [SerializeField] private ResultPopup _lostPopupCards;
        [SerializeField] private ResultPopup _wonPopup;

        private GameController _controller;

        private void Awake()
        {
            _drawBtn.onClick.AddListener(OnDrawClick);
            _menuBtn.onClick.AddListener(OnMenuClick);
        }
        
        private void Start()
        {
            _controller = Main.Instance.Client.Game;

            InitializeView();
            AddEventListeners();
            _controller.Start();
        }

        private void InitializeView()
        {
            _playerCounter.Initialize(_controller.Player, _playerCard);
            _enemyCounter.Initialize(_controller.Opponent, _enemyCard);
            _timer.Initialize(DateTime.Now + new TimeSpan(0, 1, 0));
        }

        private void AddEventListeners()
        {
            _timer.OnTimerFinished.AddListener(OnTimerFinished);
            _controller.OnGameOver.AddListener(OnGameFinished);
            _controller.OnGamePaused.AddListener(OnGamePaused);
            _controller.OnGameResumed.AddListener(OnGameResumed);
        }

        private void OnDrawClick()
        {
            _controller.DrawCard();
        }
        
        private void OnMenuClick()
        {
            _controller.Pause();
        }

        private void OnTimerFinished()
        {
            _controller.Finish(GameController.BattleResult.LOST_TIME);
        }

        private void OnGameFinished()
        {
            GameController.BattleResult result = _controller.GetBattleResult();
            switch (result)
            {
                case GameController.BattleResult.WON:
                    _wonPopup.Initialize(_controller);
                    break;
                case GameController.BattleResult.LOST_TIME:
                    _lostPopupTime.Initialize(_controller);
                    break;
                case GameController.BattleResult.LOST_CARDS:
                    _lostPopupCards.Initialize(_controller);
                    break;
            }
        }

        private void OnGamePaused()
        {
            _timer.Pause();
            _pausePopup.Initialize(_controller);
        }
        
        private void OnGameResumed()
        {
            _timer.Resume();
        }
    }
}
