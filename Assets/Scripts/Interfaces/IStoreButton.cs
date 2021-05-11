using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interfaces
{
    interface IStoreButton
    {
        public abstract string Name { get; }
        public abstract int Cost { get; }
        void Buy();

        /// <summary>
        /// Updates the text on the button
        /// </summary>
        void UpdateText();

    }
}
