using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyMeaderyButton : StoreButtonBase, ITickable, IProduct
    {
        public override string Name { get; set; } = "BuyMeaderyBtn";
        public override int Cost { get; protected set; } = 1000;
        public override int Level { get; protected set; } = 0;
        public string InventoryLabel { get; } = Constants.MeadLabel;

        public int Supply { get; private set; } = 0;
        public int Value { get; private set; } = 0;

        private int ConversionAmount = 1000;
        private int Yield = 1;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                HiveManager.Instance.AddHive();
                Cost += Level * 1000;
                Level++;
                UpdateText();

                if(Level == 1)
                {
                    GameManager.Instance.RegisterTickMethod(Tick);
                    InventoryManager.Instance.AddProduct(this);
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyMeaderyText} ({Level}) - ${Cost}";
        }

        public void Tick()
        {
            if(HoneyManager.Instance.Supply > ConversionAmount)
            {
                HoneyManager.Instance.RemoveHoney(ConversionAmount);
                Supply += Yield;
            }
        }

        public void Sell()
        {
            CashManager.Instance.AddCash(Supply * Value);
            Supply = 0;
        }
    }
}