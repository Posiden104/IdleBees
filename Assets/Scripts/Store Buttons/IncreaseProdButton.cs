using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts.Store_Buttons
{
    public class IncreaseProdButton : StoreButtonBase
    {
        public override string Name { get; set; } = "IncProdBtn";
        public override int Cost { get; protected set; } = 10;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                Cost += HoneyManager.Instance.YieldPerLevel * 10;
                HoneyManager.Instance.Upgrade();
                UpdateText();
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.IncreaseProductivityText} ({HoneyManager.Instance.YieldPerLevel}) - ${Cost}";
        }
    }
}