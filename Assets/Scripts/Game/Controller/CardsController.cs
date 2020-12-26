using System.Collections;
using System.Collections.Generic;
using Game.Model;
using UnityEngine;

namespace Game.Controller
{
    public class CardsController
    {
        private CardModel[,] cards;
        public CardsController()
        {
            cards = new CardModel[Main.CARD_TYPES, Main.CARD_COUNT];
            for (int i = 0; i < Main.CARD_TYPES; i++)
            {
                for (int j = 0; j < Main.CARD_COUNT; j++)
                {
                    cards[i, j] = new CardModel(i, j);
                }
            }
        }
    }
}