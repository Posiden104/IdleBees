using UnityEngine;
using Assets.Scripts.Helpers;
using System.Collections;

namespace Assets.Scripts
{
    public class CashManager : Singleton<CashManager>
    {
        public decimal Cash = 10000m;

        private void Start()
        {
            UpdateText();
        }

        public void AddCash(int amt)
        {
            Cash += amt;
            UpdateText();
        }

        public bool RemoveCash(int amt)
        {
            if(Cash >= amt)
            {
                Cash -= amt;
                UpdateText();
                return true;
            }
            return false;
        }

        private void UpdateText()
        {
            TextManager.Instance.CashTxt.text = $"${Cash}";
        }
    }
}