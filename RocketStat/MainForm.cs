using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace RocketStat
{
    public partial class MainForm : Form
    {
        #region Global Variables

        private string mask;
        private byte[] pattern;

        private Process RocketProcess;

        private string ProcessName;
        private int AddressNum;
        private string AddressHex;

        private IntPtr pAddr;
        private System.Windows.Forms.Timer RefreshTimer;

        private int RetryCounter = 0;
        private bool FirstScanComplete = false;

        private static int TotalPoints = 0;
        private static int TotalGoals = 0;
        private static int TotalAssists = 0;
        private static int TotalSaves = 0;
        private static int TotalShots = 0;

        private static Hashtable HashAddresses;

        #endregion

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, int lpNumberOfBytesWritten);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProcessName = "rocketleague";

            mask = "xx?x????xxxxxxxx????????xxxxxxxx??xxxxxxx???xxxx?xxxxx??xx"; //x for known, ? for unknown

            pattern = new byte[] {  0xD0, 0x9E, 0, 0x01, 0, 0, 0, 0, 0x00, 0x00, 0x10, 0x10, 0x01, 0x00, 0x00, 0x02,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF,
                                    0, 0, 0x01, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0, 0, 0, 0xC8, 0xAB, 0x00, 0x00,
                                    0, 0x00, 0x00, 0x00, 0x80, 0xDE, 0, 0, 0x00, 0x4D }; 

            try
            {
                RocketProcess = Process.GetProcessesByName(ProcessName)[0];

                ProcessModuleCollection myProcessModuleCollection = RocketProcess.Modules;
                Console.WriteLine("Base addresses of the modules associated " + "with selected process are:");

                // Display the 'BaseAddress' of each of the modules.
                for (int i = 0; i < myProcessModuleCollection.Count; i++)
                {
                    Console.WriteLine(myProcessModuleCollection[i].ModuleName + " : " + myProcessModuleCollection[i].BaseAddress);
                }
            }
            catch (Exception m)
            {
                if (m.Message == "Index was outside the bounds of the array.")
                {
                    MessageBox.Show("Process not found! \nPlease start the game and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    MessageBox.Show(m.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            // Deserialize and get info if file exists
            if (File.Exists("info.dat"))
            {
                Deserialize();

                TotalPoints = (int)HashAddresses["Points"];
                TotalGoals = (int)HashAddresses["Goals"];
                TotalAssists = (int)HashAddresses["Assists"];
                TotalSaves = (int)HashAddresses["Saves"];
                TotalShots = (int)HashAddresses["Shots"];

                TotalPointsLabel.Text = TotalPoints.ToString();
                TotalGoalsLabel.Text = TotalGoals.ToString();
                TotalAssistsLabel.Text = TotalAssists.ToString();
                TotalSavesLabel.Text = TotalSaves.ToString();
                TotalShotsLabel.Text = TotalShots.ToString();
            }
        }

        private void ScanMem()
        {
            if(RetryCounter == 0)
            {
                InfoLabel.ForeColor = Color.Orange;
                InfoLabel.Text = "scanning...";
                InfoLabel.Refresh();
            }
            else if (RetryCounter == 1)
            {
                InfoLabel.Text = "retrying in 3 seconds";
                InfoLabel.Refresh();

                Thread.Sleep(3000);

                InfoLabel.ForeColor = Color.Orange;
                InfoLabel.Text = "retrying scan...";
                InfoLabel.Refresh();
            }
            else if (RetryCounter == 2)
            {
                InfoLabel.Text = "retrying in 3 seconds";
                InfoLabel.Refresh();

                Thread.Sleep(3000);

                InfoLabel.ForeColor = Color.Orange;
                InfoLabel.Text = "retrying again...";
                InfoLabel.Refresh();
            }

            // Scan for array of bytes
            AobMemScan AobScanner = new AobMemScan();
            pAddr = AobScanner.AobScan(ProcessName, pattern, mask);

            // If something was found
            if (pAddr != IntPtr.Zero)
            {
                AddressNum = pAddr.ToInt32();
                AddressHex = string.Format("0x{0:X}", AddressNum);

                if (AddressHex.Length > 4)
                {
                    InfoLabel.ForeColor = Color.Green;
                    InfoLabel.Text = AddressHex;

                    RefreshForm();
                    InitTimer();

                    return;
                }
            }

            // If not found, try again
            if (RetryCounter == 0)
            {
                RetryCounter++;
                ScanMem();
            }
            else if (RetryCounter == 1)
            {
                RetryCounter++;
                ScanMem();
            }

            // Not found after second retry
            RetryCounter = 0;

            NumPointsLabel.Text = "0";
            NumGoalsLabel.Text = "0";
            NumAssistsLabel.Text = "0";
            NumSavesLabel.Text = "0";
            NumShotsOnGoalLabel.Text = "0";

            InfoLabel.ForeColor = Color.Red;
            InfoLabel.Text = "not found";
        }

        private void RefreshForm()
        {
            int temp = 0;
            int bytesRead = 0;

            // Check if memory moved
            byte[] ChunkStatusByte = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, pAddr, ChunkStatusByte, ChunkStatusByte.Length, bytesRead);

            if (ChunkStatusByte[0] != 0xD0)
            {
                InfoLabel.ForeColor = Color.Orange;
                InfoLabel.Text = "mem realloc detected";
                InfoLabel.Refresh();

                Thread.Sleep(5000);
                ScanMem();

                return;
            }

            // Points
            bytesRead = 0;
            int PointsAddress = AddressNum + 756;
            IntPtr PointsAddressPtr = new IntPtr(PointsAddress);
            byte[] points = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, PointsAddressPtr, points, points.Length, bytesRead);
            temp = Int32.Parse(NumPointsLabel.Text);
            int PointsAmount = BitConverter.ToInt32(points, 0);

            if (PointsAmount > 99999 || PointsAmount < 0)
            {
                Thread.Sleep(4000);
                ScanMem();
                return;
            }

            NumPointsLabel.Text = PointsAmount.ToString();

            if (temp < PointsAmount && FirstScanComplete == true)
            {
                TotalPoints += PointsAmount - temp;
                TotalPointsLabel.Text = TotalPoints.ToString();
            }

            // Goals
            bytesRead = 0;
            int GoalsAddress = AddressNum + 760;
            IntPtr GoalsAddressPtr = new IntPtr(GoalsAddress);
            byte[] goals = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, GoalsAddressPtr, goals, goals.Length, bytesRead);
            temp = Int32.Parse(NumGoalsLabel.Text);
            int GoalsAmount = BitConverter.ToInt32(goals, 0);

            if (GoalsAmount > 99 || GoalsAmount < 0)
            {
                Thread.Sleep(4000);
                ScanMem();
                return;
            }

            NumGoalsLabel.Text = GoalsAmount.ToString();

            if (temp < GoalsAmount && FirstScanComplete == true)
            {
                TotalGoals += GoalsAmount - temp;
                TotalGoalsLabel.Text = TotalGoals.ToString();
            }

            // Assists
            bytesRead = 0;
            int AssistsAddress = AddressNum + 768;
            IntPtr AssistsAddressPtr = new IntPtr(AssistsAddress);
            byte[] assists = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, AssistsAddressPtr, assists, assists.Length, bytesRead);
            temp = Int32.Parse(NumAssistsLabel.Text);
            int AssistsAmount = BitConverter.ToInt32(assists, 0);

            if (AssistsAmount > 99 || AssistsAmount < 0)
            {
                Thread.Sleep(4000);
                ScanMem();
                return;
            }

            NumAssistsLabel.Text = AssistsAmount.ToString();

            if (temp < AssistsAmount && FirstScanComplete == true)
            {
                TotalAssists += AssistsAmount - temp;
                TotalAssistsLabel.Text = TotalAssists.ToString();
            }

            // Saves
            bytesRead = 0;
            int SavesAddress = AddressNum + 772;
            IntPtr SavesAddressPtr = new IntPtr(SavesAddress);
            byte[] saves = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, SavesAddressPtr, saves, saves.Length, bytesRead);
            temp = Int32.Parse(NumSavesLabel.Text);
            int SavesAmount = BitConverter.ToInt32(saves, 0);

            if (SavesAmount > 99 || SavesAmount < 0)
            {
                Thread.Sleep(4000);
                ScanMem();
                return;
            }

            NumSavesLabel.Text = SavesAmount.ToString();

            if (temp < SavesAmount && FirstScanComplete == true)
            {
                TotalSaves += SavesAmount - temp;
                TotalSavesLabel.Text = TotalSaves.ToString();
            }

            // Shots
            bytesRead = 0;
            int ShotsOnGoalAddress = AddressNum + 776;
            IntPtr ShotsOnGoalAddressPtr = new IntPtr(ShotsOnGoalAddress);
            byte[] shotsOnGoal = new byte[4];
            ReadProcessMemory(RocketProcess.Handle, ShotsOnGoalAddressPtr, shotsOnGoal, shotsOnGoal.Length, bytesRead);
            temp = Int32.Parse(NumShotsOnGoalLabel.Text);
            int ShotsOnGoalAmount = BitConverter.ToInt32(shotsOnGoal, 0);

            if (ShotsOnGoalAmount > 99 || ShotsOnGoalAmount < 0)
            {
                Thread.Sleep(4000);
                ScanMem();
                return;
            }

            NumShotsOnGoalLabel.Text = ShotsOnGoalAmount.ToString();

            if (temp < ShotsOnGoalAmount && FirstScanComplete == true)
            {
                TotalShots += ShotsOnGoalAmount - temp;
                TotalShotsLabel.Text = TotalShots.ToString();
            }

            // Boost
            //bytesRead = 0;
            //int BoostAddress = AddressNum + 352;
            //IntPtr BoostAddressPtr = new IntPtr(BoostAddress);
            //byte[] boost = new byte[4];
            //ReadProcessMemory(RocketProcess.Handle, BoostAddressPtr, boost, boost.Length, bytesRead);
            //int BoostAmount = BitConverter.ToInt32(boost, 0);

            //if (BoostAmount > 100 || BoostAmount < 0)
            //{
            //    Thread.Sleep(5000);
            //    ScanMem();
            //    return;
            //}

            //BoostAmountLabel.Text = BoostAmount.ToString();

            // Serialize info to file
            Serialize();

            if (FirstScanComplete == false)
                FirstScanComplete = true;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            ScanMem();
        }

        public void InitTimer()
        {
            RefreshTimer = new System.Windows.Forms.Timer();
            RefreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
            RefreshTimer.Interval = 1000; //in miliseconds
            RefreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshForm();
        }

        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            HashAddresses = new Hashtable();
            HashAddresses.Add("Points", TotalPoints);
            HashAddresses.Add("Goals", TotalGoals);
            HashAddresses.Add("Assists", TotalAssists);
            HashAddresses.Add("Saves", TotalSaves);
            HashAddresses.Add("Shots", TotalShots);

            // To serialize the hashtable and its key/value pairs, you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream("info.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, HashAddresses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        static void Deserialize()
        {
            // Declare the hashtable reference.
            HashAddresses = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("info.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and assign the reference to the local variable.
                HashAddresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, display the key/value pairs.
            foreach (DictionaryEntry de in HashAddresses)
            {
                Console.WriteLine("{0} : {1}.", de.Key, de.Value);
            }
        }
    }
}
