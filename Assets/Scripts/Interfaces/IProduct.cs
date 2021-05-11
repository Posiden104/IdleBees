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

        /// <summary>
        /// The upgrade level of the product
        /// </summary>
        public int Level { get; }


        /// <summary>
        /// The yield of the product per tick
        /// </summary>
        public int Yield { get; }

        /// <summary>
        /// Sells all of product
        /// </summary>
        void SellAll();

        /// <summary>
        /// Adds an amount of the product to inventory
        /// </summary>
        /// <param name="amt">Amount to be added</param>
        void Add(int amt);

        /// <summary>
        /// Activates the product to show in Inventory and starts it's Tick
        /// </summary>
        void Activate();

        /// <summary>
        /// Upgrades the product
        /// </summary>
        void Upgrade();
    }
}
