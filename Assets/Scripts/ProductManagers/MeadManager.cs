using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class MeadManager : Singleton<MeadManager>, IProduct
    {
        public string InventoryLabel { get; } = Constants.MeadLabel;

        public int Supply { get; private set; }

        // Tied to value of honey because this is a secondary product
        public int Value { get; private set; }

        public int Level { get; set; }
        public int Yield { get; private set; } = 1;

        private int ConversionAmount = 1000;

        public void Activate()
        {
            GameManager.Instance.RegisterTickMethod(Tick);
            InventoryManager.Instance.AddProduct(this);

            ConversionAmount = 1000;
            Value = 1000 * HoneyManager.Instance.Value;
        }

        public void Add(int amt)
        {
            Supply += amt;
        }

        public void SellAll()
        {
            CashManager.Instance.AddCash(Supply * Value);
            Supply = 0;
        }

        public void Upgrade()
        {
            Level++;
        }

        public void Tick()
        {
            if ((HoneyManager.Instance.Supply * Level) > (ConversionAmount * Level))
            {
                HoneyManager.Instance.RemoveHoney(ConversionAmount * Level);
                Add(Yield * Level);
            }
        }
    }
}