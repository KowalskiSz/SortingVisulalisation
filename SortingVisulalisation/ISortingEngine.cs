using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace SortingVisulalisation
{
    interface ISortingEngine
    {
        // Dfinie the the sorting method in the interface in order to 
        //implement different sorting engines next

        //Passing the arrat to sort, graphics obj and max value (number of the obj to sort)
        void DoSorting(int[] toSortArray, Graphics graphics, int maxVal); 

    }
}
