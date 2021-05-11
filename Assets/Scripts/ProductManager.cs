using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using System;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts
{
    public class ProductManager : Singleton<ProductManager>, ITickable
    {
        public enum ProductEnum : int
        { 
            HONEY, 
            MEAD, 
            COMB,
            CHAPSTICK,
            NumberOfProducts
        };

        public IProduct[] Products;

        // Use this for initialization
        void Start()
        {
            Products = new IProduct[(int)ProductEnum.NumberOfProducts];

            Products[(int)ProductEnum.HONEY] = HoneyManager.Instance;
            Products[(int)ProductEnum.MEAD] = MeadManager.Instance;
            Products[(int)ProductEnum.COMB] = CombManager.Instance;
            Products[(int)ProductEnum.CHAPSTICK] = ChapstickManager.Instance;

            GameManager.Instance.RegisterTickMethod(Tick);
        }

        public void Tick()
        {
            var requestedHoney = 0;
            var producedHoney = HoneyManager.Instance.GetHoneyProduced();
            List<IProduct> requestingProducts = new List<IProduct>();

            foreach(var p in Products)
            {
                if(p.IsActive == false)
                {
                    continue;
                }

                var honeyNeeded = p.GetRequestedHoney();
                if (honeyNeeded > 0){
                    requestedHoney += honeyNeeded;
                    requestingProducts.Add(p);
                }
            }

            if(requestingProducts.Count > 0)
            {
                if (requestedHoney > producedHoney)
                {
                    // Need to split the honey evenly
                    var honeyPerProduct = (int) (producedHoney / requestingProducts.Count);
                    Debug.Log($"ProductManager - HoneyPerProduct: {honeyPerProduct}");

                    // Each product gets an even amount of honey
                    // Or the amount it requested
                    foreach (var p in requestingProducts)
                    {
                        var honeyUsed = Math.Min(honeyPerProduct, p.GetRequestedHoney());
                        p.StoreHoney(honeyUsed);
                        producedHoney -= honeyUsed;
                    }
                }
                else 
                { 
                    // Each product can get all the honey it wants
                    foreach(var p in requestingProducts)
                    {
                        p.StoreHoney(p.GetRequestedHoney());
                        producedHoney -= p.GetRequestedHoney();
                    }

                }
            }
            // The rest of the honey is stored as honey
            HoneyManager.Instance.StoreHoney(producedHoney);
        }
    }
}