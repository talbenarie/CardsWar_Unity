using System;
using System.Collections;
using System.Collections.Generic;
using Game.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _cardBack;

        public void Initialize(CardModel card)
        {
            CardType cardType = GetCardType(card.Type);
            _background.sprite = Main.Instance.CardAssets[card.Type - 1, card.Worth - 1];
            _cardBack.enabled = false;
        }

        private CardType GetCardType(int type)
        {
            CardType[] cardTypes = Main.Instance.CardTypes;
            for (int i = 0; i < cardTypes.Length; i++)
            {
                if (cardTypes[i].GetCardType() == type)
                {
                    return cardTypes[i];
                } 
            }

            return null;
        }
    }
}
