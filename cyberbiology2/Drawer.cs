using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace cyberbiology2
{
    class Drawer
    {
        private static Bitmap map = new Bitmap(MainWindow.windowWidth, MainWindow.windowHeight);
        private Graphics g = Graphics.FromImage(map);
        //1801; 320
        private int chartspboxwidth= 1801;
        private int chartspboxheight = 320;
        private int pointsDistance = 5;

        private static Bitmap chartsMap;
        private Graphics chartsG;

        private SolidBrush brush;
        private Pen chartsPen = new Pen(MainWindow.seasonsDict[0].color);
        private SolidBrush textBrush = new SolidBrush(Color.Black);

        private Pen pen = new Pen(Color.Black);

        private int width = MainWindow.width;
        private int height = MainWindow.height;
        private int tilesize = MainWindow.tilesize;

        private Font font = new Font("Lucida Console", 14, FontStyle.Bold);
        private Font chartsFont = new Font("Times New Roman", 14);
        private Font smallFont = new Font("Lucida Console", 8);

        private int previous_parameter, time=0, yearCounter=0;
        
        public Drawer(int chartsPboxWidth, int chartspboxHeight)
        {
            chartsMap = new Bitmap(chartspboxwidth, chartspboxheight);
            chartsG = Graphics.FromImage(chartsMap);
            previous_parameter = 0;
            chartsPen.Width = 1;
            chartspboxwidth = chartsPboxWidth;
            chartspboxheight = chartspboxHeight;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;
            chartsG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            chartsG.SmoothingMode = SmoothingMode.HighQuality;
        }
        //---------------------------------------------------------------------------------------------
        public Bitmap GetMap()
        {
            return map;
        }
        public Bitmap GetCharts()
        {
            return chartsMap;
        }
        public void SetTime()
        {
            time = 0;
            yearCounter = 0;
        }
        public void Refresh()
        {
            map = null;
            map = new Bitmap(MainWindow.windowWidth - 120, MainWindow.windowHeight);
            g = Graphics.FromImage(map);
        }
        public void RefreshCharts()
        {
            chartsMap = null;
            chartsMap = new Bitmap(chartspboxwidth, chartspboxheight);
            chartsG = Graphics.FromImage(chartsMap);
            DrawChartsAxis();
        }
        //---------------------------------------------------------------------------------------------
        public void DrawGrid()
        {
            for (int y = 0; y < height; y++)
            {
                if (y % 8 == 0)
                {
                    g.DrawLine(pen, 0, y * tilesize, width * tilesize, y * tilesize);
                }
            }
            
        }
        public void DrawNumbers()
        {
            Refresh();
            for (int y = 0; y <= height; y++)
            {
                if (y % 8 == 0)
                {
                    bool plusExist = false;
                    textBrush = new SolidBrush(Color.Yellow);
                    if (CalculateEnergy(y) > 0 && y != 0)
                    {
                        g.DrawString("+" + CalculateEnergy(y).ToString(), font, textBrush, 0, y * tilesize - 26);
                        plusExist = true;
                    }
                    textBrush = new SolidBrush(Color.DeepSkyBlue);
                    if (MainWindow.mineralsEnabled&&(int)Math.Ceiling((y - height / 2) / 8.0) > 0)
                    {
                        if (!plusExist)
                            g.DrawString("+" + ((int)Math.Ceiling((y - height / 2) / 8.0)).ToString(), font, textBrush, 20, y * tilesize - 26);
                        else
                            g.DrawString(" " + ((int)Math.Ceiling((y - height / 2) / 8.0)).ToString(), font, textBrush, 20, y * tilesize - 26);
                    }
                }
            }
        }
        public void DrawTile(int x, int y)
        {
            GenerateBrushColor(y);
            g.FillRectangle(brush, x * tilesize - 1,
            y * tilesize - 1,
            tilesize + 1, tilesize + 1);
            brush = null;

        }
        public void DrawCell(Cell cell)
        {
            if (cell == null)
                return;
            if (MainWindow.drawtype==1)
                GenerateBrushColor(cell.color);
            if (MainWindow.drawtype == 2)
            {
                if (cell.energy > 0)
                    GenerateBrushColorFromEnergy(cell.energy);
                else
                    brush = new SolidBrush(Color.White);
            }
            if (MainWindow.drawtype == 3)
            {
                if (cell.energy > 0)
                    GenerateBrushColorFromGenome(cell.genome);
                else
                    brush = new SolidBrush(Color.White);
            }
            g.FillRectangle(brush, cell.x * tilesize+1,
            cell.y * tilesize+1,
            tilesize-2, tilesize-2);
            g.DrawRectangle(pen, cell.x * tilesize,cell.y * tilesize,tilesize-1, tilesize-1);
           // g.DrawString(cell.id.ToString(), font, textBrush, cell.x * tilesize, cell.y * tilesize);
            brush = null;
        }
        public void ClearTile(int x, int y)
        {
            brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            g.FillRectangle(brush, x * tilesize,
            y * tilesize,
            tilesize, tilesize);
        }
        public void DrawCharts(int parameter)
        {
            if (time % (40*pointsDistance) == 0 && time != 0)
            {
                Pen tpen = new Pen(Color.Red);
                brush = new SolidBrush(Color.Red);
                yearCounter++;
                chartsG.DrawLine(tpen, time, 0, time, chartspboxheight - 10);
                chartsG.DrawString(yearCounter.ToString(), smallFont, brush, time - 15, 0);
            }
            if (time % (10 * pointsDistance) == 0)
            {
                Color color = MainWindow.seasonsDict[(time/(10 * pointsDistance))%4].color;
                brush = new SolidBrush(color);
                chartsPen = new Pen(color);
                chartsG.DrawString("*", chartsFont, brush, time- pointsDistance, chartspboxheight - parameter / 35 - 45);
            }
            if (parameter / 32 > previous_parameter * 2 && parameter>300)
            {
                Pen tpen = new Pen(Color.Yellow);
                chartsG.DrawLine(tpen, time, 0, time, chartspboxheight - 10);
            }
            chartsG.DrawLine(chartsPen, time, chartspboxheight - previous_parameter - 10, time + pointsDistance, chartspboxheight - parameter / 35 - 10);

            previous_parameter = parameter / 35 ;
            if (time>=chartspboxwidth-pointsDistance)
            {
                RefreshCharts();
                SetTime();
                return;
            }
            time += pointsDistance;
        }
        public void DrawChartsAxis()
        {
            Pen tpen = new Pen(Color.Aquamarine);
            chartsG.DrawLine(tpen, 0, chartspboxheight - 9, chartspboxwidth, chartspboxheight - 9);
            for (int i = 0; i < chartspboxwidth; i += 50)
            {
                chartsG.DrawLine(tpen, i, chartspboxheight - 9, i, chartspboxheight);
                chartsG.DrawLine(tpen, i, chartspboxheight - 9, i, chartspboxheight);
            }
        }
            
        //----------------------------------------------------------------------------------------------
        private void GenerateBrushColor(int y)
        {
            if (y < height / 2)
            {
                brush = new SolidBrush(Color.FromArgb(255, 255, Math.Min(64 + y * 4, 255)));

            }
            else
                brush = new SolidBrush(Color.FromArgb(Math.Min(64 + (height - y) * 4, 255),
                    Math.Min(64 + (height - y) * 4, 255),
                    255
                    ));

        }
        private void GenerateBrushColor(int[] color)
        {
            brush = new SolidBrush(Color.FromArgb(color[0], color[1], color[2]));
        }
        private void GenerateBrushColorFromEnergy(int energy)
        {
            int rMax = Color.Red.R;
            int rMin = Color.Yellow.R;
            int gMax = Color.Red.G;
            int gMin = Color.Yellow.G;
            var rAverage = rMin + (int)((rMax - rMin) * energy / 1000);
            var gAverage = gMin + (int)((gMax - gMin) * energy / 1000);
            brush = new SolidBrush(Color.FromArgb(Math.Max(rAverage,0), Math.Max(gAverage,0), 0));
            
        }
        private void GenerateBrushColorFromGenome(int[] genome)
        {
            double red = 0, green = 0, blue = 0;
            for (int i=0;i<MainWindow.genLenght;i++)
            {
                if (genome[i] <= 20)
                    red += 3.9;
                if (genome[i] > 20 && genome[i] <= 40)
                    green += 3.9;
                if (genome[i] > 40)
                    blue += 3.9;
            }
            brush = new SolidBrush(Color.FromArgb((int)(red),
                (int)(green),
                (int)(blue)));
        }
        private int CalculateEnergy(int y)
        {
            return (int)Math.Ceiling((height / 2 - y) / 8.0) + MainWindow.seasonsDict[MainWindow.season].sunPower;
        }

    }

}

