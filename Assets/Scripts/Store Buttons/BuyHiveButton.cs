using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyHiveButton : StoreButtonBase
    {
        public override string Name { get; set; } = "BuyHiveBtn";
        public override int Cost { get; protected set; } = 100;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                HoneyManager.Instance.AddHive();
                Cost += HoneyManager.Instance.Level * 100;
                UpdateText();
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyBeehiveText} ({HoneyManager.Instance.Level}) - ${Cost}";
        }
    }
}