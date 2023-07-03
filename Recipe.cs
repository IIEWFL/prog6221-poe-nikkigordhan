using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_PoE_Part3
{
    public class Recipe
    {
        public string Name_of_Recipe;
        //creates a variable called Name_of_Recipe of type string.
        public string sName_of_Recipe
        {
            get { return Name_of_Recipe; }
            set { Name_of_Recipe = value; }
        }
        //getters and setters using automatic properties.

        public int iTotal_Calories;
        //creates a variable called iNumber_Of_Calories of type int.
        public int Total_Calories
        {
            get { return iTotal_Calories; }
            set { iTotal_Calories = value; }
        }
        //getters and setters using automatic properties.

        public Ingredeint[] Ingredeints { get; set; }
        //creates a variable called Ingredeints of type Ingredeint array.

        public List<Ingredeint> lIngredeint = new List<Ingredeint>();
        // creates a list for Ingredeints
       
        public string[] sSteps;
        //creates a variable called sSteps of type string array.

       public  List<string> lSteps = new List<string>();
        // creates a list for steps

        public string[] steps
        {
            get { return sSteps; }
            set { sSteps = value; }
        }
        //getters and setters using automatic properties.

        public float factor;
        //creates a variable called factor of type float.
        public float ffactor
        {
            get { return factor; }
            set { factor = value; }
        }
        //getters and setters using automatic properties.

        public Boolean bScaled;

        public int TotalCalories(List<Ingredeint> lIngredientobj)
        {
            iTotal_Calories = 0;
            for (int i = 0; i < lIngredientobj.Count; i++)
            {
                dynamic selectedItem = lIngredientobj[i];
                iTotal_Calories =  iTotal_Calories + selectedItem.Number_Of_Calories;
            }
            return iTotal_Calories;
        }
        //calculates the total calories.
        public string Check_Calories(int iTotal_Calories)
        {
            string sTCaoloriesMsg = "";


            if (iTotal_Calories <= 100)
            {
                
                sTCaoloriesMsg = "Total calories is less than 100.";
                
            }
            else if (iTotal_Calories >= 101 && iTotal_Calories <= 200)
            {
                
                sTCaoloriesMsg = "Total calories is less than 200 but more than 100.";
            }
            else if (iTotal_Calories >= 201 && iTotal_Calories <= 299)
            {
                
                sTCaoloriesMsg = "Total calories is less than 300.";
            }
            else if (iTotal_Calories >= 300)
            {
                
                sTCaoloriesMsg = "The total calories have exceed 300.";
            }
            return sTCaoloriesMsg;
        }
        //checks which category the calories belong to.
        public string Create_A_Recipe(string sRecipeName, int iNoOfIngrdeints, int iNoOfSteps, List<Ingredeint> lIngredientobj, List<string> lStepsobj)
        {
           
            try
            {
                string sReturnMsg = "";

                Name_of_Recipe = sRecipeName;

                iTotal_Calories = TotalCalories(lIngredientobj);
                string sMsgCalories = Check_Calories(iTotal_Calories);

                lIngredeint = lIngredientobj;

                if (lIngredeint != null)
                {
                    lSteps = lStepsobj;
                }
                sReturnMsg = "Recipe saved succesfully. " +  '\n' + sMsgCalories;
                return sReturnMsg;

            }
            catch (Exception e)
            {
                return  "Error saving recipe.";
            }
            
        }
        //creates a new recipe.

      
    }
}
