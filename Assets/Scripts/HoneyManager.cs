using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts
{
    public class HoneyManager : Singleton<HoneyManager>, IProduct
    {
        public int Supply { get; private set; } = 10000;
        public int Value { get; private set; } = 10000;
        public string InventoryLabel { get; } = Constants.HoneyLabel;

        private void Start()
        {
            UpdateText();
            InventoryManager.Instance.AddProduct(this);
        }

        public void AddHoney(int amt = 1)
        {
            Supply += amt;
            UpdateText();
        }

        public void RemoveHoney(int amt = 1)
        {
            Supply -= amt;
            UpdateText();
        }

        public void Sell()
        {
            CashManager.Instance.AddCash(Supply * Value);
            RemoveHoney(Supply);
        }

        private void UpdateText()
        {
            TextManager.Instance.HoneyTxt.text = $"Honey: {Supply}";
        }
    }
}
