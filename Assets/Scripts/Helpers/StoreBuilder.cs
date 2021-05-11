using Assets.Scripts.Interfaces;
using Assets.Scripts.Store_Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    public class StoreBuilder : Singleton<StoreBuilder>
    {
        public GameObject StoreScroller_Content;
        public GameObject ButtonPrefab;
        public GameObject HeaderPrefab;
        public GameObject SpacerPrefab;

        private int SpacerCount = 0;

        void Start()
        {
            InsertHeader("Purchase");
            BuildPurchaseButtons();

            InsertSpacer();

            InsertHeader("Upgrades");
            BuildUpgradeButtons();

        }

        private void BuildPurchaseButtons()
        {
            GameObject go;
            StoreButtonBase btnData;

            go = Instantiate(ButtonPrefab);
            btnData = go.AddComponent<BuyHiveButton>();
            InsertButton(go, btnData);

            go = Instantiate(ButtonPrefab);
            btnData = go.AddComponent<BuyMeaderyButton>();
            InsertButton(go, btnData);

            go = Instantiate(ButtonPrefab);
            btnData = go.AddComponent<BuyCombButton>();
            InsertButton(go, btnData);
        }

        private void BuildUpgradeButtons()
        {
            GameObject go;
            StoreButtonBase btnData;

            go = Instantiate(ButtonPrefab);
            btnData = go.AddComponent<IncreaseProdButton>();
            InsertButton(go, btnData);
        }

        private void InsertButton(GameObject go, StoreButtonBase btnData)
        {
            go.SetActive(true);
            go.transform.SetParent(StoreScroller_Content.transform);
            Button btn = btnData.Btn = go.GetComponent<Button>();
            btnData.ButtonTxt = go.GetComponentInChildren<Text>();
            btn.onClick.AddListener(delegate { btnData.Buy(); });
            go.name = btnData.Name;
            btnData.UpdateText();
        }

        private void InsertHeader(string headerText)
        {
            GameObject go = Instantiate(HeaderPrefab);
            go.SetActive(true);
            go.transform.SetParent(StoreScroller_Content.transform);
            go.GetComponentInChildren<Text>().text = headerText;
            go.name = $"{headerText}_Header";
        }

        private void InsertSpacer()
        {
            GameObject go = Instantiate(SpacerPrefab);
            go.SetActive(true);
            go.transform.SetParent(StoreScroller_Content.transform);
            go.name = $"storeSpacer_{SpacerCount}";
            SpacerCount++;
        }
    }
}
