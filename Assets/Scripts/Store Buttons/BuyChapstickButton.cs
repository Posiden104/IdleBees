using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts.Store_Buttons
{
    public class BuyChapstickButton : StoreButtonBase
    {
        public override string Name { get; set; } = "BuyChapstickBtn";
        public override int Cost { get; protected set; } = 10;
       

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                ChapstickManager.Instance.Upgrade();
                Cost += ChapstickManager.Instance.Level * 10;
                UpdateText();

                if(ChapstickManager.Instance.IsActive == false)
                {
                    ChapstickManager.Instance.Activate();
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyChapstickText} ({ChapstickManager.Instance.Level}) - ${Cost}";
        }

    }
}