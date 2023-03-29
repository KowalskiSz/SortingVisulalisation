using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisulalisation
{
    public partial class Form1 : Form
    {
        
        // Number of objs to sort (1 px reqtangles) to display 
        int[] toSortObj;
        Graphics g; //grafics obj


        public Form1()
        {
            InitializeComponent();
            
        }

        //Function to generate 
        private void genetareRandomNumbers(int[] numArray, int s, int maxV)
        {
            //init new Random Obj
            Random random = new Random();
            
            //Fill the array wiht random nubers 
            for(int i=0; i<s; i++)
            {
                numArray[i] = random.Next(0, maxV);
            }

        }

        //Reset button function
        private void resetButton_Click(object sender, EventArgs e)
        {
            //Creating the display object on the panel
            g = graphicsPanel.CreateGraphics();

            //sorting obj (rectangles) params
            int numEntries = graphicsPanel.Width;
            int maxVal = graphicsPanel.Height; 

            toSortObj = new int[numEntries];
            
            //init of the reqtangle space on the panel (black backqround)
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxVal);

            //Random numbers fun
            genetareRandomNumbers(toSortObj, numEntries, maxVal);

            //Filling the graphics pannel with white 1 px wide rectangles
            for(int i=0; i < numEntries; i++)
            {
                g.FillRectangle(new SolidBrush(Color.White), i, toSortObj[i], 1, maxVal);
            }

        }
    }
}
