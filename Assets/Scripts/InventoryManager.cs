using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using UnityEngine.UI;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class InventoryManager : Singleton<InventoryManager>, ITickable
    {
        private IEnumerable<IProduct> ProductList;
        private Text InventoryText;

        private void Start()
        {
            InventoryText = TextManager.Instance.InventoryText;
            ProductList = new List<IProduct>();
            GameManager.Instance.RegisterAfterTickMethod(Tick);
            UpdateText();
        }

        public void AddProduct(IProduct product)
        {
            ProductList = ProductList.Append(product);
            UpdateText();
        }

        public void UpdateText()
        {
            InventoryText.text = "Inventory\n";
            foreach (var p in ProductList)
            {
                InventoryText.text += $"{p.InventoryLabel}: {p.Supply}\n";
            }
        }

        public void Tick()
        {
            UpdateText();
        }
    }
}