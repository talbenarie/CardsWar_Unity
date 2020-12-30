using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Controller
{
    public class PlayerController
    {
        private CardsController _cards;
        private Stack<CardModel> _playerCards;
        private int _cardsAmount = -1;

        public class OnCardDrawEvent : UnityEvent<CardModel> { }
        public OnCardDrawEvent OnCardDraw = new OnCardDrawEvent();
        public UnityEvent OnCardsOver = new UnityEvent();
        public UnityEvent OnCardsUpdated = new UnityEvent();

        public PlayerController(CardsController cards)
        {
            _cards = cards;
        }

        public void Start()
        {
            _playerCards = _cards.GetCards(-1);
            _cardsAmount = _playerCards.Count;
            OnCardsUpdated.Invoke();
        }

        public CardModel Draw()
        {
            if (_playerCards.Count == 0)
            {
                OnCardsOver.Invoke();
                return null;
            }
            
            CardModel card = _playerCards.Pop();
            OnCardDraw.Invoke(card);
            return card;
        }

        public void AddCard(CardModel card)
        {
            _playerCards.Push(card);
            Shuffle(_playerCards);
            OnCardsUpdated.Invoke();
        }
        
        public int GetCardsLeft()
        {
            return _playerCards.Count;
        }

        private static void Shuffle(Stack<CardModel> stack)
        {
            System.Random random = new System.Random();
            CardModel[] values = stack.ToArray();
            stack.Clear();
            foreach (var value in values.OrderBy(x => random.Next()))
            {
                stack.Push(value);
            }
        }
    }
}