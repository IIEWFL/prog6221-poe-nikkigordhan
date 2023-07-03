using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PROG6221_PoE_Part3
{
    public class eCookBook
    {
        List<Recipe> lRecipe = new List<Recipe>(); 
        //creates a Recipe object.
        public string Validate_Recipe(string sRecipeName,int iNoOfIngrdeints,int iNoOfSteps)
        {
            string sRecipeMsg = "";
            if (sRecipeName == "")
            {
                sRecipeMsg = sRecipeMsg + "Recipe Name is invalid.";
            }
            if(iNoOfIngrdeints < 0) 
            {
                sRecipeMsg = sRecipeMsg + "Number of ingrdients is invalid.";
            }
            if (iNoOfSteps < 0)
            {
                sRecipeMsg = sRecipeMsg + "Number of steps is invalid.";
            }    
            return sRecipeMsg;
            
        }
        //validates the recipe.
        public string Validate_Ingredient(string sIngredientName, int iIngredientQuantity, string sIngredientMeasurement, int iCalories, string sFoodGroup )
        {
            string sIngredientMsg = "";
            if (sIngredientName == "")
            {
                sIngredientMsg = sIngredientMsg + "Recipe Name is invalid.";
            }
            if (iIngredientQuantity < 0)
            {
                sIngredientMsg = sIngredientMsg + "Number of ingrdients is invalid.";
            }
            if (sIngredientMeasurement == "")
            {
                sIngredientMsg = sIngredientMsg + "Number of steps is invalid.";
            }
            if (iCalories < 0)
            {
                sIngredientMsg = sIngredientMsg + "Number of steps is invalid.";
            }

            return sIngredientMsg;

        }
       //validates the ingredients.
        public string Validate_Steps (string sSteps)
        {
            string sStepsMsg = "";
            if (sSteps == "")
            {
                sStepsMsg = sStepsMsg + "Steps is invalid.";
            }
            return sStepsMsg;
        }
        //validates the steps.
       
        public string Create_Recipe(string sRecipeName, int iNoOfIngrdeints, int iNoOfSteps, List<Ingredeint> lIngredient, List<string> lSteps)
        {
            Recipe oCreateRecipe = new Recipe();

            //do code here to create the recipe
            string sMsg = oCreateRecipe.Create_A_Recipe(sRecipeName, iNoOfIngrdeints, iNoOfSteps, lIngredient, lSteps);
            lRecipe.Add(oCreateRecipe);
            return sMsg;

        }
        //creates a recipe.
        public List<Recipe> DisplayRecipeNmaes()
        {

            List<Recipe> SortedList = lRecipe.OrderBy(r => r.Name_of_Recipe).ToList();

            return SortedList;
        }
        //dispaly the recipe names in alphabetical order.
        public Recipe SearchRecipe(string sSearched)
        {
            Recipe oFoundRecipe = new Recipe();
            oFoundRecipe = lRecipe.Find(x => x.Name_of_Recipe.Equals(sSearched));

            return oFoundRecipe;

        }
        //searches for a reicpe based on its name.
        public Boolean SearchClearRecipe(string sSearched)
        {
            try
            {
                Recipe oFoundRecipe = new Recipe();
                oFoundRecipe = lRecipe.Find(x => x.Name_of_Recipe.Equals(sSearched));
                lRecipe.Remove(oFoundRecipe);

                return true;
            }
            catch 
            { 
                return false; 
            }

        }
        // searches for a recipe to clear it.
        public void createtestrecipie(string srecnamepre="")
        {

            List<Ingredeint> lListOfIngredients = new List<Ingredeint>();
            lListOfIngredients.Add(new Ingredeint { Ingredeint_Name = "Ing1", dIngredeint_quantity = 1, sIngredeint_unit = "cup", iNumber_Of_Calories = 23, Food_Group = "Protein" });
            lListOfIngredients.Add(new Ingredeint { Ingredeint_Name = "Ing2", dIngredeint_quantity = 1, sIngredeint_unit = "tsp", iNumber_Of_Calories = 40, Food_Group = "Fruit" });


            List<string> lListOfSteps = new List<string>();
            lListOfSteps.Add("Step1");
            lListOfSteps.Add("Step2");
            lListOfSteps.Add("Step3");
            lListOfSteps.Add("Step4");
            lListOfSteps.Add("Step5");
            lListOfSteps.Add("Step6");
            lListOfSteps.Add("Step7");
            lListOfSteps.Add("Step8");
            lListOfSteps.Add("Step9");
            Recipe oTestREcipe = new Recipe();
           
           string  osout= oTestREcipe.Create_A_Recipe("Toast" + srecnamepre, 1, 1, lListOfIngredients, lListOfSteps);

            lRecipe.Add(oTestREcipe);
        }
        //method that is used for testing functions without me having to input data evrytime I need to test the function.


        public List<Recipe> FilterRecipe(string sNameIngredeint, string sFoodGroup, int iMaximumCalories)
        {

            //test code for creation of recipe
            //createtestrecipie();

            //List<Recipe> FilteredList = lRecipe.Find(x => x.Name_of_Recipe.Equals(sSearched)).ToList();
            List<Recipe> FilteredList = new List<Recipe>();

            //search for the ingredient in the ingredient lists and pass the name of recipe to the list
            //search for the FoodGroup of the ingrident and return the recipie to the list 
            //search for the Calories <= max cal and return name  - recipe level 
            Ingredeint oIngfound = new Ingredeint();
            Ingredeint oFoodGroupfound = new Ingredeint();
            Recipe oRecTemp = new Recipe(); 
            for (int i = 0; i < lRecipe.Count; i++)
            {
                oRecTemp = lRecipe[i];
                List<Ingredeint> selectedItem = oRecTemp.lIngredeint;

                
                oIngfound = selectedItem.Find(x => x.Ingredeint_Name.Equals(sNameIngredeint));
                oFoodGroupfound = selectedItem.Find(x => x.Food_Group.Equals(sFoodGroup));
                //find the filters in the ingredients for nme and food group


                if (oIngfound != null || oFoodGroupfound != null || oRecTemp.iTotal_Calories <= iMaximumCalories) // if any were found add the recipe to the list to return to user
                {
                    FilteredList.Add(oRecTemp);
                }

            }
            return FilteredList;
        }
        //filter recipe.
    }
}
