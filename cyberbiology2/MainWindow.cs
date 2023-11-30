using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Windows.Input;

namespace cyberbiology2
{
    public partial class MainWindow : Form
    {
        //old format .cmakk
        //1498; 857
        //setup consts
        static public int tilesize = 5;
        static public int width = 90*2;
        static public int height = 56*2;
        static public int windowWidth = width * tilesize + 137 + 50;
        static public int windowHeight = height * tilesize + 68;
        static public int size = width * height;
        //objects
        //180 112
        Drawer drawer;
        public static Cell[,] cells = new Cell[width, height];
        public static Cell Operator = new Cell(false, 0, 0, null, null, 0, 0, 0, 0, 0, 0);
        //cell class vars
        static public int genLenght = 64;
        //world parametrs vars
        static public int season = 0;
        static public int time = 0;//0-2400
        static public int dayCounter = 0;
        static public int yearCounter = 0;
        static public int population = 0;
        static public int organicCounter = 0;
        static public int maxGeneration = 1;
        static public bool mineralsEnabled = true;
        static public Seasons winter = new Seasons(0, "Winter", Color.Cyan, "ᛁᛁᛁ");
        static public Seasons autumn = new Seasons(1, "Autumn", Color.DarkOrange, "ᚿᚿᚿ");
        static public Seasons spring = new Seasons(2, "Spring", Color.GreenYellow, "ᚾᚾᚾ");
        static public Seasons summer = new Seasons(3, "Summer", Color.ForestGreen, "ᚬᚬᚬ");
        static public Dictionary<int, Seasons> seasonsDict = new Dictionary<int, Seasons>() {
            { 0, spring },
            { 1, summer },
            { 2, autumn },
            { 3, winter },
        };
        //threads
        Thread mainThread;
        Thread drawingThread;
        Thread UIThread;
        //random generator
        public static Random rnd = new Random();
        //other parameters
        public static int drawtype = 1;
        public static int simulationSpeed = 3;
        public static bool simulationIsAlive = true;
        public static bool turnIsOver = false;//flag sends to other threads that turn is over and save/load could be performed
        public static bool autosaveCompleted = false;//checked every 1 day of season and autosaved then
        public static int quitRequired = 0;//timer until quit 
        public static bool redrawNeeded = true;
        public static bool redrawNeededForCharts = true;
        DateTime elapsedTime;
        DateTime starttime;
        TimeSpan timeSpan;
        CultureInfo enUS = new CultureInfo("en-US");
        Font defaultFont;

