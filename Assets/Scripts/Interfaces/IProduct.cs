using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// How much you have
        /// </summary>
        public int Supply { get; }

        /// <summary>
        /// How much the product sells for
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The label for the inventory panel
        /// </summary>
        public string InventoryLabel { get; }

        void Sell();
    }
}
