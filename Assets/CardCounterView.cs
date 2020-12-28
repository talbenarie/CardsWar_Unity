using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.Model;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public class CardCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private PlayerController _player;
        [SerializeField] private CardView _card;

        public void Initialize(PlayerController player, CardView card)
        {
            _card = card;
            _player = player;
            _player.OnCardDraw.AddListener(OnCardDrawn);
            _player.OnCardsUpdated.AddListener(OnCardsUpdated);
        }

        private void OnCardsUpdated()
        {
            _count.text = _player.GetCardsLeft().ToString();
        }
        
        private void OnCardDrawn(CardModel card)
        {
            _card.Initialize(card);
            OnCardsUpdated();
        }
    }
}