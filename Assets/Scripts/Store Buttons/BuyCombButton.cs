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
        public override int Level { get; protected set; }

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                Cost += Level * 1000;
                Level++;
                CombManager.Instance.Upgrade();
                UpdateText();

                if(Level == 1)
                {
                    CombManager.Instance.Activate();
                }
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.BuyCombText} ({Level}) - ${Cost}";
        }
    }
}