using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderForm {
    /// <summary>
    /// Author: Matthew Holdsworth
    /// Student Number: 08576904
    /// Date: 14/09/2016
    /// Pizza Order Form is a simple GUI to read in user's selections and output
    /// the required information for the Beagle Boys pizza order.
    /// </summary>
    public partial class Form1 : Form {
        public double toppings = 0;
        public string crust;
        public string sauce;
        public string name;
        public double total;

        public Form1() {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            comboBox1.Enabled = false;
            button1.Visible = false;
            textBox1.Enabled = true;
        }//end Form1

        private void textBox1_TextChanged(object sender, EventArgs e) {
            groupBox1.Enabled = true;
            GetName();//calls method GetName
        }//end event handler

        private void ThinRadio_CheckedChanged(object sender, EventArgs e) {
            comboBox1.Enabled = true;
            RadioButton check = (RadioButton) sender;
            if (check.Checked) {
                crust = ThinRadio.Text;//updates global variable crust with thin crust selection
            }//end if
        }//end event handler

        private void ThickRadio_CheckedChanged(object sender, EventArgs e) {
            comboBox1.Enabled = true;
            RadioButton check = (RadioButton) sender;
            if (check.Checked) {
                crust = ThickRadio.Text;//updates global variable crust with thick crust selection
            }//end if
        }//end event handler

        private void GlutenRadio_CheckedChanged(object sender, EventArgs e) {
            comboBox1.Enabled = true;
            RadioButton select = (RadioButton) sender;
            if (select.Checked) {
                crust = GlutenRadio.Text;//updates global variable crust with gluten-free selection
            }//end if
        }//end event handler

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            groupBox2.Enabled = true;
            button1.Visible = true;
            GetSauce();//calls method to obtain the sauce string
        }//end event handler

        private void checkBox1_Click(object sender, EventArgs e) {
            CheckBox check = (CheckBox) sender;
            if (check.Checked) {
                IncrementToppings();//call to method - increments toppings by one
            } else {
                DecrementToppings();//call to method - decrements toppings by one
            }//end if-else
        }//end event handler

        private void button1_Click(object sender, EventArgs e) {
            CalculateTotal(crust, toppings);//calculates total depending on input
            if (toppings == 0) {
                MessageBox.Show("You require at least 1 topping to complete your order.\n\n" + 
                    "Remember up to 4 toppings are free!"); 
            } else {
                OutputResults(total);//calls method to show output message box
            }//end if-else
        }//end event handler

        /// <summary>
        /// Gets the sauce selection for the pizza
        /// Converts comboBox1 selection to string
        /// </summary>
        /// <returns>string sauce</returns>
        string GetSauce() {
            return sauce = comboBox1.SelectedItem.ToString();
        }//end GetSauce

        /// <summary>
        /// Gets the users entry from the textbox
        /// </summary>
        /// <returns>string name</returns>
        string GetName() {
            return name = textBox1.Text;
        }//end GetName

        /// <summary>
        /// Increments toppings by one
        /// </summary>
        /// <returns>double toppings - number of toppings</returns>
        double IncrementToppings() {
            toppings = toppings+1;
            return toppings;
        }//end IncrementToppings

        /// <summary>
        /// Decrements toppings by one
        /// </summary>
        /// <returns>double toppings - number of toppings</returns>
        double DecrementToppings() {
            toppings = toppings-1;
            return toppings;
        }//end DecrementToppings

        /// <summary>
        /// Calculates the total cost of the pizza by checking if it is gluten-free
        /// and adding the toppings and base cost
        /// </summary>
        /// <param name="crust">string obtained from the radio button selection</param>
        /// <param name="toppings">integer number of toppings</param>
        /// <returns>double total - cost of the pizza</returns>
        public double CalculateTotal(string crust, double toppings) {
            double initialCost = 10.00;//$10 base cost for any pizza
            double glutenCharge = 2.00;//$2 surcharge for gluten-free
            double freeToppings = 4.00;//limit of free toppings
            
            if ((toppings > freeToppings) && (crust != "gluten-free *")) {
                total = initialCost + (toppings - freeToppings);//if toppings are less than free topping limit and not a gluten-free crust, adds appropriate srcharges
                return total;
            } else if ((crust == "gluten-free *") && (toppings <= freeToppings)) {
                total = initialCost + glutenCharge;//if crust is gluten-free, adds appropriate surcharge
                return total;
            } else if ((crust == "gluten-free *") && (toppings > freeToppings)) {
                total = initialCost + glutenCharge + (toppings - freeToppings);//if toppings are more than four and gluten-free, adds appropriate surcharges
                return total;
            } else {
                return total = initialCost;//returns initial cost for pizza without surcharges
            }//end if-else
        }//end CalculateTotal

        /// <summary>
        /// Outputs results of selection and total price for the pizza.
        /// Outputs thankyou message.
        /// </summary>
        void OutputResults(double total) {
                MessageBox.Show("Thankyou for your order " + name + ", of a " + crust + " pizza base with " + sauce + 
                    " sauce and " + toppings + " topping/s.\n\nThe cost of your pizza is $" + total.ToString("F") + "\n\n");//converts total to double decimal string
                MessageBox.Show("Thanks for your order from Beagle Boys Pizza. Your pizza will be delivered in 30 minutess or it's free!");
        }//end OutputResults
    }//end class
}//end namespace
