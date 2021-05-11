using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IProduct : ITickable
    {
        /// <summary>
        /// How much honey is stored
        /// </summary>
        public int HoneySupply { get; }

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
        /// The yield per level of the product per tick
        /// </summary>
        public int YieldPerLevel { get; }

        /// <summary>
        /// If the product is active or not
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// The amount of the product produced per tick
        /// </summary>
        public float YieldPerTick{ get; }

        /// <summary>
        /// Activates the product to show in Inventory and starts it's Tick
        /// </summary>
        void Activate();

        /// <summary>
        /// Upgrades the product
        /// </summary>
        void Upgrade();

        /// <summary>
        /// Gets the amount of honey this products wants per tick. 
        /// </summary>
        /// <returns>Amount of honey needed per tick</returns>
        int GetRequestedHoney();

        /// <summary>
        /// Stores honey to be used when theres enough to produce the product
        /// </summary>
        /// <param name="amt">Amount of honey to be stored</param>
        void StoreHoney(int amt);
    }
}
