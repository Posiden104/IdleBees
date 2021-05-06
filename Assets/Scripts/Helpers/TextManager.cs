using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    public class TextManager : Singleton<TextManager>
    {
        // Buttons
        public Text AddHoneyTxt;
        public Text SellHoneyTxt;
        
        // Left Labels
        public Text CashTxt;
        public Text HoneyTxt;
        public Text BeehiveTxt;
        
        // Other
        public Text InventoryText;

    }
}