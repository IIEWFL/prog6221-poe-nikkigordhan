using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PROG6221_PoE_Part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool btDisplayTabSelected = false;
        eCookBook oeCookBook = new eCookBook();
        // creates a eCookBook object.
        public MainWindow()
        {
            InitializeComponent();
           

            //test code to add a new recipe used during codeing to save time 
         //  oeCookBook.createtestrecipie();

            //create the second recipe for testing 
         //   oeCookBook.createtestrecipie("Cheese");
        }
        public void ClearRecipeTabs()
        {
            //Recipe tab: clears the tab
                txtRecipe_Name.Clear();
                txtNumber_Ingredients.Clear();
                txtNumber_Steps.Clear();

            //Ingredeints Tab: clears the tab
                txtName_Ingredient.Clear();
                txtIngredient_Quantity.Clear();
                txtIngredient_Measurement.Clear();
                txtCalories.Clear();
                lListOfIngredients.Items.Clear();

            //Steps Tab: clears the tab
                txtEnter_Steps.Clear();
                lListOfSteps.Items.Clear();

            //Create Recipe Tab: clears the tab
                txtDisplayRecipe.Text = "";
  
        }
        //clears all the tabs

        private void btnCRNext_Click(object sender, RoutedEventArgs e)
        {
            if (tRecipe.IsSelected == true)
            {
                string sRecipeName = txtRecipe_Name.Text;
                //assigns the textbox value of recipe name to the variable sRecipeName.
                int iNoOfIngredients = int.Parse(txtNumber_Ingredients.Text);
                //assigns the textbox value of number of ingredients to the variable iNoOfIngrdeints.
                int iNoOfSteps = int.Parse(txtNumber_Steps.Text);
                //assigns the textbox value of number of steps to the variable iNoOfSteps.

                string sValidateRecipe = oeCookBook.Validate_Recipe(sRecipeName, iNoOfIngredients, iNoOfSteps);
                //validates the recipe details.
                if (sValidateRecipe == "")
                {
                    lName_Of_Recipe.Content = "Name of the Recipe: " + sRecipeName;
                    lNo_Of_Ingredients.Content = "No.of Ingredients: " + iNoOfIngredients.ToString();
                    //adds to coresponding labels.
                    
                    tIngredients.IsSelected = true;
                   //automatically takes the user to the Ingredients tab.
                }
                else
                {
                    MessageBox.Show("Error:" + sValidateRecipe);
                }
            }
        }
        //captures the recipe name, number of ingredeints and steps.

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //closes the entire application.

        private void btnNext_Ingredient_Click(object sender, RoutedEventArgs e)
        {
            string sIngredientName = txtName_Ingredient.Text;
            //assigns the textbox value of ingredient name to the variable sIngredientName.

          //the line of code below was taken and adapted from StackOverflow.
          //https://stackoverflow.com/questions/11931770/get-integer-from-textbox
          //Habib
          //https://stackoverflow.com/users/961113/habib
            int iIngredientQuantity = int.Parse(txtIngredient_Quantity.Text);
            //assigns the textbox value of ingredeint quantity to the variable iIngredientQuantity.
            string sIngredientMeasurement = txtIngredient_Measurement.Text;
            //assigns the textbox value of ingredeint measurement to the variable sIngredientMeasurement.
            int iCalories = int.Parse(txtCalories.Text);
            //assigns the textbox value of calories to the variable iCalories.
            string sFoodGroup = cbFood_Group.Text;
            //assigns the combobox value of food group to the variable sFoodGroup.


            string sValidateIngredient = oeCookBook.Validate_Ingredient(sIngredientName, iIngredientQuantity, sIngredientMeasurement, iCalories, sFoodGroup);
            //validates the ingredient.
            if (sValidateIngredient == "")
            {
                lListOfIngredients.Items.Add(new { Ingredient = sIngredientName, Quantity = iIngredientQuantity, Measurement = sIngredientMeasurement, Calories = iCalories, FoodGroup = sFoodGroup });
                //adds the ingredient to the listbox.
            }
            else
            {
                MessageBox.Show("Error:" + sValidateIngredient);
            }
            txtName_Ingredient.Clear();
            txtIngredient_Quantity.Clear();
            txtIngredient_Measurement.Clear();
            txtCalories.Clear();
            //clears the textboxes for the next ingredient.
        }
        //captures the ingredients name, quantity, measurment, calories and food group.

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            tSteps.IsSelected = true;
            //automatically takes the user to the Steps tab.

            string sRecipeName = txtRecipe_Name.Text;
            //assigns the textbox value of recipe name to the variable sRecipeName.
            int iNoOfSteps = int.Parse(txtNumber_Steps.Text);
            //assigns the textbox value of number of steps to the variable iNoOfSteps.

            lSName_Of_Recipe.Content = "Name of the Recipe: " + sRecipeName;
            lSNumber_Of_Steps.Content = "No.of Steps: " + iNoOfSteps.ToString();
            //addas to the corresponding labels.
        }
        //captures all the ingredients and takes the user to the steps tab.

        private void btnNext_Steps_Click(object sender, RoutedEventArgs e)
        {
            string sSteps = txtEnter_Steps.Text;
            //assigns the textbox value of entered steps to the variable sSteps.

            string sValidateStep = oeCookBook.Validate_Steps(sSteps);
            if (sValidateStep == "")
            {
                lListOfSteps.Items.Add(new { Step = sSteps });
                //adds the step to the listbox.
            }
            else
            {
                MessageBox.Show("Error:" + sValidateStep);
            }
            txtEnter_Steps.Clear();
            //clears the steps textbox.
        }
        //captures the step.

        private void btnSNext_Click(object sender, RoutedEventArgs e)
        {
            tCreateRecipe.IsSelected = true;
            //automatically takes the user to the Create Recipe tab.
            string sDisplayRecipe = "";
            sDisplayRecipe = sDisplayRecipe + "Recipe Name:  " + txtRecipe_Name.Text;
            sDisplayRecipe = sDisplayRecipe + '\n';

            //the code below was taken and adapted from StackOverflow
            //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
            //Trm
            //https://stackoverflow.com/users/3535152/trm
            for (int i = 0; i < lListOfIngredients.Items.Count; i++)
            {
                dynamic selectedItem = lListOfIngredients.Items[i];
                sDisplayRecipe += "Ingredeint " + (i+1) + ": " + '\n' +
                    '\t' +"Name: " + selectedItem.Ingredient + '\n' +
                    '\t' + "Quatity: " + selectedItem.Quantity + '\n' +
                    '\t' + "Measurement: " + selectedItem.Measurement + '\n' +
                    '\t' + "Calories: " + selectedItem.Calories + '\n' +
                    '\t' + "Food Group: " + selectedItem.FoodGroup + '\n';

            }
            //goes through a loop to dispaly each of the ingredeints.
            for (int i = 0; i < lListOfSteps.Items.Count; i++)
            {
                dynamic selectedItem = lListOfSteps.Items[i];
                sDisplayRecipe += "Step " + (i+1) + ": " + selectedItem.Step + '\n';

            }
            //goes through a loop to diasplay each of the steps.

                txtDisplayRecipe.Text = sDisplayRecipe;
        }

        private void btnSave_Recipe_Click(object sender, RoutedEventArgs e)
            {
              List<Ingredeint> lIngredient = new List<Ingredeint>();

            //the code below was taken and adapted from StackOverflow
            //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
            //Trm
            //https://stackoverflow.com/users/3535152/trm
            for (int b = 0; b < lListOfIngredients.Items.Count; b++)
                {
                    dynamic selectedItem = lListOfIngredients.Items[b];
                    var Ingredient = selectedItem.Ingredient;
                    var Ingredientqty = selectedItem.Quantity;
                    var IngredientCal = selectedItem.Calories;
                    var IngredientFoodgrp = selectedItem.FoodGroup;
                    var Ingredientunit = selectedItem.Measurement;

                    lIngredient.Add(new Ingredeint() { Ingredeint_Name = Ingredient, dIngredeint_quantity = Ingredientqty, iNumber_Of_Calories = IngredientCal, sFood_Group = IngredientFoodgrp, sIngredeint_unit = Ingredientunit });
                    
                }

                List<string> lSteps = new List<string>();

                for (int a = 0; a < lListOfSteps.Items.Count; a++)
                {
                    dynamic step = lListOfSteps.Items[a];
                    var sstep = step.Step;

                    lSteps.Add(sstep);
                    //adds steps to the list.

                }

               string sMsg =  oeCookBook.Create_Recipe(txtRecipe_Name.Text, int.Parse(txtNumber_Ingredients.Text), int.Parse(txtNumber_Steps.Text), lIngredient, lSteps);
                
                MessageBox.Show(sMsg);
                ClearRecipeTabs();
                tRecipe.IsSelected = true;

            }

        public void DisplayRecipe()
        {
            
            if (tDisplay.IsSelected)
            {
                List<Recipe> lRecipeNames = oeCookBook.DisplayRecipeNmaes();
                string sDisplayRecipe = "";
                for (int i = 0; i < lRecipeNames.Count; i++)
                {
                    dynamic selectedItem = lRecipeNames[i];
                    sDisplayRecipe += "Recipe " + (i + 1) + ": " + selectedItem.Name_of_Recipe + '\n';
                    lListOfRecipes.Items.Add(new { Name = sDisplayRecipe });
                    sDisplayRecipe = "";
                }
                btDisplayTabSelected = true;
            }
            else
                { btDisplayTabSelected = false; }

        }
        //dispalys the recipe names

        private void tContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (!btDisplayTabSelected && tDisplay.IsSelected)
            {

                DisplayRecipe();
            }
            else
            {
                lListOfRecipes.Items.Clear();   
                btDisplayTabSelected = false; 

            }
        }
        //displays the recipe names once the tab is clicked.
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //create the second recipe for testing 
          //  oeCookBook.createtestrecipie("Cheese");
            
            string sSearched = txtSearched_Recipe.Text;
            if (sSearched != "")
            {
                Recipe oSearchedRecipe = new Recipe();
                oSearchedRecipe = oeCookBook.SearchRecipe(sSearched);
                if (oSearchedRecipe != null)
                {
                    string sFoundRecipe = "";
                    sFoundRecipe += "Recipe name: " + oSearchedRecipe.Name_of_Recipe + '\n';
                    List<Ingredeint> oFoundRIngredients = new List<Ingredeint>();
                    List<string> oSteps = new List<string>();
                   
                    oFoundRIngredients = oSearchedRecipe.lIngredeint;
                    oSteps = oSearchedRecipe.lSteps;

                    //the code below was taken and adapted from StackOverflow
                    //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
                    //Trm
                    //https://stackoverflow.com/users/3535152/trm
                    for (int i = 0; i < oFoundRIngredients.Count; i++)
                    {
                        dynamic selectedItem = oFoundRIngredients[i];
                        sFoundRecipe += "Ingredeint " + (i + 1) + ": " + '\n' +
                            '\t' + "Name: " + selectedItem.Ingredeint_Name + '\n' +
                            '\t' + "Quatity: " + selectedItem.Ingredeint_Quantity + '\n' +
                            '\t' + "Measurement: " + selectedItem.Ingredeint_Unit + '\n' +
                            '\t' + "Calories: " + selectedItem.Number_Of_Calories + '\n' +
                            '\t' + "Food Group: " + selectedItem.Food_Group + '\n';

                    }

                    var inLineIng = new Span();
                    inLineIng.Inlines.Add(sFoundRecipe);
                    txbFoundRecipeDetails.Inlines.Add(inLineIng);
                    sFoundRecipe = "";

                    for (int i = 0; i < oSteps.Count; i++)
                    {
                        
                        //txbFoundRecipeDetails.Inlines.Add(inLineChcBox);
                        dynamic selectedItem = oSteps[i];
                        sFoundRecipe += "Step " + (i + 1) + ": " + selectedItem;

                        CheckBox chb = new CheckBox();
                        chb.Content = sFoundRecipe;
                        chb.IsChecked = false;
                        var inLineChcBox = new Span();
                        inLineChcBox.Inlines.Add(chb);
                        txbFoundRecipeDetails.Inlines.Add(inLineChcBox);
                        txbFoundRecipeDetails.Inlines.Add(new LineBreak());
                        sFoundRecipe = "";
                    }

                   
                    string sCaloryCatergory = oSearchedRecipe.Check_Calories(oSearchedRecipe.iTotal_Calories);
                    var inLineCal = new Span();
                    inLineCal.Inlines.Add(sCaloryCatergory);
                    txbFoundRecipeDetails.Inlines.Add(inLineCal);


                    // txbFoundRecipeDetails.Text = txbFoundRecipeDetails.Text + '\n' + sCaloryCatergory;

                }
                else
                {
                    MessageBox.Show("Recipe not found.");
                
                }

            }
            else
            {
                MessageBox.Show("Enter a valid recipe name.");
            }

        }
        //allows to search for a recipe.

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            tSSearch_Scale.IsSelected = true;
            

        }
        //takes the user the scale tab.
        private void btnSRScale_Click(object sender, RoutedEventArgs e)
        {
            int iScaleOption = cbScaling_Option.SelectedIndex;
            

            double dScaleFactor = 1;

            if (iScaleOption == 0)
            {
                dScaleFactor = 0.5;
            }
            else if (iScaleOption == 1)
            {
                dScaleFactor = 2;

            }
            else if (iScaleOption == 2)
            {
                dScaleFactor = 3;
            }
            else
            {
                dScaleFactor = 1;
            }
            string sSearched = txtSearched_Recipe.Text;
            if (sSearched != "")
            {
                Recipe oSearchedRecipe = new Recipe();
                oSearchedRecipe = oeCookBook.SearchRecipe(sSearched);
                if (oSearchedRecipe != null)
                {
                    string sFoundRecipe = "";
                    sFoundRecipe += "Recipe name: " + oSearchedRecipe.Name_of_Recipe + '\n';
                    List<Ingredeint> oFoundRIngredients = new List<Ingredeint>();
                    
                    oFoundRIngredients = oSearchedRecipe.lIngredeint;

                    //the code below was taken and adapted from StackOverflow
                    //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
                    //Trm
                    //https://stackoverflow.com/users/3535152/trm
                    for (int i = 0; i < oFoundRIngredients.Count; i++)
                    {
                        dynamic selectedItem = oFoundRIngredients[i];
                        sFoundRecipe += "Ingredeint " + (i + 1) + ": " + '\n' +
                            '\t' + "Name: " + selectedItem.Ingredeint_Name + '\n' +
                            '\t' + "Quatity: " + (selectedItem.Ingredeint_Quantity * dScaleFactor) + '\n' +
                            '\t' + "Measurement: " + selectedItem.Ingredeint_Unit + '\n' +
                            '\t' + "Calories: " + selectedItem.Number_Of_Calories + '\n' +
                            '\t' + "Food Group: " + selectedItem.Food_Group + '\n';

                    }

                    txbSearchedScaleRecipe.Text = sFoundRecipe;
                }
                else
                {
                    MessageBox.Show("Recipe not found.");

                }

            }
            else
            {
                MessageBox.Show("Enter a valid recipe name.");
            }
        }
        //scales the recipe that was searched.

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tReset.IsSelected = true;
            string sSearchedOg = txtSearched_Recipe.Text;
            if (sSearchedOg != "")
            {
                Recipe oSearchedRecipe = new Recipe();
                oSearchedRecipe = oeCookBook.SearchRecipe(sSearchedOg);
                if (oSearchedRecipe != null)
                {
                    string sFoundRecipe = "";
                    sFoundRecipe += "Recipe name: " + oSearchedRecipe.Name_of_Recipe + '\n';
                    List<Ingredeint> oFoundRIngredients = new List<Ingredeint>();
                    
                    oFoundRIngredients = oSearchedRecipe.lIngredeint;

                    //the code below was taken and adapted from StackOverflow
                    //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
                    //Trm
                    //https://stackoverflow.com/users/3535152/trm
                    for (int i = 0; i < oFoundRIngredients.Count; i++)
                    {
                        dynamic selectedItem = oFoundRIngredients[i];
                        sFoundRecipe += "Ingredeint " + (i + 1) + ": " + '\n' +
                            '\t' + "Name: " + selectedItem.Ingredeint_Name + '\n' +
                            '\t' + "Quatity: " + selectedItem.Ingredeint_Quantity + '\n' +
                            '\t' + "Measurement: " + selectedItem.Ingredeint_Unit + '\n' +
                            '\t' + "Calories: " + selectedItem.Number_Of_Calories + '\n' +
                            '\t' + "Food Group: " + selectedItem.Food_Group + '\n';

                    }

                    txbFoundSearchOg.Text = sFoundRecipe;
                }
                else
                {
                    MessageBox.Show("Recipe not found.");

                }
            }
            else
            {
                MessageBox.Show("Enter a valid recipe name.");
            }
        }
        //displays the searched recipes orginal quantites.
        private void btnCSearch_Click(object sender, RoutedEventArgs e)
        {
            tClear.IsSelected = true;
            string sClearRecipe = txtSearch_Clear.Text;
            if (sClearRecipe != "")
            {
                Recipe oSearchedRecipe = new Recipe();
                oSearchedRecipe = oeCookBook.SearchRecipe(sClearRecipe);
                if (oSearchedRecipe != null)
                {
                    string sFoundRecipe = "";
                    sFoundRecipe += "Recipe name: " + oSearchedRecipe.Name_of_Recipe + '\n';
                    List<Ingredeint> oFoundRIngredients = new List<Ingredeint>();
                    
                    oFoundRIngredients = oSearchedRecipe.lIngredeint;

                    //the code below was taken and adapted from StackOverflow
                    //https://stackoverflow.com/questions/42635953/c-sharp-wpf-iterate-through-listview-items
                    //Trm
                    //https://stackoverflow.com/users/3535152/trm

                    for (int i = 0; i < oFoundRIngredients.Count; i++)
                    {
                        dynamic selectedItem = oFoundRIngredients[i];
                        sFoundRecipe += "Ingredeint " + (i + 1) + ": " + '\n' +
                            '\t' + "Name: " + selectedItem.Ingredeint_Name + '\n' +
                            '\t' + "Quatity: " + selectedItem.Ingredeint_Quantity + '\n' +
                            '\t' + "Measurement: " + selectedItem.Ingredeint_Unit + '\n' +
                            '\t' + "Calories: " + selectedItem.Number_Of_Calories + '\n' +
                            '\t' + "Food Group: " + selectedItem.Food_Group + '\n';

                    }

                    txbClearRecipeDetails.Text = sFoundRecipe;
                    
                }
                else
                {
                    MessageBox.Show("Recipe not found.");

                }
            }
            else
            {
                MessageBox.Show("Enter a valid recipe name.");
            }
        }
        //searches for a recipe.

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            string sClearRecipe = txtSearch_Clear.Text; 
            if (sClearRecipe != "")
            {
                if(oeCookBook.SearchClearRecipe(sClearRecipe))
                {
                    MessageBox.Show("Recipe " + sClearRecipe + " has been deleted.");
                }
                else
                {
                    MessageBox.Show("Error with deleting Recipe " + sClearRecipe );
                }
            }
            txtSearch_Clear.Clear();
            txbClearRecipeDetails.Text = String.Empty;

        }
        //searches for a recipe and then clears it.

        private void btnApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string sNameIngredient = txtSFNameIngredient.Text;
            string sFoodGroup = cbSFFood_Group.Text;
            int iMaximumCalories = int.Parse(txtSFCalories.Text);
            lDisplayFilterdRecipes.Items.Clear();

            if (sNameIngredient != "" || sFoodGroup != "" || iMaximumCalories > 0)
            {
                List<Recipe> lRecipeNames = oeCookBook.FilterRecipe(sNameIngredient, sFoodGroup, iMaximumCalories);
                string sDisplayRecipe = "";
                for (int i = 0; i < lRecipeNames.Count; i++)
                {
                    dynamic selectedItem = lRecipeNames[i];
                    sDisplayRecipe += "Recipe " + (i + 1) + ": " + selectedItem.Name_of_Recipe + '\n';
                    lDisplayFilterdRecipes.Items.Add(new { RecipeName = sDisplayRecipe });
                    sDisplayRecipe = "";
                }
              
                MessageBox.Show("The filter was applied.");
            }
        }

        private void btnSFClear_Click(object sender, RoutedEventArgs e)
        {
            txtSFNameIngredient.Text = "";
            txtSFCalories.Text = "0";
            lDisplayFilterdRecipes.Items.Clear();   

        }
        //filters the recipes based on the ingriedent name,food group or maximun calory.
    }
 }

