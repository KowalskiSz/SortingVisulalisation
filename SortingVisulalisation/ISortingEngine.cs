using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace SortingVisulalisation
{
    interface ISortingEngine
    {
        

        void ExecuteStep();

        bool IsSorted();

        void UpDateDraw();
        
        
        
        //void DoSorting(int[] toSortArray, Graphics graphics, int maxVal); 

    }
}
