using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace cyberbiology2
{
    public class Cell
    {
        public static int population, organicCounter;



        int genLenght = 64;
        int height = MainWindow.height, width = MainWindow.width;
        Random rnd = new Random();
        public int[] genome;
        public int energy;
        public int commandAddress;
        public int[] color;
        public int storedMinerals;
        public int organic;//1-живой, 2-тонущая органика, 3-статичная органика
        public int x, y, rotation;
        public bool active;
        public int generation;
        /*rotate
           3 2 1
           4 @ 0
           5 6 7
        */
        public Cell(bool tactive, int tenergy, int tcommandAddress, int[] tgenome, int[] tcolor, int torganic, int tstoredMinerals,
            int tx, int ty, int trotation, int tgeneration)
        {
            this.active = tactive;
            this.energy = tenergy;
            this.commandAddress = tcommandAddress;
            this.genome = tgenome;
            this.color = tcolor;
            this.organic = torganic;
            this.x = tx;
            this.y = ty;
            this.storedMinerals = tstoredMinerals;
            this.rotation = trotation;
            this.generation = tgeneration;
        }
        //genome main cycle
        public void GenomeExecute()
        {
            int breakflag;
            int command;
            for (int cyc = 0; cyc < 15; cyc++)
            {
                if (organic != 1)
                    return;
                command = genome[commandAddress];        
                breakflag = 0;
                switch (command)
                {
                    case 0://мутация
                        Mutate();
                        ChangeAddress(1);   
                        breakflag = 1;    
                        break;
                    case 16://делитьс
                        Replicate();
                        ChangeAddress(1);
                        breakflag = 1;
                        break;
                    case 23://повернуть по параметру
                        rotation = (rotation + GetNextByte()) % 8;
                        ChangeAddress(2);
                        break;
                    case 25://фотосинтез
                        Photosynthesis();
                        ChangeAddress(1);
                        breakflag = 1;
                        break;
                    case 26://двигаться
                        JumpToAddress(Move()); 
                        breakflag = 1;
                        break;
                    case 33://энергию в минералы
                        MineralsToEnergy();
                        ChangeAddress(1);
                        breakflag = 1;
                        break;
                    case 34://съесть
                        JumpToAddress(Eat());
                        breakflag = 1;
                        break;
                    case 40://посмотреть в направлении с параметром
                        JumpToAddress(CheckInDirection());
                        break;
                    case 41://узнать высоту
                        JumpToAddress(CheckParameter(GetNextByte() * 2, y));
                        break;
                    case 42://узнать энергию
                        JumpToAddress(CheckParameter(GetNextByte() * 15, energy));
                        break;
                    case 43://узнать колво минералов
                        JumpToAddress(CheckParameter(GetNextByte() * 15, energy));
                        break;
                    case 46://узнать окружена ли клектка
                        JumpToAddress(IsEncircled());
                        break;
                    case 47://узнать есть ли доход энергии
                        JumpToAddress(IsEnergyGrowing());
                        break;
                    case 48://узнать есть ли доход минералов
                        JumpToAddress(IsMineralGrowing());
                        break;
                    case 52://заменить один ген соседа
                        ChangeAnotherGenome();
                        ChangeAddress(1);
                        breakflag = 1;
                        break;
                    default:
                        ChangeAddress(command);
                        break;
                }
                if (breakflag == 1) break;
            }

            if (organic==1)
            {
                energy -= 3;                           
                if (!EnergyIsGreaterThanZero())
                    return;
                if (y > height / 2 && MainWindow.mineralsEnabled)
                    storedMinerals += (int)Math.Ceiling((y - height / 2) / 8.0);
                if (storedMinerals > 1000) storedMinerals = 1000;
                if (energy > 999)
                {                    
                    Replicate();
                }
            }
        }
        //genome realization (private functions)
        private void Mutate()
        {
            genome[rnd.Next(0, genLenght)] = rnd.Next(0, genLenght);
        }
        private void Photosynthesis()
        {
            int t;
            if (storedMinerals < 100)
                t = 0;
            else if (storedMinerals <= 400)
                t = 1;
            else
                t = 2;
            t += (int)Math.Ceiling((height / 2 - y) / 8.0) + MainWindow.seasonsDict[MainWindow.season].sunPower;
            if (t > 0)
            {
                energy += t;
                GoGreen(t);
            }
        }
        private int IsEnergyGrowing()
        {
            if (y > height / 2 /*|| !MainWindow.isDay*/)
                return 1;
            else
                return 2;
        }
        private int IsMineralGrowing()
        {
            if (y < height / 2)
                return 1;
            else
                return 2;
        }
        private void MineralsToEnergy()
        {
            if (storedMinerals > 100)
            {
                storedMinerals -= 100;
                energy += 400;
                GoBlue(100);
            }
            else
            {
                energy += storedMinerals * 4;
                GoBlue(storedMinerals);
                storedMinerals = 0;
            }

        }
        private int IsEncircled()
        {
            int cellsAround = 0;
            for (int i = 0; i < 8; i++)
            {
                int[] XY = CalculateDesiredXY(i);
                int tx = XY[0], ty = XY[1];
                if (tx == x && ty == y)
                    continue;
                if (ty >= height || ty < 0)
                {
                    cellsAround++;
                    continue;
                }
                if (MainWindow.cells[tx, ty] != null)
                    cellsAround++;
            }
            if (cellsAround == 8)
                return 1;
            else
                return 2;
        }
        private int CheckParameter(int nextByte, int parameter)
        {
            if (parameter < nextByte)
                return 2;
            else
                return 3;
        }
        private int Move()
        {
            int[] XY;
            XY = CalculateDesiredXY((GetNextByte() + rotation) % 8);
            if (!EnergyIsGreaterThanZero())
                return 0;
            if (XY[1] >= height || XY[1] < 0)
                return 3;
            if (MainWindow.cells[XY[0], XY[1]] == null)
            {
                MainWindow.cells[XY[0], XY[1]] = this;
                MainWindow.cells[x, y] = null;
                x = XY[0];
                y = XY[1];
                return 2;
            }
            if (MainWindow.cells[XY[0], XY[1]].organic==2|| MainWindow.cells[XY[0], XY[1]].organic == 3)
                return 4;
            if (GenomesAreRelated(genome, MainWindow.cells[XY[0], XY[1]].genome))
                return 5;
            else
                return 6;
        }
        private int Eat()
        {
            if (!EnergyIsGreaterThanZero())
                return 0;
            int[] XY = CalculateDesiredXY((GetNextByte() + rotation) % 8);
            if (XY[1] >= height || XY[1] < 0)
                return 2;
            if (MainWindow.cells[XY[0], XY[1]] == null)
            {
                return 3;
            }
            if (MainWindow.cells[XY[0], XY[1]].organic == 2 || MainWindow.cells[XY[0], XY[1]].organic == 3)
            {
                MainWindow.cells[XY[0], XY[1]] = null;
                energy += 100;
                GoRed(100);
                return 4;
            }
            else
            {
                int min0 = storedMinerals;                 
                int min1 = MainWindow.cells[XY[0], XY[1]].storedMinerals;  
                int hl = MainWindow.cells[XY[0], XY[1]].energy;

                /*if (min0 >= min1)
                {
                    storedMinerals = min0 - min1;         
                                                          
                    MainWindow.cells[XY[0], XY[1]] = null;       
                    int cl = 100 + (hl / 2);       
                    energy += cl;
                    GoRed(cl);                      
                    return 5;                       
                }
                
                storedMinerals = 0;                        
                min1 -= min0;                 
                MainWindow.cells[XY[0], XY[1]].storedMinerals = min1;
                if (energy >= 2 * min1)
                {
                    MainWindow.cells[XY[0], XY[1]] = null; 
                    int cl = 100 + (hl / 2) - 2 * min1; 
                    energy += cl;
                    if (cl < 0)
                        cl = 0; 
                    GoRed(cl);                      
                    return 5;
                }
                MainWindow.cells[XY[0], XY[1]].storedMinerals -= (energy / 2); 
                energy = 0;                         
                CellDie();*/
                MainWindow.cells[XY[0], XY[1]] = null;
                int cl = 100 + (hl / 2);
                energy += cl;
                GoRed(cl);
                return 5;
            }
        }
        private void Replicate()
        {
            if (IsEncircled() == 1)
            {
                CellDie();
                return;
            }
            energy -= 150;
            if (!EnergyIsGreaterThanZero())
                return;
            for (int i = 0; i < 8; i++)
            {
                int[] XY = CalculateDesiredXY(i);
                int tx = XY[0], ty = XY[1];
                if (ty >= height || ty < 0)
                    continue;
                if (MainWindow.cells[tx, ty] != null)
                    continue;
                Cell tcell;
                int[] tcolor = new int[3];
                tcolor[0] = color[0]; tcolor[1] = color[1]; tcolor[2] = color[2];
                int[] tgenome = new int[genLenght];
                for (int j = 0; j < genLenght; j++)
                    tgenome[j] = genome[j];
                tcell = new Cell(false, energy / 2, 0, tgenome, tcolor, 1, storedMinerals / 2, tx, ty, rnd.Next(0, 8), generation + 1);
                if (rnd.Next(0, 4) == 0)
                    tcell.genome[rnd.Next(0, genLenght)] = rnd.Next(0, genLenght);
                MainWindow.cells[tx, ty] = tcell;
                energy /= 2;
                storedMinerals /= 2;
                return;

            }
            CellDie();
        }
        private int CheckInDirection()
        {
            int[] XY = CalculateDesiredXY(rotation);
            int ty = XY[1], tx = XY[0];
            if (ty < 0 || ty >= height)
            {              
                return 3;
            }
            else if (MainWindow.cells[tx, ty] == null)
            {       
                return 2;
            }
            else if (MainWindow.cells[XY[0], XY[1]].organic == 2 || MainWindow.cells[XY[0], XY[1]].organic == 3)
            { 
                return 4;
            }
            else if (GenomesAreRelated(genome, MainWindow.cells[tx, ty].genome))
            {   
                return 6;
            }
            else
            {                                                    
                return 5;
            }
        }
        private void ChangeAnotherGenome()
        {
            int[] XY = CalculateDesiredXY(rotation);
            int ty = XY[1], tx = XY[0];
            if (ty < 0 || ty >= height || MainWindow.cells[tx, ty] == null || MainWindow.cells[XY[0], XY[1]].organic == 2 || MainWindow.cells[XY[0], XY[1]].organic == 3)
            {
                return;
            }
            MainWindow.cells[tx, ty].genome[rnd.Next(0, genLenght)] = rnd.Next(0, genLenght);
            energy -= 10;
        }
        //another private slots
        private void SetCellColor(int red, int green, int blue)
        {
            color[0] = red; color[1] = green; color[2] = blue;
        }
        private void GoRed(int red)
        {
            color[0] = Math.Min(color[0] + red, 255);
            color[1] = Math.Max(color[1] - red, 64);
            color[2] = Math.Max(color[2] - red, 64);
        }
        private void GoGreen(int green)
        {
            color[0] = Math.Max(color[0] - green, 64);
            color[1] = Math.Min(color[1] + green, 255);
            color[2] = Math.Max(color[2] - green, 64);
        }
        private void GoBlue(int blue)
        {
            color[0] = Math.Max(color[0] - blue, 64);
            color[1] = Math.Max(color[1] - blue, 64);
            color[2] = Math.Min(color[2] + blue, 255);
        }
        private void DrownOrganic()
        {
            if (y+1<height&&MainWindow.cells[x,y+1]==null)
            {
                MainWindow.cells[x, y+1] = this;
                MainWindow.cells[x, y] = null;
                y += 1;
            }
            else
            {
                organic = 3;
            }
        }
        private bool EnergyIsGreaterThanZero()
        {
            if (energy > 0)
                return true;
            else
            {
                CellDie();
                return false;
            }
        }
        private void CellDie()
        {
            organic = 2;
            energy = 0;
            color[0] = 240; color[1] = 240; color[2] = 240;
        }
        private int[] CalculateDesiredXY(int desiredTile)
        {
            int angle = desiredTile * 45;
            int[] XY = new int[2];
            XY[0] = x + (int)Math.Round(Math.Cos((angle / 180D) * Math.PI));
            XY[1] = y + (int)-Math.Round(Math.Sin((angle / 180D) * Math.PI));
            if (XY[0] >= width)
                XY[0] = 0;
            if (XY[0] < 0)
                XY[0] = width - 1;
            return XY;
        }
        private bool GenomesAreRelated(int[] genome1, int[] genome2)
        {
            int differences = 0;
            for (int i = 0; i < genLenght; i++)
                if (genome1[i] != genome2[i])
                    differences++;
            if (differences > 1)
                return false;
            return true;
        }
        private void ChangeAddress(int a)
        {
            commandAddress = (commandAddress + a) % genLenght;
        }
        private int GetNextByte()
        {
            return genome[(commandAddress + 1) % genLenght]; 
        }
        private void JumpToAddress(int a)
        {
            int bias = genome[(commandAddress + a) % genLenght];
            ChangeAddress(bias);
        }
        //public slots
        public void CreateFirst()
        {
                int x = rnd.Next(20,80), y = 5;
                int[] tgenome = new int[genLenght];
                int[] tcolor = new int[3];
                for (int j = 0; j < genLenght; j++)
                    tgenome[j] = 25;
                Cell tcell = new Cell(true, 999, 0, tgenome, tcolor, 1, 25, x, y, rnd.Next(0, 8), 1);
                tcell.SetCellColor(64, 255, 64);
                MainWindow.cells[x, y] = tcell;
            
        }
        public void CreateMutants()
        {
            for (int tx = 0; tx < width; tx++)
                for (int ty = 0; ty < height; ty++)
                {
                    int[] tgenome = new int[genLenght];
                    int[] tcolor = new int[3];
                    for (int j = 0; j < genLenght; j++)
                        tgenome[j] = rnd.Next(0,genLenght);
                    Cell tcell = new Cell(true, 999, 0, tgenome, tcolor, 1, 999, tx, ty, rnd.Next(0, 8), 1);
                    tcell.SetCellColor(rnd.Next(64,255), rnd.Next(64, 255), rnd.Next(64, 255));
                    MainWindow.cells[tx, ty] = tcell;
                }
        }
        public void CellsProgress()
        {
            int tpopulation = 0;
            int torganicCounter = 0;
            for (int tx = 0; tx < width; tx++)
            {
                for (int ty = 0; ty < height; ty++)
                {
                    if (MainWindow.cells[tx, ty] != null && MainWindow.cells[tx, ty].active)
                    {
                        if (MainWindow.cells[tx, ty].organic == 1)
                        {
                            tpopulation++;
                            if (MainWindow.cells[tx, ty].generation > MainWindow.maxGeneration)
                                MainWindow.maxGeneration = MainWindow.cells[tx, ty].generation;
                            MainWindow.cells[tx, ty].active = false;
                            MainWindow.cells[tx, ty].GenomeExecute();
                            continue;
                        }
                        if (MainWindow.cells[tx, ty].organic == 2)
                        {
                            torganicCounter++;
                            MainWindow.cells[tx, ty].active = false;
                            /*if (MainWindow.time%4==0)*/
                            MainWindow.cells[tx, ty].DrownOrganic();
                            continue;
                        }
                        if (MainWindow.cells[tx, ty].organic == 3)
                        {
                            torganicCounter++;
                            MainWindow.cells[tx, ty].active = false;
                        }
                    }
                }

            }
            for (int tx = 0;tx < width; tx++)
                for (int ty = 0; ty < height; ty++)
                {
                    if (MainWindow.cells[tx, ty] != null)
                    {
                        MainWindow.cells[tx, ty].active = true;
                    }
                }
            population = tpopulation;
            organicCounter = torganicCounter;
        }
        public void GetStats()
        {
            MainWindow.population = population;
            MainWindow.organicCounter = organicCounter;
        }



    }
}