        public MainWindow()
        {
            InitializeComponent();
            Window_Setup();
        }
        //-----------------------------------------------------------------------------------
        private void Window_Setup()
        {
            this.Width = windowWidth;
            this.Height = windowHeight;

            if (windowWidth > 0)
               defaultFont = new Font("Lucida Console", 12, FontStyle.Bold);
            dataStrip.Font = defaultFont;
            dataStrip.Width = windowWidth;
            dataStrip.BringToFront();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.chartsPictureBox.BringToFront();
            this.ControlBox = false;
            this.Text = "";
            starttime = DateTime.Now;
            mineralsEnabledButton_Click(null, null);
            hintTextBox.ReadOnly = true;
            hintTextBox.Text=("=Backspace - Close\n=Space - Pause&Continue\n" +
                "=Esc/RMouse - Show/Hide InfoBox\n" +
                "=Q To Quit\n=Press H to Hide window\n" +
                "=1/2/3 to Change Draw Types\n"+
                "=These binds could be used alternatively to buttons.");
        }
        private void Turn()
        {
            while (true)
            {
                if (simulationIsAlive)
                {
                    turnIsOver = false;
                    TimeProgress();
                    Operator.CellsProgress();
                    Autosave();
                }
                else
                {
                    Thread.Sleep(50);
                }
                turnIsOver = true;
                if (simulationSpeed == 1)
                    Thread.Sleep(35);
                if (simulationSpeed == 2)
                    Thread.Sleep(20);
            }
        }
        private void TimeProgress()
        {
            time++;
        }
        private void ImageUpdate()
        {
            while (true)
            {
                if (!simulationIsAlive)
                {
                    Thread.Sleep(50);
                }
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        if (cells[x, y] != null)
                            drawer.DrawCell(cells[x, y]);
                        else
                            drawer.ClearTile(x, y);
                    }
                drawer.DrawGrid();
                world_pictureBox.Image = drawer.GetMap();
                drawer.Refresh();
                Operator.GetStats();
                if (redrawNeeded)
                {
                    drawer.DrawNumbers();
                    rightInfoPanel.BackgroundImage = drawer.GetMap();
                    redrawNeeded = false;
                }
                if (redrawNeededForCharts)
                {
                    drawer.DrawCharts(population);
                    chartsPictureBox.Image = drawer.GetCharts();
                    redrawNeededForCharts = false;
                }
                drawer.Refresh();
                // Thread.Sleep(15);
            }
        }
        private void UpdateUI()
        {
            while (true)
            {
                Operator.GetStats();
                time_dataStrip.Text = (time / 100).ToString() + ":00";
                Thread.Sleep(10);
                if (time >= 2400)
                {
                    redrawNeededForCharts = true;
                    time = 0;
                    dayCounter++;
                    time_dataStrip.Text = (time % 100).ToString() + ":00";
                    Thread.Sleep(10);
                    day_dataStrip.Text = "Day " + dayCounter.ToString() + " of";
                    Thread.Sleep(10);
                    if (dayCounter >= 10)
                    {
                        redrawNeeded = true;
                        autosaveCompleted = false;
                        if (season == 3)
                            yearCounter++;
                        dayCounter = 0;
                        season = (season + 1) % 4;
                        day_dataStrip.Text = "Day " + dayCounter.ToString() + " of";
                        Thread.Sleep(10);
                        season_dataStrip.Text = seasonsDict[season].name + ", Year " + yearCounter.ToString();
                        Thread.Sleep(10);
                    }
                }
                if (chartsPanel.Visible)
                {
                    Invoke(new Action(() => populationStrip.Text = "Alive: " + population.ToString()));
                    Thread.Sleep(10);
                    Invoke(new Action(() => organicCountStrip.Text = "Organic: " + organicCounter.ToString()));
                    Thread.Sleep(10);
                    Invoke(new Action(() => maxGenerationStrip.Text = "Last generation: " + maxGeneration.ToString()));
                    Thread.Sleep(10);
                }
                else
                {
                    Thread.Sleep(30);
                }
                Action action = () => season_dataStrip.ForeColor = seasonsDict[season].color;
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
                Thread.Sleep(10);
                currentTime.Text = DateTime.Now.ToString(enUS);
                timeSpan = DateTime.Now - starttime;
                elapsedTime = new DateTime(timeSpan.Ticks);
                elapsedStrip.Text = elapsedTime.ToLongTimeString();
                Thread.Sleep(10);
            }
        }
        private void Save(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(time);
                writer.Write(season);
                writer.Write(dayCounter);
                writer.Write(yearCounter);
                writer.Write(population);
                writer.Write(organicCounter);
                writer.Write(maxGeneration);
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        if (cells[x, y] != null)
                        {

                            writer.Write(x);
                            writer.Write(y);
                            writer.Write(cells[x, y].rotation);
                            writer.Write(cells[x, y].energy);
                            writer.Write(cells[x, y].storedMinerals);
                            writer.Write(cells[x, y].commandAddress);
                            writer.Write(cells[x, y].organic);
                            writer.Write(cells[x, y].active);
                            writer.Write(cells[x, y].generation);
                            for (int i = 0; i < genLenght; i++)
                                writer.Write(cells[x, y].genome[i]);
                            for (int i = 0; i < 3; i++)
                                writer.Write(cells[x, y].color[i]);

                        }
                    }
            }
        }
        private void Autosave()
        {
            if (dayCounter == 1 && !autosaveCompleted)
            {
                autosaveCompleted = true;
                Save("autosave.cybsf");
                autosavedateStrip.Text = "Last autosave: " + DateTime.Now.ToString("hh:mm tt", enUS);

            }
        }
        //user events
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //world_pictureBox.BackgroundImage = new Bitmap(cyberbiology2.Properties.Resources.world);
            drawer = new Drawer(chartsPictureBox.Width, chartsPictureBox.Height);
            drawer.DrawGrid();
            drawer.DrawChartsAxis();
            Operator.CreateFirst();
            mainThread = new Thread(Turn);
            mainThread.Start();
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    drawer.DrawTile(x, y);
            world_pictureBox.BackgroundImage = drawer.GetMap();
            drawer.Refresh();
            drawingThread = new Thread(ImageUpdate);
            drawingThread.Start();
            UIThread = new Thread(UpdateUI);
            UIThread.Start();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainThread.Abort();
            drawingThread.Abort();
            UIThread.Abort();
            if (!mainThread.IsAlive && !drawingThread.IsAlive && !UIThread.IsAlive)
                System.Environment.Exit(1);
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 49)
                drawEnergyTypeButton_Click(null, null);
            if (e.KeyValue == 50)
                drawStoredEnergyButton_Click(null, null);
            if (e.KeyValue == 51)
                drawGenomeButton_Click(null, null);
            if (e.KeyValue == 8)
                this.Close();
            if (e.KeyValue == 27)
                cellInfo.Visible = !cellInfo.Visible;
            if (e.KeyValue == 32)
            {
                simulationIsAlive = !simulationIsAlive;
                if (!simulationIsAlive)
                    ButtonChangeColor_Yellow(pauseButton, null);
                else
                    ButtonChangeColor_Green(pauseButton, null);
            }
            if (e.KeyValue == 72)
            {
                    this.WindowState = FormWindowState.Minimized;
            }
            if (e.KeyValue == 81)
            {
                this.Close();
            }
        }
        private void world_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cellInfo.Visible = false;
                return;
            }
            if (cells[e.X / tilesize, e.Y / tilesize] != null)
            {
                Cell tcell = cells[e.X / tilesize, e.Y / tilesize];
                switch (tcell.organic)
                {
                    case 1:
                        cellInfo.Text = "Cell";
                        break;
                    case 2:
                        cellInfo.Text = "Sinking Organic";
                        break;
                    case 3:
                        cellInfo.Text = "Drowned Organic";
                        break;
                }
                cellImage.BackColor = Color.FromArgb(tcell.color[0],
                    tcell.color[1],
                    tcell.color[2]);
                textBoxCellInfo.Text = "------------------------\n";
                textBoxCellInfo.Text += "Color: " + tcell.color[0].ToString() + ", " +
                    tcell.color[1].ToString() + ", " +
                    tcell.color[2].ToString() + "\n";
                textBoxCellInfo.Text += "Energy: " + tcell.energy + "\n";
                textBoxCellInfo.Text += "Minerals: " + tcell.storedMinerals + "\n";
                textBoxCellInfo.Text += "Location: X:" + tcell.x + " Y:" + tcell.y + "\n";
                textBoxCellInfo.Text += "Rotated: " + tcell.rotation + "\n";
                textBoxCellInfo.Text += "From Generation: " + tcell.generation + "\n";
                textBoxCellInfo.Text += "        Genome " + "\n";
                for (int i = 0; i < genLenght; i++)
                {
                    textBoxCellInfo.Text += tcell.genome[i] + " ";
                    if ((i + 1) % 8 == 0)
                        textBoxCellInfo.Text += "\n";
                }
                textBoxCellInfo.Text += "------------------------";
                cellInfo.Visible = true;

            }
            else
            {
                cellInfo.Text = "None";
                textBoxCellInfo.Text = "";
                cellImage.BackColor = SystemColors.Control;
                cellInfo.Visible = true;
            }
        }        
        private void drawEnergyTypeButton_Click(object sender, EventArgs e)
        {
            drawtype = 1;
            drawEnergyTypeButton.BackColor = Color.Yellow;
            drawGenomeButton.BackColor = Color.Black;
            drawStoredEnergyButton.BackColor = Color.Black;
        }
        private void drawStoredEnergyButton_Click(object sender, EventArgs e)
        {
            drawtype = 2;
            drawEnergyTypeButton.BackColor = Color.Black;
            drawGenomeButton.BackColor = Color.Black;
            drawStoredEnergyButton.BackColor = Color.Yellow;
        }
        private void drawGenomeButton_Click(object sender, EventArgs e)
        {
            drawtype = 3;
            drawEnergyTypeButton.BackColor = Color.Black;
            drawGenomeButton.BackColor = Color.Yellow;
            drawStoredEnergyButton.BackColor = Color.Black;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void quitButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        private void pauseButton_MouseClick(object sender, MouseEventArgs e)
        {
            simulationIsAlive = !simulationIsAlive;
            if (simulationIsAlive)
            {
                pauseButton.ForeColor = Color.Lime;
                pauseButton.FlatAppearance.BorderColor = Color.Lime;
            }
            else
            {
                pauseButton.ForeColor = Color.Yellow;
                pauseButton.FlatAppearance.BorderColor = Color.Yellow;
            }
        }
        private void hideButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        async private void saveButton_MouseClick(object sender, MouseEventArgs e)
        {
            simulationIsAlive = false;
            await Task.Run(() => { while (!turnIsOver) continue; });
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Cyberbiology File|*.cybsf";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string savePath = sf.FileName;
                Save(savePath);
            }
            simulationIsAlive = true;
        }
        async private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {
            pauseButton_MouseClick(null,null);
            await Task.Run(() => { while (!turnIsOver) continue; });
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Cyberbiology File|*.cybsf";
            if (of.ShowDialog() == DialogResult.OK)
            {
                cells = new Cell[width, height];
                string openPath = of.FileName;
                using (BinaryReader reader = new BinaryReader(File.Open(openPath, FileMode.Open)))
                {
                    time = reader.ReadInt32();
                    season = reader.ReadInt32();
                    dayCounter = reader.ReadInt32();
                    yearCounter = reader.ReadInt32();
                    population = reader.ReadInt32();
                    organicCounter = reader.ReadInt32();
                    maxGeneration = reader.ReadInt32();
                    time_dataStrip.Text = (time / 100).ToString() + ":00";
                    day_dataStrip.Text = "Day " + dayCounter.ToString() + " of";
                    season_dataStrip.Text = seasonsDict[season].name + ", Year " + yearCounter.ToString();
                    populationStrip.Text = "Alive: " + population.ToString();
                    organicCountStrip.Text = "Organic: " + organicCounter.ToString();
                    maxGenerationStrip.Text = "Last generation: " + maxGeneration.ToString();
                    currentTime.Text = DateTime.Now.ToString(enUS);
                    timeSpan = DateTime.Now - starttime;
                    elapsedTime = new DateTime(timeSpan.Ticks);
                    elapsedStrip.Text = elapsedTime.ToLongTimeString();
                    season_dataStrip.ForeColor = seasonsDict[season].color;
                    while (reader.PeekChar() > -1)
                    {
                        int x = reader.ReadInt32();
                        int y = reader.ReadInt32();
                        int rotation = reader.ReadInt32();
                        int energy = reader.ReadInt32();
                        int storedMinerals = reader.ReadInt32();
                        int commandAddress = reader.ReadInt32();
                        int organic = reader.ReadInt32();
                        bool active = reader.ReadBoolean();
                        int generation = reader.ReadInt32();
                        int[] genome = new int[64];
                        int[] color = new int[3];
                        for (int j = 0; j < genLenght; j++)
                            genome[j] = reader.ReadInt32();
                        for (int j = 0; j < 3; j++)
                            color[j] = reader.ReadInt32();
                        cells[x, y] = new Cell(active, energy, commandAddress, genome, color, organic, storedMinerals, x, y, rotation, generation);
                    }
                }
                return;
            }
            pauseButton_MouseClick(null, null);
        }
        async private void restartButton_MouseClick(object sender, MouseEventArgs e)
        {
            simulationIsAlive = false;
            await Task.Run(() => { while (!turnIsOver) continue; });
            cells = new Cell[width, height];
            starttime = DateTime.Now;
            autosavedateStrip.Text = "Last autosave: Never";
            Operator.CreateFirst();
            season = 0;
            time = 0;
            dayCounter = 0;
            yearCounter = 0;
            population = 0;
            organicCounter = 0;
            maxGeneration = 1;
            redrawNeeded = true; 
            populationStrip.Text = "Alive: 1";
            organicCountStrip.Text = "Organic: 0";
            maxGenerationStrip.Text = "Last generation: 1";
            time_dataStrip.Text = "00:00";
            day_dataStrip.Text = "Day 0 of";
            season_dataStrip.Text = "Spring, Year 0";
            season_dataStrip.ForeColor = seasonsDict[0].color;
            drawer.RefreshCharts();
            drawer.SetTime();
            drawer.DrawChartsAxis();
            simulationIsAlive = true;
        }
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void mineralsEnabledButton_Click(object sender, EventArgs e)
        {
            mineralsEnabled = !mineralsEnabled;
            redrawNeeded = true;
            if (mineralsEnabled)
                mineralsEnabledButton.Text = "-";
            else
                mineralsEnabledButton.Text = "+";
        }
        private void hintButton_MouseClick(object sender, MouseEventArgs e)
        {
            hintTextBox.Visible = !hintTextBox.Visible;
            
        }
        private void ButtonChangeColor_Red(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Red;
            button.FlatAppearance.BorderColor = Color.Red;
        }
        private void ButtonChangeColor_Yellow(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Yellow;
            button.FlatAppearance.BorderColor = Color.Yellow;
        }
        private void ButtonChangeColor_MediumSpringGreen(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.DarkOrchid;
            button.FlatAppearance.BorderColor = Color.DarkOrchid;
        }
        private void ButtonChangeColor_Green(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == this.pauseButton && !simulationIsAlive)
                return;
            button.ForeColor = Color.Lime;
            button.FlatAppearance.BorderColor = Color.Lime;
        }
        private void ButtonChangeColor_Cyan(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Cyan;
            button.FlatAppearance.BorderColor = Color.Cyan;
        }
        private void chartButton_MouseClick(object sender, MouseEventArgs e)
        {
            chartsPanel.Visible = !chartsPanel.Visible;
        }
        private void speedBar_ValueChanged(object sender, EventArgs e)
        {
            simulationSpeed = speedBar.Value;
        }
        private void mutatuionsButton_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Coral;
            button.FlatAppearance.BorderColor = Color.Coral;
        }
        async private void mutatuionsButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (simulationIsAlive)
                pauseButton_MouseClick(null, null);
            await Task.Run(() => { while (!turnIsOver) continue; });
            cells = new Cell[width, height];
            starttime = DateTime.Now;
            autosavedateStrip.Text = "Last autosave: Never";
            Operator.CreateMutants();
            season = 0;
            time = 0;
            dayCounter = 0;
            yearCounter = 0;
            population = 0;
            organicCounter = 0;
            maxGeneration = 1;
            redrawNeeded = true;
            populationStrip.Text = "Alive: 1";
            organicCountStrip.Text = "Organic: 0";
            maxGenerationStrip.Text = "Last generation: 1";
            time_dataStrip.Text = "00:00";
            day_dataStrip.Text = "Day 0 of";
            season_dataStrip.Text = "Spring, Year 0";
            season_dataStrip.ForeColor = seasonsDict[0].color;
            drawer.RefreshCharts();
            drawer.SetTime();
            drawer.DrawChartsAxis();
        }
    }
}
