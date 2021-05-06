using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;

namespace Assets.Scripts.Store_Buttons
{
    public class IncreaseProdButton : StoreButtonBase
    {
        public override string Name { get; set; } = "IncProdBtn";
        public override int Cost { get; protected set; } = 10;
        public override int Level { get; protected set; } = 1;

        public override void Buy()
        {
            if (CashManager.Instance.RemoveCash(Cost))
            {
                HiveManager.Instance.AddProductivity();
                Cost += HiveManager.Instance.Productivity * 10;
                Level++;
                UpdateText();
            }
        }

        public override void UpdateText()
        {
            ButtonTxt.text = $"{Constants.IncreaseProductivityText} ({HiveManager.Instance.Productivity}) - ${Cost}";
        }
    }
}