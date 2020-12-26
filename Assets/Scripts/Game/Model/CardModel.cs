using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model
{
    public class CardModel
    {
        private static readonly string[] Numbers = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

        public int Type;
        public int Worth;
        public string Number;
        public bool Used = false;

        public CardModel(int type, int worth)
        {
            Type = type + 1;
            Worth = worth + 1;
            Number = GetNumber(worth);
        }

        private static string GetNumber(int worth)
        {
            return Numbers[worth];
        }
    }
}
