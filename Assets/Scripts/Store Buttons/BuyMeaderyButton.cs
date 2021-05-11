using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyMeaderyButton : StoreButtonBase
    {
        public override string Name { get; set; } = "BuyMeaderyBtn";
        public override int Cost { get; protected set; } = 1000;
       

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                MeadManager.Instance.Upgrade();
                Cost += MeadManager.Instance.Level * 1000;
                UpdateText();

                if(MeadManager.Instance.IsActive == false)
                {
                    MeadManager.Instance.Activate();
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyMeaderyText} ({MeadManager.Instance.Level}) - ${Cost}";
        }

    }
}