namespace lab3tema
{
    partial class Form1
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
            this.dataGridViewChild = new System.Windows.Forms.DataGridView();
            this.scoliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catalog_virtualDataSet = new lab3tema.catalog_virtualDataSet();
            this.dataGridViewParent = new System.Windows.Forms.DataGridView();
            this.oraseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oraseTableAdapter = new lab3tema.catalog_virtualDataSetTableAdapters.OraseTableAdapter();
            this.scoliTableAdapter = new lab3tema.catalog_virtualDataSetTableAdapters.ScoliTableAdapter();
            this.labelChild = new System.Windows.Forms.Label();
            this.labelParent = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonCommit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalog_virtualDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oraseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewChild
            // 
            this.dataGridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChild.Location = new System.Drawing.Point(362, 45);
            this.dataGridViewChild.Name = "dataGridViewChild";
            this.dataGridViewChild.Size = new System.Drawing.Size(343, 250);
            this.dataGridViewChild.TabIndex = 0;
            // 
            // scoliBindingSource
            // 
            this.scoliBindingSource.DataMember = "Scoli";
            this.scoliBindingSource.DataSource = this.catalog_virtualDataSet;
            // 
            // catalog_virtualDataSet
            // 
            this.catalog_virtualDataSet.DataSetName = "catalog_virtualDataSet";
            this.catalog_virtualDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewParent
            // 
            this.dataGridViewParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParent.Location = new System.Drawing.Point(35, 45);
            this.dataGridViewParent.Name = "dataGridViewParent";
            this.dataGridViewParent.Size = new System.Drawing.Size(243, 250);
            this.dataGridViewParent.TabIndex = 1;
            this.dataGridViewParent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // oraseBindingSource
            // 
            this.oraseBindingSource.DataMember = "Orase";
            this.oraseBindingSource.DataSource = this.catalog_virtualDataSet;
            // 
            // oraseTableAdapter
            // 
            this.oraseTableAdapter.ClearBeforeFill = true;
            // 
            // scoliTableAdapter
            // 
            this.scoliTableAdapter.ClearBeforeFill = true;
            // 
            // labelChild
            // 
            this.labelChild.AutoSize = true;
            this.labelChild.Location = new System.Drawing.Point(374, 25);
            this.labelChild.Name = "labelChild";
            this.labelChild.Size = new System.Drawing.Size(50, 13);
            this.labelChild.TabIndex = 2;
            this.labelChild.Text = "Scoli (fiu)";
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Location = new System.Drawing.Point(43, 29);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(76, 13);
            this.labelParent.TabIndex = 3;
            this.labelParent.Text = "Orase (parinte)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 320);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Id";
            this.label3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nume";
            this.label5.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(62, 346);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(143, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Afisare Orase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 26);
            this.button2.TabIndex = 11;
            this.button2.Text = "Update Scoala";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 359);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "Sterge Scoala";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(507, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 26);
            this.button4.TabIndex = 13;
            this.button4.Text = "Adauga Scoala";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(362, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 26);
            this.button5.TabIndex = 14;
            this.button5.Text = "Afisare Scoli";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonCommit
            // 
            this.buttonCommit.Location = new System.Drawing.Point(294, 406);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(112, 26);
            this.buttonCommit.TabIndex = 16;
            this.buttonCommit.Text = "buttonCommit";
            this.buttonCommit.UseVisualStyleBackColor = true;
            this.buttonCommit.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelParent);
            this.Controls.Add(this.labelChild);
            this.Controls.Add(this.dataGridViewParent);
            this.Controls.Add(this.dataGridViewChild);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalog_virtualDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oraseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewChild;
        private System.Windows.Forms.DataGridView dataGridViewParent;
        private catalog_virtualDataSet catalog_virtualDataSet;
        private System.Windows.Forms.BindingSource oraseBindingSource;
        private catalog_virtualDataSetTableAdapters.OraseTableAdapter oraseTableAdapter;
        private System.Windows.Forms.BindingSource scoliBindingSource;
        private catalog_virtualDataSetTableAdapters.ScoliTableAdapter scoliTableAdapter;
        private System.Windows.Forms.Label labelChild;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonCommit;
    }
}

