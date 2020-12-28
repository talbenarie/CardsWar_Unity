using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Game.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Popups
{
    public class PausePopup : PopupView
    {
        [SerializeField] private Button _resumeBtn;
        [SerializeField] private Button _homeBtn;
        
        private void Awake()
        {
            _resumeBtn.onClick.AddListener(OnResumeClick);
            _homeBtn.onClick.AddListener(OnHomeClick);
        }

        private void OnHomeClick()
        {
            _controller.Finish(GameController.BattleResult.NONE);
            Home();    
        }
        
        private void OnResumeClick()
        {
            _controller.Resume();
            Close();
        }
    }
}