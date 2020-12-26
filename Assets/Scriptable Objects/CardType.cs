using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Card Type", menuName = "Card Type")]
public class CardType : ScriptableObject
{
   public enum CardSymbol
   {
      Diamond,
      Heart,
      Spade,
      Trebol
   };
   
   public CardSymbol Type;
   public Sprite Image;
   public Color Color;

   public int GetCardType()
   {
      if (Type == CardSymbol.Diamond) return 1;
      else if (Type == CardSymbol.Heart) return 2;
      else if (Type == CardSymbol.Spade) return 3;
      else if (Type == CardSymbol.Trebol) return 4;
      else return 0;
   }
}
