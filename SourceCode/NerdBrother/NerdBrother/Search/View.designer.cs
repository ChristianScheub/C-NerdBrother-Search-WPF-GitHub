namespace Suche
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.label1 = new System.Windows.Forms.Label();
            this.label_anfrage = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_newSearch = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.allBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.abfrage1 = new Suche.Abfrage1();
            this.allBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.allTableAdapter1 = new Suche.Abfrage1TableAdapters.AllTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abfrage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(965, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ihre Ergebisse zu der Suchanfrage: ";
            // 
            // label_anfrage
            // 
            this.label_anfrage.AutoSize = true;
            this.label_anfrage.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_anfrage.Font = new System.Drawing.Font("Arial Black", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_anfrage.ForeColor = System.Drawing.Color.White;
            this.label_anfrage.Location = new System.Drawing.Point(1255, 0);
            this.label_anfrage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_anfrage.Name = "label_anfrage";
            this.label_anfrage.Size = new System.Drawing.Size(189, 68);
            this.label_anfrage.TabIndex = 2;
            this.label_anfrage.Text = "label2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.LightSlateGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 65);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1444, 719);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Refresh
            // 
            this.button_Refresh.BackColor = System.Drawing.Color.White;
            this.button_Refresh.BackgroundImage = global::NerdBrother.Properties.Resources.baseline_autorenew_black_18dp;
            this.button_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Refresh.Location = new System.Drawing.Point(0, 717);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(65, 65);
            this.button_Refresh.TabIndex = 5;
            this.button_Refresh.UseVisualStyleBackColor = false;
            this.button_Refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_newSearch
            // 
            this.button_newSearch.BackColor = System.Drawing.Color.White;
            this.button_newSearch.BackgroundImage = global::NerdBrother.Properties.Resources.baseline_search_black_18dp;
            this.button_newSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_newSearch.Location = new System.Drawing.Point(176, 719);
            this.button_newSearch.Name = "button_newSearch";
            this.button_newSearch.Size = new System.Drawing.Size(65, 65);
            this.button_newSearch.TabIndex = 7;
            this.button_newSearch.UseVisualStyleBackColor = false;
            this.button_newSearch.Click += new System.EventHandler(this.button_newSearch_Click);
            // 
            // button_settings
            // 
            this.button_settings.AutoSize = true;
            this.button_settings.BackColor = System.Drawing.Color.White;
            this.button_settings.BackgroundImage = global::NerdBrother.Properties.Resources.baseline_add_circle_outline_black_18dp;
            this.button_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_settings.Location = new System.Drawing.Point(87, 719);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(65, 65);
            this.button_settings.TabIndex = 6;
            this.button_settings.UseVisualStyleBackColor = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // abfrage1
            // 
            this.abfrage1.DataSetName = "Abfrage1";
            this.abfrage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allBindingSource1
            // 
            this.allBindingSource1.DataMember = "All";
            this.allBindingSource1.DataSource = this.abfrage1;
            // 
            // allTableAdapter1
            // 
            this.allTableAdapter1.ClearBeforeFill = true;
            // 
            // View
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1444, 784);
            this.Controls.Add(this.button_newSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.label_anfrage);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "View";
            this.Text = "Ergebnisse";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abfrage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_anfrage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource allBindingSource;
        private Abfrage1 abfrage1;
        private System.Windows.Forms.BindingSource allBindingSource1;
        private Abfrage1TableAdapters.AllTableAdapter allTableAdapter1;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.Button button_newSearch;
    }
}