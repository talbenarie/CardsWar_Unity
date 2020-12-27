using System;
using System.Collections;
using System.Collections.Generic;
using Game.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Controller
{
    public class OnCardDrawEvent : UnityEvent<CardModel> { }
    public class OnCardsOverEvent : UnityEvent { }
    
    [Serializable]
    public class PlayerController
    {
        [SerializeField] private CardsController _cards;
        [SerializeField] private Stack<CardModel> _playerCards;
        [SerializeField] private int cardsAmount = -1;

        public OnCardDrawEvent OnCardDraw;
        public OnCardsOverEvent OnCardsOver;
        
        public PlayerController(CardsController cards)
        {
            _cards = cards;
            OnCardDraw = new OnCardDrawEvent();
            OnCardsOver = new OnCardsOverEvent();
        }

        public void Start()
        {
            _playerCards = _cards.GetCards(cardsAmount);
            cardsAmount = _playerCards.Count;
        }

        public void Draw()
        {
            if (_playerCards.Count == 0)
            {
                OnCardsOver.Invoke();
                return;
            }
            
            CardModel card = _playerCards.Pop();
            OnCardDraw.Invoke(card);
        }

        public int GetCardsLeft()
        {
            return _playerCards.Count;
        }
    }
}