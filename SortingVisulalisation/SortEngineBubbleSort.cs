using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace SortingVisulalisation
{
    class SortEngineBubbleSort : ISortingEngine
    {
        //Essential vals to perform the sorting (those copies need to be changed)
        private int[] arrayToSort; 
        private Graphics g;
        private int maxVal;


        //Define two Brush obj
        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black); 

        public SortEngineBubbleSort(int[] toSortArray, Graphics graphics, int mVal)
        {
            arrayToSort = toSortArray;
            g = graphics;
            maxVal = mVal;
        }
        
        //DoSorting method contains the Bubble Sort Algh
        public void ExecuteStep()
        {
            //Sorting through the array under the condition
            for(int i = 0; i < arrayToSort.Count() - 1; i++)
            {
                if (arrayToSort[i] > arrayToSort[i + 1])
                {
                    SwapVals(i, i + 1);
                }
            }

        }

        //Swapping two unsorted values
        private void SwapVals(int a, int n)
        {
            int tempVal = arrayToSort[a];
            arrayToSort[a] = arrayToSort[n];
            arrayToSort[n] = tempVal;

            //Upadate the display on the screen
            //Remove old valuse for the dispaly and show the black background
            g.FillRectangle(BlackBrush, a, 0, 1, maxVal);
            g.FillRectangle(BlackBrush, n, 0, 1, maxVal);

            //Display the new value as a white reqtangle
            g.FillRectangle(WhiteBrush, a, maxVal - arrayToSort[a], 1, maxVal);
            g.FillRectangle(WhiteBrush, n, maxVal - arrayToSort[n], 1, maxVal);


        }

        //Checking of the array is already sorted - if so return true - stop the main loop
        public bool IsSorted()
        {
            for(int i=0; i < arrayToSort.Count() - 1; i++)
            {
                if (arrayToSort[i] > arrayToSort[i + 1])
                {
                    return false; 
                }

            }
            return true;
        }

        public void UpDateDraw()
        {
            for(int i=0; i<arrayToSort.Count()-1; i++)
            {
                g.FillRectangle(new SolidBrush(Color.White), i, arrayToSort[i], 1, maxVal); 
            }
        }
    }
}
