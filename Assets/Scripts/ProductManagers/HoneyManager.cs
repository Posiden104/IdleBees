using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class HoneyManager : Singleton<HoneyManager>, IProduct
    {
        public int HoneySupply { get; private set; } = 100000;
        public int Value { get; private set; } = 1;
        public string InventoryLabel { get; } = Constants.HoneyLabel;
        public int Level { get; private set; } = 100;
        public int YieldPerLevel { get; private set; } = 10;
        public bool IsActive { get; private set; } = true;
        public float YieldPerTick { get; private set; }


        public void Start()
        {
            InventoryManager.Instance.AddProduct(this);
            GameManager.Instance.RegisterAfterTickMethod(Tick);
            UpdateText();
        }

        public void AddHoney(int amt)
        {
            HoneySupply += amt;
            UpdateText();
        }

        public void RemoveHoney(int amt = 1)
        {
            HoneySupply -= amt;
            UpdateText();
        }

        public void SellAll()
        {
            CashManager.Instance.AddCash(HoneySupply * Value);
            RemoveHoney(HoneySupply);
        }

        private void UpdateText()
        {
            TextManager.Instance.HoneyTxt.text = $"Honey: {HoneySupply}";
            TextManager.Instance.BeehiveTxt.text = $"Beehives: {Level} ({YieldPerLevel})";
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
            YieldPerLevel++;
            UpdateText();
        }

        public void Tick()
        {
            UpdateText();
        }

        public int GetRequestedHoney() => 0;

        public int GetHoneyProduced()
        {
            return Level * YieldPerLevel;
        }

        public void StoreHoney(int amt)
        {
            HoneySupply += amt;
            YieldPerTick = amt;
            UpdateText();
        }
    }
}
