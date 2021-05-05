using UnityEngine;
using Assets.Scripts.Helpers;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StoreManager : Singleton<StoreManager>
    {
        public int incProdCost = 10;
        public int newHiveCost = 100;

        // Use this for initialization
        void Start()
        {
            // set initial button text
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            TextManager.Instance.IncreaseProductivityTxt.text = $"{Constants.IncreaseProductivityText} ({HiveManager.Instance.Productivity}) - ${incProdCost}";
            TextManager.Instance.BuyBeehiveTxt.text = $"{Constants.BuyBeehiveText} ({HiveManager.Instance.HiveCount}) - ${newHiveCost}";
        }

        public void IncreaseProductivity()
        {
            if (CashManager.Instance.RemoveCash(incProdCost))
            {
                HiveManager.Instance.AddProductivity();
                incProdCost += HiveManager.Instance.Productivity * 10;
                UpdateLabels();
            }
        }

        public void BuyBeehive()
        {
            if (CashManager.Instance.RemoveCash(newHiveCost))
            {
                HiveManager.Instance.AddHive();
                newHiveCost += HiveManager.Instance.HiveCount * 100;
                UpdateLabels();
            }
        }
    }
}