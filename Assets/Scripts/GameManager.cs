using Assets.Scripts;
using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public int Hives;
        public float TickTimer;

        private float elapsed = 0f;
        private Action TickMethods;

        public float TickProgress { get { return elapsed / TickTimer; } }

        private void Start()
        {
            // Register all methods to call on tick
            RegisterTickMethod(HiveManager.Instance.Tick);
        }

        // Update is called once per frame
        void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed >= TickTimer)
            {
                elapsed = elapsed % TickTimer;
                TickMethods();
            }
        }

        public void RegisterTickMethod(Action act) 
        {
            TickMethods += act;   
        }
        public void UnRegisterTickMethod(Action act) 
        {
            TickMethods -= act;
        }
    }
}
