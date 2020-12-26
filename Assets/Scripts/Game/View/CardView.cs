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
        [SerializeField] private Image _symbol;
        [SerializeField] private Image _cardBack;
        [SerializeField] private TextMeshProUGUI _numberTxt;
        [SerializeField] private TextMeshProUGUI _numberBigTxt;

        public void Initialize(CardModel card)
        {
            CardType cardType = GetCardType(card.Type);
            _symbol.sprite = cardType.Image;
            _numberTxt.text = card.Number;
            _numberBigTxt.text = card.Number;
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
