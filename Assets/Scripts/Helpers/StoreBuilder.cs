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

        void Start()
        {
            GameObject go;
            StoreButtonBase btnData;

            go = Instantiate(ButtonPrefab); 
            btnData = go.AddComponent<IncreaseProdButton>();
            BuildButton(go, btnData);

            go = Instantiate(ButtonPrefab);
            btnData = go.AddComponent<BuyHiveButton>();
            BuildButton(go, btnData);
        }

        private void BuildButton(GameObject go, StoreButtonBase btnData)
        {
            go.SetActive(true);
            go.transform.SetParent(StoreScroller_Content.transform);
            Button btn = btnData.Btn = go.GetComponent<Button>();
            btnData.ButtonTxt = go.GetComponentInChildren<Text>();
            btn.onClick.AddListener(delegate { btnData.Buy(); });
            go.name = btnData.Name;
            btnData.UpdateText();
        }
    }
}
