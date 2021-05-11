using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.ProductManagers
{
    public class CombManager : Singleton<CombManager>, IProduct, ITickable
    {
        public int Supply { get; private set; }

        public int Value { get; private set; } = 1;

        public string InventoryLabel => Constants.CombLabel;

        public int Level { get; private set; }

        public int Yield { get; private set; }


        private int TickTimer = 10;
        private int TickCounter;

        public void Activate()
        {
            GameManager.Instance.RegisterTickMethod(Tick);
            InventoryManager.Instance.AddProduct(this);
            TickTimer = 10;
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
            TickCounter++;
            if (TickCounter >= TickTimer)
            {
                Add(Level);
                TickCounter = 0;
            }
        }
    }
}