using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisulalisation
{

    /// <summary>
    /// To add now: 
    /// - add more algorythms
    /// - add some time mesurement
    /// </summary>
    public partial class SortForm : Form
    {
        
        // Number of objs to sort (1 px reqtangles) to display 
        int[] toSortObj;
        Graphics g;

        //Properties to execute threading with pausing the execution
        BackgroundWorker bWorker = null;
        bool isPaused = false; 

        public SortForm()
        {
            InitializeComponent();
            GetSortAlgorythms(); 
            
        }

       
        public void GetSortAlgorythms()
        {
            //Getting list of all the classes implementing the ISortEngine Interface
            List<string> classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(
                x => x.GetTypes()).Where(x => typeof(ISortingEngine).IsAssignableFrom(x)
                && !x.IsInterface && !x.IsAbstract).Select(x => x.Name).ToList();

            //Sprting and adding results to the combobox
            classList.Sort();

            foreach(var item in classList)
            {
                algorythmComboBox.Items.Add(item);
            }

            algorythmComboBox.SelectedIndex = 0;
        }

        
        //Function to generate random nums to sort
        private static void genetareRandomNumbers(ref int[] numArray, int s, int maxV)
        {
            //init new Random Obj
            Random random = new Random();
            
            //Fill the array wiht random nubers 
            for(int i=0; i<s; i++)
            {
                numArray[i] = random.Next(0, maxV);
            }

        }

        //Pausing and resuming the algorythm 
        private void pauseButton_Click(object sender, EventArgs e)
        {
            if(!isPaused && bWorker.IsBusy)
            {
                isPaused = true;
                bWorker.CancelAsync(); //Stopping the thread 

            }    
            else 
            {
                isPaused = false;

                //It can propably be unusefull

                //int numEntries = graphicsPanel.Width;
                //int maxVal = graphicsPanel.Height;

                //for (int i = 0; i < numEntries; i++)
                //{
                //   g.FillRectangle(new SolidBrush(Color.Black), i, 0, 1, maxVal); 
                //   g.FillRectangle(new SolidBrush(Color.White), i, maxVal - toSortObj[i], 1, maxVal);
                //}

                bWorker.RunWorkerAsync(argument: algorythmComboBox.SelectedItem); //Running thread
                
            }

        }

        
        //Perform the sorting algorythm 
        private void sortButton_Click(object sender, EventArgs e)
        {
            //Invoke the restet button click method to fill in the space to sort
            if(toSortObj == null)
            {
                resetButton_Click(null, null);
            }
            //new instance of the BackgroundWorker class to handle the Threading
            bWorker = new BackgroundWorker();
            bWorker.WorkerSupportsCancellation = true;

            //adding new event to doWork method
            bWorker.DoWork += new DoWorkEventHandler(bgwDoWork);
            bWorker.RunWorkerAsync(argument: algorythmComboBox.SelectedItem);

            sortButton.Enabled = false;
            
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
            genetareRandomNumbers(ref toSortObj, numEntries, maxVal);

            //Filling the graphics pannel with white 1 px wide rectangles
            for(int i=0; i < numEntries; i++)
            {
                g.FillRectangle(new SolidBrush(Color.White), i, maxVal - toSortObj[i], 1, maxVal);
            }

            sortButton.Enabled = true;
            pauseButton.Enabled = true; 
        }

        #region BackgroundWorker Settings

        private void bgwCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show($"{e.Result}", "Completed", MessageBoxButtons.OK);
        }

        private void bgwDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            //Argumnet passed in the RunWorkerAsync - name of the SortingEngine from combobox
            string SortEngineName = e.Argument.ToString();
            
            //Getting the name of the certain class to be called to execute the sorting 
            Type type = Type.GetType("SortingVisulalisation." + SortEngineName);
            var ctors = type.GetConstructors(); //there will be one Constructor
            
            try
            {
                //Dynamically calling function (by Invoke method and its interface)
                ISortingEngine se = (ISortingEngine)ctors[0].Invoke(new object[] { toSortObj,
                g, graphicsPanel.Height});

                //Main loop executing the sorting method
                while ((!se.IsSorted()) && (!bWorker.CancellationPending))
                {
                    se.ExecuteStep(); 
                }

                //Occures when the sorting is done
                if(se.IsSorted())
                {
                    e.Result = "Sorting has been completed";
                    MessageBox.Show($"{e.Result}", "Completed", MessageBoxButtons.OK);
                }
            }
            catch
            {
               

            }
             
        }

        #endregion

       
    }


}
