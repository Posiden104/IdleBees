using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyHiveButton : StoreButtonBase
    {
        public override string Name { get; set; } = "BuyHiveBtn";
        public override int Cost { get; protected set; } = 100;
        public override int Level { get; protected set; } = 1;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                HiveManager.Instance.AddHive();
                Cost += HiveManager.Instance.HiveCount * 100;
                UpdateText();
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyBeehiveText} ({HiveManager.Instance.HiveCount}) - ${Cost}";
        }
    }
}