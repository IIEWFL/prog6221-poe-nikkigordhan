using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_PoE_Part3
{
    public class Ingredeint
    {
        //https://www.w3schools.com/cs/cs_properties.php
        //w3schools

        public string sIngredeint_name;
        //creates a variable called sIngredeint_name of type string.
        public string Ingredeint_Name
        {
            get { return sIngredeint_name; }
            set { sIngredeint_name = value; }
        }
        //getters and setters using automatic properties.

        public double dIngredeint_quantity;
        //creates a variable called dIngredeint_quantity of type double.
        public double Ingredeint_Quantity
        {
            get { return dIngredeint_quantity; }
            set { dIngredeint_quantity = value; }
        }
        //getters and setters using automatic properties.

        public string sIngredeint_unit;
        //creates a variable called sIngredeint_unit of type string.
        public string Ingredeint_Unit
        {
            get { return sIngredeint_unit; }
            set { sIngredeint_unit = value; }
        }
        //getters and setters using automatic properties.

        public int iNumber_Of_Calories;
        //creates a variable called iNumber_Of_Calories of type int.
        public int Number_Of_Calories
        {
            get { return iNumber_Of_Calories; }
            set { iNumber_Of_Calories = value; }
        }
        //getters and setters using automatic properties.

        public string sFood_Group;
        //creates a variable called sFood_Group of type string.
        public string Food_Group
        {
            get { return sFood_Group; }
            set { sFood_Group = value; }
        }
        //getters and setters using automatic properties.

    }
}
