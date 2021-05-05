using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class HoneyManager : Singleton<HoneyManager>
    {
        public int HoneyAmount = 0;

        private void Start()
        {
            UpdateText();
        }

        public void AddHoney(int amt = 1)
        {
            HoneyAmount += amt;
            UpdateText();
        }

        public void RemoveHoney(int amt = 1)
        {
            HoneyAmount -= amt;
            UpdateText();
        }

        public void SellHoney()
        {
            CashManager.Instance.AddCash(HoneyAmount);
            RemoveHoney(HoneyAmount);
        }

        private void UpdateText()
        {
            TextManager.Instance.HoneyTxt.text = $"Honey: {HoneyAmount}";
        }
    }
}
