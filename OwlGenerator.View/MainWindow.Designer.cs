
namespace OwlGenerator.View
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Load = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSubClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.Button();
            this.CreateThing = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Execute = new System.Windows.Forms.Button();
            this.SaveAsScs = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView1.Location = new System.Drawing.Point(3, 72);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(1455, 665);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Load
            // 
            this.Load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Load.Location = new System.Drawing.Point(1317, 16);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(130, 39);
            this.Load.TabIndex = 2;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Open_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubClassToolStripMenuItem,
            this.addIndividualToolStripMenuItem,
            this.addRelationToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 152);
            // 
            // addSubClassToolStripMenuItem
            // 
            this.addSubClassToolStripMenuItem.Name = "addSubClassToolStripMenuItem";
            this.addSubClassToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.addSubClassToolStripMenuItem.Text = "Add SubClass";
            this.addSubClassToolStripMenuItem.Click += new System.EventHandler(this.addSubClassToolStripMenuItem_Click);
            // 
            // addIndividualToolStripMenuItem
            // 
            this.addIndividualToolStripMenuItem.Name = "addIndividualToolStripMenuItem";
            this.addIndividualToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.addIndividualToolStripMenuItem.Text = "Add Individual";
            this.addIndividualToolStripMenuItem.Click += new System.EventHandler(this.AddIndividualToolStripMenuItem_Click);
            // 
            // addRelationToolStripMenuItem
            // 
            this.addRelationToolStripMenuItem.Name = "addRelationToolStripMenuItem";
            this.addRelationToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.addRelationToolStripMenuItem.Text = "Add Relation";
            this.addRelationToolStripMenuItem.Click += new System.EventHandler(this.addRelationToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(1197, 16);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(114, 39);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CreateThing
            // 
            this.CreateThing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateThing.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CreateThing.Location = new System.Drawing.Point(12, 13);
            this.CreateThing.Name = "CreateThing";
            this.CreateThing.Size = new System.Drawing.Size(114, 41);
            this.CreateThing.TabIndex = 4;
            this.CreateThing.Text = "Create Thing";
            this.CreateThing.UseVisualStyleBackColor = false;
            this.CreateThing.Click += new System.EventHandler(this.CreateThing_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(151, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(785, 54);
            this.textBox1.TabIndex = 5;
            // 
            // Execute
            // 
            this.Execute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Execute.Location = new System.Drawing.Point(1077, 16);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(114, 38);
            this.Execute.TabIndex = 6;
            this.Execute.Text = "Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // SaveAsScs
            // 
            this.SaveAsScs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAsScs.Location = new System.Drawing.Point(957, 16);
            this.SaveAsScs.Name = "SaveAsScs";
            this.SaveAsScs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveAsScs.Size = new System.Drawing.Size(114, 38);
            this.SaveAsScs.TabIndex = 7;
            this.SaveAsScs.Text = "Save as SCs";
            this.SaveAsScs.UseVisualStyleBackColor = true;
            this.SaveAsScs.Click += new System.EventHandler(this.SaveAsScs_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 738);
            this.Controls.Add(this.SaveAsScs);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CreateThing);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.treeView1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addSubClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button CreateThing;
        private System.Windows.Forms.ToolStripMenuItem addIndividualToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.ToolStripMenuItem addRelationToolStripMenuItem;
        private System.Windows.Forms.Button SaveAsScs;
    }
}

