using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;

namespace Assets.Scripts.Store_Buttons
{
    public abstract class StoreButtonBase : MonoBehaviour, IStoreButton
    {
        public Text ButtonTxt;
        public Button Btn;

        public abstract string Name { get; set; }
        public abstract int Cost { get; protected set; }

        public abstract void Buy();
        public abstract void UpdateText();

    }
}