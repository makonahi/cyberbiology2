
namespace cyberbiology2
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.dataStrip = new System.Windows.Forms.MenuStrip();
            this.day_dataStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.season_dataStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.autosavedateStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.currentTime = new System.Windows.Forms.ToolStripMenuItem();
            this.elapsedStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.cellInfo = new System.Windows.Forms.GroupBox();
            this.textBoxCellInfo = new System.Windows.Forms.RichTextBox();
            this.cellImage = new System.Windows.Forms.PictureBox();
            this.drawEnergyTypeButton = new System.Windows.Forms.Button();
            this.drawStoredEnergyButton = new System.Windows.Forms.Button();
            this.drawGenomeButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.hintButton = new System.Windows.Forms.Button();
            this.mineralsEnabledButton = new System.Windows.Forms.Button();
            this.hintTextBox = new System.Windows.Forms.RichTextBox();
            this.chartButton = new System.Windows.Forms.Button();
            this.rightInfoPanel = new System.Windows.Forms.Panel();
            this.chartsPanel = new System.Windows.Forms.Panel();
            this.maxGenerationStrip = new System.Windows.Forms.Label();
            this.organicCountStrip = new System.Windows.Forms.Label();
            this.populationStrip = new System.Windows.Forms.Label();
            this.chartsPictureBox = new System.Windows.Forms.PictureBox();
            this.world_pictureBox = new System.Windows.Forms.PictureBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.time_dataStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mutatuionsButton = new System.Windows.Forms.Button();
            this.dataStrip.SuspendLayout();
            this.cellInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellImage)).BeginInit();
            this.rightInfoPanel.SuspendLayout();
            this.chartsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.world_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataStrip
            // 
            this.dataStrip.AutoSize = false;
            this.dataStrip.BackColor = System.Drawing.Color.Black;
            this.dataStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataStrip.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dataStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.time_dataStrip,
            this.day_dataStrip,
            this.season_dataStrip,
            this.autosavedateStrip,
            this.currentTime,
            this.elapsedStrip});
            this.dataStrip.Location = new System.Drawing.Point(0, 1119);
            this.dataStrip.Name = "dataStrip";
            this.dataStrip.Size = new System.Drawing.Size(1971, 30);
            this.dataStrip.TabIndex = 0;
            this.dataStrip.Text = "menuStrip1";
            // 
            // day_dataStrip
            // 
            this.day_dataStrip.AutoSize = false;
            this.day_dataStrip.ForeColor = System.Drawing.Color.White;
            this.day_dataStrip.Name = "day_dataStrip";
            this.day_dataStrip.Padding = new System.Windows.Forms.Padding(0);
            this.day_dataStrip.Size = new System.Drawing.Size(120, 26);
            this.day_dataStrip.Text = "Day 29 of";
            this.day_dataStrip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.day_dataStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // season_dataStrip
            // 
            this.season_dataStrip.AutoSize = false;
            this.season_dataStrip.ForeColor = System.Drawing.Color.GreenYellow;
            this.season_dataStrip.Name = "season_dataStrip";
            this.season_dataStrip.Padding = new System.Windows.Forms.Padding(0);
            this.season_dataStrip.Size = new System.Drawing.Size(175, 26);
            this.season_dataStrip.Text = "Spring, Year 0";
            this.season_dataStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autosavedateStrip
            // 
            this.autosavedateStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.autosavedateStrip.AutoSize = false;
            this.autosavedateStrip.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autosavedateStrip.ForeColor = System.Drawing.Color.Lime;
            this.autosavedateStrip.Name = "autosavedateStrip";
            this.autosavedateStrip.Size = new System.Drawing.Size(185, 26);
            this.autosavedateStrip.Text = "Last autosave: Never ";
            // 
            // currentTime
            // 
            this.currentTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.currentTime.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTime.ForeColor = System.Drawing.Color.Lime;
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(201, 26);
            this.currentTime.Text = "0000 30/12/2024 23:59PM";
            // 
            // elapsedStrip
            // 
            this.elapsedStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.elapsedStrip.AutoSize = false;
            this.elapsedStrip.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elapsedStrip.ForeColor = System.Drawing.Color.Lime;
            this.elapsedStrip.Name = "elapsedStrip";
            this.elapsedStrip.Size = new System.Drawing.Size(81, 26);
            this.elapsedStrip.Text = "23:59:59";
            // 
            // cellInfo
            // 
            this.cellInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cellInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cellInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cellInfo.Controls.Add(this.textBoxCellInfo);
            this.cellInfo.Controls.Add(this.cellImage);
            this.cellInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cellInfo.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cellInfo.ForeColor = System.Drawing.Color.Black;
            this.cellInfo.Location = new System.Drawing.Point(1491, 0);
            this.cellInfo.Name = "cellInfo";
            this.cellInfo.Size = new System.Drawing.Size(360, 1116);
            this.cellInfo.TabIndex = 2;
            this.cellInfo.TabStop = false;
            this.cellInfo.Text = "None Selected";
            this.cellInfo.Visible = false;
            // 
            // textBoxCellInfo
            // 
            this.textBoxCellInfo.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCellInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCellInfo.ForeColor = System.Drawing.Color.Black;
            this.textBoxCellInfo.Location = new System.Drawing.Point(0, 227);
            this.textBoxCellInfo.Name = "textBoxCellInfo";
            this.textBoxCellInfo.ReadOnly = true;
            this.textBoxCellInfo.Size = new System.Drawing.Size(360, 300);
            this.textBoxCellInfo.TabIndex = 1;
            this.textBoxCellInfo.Text = "";
            // 
            // cellImage
            // 
            this.cellImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cellImage.Location = new System.Drawing.Point(80, 27);
            this.cellImage.Name = "cellImage";
            this.cellImage.Size = new System.Drawing.Size(194, 194);
            this.cellImage.TabIndex = 0;
            this.cellImage.TabStop = false;
            // 
            // drawEnergyTypeButton
            // 
            this.drawEnergyTypeButton.BackColor = System.Drawing.Color.Yellow;
            this.drawEnergyTypeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.drawEnergyTypeButton.FlatAppearance.BorderSize = 3;
            this.drawEnergyTypeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.drawEnergyTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawEnergyTypeButton.Location = new System.Drawing.Point(125, 15);
            this.drawEnergyTypeButton.Name = "drawEnergyTypeButton";
            this.drawEnergyTypeButton.Size = new System.Drawing.Size(34, 108);
            this.drawEnergyTypeButton.TabIndex = 7;
            this.drawEnergyTypeButton.TabStop = false;
            this.drawEnergyTypeButton.UseVisualStyleBackColor = false;
            this.drawEnergyTypeButton.Click += new System.EventHandler(this.drawEnergyTypeButton_Click);
            // 
            // drawStoredEnergyButton
            // 
            this.drawStoredEnergyButton.BackColor = System.Drawing.Color.Black;
            this.drawStoredEnergyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.drawStoredEnergyButton.FlatAppearance.BorderSize = 3;
            this.drawStoredEnergyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.drawStoredEnergyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawStoredEnergyButton.Location = new System.Drawing.Point(125, 129);
            this.drawStoredEnergyButton.Name = "drawStoredEnergyButton";
            this.drawStoredEnergyButton.Size = new System.Drawing.Size(34, 108);
            this.drawStoredEnergyButton.TabIndex = 8;
            this.drawStoredEnergyButton.TabStop = false;
            this.drawStoredEnergyButton.UseVisualStyleBackColor = false;
            this.drawStoredEnergyButton.Click += new System.EventHandler(this.drawStoredEnergyButton_Click);
            // 
            // drawGenomeButton
            // 
            this.drawGenomeButton.BackColor = System.Drawing.Color.Black;
            this.drawGenomeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.drawGenomeButton.FlatAppearance.BorderSize = 3;
            this.drawGenomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.drawGenomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawGenomeButton.Location = new System.Drawing.Point(125, 244);
            this.drawGenomeButton.Name = "drawGenomeButton";
            this.drawGenomeButton.Size = new System.Drawing.Size(34, 108);
            this.drawGenomeButton.TabIndex = 6;
            this.drawGenomeButton.TabStop = false;
            this.drawGenomeButton.UseVisualStyleBackColor = false;
            this.drawGenomeButton.Click += new System.EventHandler(this.drawGenomeButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Black;
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quitButton.ForeColor = System.Drawing.Color.Lime;
            this.quitButton.Location = new System.Drawing.Point(37, 14);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(82, 32);
            this.quitButton.TabIndex = 1;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.quitButton_MouseClick);
            this.quitButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.quitButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Red);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Black;
            this.pauseButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.ForeColor = System.Drawing.Color.Lime;
            this.pauseButton.Location = new System.Drawing.Point(37, 90);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(82, 32);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.TabStop = false;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pauseButton_MouseClick);
            this.pauseButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.pauseButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.Black;
            this.hideButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hideButton.ForeColor = System.Drawing.Color.Lime;
            this.hideButton.Location = new System.Drawing.Point(37, 52);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(82, 32);
            this.hideButton.TabIndex = 3;
            this.hideButton.TabStop = false;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            this.hideButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.hideButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.Black;
            this.RestartButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartButton.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestartButton.ForeColor = System.Drawing.Color.Lime;
            this.RestartButton.Location = new System.Drawing.Point(37, 242);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(82, 32);
            this.RestartButton.TabIndex = 6;
            this.RestartButton.TabStop = false;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.restartButton_MouseClick);
            this.RestartButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.RestartButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Red);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Black;
            this.loadButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.ForeColor = System.Drawing.Color.Lime;
            this.loadButton.Location = new System.Drawing.Point(37, 204);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(82, 32);
            this.loadButton.TabIndex = 5;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadButton_MouseClick);
            this.loadButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.loadButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Black;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.Lime;
            this.saveButton.Location = new System.Drawing.Point(37, 166);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(82, 32);
            this.saveButton.TabIndex = 4;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveButton_MouseClick);
            this.saveButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.saveButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // hintButton
            // 
            this.hintButton.BackColor = System.Drawing.Color.Black;
            this.hintButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.hintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hintButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hintButton.ForeColor = System.Drawing.Color.Lime;
            this.hintButton.Location = new System.Drawing.Point(87, 281);
            this.hintButton.Name = "hintButton";
            this.hintButton.Size = new System.Drawing.Size(32, 32);
            this.hintButton.TabIndex = 10;
            this.hintButton.TabStop = false;
            this.hintButton.Text = "?";
            this.hintButton.UseVisualStyleBackColor = false;
            this.hintButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hintButton_MouseClick);
            this.hintButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.hintButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // mineralsEnabledButton
            // 
            this.mineralsEnabledButton.BackColor = System.Drawing.Color.Black;
            this.mineralsEnabledButton.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.mineralsEnabledButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mineralsEnabledButton.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mineralsEnabledButton.ForeColor = System.Drawing.Color.Cyan;
            this.mineralsEnabledButton.Location = new System.Drawing.Point(49, 281);
            this.mineralsEnabledButton.Name = "mineralsEnabledButton";
            this.mineralsEnabledButton.Size = new System.Drawing.Size(32, 32);
            this.mineralsEnabledButton.TabIndex = 12;
            this.mineralsEnabledButton.TabStop = false;
            this.mineralsEnabledButton.Text = "-";
            this.mineralsEnabledButton.UseVisualStyleBackColor = false;
            this.mineralsEnabledButton.Click += new System.EventHandler(this.mineralsEnabledButton_Click);
            this.mineralsEnabledButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Cyan);
            this.mineralsEnabledButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_MediumSpringGreen);
            // 
            // hintTextBox
            // 
            this.hintTextBox.BackColor = System.Drawing.Color.Black;
            this.hintTextBox.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hintTextBox.ForeColor = System.Drawing.Color.Lime;
            this.hintTextBox.Location = new System.Drawing.Point(0, 0);
            this.hintTextBox.Name = "hintTextBox";
            this.hintTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.hintTextBox.Size = new System.Drawing.Size(1801, 277);
            this.hintTextBox.TabIndex = 14;
            this.hintTextBox.Text = "";
            this.hintTextBox.Visible = false;
            // 
            // chartButton
            // 
            this.chartButton.BackColor = System.Drawing.Color.Black;
            this.chartButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.chartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chartButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartButton.ForeColor = System.Drawing.Color.Lime;
            this.chartButton.Location = new System.Drawing.Point(37, 128);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(82, 32);
            this.chartButton.TabIndex = 15;
            this.chartButton.TabStop = false;
            this.chartButton.Text = "Show Charts";
            this.chartButton.UseVisualStyleBackColor = false;
            this.chartButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartButton_MouseClick);
            this.chartButton.MouseLeave += new System.EventHandler(this.ButtonChangeColor_Green);
            this.chartButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // rightInfoPanel
            // 
            this.rightInfoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rightInfoPanel.BackColor = System.Drawing.Color.Black;
            this.rightInfoPanel.Controls.Add(this.mutatuionsButton);
            this.rightInfoPanel.Controls.Add(this.speedBar);
            this.rightInfoPanel.Controls.Add(this.drawEnergyTypeButton);
            this.rightInfoPanel.Controls.Add(this.chartButton);
            this.rightInfoPanel.Controls.Add(this.drawStoredEnergyButton);
            this.rightInfoPanel.Controls.Add(this.drawGenomeButton);
            this.rightInfoPanel.Controls.Add(this.mineralsEnabledButton);
            this.rightInfoPanel.Controls.Add(this.quitButton);
            this.rightInfoPanel.Controls.Add(this.hintButton);
            this.rightInfoPanel.Controls.Add(this.pauseButton);
            this.rightInfoPanel.Controls.Add(this.hideButton);
            this.rightInfoPanel.Controls.Add(this.saveButton);
            this.rightInfoPanel.Controls.Add(this.RestartButton);
            this.rightInfoPanel.Controls.Add(this.loadButton);
            this.rightInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightInfoPanel.Location = new System.Drawing.Point(1800, 0);
            this.rightInfoPanel.Name = "rightInfoPanel";
            this.rightInfoPanel.Size = new System.Drawing.Size(171, 1119);
            this.rightInfoPanel.TabIndex = 17;
            // 
            // chartsPanel
            // 
            this.chartsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartsPanel.BackColor = System.Drawing.Color.Black;
            this.chartsPanel.Controls.Add(this.maxGenerationStrip);
            this.chartsPanel.Controls.Add(this.organicCountStrip);
            this.chartsPanel.Controls.Add(this.populationStrip);
            this.chartsPanel.Controls.Add(this.chartsPictureBox);
            this.chartsPanel.Location = new System.Drawing.Point(0, 754);
            this.chartsPanel.Name = "chartsPanel";
            this.chartsPanel.Size = new System.Drawing.Size(1801, 365);
            this.chartsPanel.TabIndex = 18;
            this.chartsPanel.Visible = false;
            // 
            // maxGenerationStrip
            // 
            this.maxGenerationStrip.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold);
            this.maxGenerationStrip.ForeColor = System.Drawing.Color.NavajoWhite;
            this.maxGenerationStrip.Location = new System.Drawing.Point(328, 12);
            this.maxGenerationStrip.Name = "maxGenerationStrip";
            this.maxGenerationStrip.Size = new System.Drawing.Size(252, 18);
            this.maxGenerationStrip.TabIndex = 19;
            this.maxGenerationStrip.Text = "Last generation: 99999";
            // 
            // organicCountStrip
            // 
            this.organicCountStrip.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold);
            this.organicCountStrip.ForeColor = System.Drawing.Color.NavajoWhite;
            this.organicCountStrip.Location = new System.Drawing.Point(159, 13);
            this.organicCountStrip.Name = "organicCountStrip";
            this.organicCountStrip.Size = new System.Drawing.Size(163, 18);
            this.organicCountStrip.TabIndex = 18;
            this.organicCountStrip.Text = "Organic: 15999";
            // 
            // populationStrip
            // 
            this.populationStrip.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold);
            this.populationStrip.ForeColor = System.Drawing.Color.NavajoWhite;
            this.populationStrip.Location = new System.Drawing.Point(12, 14);
            this.populationStrip.Name = "populationStrip";
            this.populationStrip.Size = new System.Drawing.Size(141, 18);
            this.populationStrip.TabIndex = 17;
            this.populationStrip.Text = "Alive: 15999";
            // 
            // chartsPictureBox
            // 
            this.chartsPictureBox.BackColor = System.Drawing.Color.Black;
            this.chartsPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartsPictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chartsPictureBox.Location = new System.Drawing.Point(0, 45);
            this.chartsPictureBox.Name = "chartsPictureBox";
            this.chartsPictureBox.Size = new System.Drawing.Size(1801, 320);
            this.chartsPictureBox.TabIndex = 16;
            this.chartsPictureBox.TabStop = false;
            // 
            // world_pictureBox
            // 
            this.world_pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.world_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.world_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.world_pictureBox.Name = "world_pictureBox";
            this.world_pictureBox.Size = new System.Drawing.Size(1801, 1119);
            this.world_pictureBox.TabIndex = 1;
            this.world_pictureBox.TabStop = false;
            this.world_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.world_pictureBox_MouseDown);
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 1;
            this.speedBar.Location = new System.Drawing.Point(49, 319);
            this.speedBar.Maximum = 3;
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(70, 45);
            this.speedBar.TabIndex = 16;
            this.speedBar.TabStop = false;
            this.speedBar.Value = 3;
            this.speedBar.ValueChanged += new System.EventHandler(this.speedBar_ValueChanged);
            // 
            // time_dataStrip
            // 
            this.time_dataStrip.AutoSize = false;
            this.time_dataStrip.ForeColor = System.Drawing.Color.White;
            this.time_dataStrip.Name = "time_dataStrip";
            this.time_dataStrip.Padding = new System.Windows.Forms.Padding(0);
            this.time_dataStrip.Size = new System.Drawing.Size(67, 26);
            this.time_dataStrip.Text = "23:59";
            // 
            // mutatuionsButton
            // 
            this.mutatuionsButton.BackColor = System.Drawing.Color.Black;
            this.mutatuionsButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.mutatuionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mutatuionsButton.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mutatuionsButton.ForeColor = System.Drawing.Color.Coral;
            this.mutatuionsButton.Location = new System.Drawing.Point(57, 358);
            this.mutatuionsButton.Name = "mutatuionsButton";
            this.mutatuionsButton.Size = new System.Drawing.Size(102, 46);
            this.mutatuionsButton.TabIndex = 17;
            this.mutatuionsButton.TabStop = false;
            this.mutatuionsButton.Text = "Mutations Mode";
            this.mutatuionsButton.UseVisualStyleBackColor = false;
            this.mutatuionsButton.Visible = false;
            this.mutatuionsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mutatuionsButton_MouseClick);
            this.mutatuionsButton.MouseLeave += new System.EventHandler(this.mutatuionsButton_MouseLeave);
            this.mutatuionsButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonChangeColor_Yellow);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1971, 1149);
            this.Controls.Add(this.chartsPanel);
            this.Controls.Add(this.rightInfoPanel);
            this.Controls.Add(this.hintTextBox);
            this.Controls.Add(this.cellInfo);
            this.Controls.Add(this.world_pictureBox);
            this.Controls.Add(this.dataStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.dataStrip;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.dataStrip.ResumeLayout(false);
            this.dataStrip.PerformLayout();
            this.cellInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cellImage)).EndInit();
            this.rightInfoPanel.ResumeLayout(false);
            this.rightInfoPanel.PerformLayout();
            this.chartsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.world_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip dataStrip;
        private System.Windows.Forms.PictureBox world_pictureBox;
        private System.Windows.Forms.ToolStripMenuItem day_dataStrip;
        private System.Windows.Forms.ToolStripMenuItem season_dataStrip;
        private System.Windows.Forms.GroupBox cellInfo;
        private System.Windows.Forms.PictureBox cellImage;
        private System.Windows.Forms.RichTextBox textBoxCellInfo;
        private System.Windows.Forms.Button drawEnergyTypeButton;
        private System.Windows.Forms.Button drawStoredEnergyButton;
        private System.Windows.Forms.Button drawGenomeButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button hintButton;
        private System.Windows.Forms.Button mineralsEnabledButton;
        private System.Windows.Forms.RichTextBox hintTextBox;
        private System.Windows.Forms.Button chartButton;
        private System.Windows.Forms.Panel rightInfoPanel;
        private System.Windows.Forms.ToolStripMenuItem autosavedateStrip;
        private System.Windows.Forms.ToolStripMenuItem currentTime;
        private System.Windows.Forms.ToolStripMenuItem elapsedStrip;
        private System.Windows.Forms.Panel chartsPanel;
        private System.Windows.Forms.Label populationStrip;
        private System.Windows.Forms.Label organicCountStrip;
        private System.Windows.Forms.Label maxGenerationStrip;
        private System.Windows.Forms.PictureBox chartsPictureBox;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.ToolStripMenuItem time_dataStrip;
        private System.Windows.Forms.Button mutatuionsButton;
    }
}

