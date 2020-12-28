using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Popups
{
    public class ResultPopup : PopupView
    {
        [SerializeField] private Button _retryBtn;
        [SerializeField] private Button _homeBtn;
        
        private void Awake()
        {
            _retryBtn.onClick.AddListener(OnRetryClick);
            _homeBtn.onClick.AddListener(OnHomeClick);
        }

        private void OnHomeClick()
        {
            _controller.Finish(GameController.BattleResult.NONE);
            Home();    
        }
        
        private void OnRetryClick()
        {
            Retry();
        }
    }
}