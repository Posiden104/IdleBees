using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class HoneyManager : Singleton<HoneyManager>, IProduct, ITickable
    {
        public int Supply { get; private set; } = 100000;
        public int Value { get; private set; } = 1000;
        public string InventoryLabel { get; } = Constants.HoneyLabel;
        public int Level { get; private set; } = 1;
        public int Yield { get; private set; } = 1;

        public void Start()
        {
            InventoryManager.Instance.AddProduct(this);
            GameManager.Instance.RegisterTickMethod(Tick);
            UpdateText();
        }

        public void Add(int amt)
        {
            Supply += amt;
            UpdateText();
        }

        public void RemoveHoney(int amt = 1)
        {
            Supply -= amt;
            UpdateText();
        }

        public void SellAll()
        {
            CashManager.Instance.AddCash(Supply * Value);
            RemoveHoney(Supply);
        }

        private void UpdateText()
        {
            TextManager.Instance.HoneyTxt.text = $"Honey: {Supply}";
            TextManager.Instance.BeehiveTxt.text = $"Beehives: {Level} ({Yield})";
        }

        public void Activate()
        {
            Debug.LogError($"HoneyManager - Activate called. This is not needed for this product.");
        }
        
        public void AddHive()
        {
            Level++;
            UpdateText();
        }

        public void Upgrade()
        {
            Yield++;
            UpdateText();
        }

        public void Tick()
        {
            Supply += Level * Yield;
            UpdateText();
        }
    }
}
