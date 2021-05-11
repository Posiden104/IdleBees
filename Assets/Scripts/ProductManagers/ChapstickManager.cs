using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class ChapstickManager : Singleton<ChapstickManager>, IProduct
    {
        public string InventoryLabel { get; } = Constants.ChapstickLabel;

        public int HoneySupply { get; private set; }

        // Tied to value of honey because this is a secondary product
        public int Value { get; private set; }

        public int Level { get; private set; }
        public int YieldPerLevel { get; private set; } = 1;
        public bool IsActive { get; private set; }
        public float YieldPerTick { get; private set; }
        
        private int HoneyNeededPerTick { get => ConversionAmount * Level; }

        private int ConversionAmount = 10;

        public void Activate()
        {
            GameManager.Instance.RegisterAfterTickMethod(Tick);
            InventoryManager.Instance.AddProduct(this);

            ConversionAmount = 10;
            Value = ConversionAmount * HoneyManager.Instance.Value;
            IsActive = true;
        }

        public void Upgrade()
        {
            Level++;
        }

        public void Tick()
        {
            if ((HoneySupply * Level) > (HoneyNeededPerTick))
            {
                HoneySupply -= HoneyNeededPerTick;
                CashManager.Instance.AddCash(YieldPerLevel * Level * Value);
            }
        }

        public int GetRequestedHoney()
        {
            return HoneyNeededPerTick;
        }

        public void StoreHoney(int amt)
        {
            HoneySupply += amt;
            YieldPerTick = (float)((float)amt / HoneyNeededPerTick) * YieldPerLevel * Level;
        }
    }
}