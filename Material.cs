using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    class Material
    {
        public enum MeasureType {WEIGHT, VOLUME, LENGTH}; 
        
        private int matID;
        private String name;
        private bool infinite;
        private double quantity;
        private MeasureType typeOfMeasure;


        public Material(String name, double quantity = 1)
        {
            this.Name = name;
            this.MatID = 1;
            this.Infinite = false;
            this.Quantity = quantity;
            this.TypeOfMeasure = MeasureType.WEIGHT;
        }

        override public String ToString()
        {
            return name + ", " + quantity;
        }

        // ACCESSORS
        private int MatID
        {
            get
            {
                return matID;
            }
            set
            {
                matID = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private bool Infinite
        {
            get
            {
                return infinite;
            }
            set
            {
                infinite = value;
            }
        }

        public double Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public MeasureType TypeOfMeasure
        {
            get
            {
                return typeOfMeasure;
            }
            set
            {
                typeOfMeasure = value;
            }
        }
    }
}
