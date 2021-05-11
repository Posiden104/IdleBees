using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using System;
using Assets.Scripts.ProductManagers;

namespace Assets.Scripts
{
    public class ProductManager : Singleton<ProductManager>
    {
        public enum ProductEnum : int
        { 
            HONEY, 
            MEAD, 
            COMB,
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

        }
        
        public IProduct GetManager(ProductEnum productKey)
        {
            return Products[(int)productKey];
        }

    }
}