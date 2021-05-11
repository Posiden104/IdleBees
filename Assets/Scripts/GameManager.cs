using Assets.Scripts;
using Assets.Scripts.Helpers;
using Assets.Scripts.ProductManagers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public float TickTimer;
        public int ClickPower = 1;
        public Image Radial;

        private float elapsed = 0f;
        private Action TickMethods;
        private Action AfterTickMethods;

        public float TickProgress { get { return elapsed / TickTimer; } }

        // Update is called once per frame
        void Update()
        {
            elapsed += Time.deltaTime;

            Radial.fillAmount = TickProgress;
            if (elapsed >= TickTimer)
            {
                elapsed %= TickTimer;
                TickMethods?.Invoke();
                AfterTickMethods?.Invoke();
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
        public void RegisterAfterTickMethod(Action act)
        {
            AfterTickMethods += act;
        }
        public void UnRegisterAfterTickMethod(Action act)
        {
            AfterTickMethods -= act;
        }

        public void MakeHoneyButtonHandler()
        {
            HoneyManager.Instance.Add(ClickPower);
        }

        public void SellHoneyButtonHandler()
        {
            HoneyManager.Instance.SellAll();
        }
    }
}
