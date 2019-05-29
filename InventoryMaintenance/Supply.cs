﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    class Supply : InvItem
    {
        private string manufacturer;
        public Supply ()
        { }

        public Supply(int itemNo, string description, decimal price, string manufacturer) : base(itemNo, description, price)
        {
            this.Manufacturer = manufacturer;
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
            }
        }

        public override string GetDisplayText() => base.ItemNo + " " + manufacturer.ToString() + " " + base.Description + " " + base.Price;
    }
}
