namespace CT_UI
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
            this.lbxAnimals = new System.Windows.Forms.ListBox();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.cbxAnimalSize = new System.Windows.Forms.ComboBox();
            this.cbxAnimalType = new System.Windows.Forms.ComboBox();
            this.lbxTrain = new System.Windows.Forms.ListBox();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTrainLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxAnimals
            // 
            this.lbxAnimals.FormattingEnabled = true;
            this.lbxAnimals.Location = new System.Drawing.Point(11, 50);
            this.lbxAnimals.Margin = new System.Windows.Forms.Padding(2);
            this.lbxAnimals.Name = "lbxAnimals";
            this.lbxAnimals.Size = new System.Drawing.Size(91, 199);
            this.lbxAnimals.TabIndex = 0;
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(12, 302);
            this.btnAddAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(90, 19);
            this.btnAddAnimal.TabIndex = 1;
            this.btnAddAnimal.Text = "Add Animal";
            this.btnAddAnimal.UseVisualStyleBackColor = true;
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // cbxAnimalSize
            // 
            this.cbxAnimalSize.FormattingEnabled = true;
            this.cbxAnimalSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.cbxAnimalSize.Location = new System.Drawing.Point(11, 254);
            this.cbxAnimalSize.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAnimalSize.Name = "cbxAnimalSize";
            this.cbxAnimalSize.Size = new System.Drawing.Size(92, 21);
            this.cbxAnimalSize.TabIndex = 2;
            // 
            // cbxAnimalType
            // 
            this.cbxAnimalType.FormattingEnabled = true;
            this.cbxAnimalType.Items.AddRange(new object[] {
            "Carnivore",
            "Herbivore"});
            this.cbxAnimalType.Location = new System.Drawing.Point(11, 278);
            this.cbxAnimalType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAnimalType.Name = "cbxAnimalType";
            this.cbxAnimalType.Size = new System.Drawing.Size(92, 21);
            this.cbxAnimalType.TabIndex = 3;
            // 
            // lbxTrain
            // 
            this.lbxTrain.FormattingEnabled = true;
            this.lbxTrain.Location = new System.Drawing.Point(140, 50);
            this.lbxTrain.Margin = new System.Windows.Forms.Padding(2);
            this.lbxTrain.Name = "lbxTrain";
            this.lbxTrain.Size = new System.Drawing.Size(449, 199);
            this.lbxTrain.TabIndex = 4;
            // 
            // btnDistribute
            // 
            this.btnDistribute.Location = new System.Drawing.Point(140, 253);
            this.btnDistribute.Margin = new System.Windows.Forms.Padding(2);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(194, 19);
            this.btnDistribute.TabIndex = 5;
            this.btnDistribute.Text = "Distribute";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trian Length";
            // 
            // lblTrainLength
            // 
            this.lblTrainLength.AutoSize = true;
            this.lblTrainLength.Location = new System.Drawing.Point(214, 278);
            this.lblTrainLength.Name = "lblTrainLength";
            this.lblTrainLength.Size = new System.Drawing.Size(13, 13);
            this.lblTrainLength.TabIndex = 7;
            this.lblTrainLength.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblTrainLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDistribute);
            this.Controls.Add(this.lbxTrain);
            this.Controls.Add(this.cbxAnimalType);
            this.Controls.Add(this.cbxAnimalSize);
            this.Controls.Add(this.btnAddAnimal);
            this.Controls.Add(this.lbxAnimals);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAnimals;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.ComboBox cbxAnimalSize;
        private System.Windows.Forms.ComboBox cbxAnimalType;
        private System.Windows.Forms.ListBox lbxTrain;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrainLength;
    }
}

