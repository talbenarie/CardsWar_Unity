using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Model;
using UnityEngine;
// ReSharper disable All

namespace Game.Controller
{
    public class CardsController
    {
        private CardModel[,] _cards;
        private List<CardModel> _deck;
        private Stack<CardModel> _drawn;
        
        public CardsController()
        {
            _cards = new CardModel[Main.CARD_TYPES, Main.CARD_COUNT];
            _deck = new List<CardModel>();
            
            for (int i = 0; i < Main.CARD_TYPES; i++)
            {
                for (int j = 0; j < Main.CARD_COUNT; j++)
                {
                    _cards[i, j] = new CardModel(i, j);
                    _deck.Add(_cards[i, j]);
                }
            }

            Shuffle(_deck);
        }

        public void Restart()
        {
            Shuffle(_deck);
            _drawn = new Stack<CardModel>(_deck);
        }
        
        /**
         * Returns List of cards the user owns
         */
        public Stack<CardModel> GetCards(int numCards)
        {
            int totalCards = _deck.Count;
            int cardsLeft = _drawn.Count;
            if (numCards == -1)
            {
                numCards = totalCards / 2;
            }

            Stack<CardModel> cards = new Stack<CardModel>();

            for (int i = 0; i < cardsLeft; i++)
            {
                cards.Push(_drawn.Pop());

                if (cards.Count > numCards)
                {
                    break;
                }
            }

            return cards;
        }
        
        private int GetCardsLeft()
        {
            return _drawn.Count;
        }
        
        private static void Shuffle(List<CardModel> list)
        {
            System.Random random = new System.Random();
            
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                CardModel value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        
    }
}