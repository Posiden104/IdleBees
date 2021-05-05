using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;
using UnityEngine.UI;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts
{
    public class HiveManager : Singleton<HiveManager>, ITickable
    {
        public Image Radial;
        public int HiveCount = 1;
        public int Productivity = 1;

        public int HoneyPerTick { get { return HiveCount * Productivity; } }
        
        public void Tick()
        {
            HoneyManager.Instance.AddHoney(HoneyPerTick);
        }

        private void Start()
        {
            UpdateText();
        }

        public void AddHive()
        {
            HiveCount++;
            UpdateText();
        }

        // Update is called once per frame
        void Update()
        {
            Radial.fillAmount = GameManager.Instance.TickProgress;
        }

        public void AddProductivity()
        {
            Productivity++;
            UpdateText();
        }

        private void UpdateText()
        {
            TextManager.Instance.BeehiveTxt.text = $"Beehives: {HiveCount} ({Productivity})";
        }
    }
}