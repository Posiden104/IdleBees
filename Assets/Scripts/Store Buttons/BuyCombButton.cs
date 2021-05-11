using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyCombButton : StoreButtonBase
    {
        public override string Name { get; set; } = "BuyCombBtn";
        public override int Cost { get; protected set; } = 1000;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                CombManager.Instance.Upgrade();
                Cost += CombManager.Instance.Level * 1000;
                ButtonTxt.text = $"{Constants.BuyCombText} - Bought";
                Btn.interactable = false;

                if (CombManager.Instance.IsActive == false)
                {
                    CombManager.Instance.Activate();
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyCombText} ({CombManager.Instance.Level}) - ${Cost}";
        }
    }
}