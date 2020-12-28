using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.View.Popups
{
    public class PopupView : MonoBehaviour
    {
        protected GameController _controller;
        
        public void Initialize(GameController controller)
        {
            gameObject.SetActive(true);
            _controller = controller;
        }

        protected void Close()
        {
            gameObject.SetActive(false);
        }

        protected void Home()
        {
            SceneManager.LoadScene("Menu");
        }

        protected void Retry()
        {
            SceneManager.LoadScene("Play");
        }
    }
}