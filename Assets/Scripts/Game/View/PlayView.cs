using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.View.Addons;
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

        private GameController _controller;

        private void Awake()
        {
            _drawBtn.onClick.AddListener(OnDrawClick);
            _menuBtn.onClick.AddListener(OnMenuClick);
        }
        
        private void Start()
        {
            _controller = Main.Instance.Client.Game;
            _playerCounter.Initialize(_controller.Player, _playerCard);
            _enemyCounter.Initialize(_controller.Opponent, _enemyCard);
            _timer.Initialize(DateTime.Now + new TimeSpan(0, 5, 0)); 
            _controller.Start();
        }

        private void OnDrawClick()
        {
            _controller.DrawCard();
        }
        
        private void OnMenuClick()
        {
            //
        }

       
    }
}
