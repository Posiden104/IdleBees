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
        public override int Level { get; protected set; } = 0;
       

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                Cost += Level * 1000;
                Level++;
                MeadManager.Instance.Upgrade();
                UpdateText();

                if(Level == 1)
                {
                    MeadManager.Instance.Activate();
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyMeaderyText} ({Level}) - ${Cost}";
        }

    }
}