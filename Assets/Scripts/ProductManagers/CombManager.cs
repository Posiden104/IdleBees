using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class CombManager : Singleton<CombManager>, IProduct
    {
        public int HoneySupply { get; private set; }

        public int Value { get; private set; } = 1;

        public string InventoryLabel => Constants.CombLabel;

        public int Level { get; private set; }

        public int YieldPerLevel { get; private set; }
        public bool IsActive { get; private set; }
        public float YieldPerTick { get; private set; }


        private int TickTimer = 10;
        private int TickCounter;

        public void Activate()
        {
            GameManager.Instance.RegisterAfterTickMethod(Tick);
            InventoryManager.Instance.AddProduct(this);
            TickTimer = 10;
            IsActive = true;
            YieldPerLevel = HoneyManager.Instance.Level;
        }

        public void Upgrade()
        {
            Level++;
        }

        public void Tick()
        {
            YieldPerLevel = HoneyManager.Instance.Level;
            TickCounter++;
            YieldPerTick = (float)((float)YieldPerLevel * Level) / TickTimer;
            if (TickCounter >= TickTimer)
            {
                CashManager.Instance.AddCash(YieldPerLevel * Level * Value);
                TickCounter = 0;
            }
        }

        public int GetRequestedHoney() => 0;
        
        public void StoreHoney(int amt)
        {
            Debug.LogError($"CombManager - StoreHoney called. This is not needed for this product.");
        }
    }
}