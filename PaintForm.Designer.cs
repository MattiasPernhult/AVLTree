namespace BinärtSökTräd_AVL
{
    partial class PaintForm
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
            this.btnFind = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.pBoxTree = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTree)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(572, 555);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(104, 35);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "Hitta";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(572, 596);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(104, 35);
            this.btnPost.TabIndex = 15;
            this.btnPost.Text = "PostOrder";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(464, 596);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(89, 35);
            this.btnPre.TabIndex = 14;
            this.btnPre.Text = "PreOrder";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click_1);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(355, 596);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(89, 35);
            this.btnIn.TabIndex = 13;
            this.btnIn.Text = "InOrder";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click_1);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(462, 555);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(91, 35);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Ta bort";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(355, 555);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 35);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Lägg till";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(138, 559);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(171, 26);
            this.txtData.TabIndex = 10;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            this.txtData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtData_KeyDown_1);
            // 
            // pBoxTree
            // 
            this.pBoxTree.Location = new System.Drawing.Point(68, 47);
            this.pBoxTree.Name = "pBoxTree";
            this.pBoxTree.Size = new System.Drawing.Size(708, 470);
            this.pBoxTree.TabIndex = 9;
            this.pBoxTree.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(701, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 35);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 668);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.pBoxTree);
            this.Name = "PaintForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.PictureBox pBoxTree;
        private System.Windows.Forms.Button btnSave;
    }
}

