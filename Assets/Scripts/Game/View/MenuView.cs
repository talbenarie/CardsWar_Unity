using System;
using System.Collections;
using System.Collections.Generic;
using Game.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.View
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private CardView[] cards;
        [SerializeField] private Button playBtn;

        private void Awake()
        {
            playBtn.onClick.AddListener(OnPlayClick);
        }

        private void Start()
        {
            cards[0].Initialize(new CardModel(0, 11));
            cards[1].Initialize(new CardModel(3, 12));
        }
        
        
        private void OnPlayClick()
        {
            SceneManager.LoadScene("Play");
        }
    }
}