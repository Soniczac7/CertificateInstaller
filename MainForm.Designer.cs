namespace CertificateInstaller
{
    partial class MainForm
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
            TreeNode treeNode1 = new TreeNode("Soniczac7 Code Signing");
            TreeNode treeNode2 = new TreeNode("Soniczac7 CA", new TreeNode[] { treeNode1 });
            label1 = new Label();
            checkButton = new Button();
            installButton = new Button();
            cancelButton = new Button();
            uncheckButton = new Button();
            certBox = new TreeView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 1;
            label1.Text = "Select certificates to install:";
            // 
            // checkButton
            // 
            checkButton.Location = new Point(272, 405);
            checkButton.Name = "checkButton";
            checkButton.Size = new Size(75, 23);
            checkButton.TabIndex = 2;
            checkButton.Text = "Check All";
            checkButton.UseVisualStyleBackColor = true;
            checkButton.Click += checkButton_Click;
            // 
            // installButton
            // 
            installButton.Location = new Point(353, 405);
            installButton.Name = "installButton";
            installButton.Size = new Size(75, 23);
            installButton.TabIndex = 3;
            installButton.Text = "Install";
            installButton.UseVisualStyleBackColor = true;
            installButton.Click += installButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(6, 405);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // uncheckButton
            // 
            uncheckButton.Location = new Point(178, 405);
            uncheckButton.Name = "uncheckButton";
            uncheckButton.Size = new Size(88, 23);
            uncheckButton.TabIndex = 5;
            uncheckButton.Text = "Uncheck All";
            uncheckButton.UseVisualStyleBackColor = true;
            uncheckButton.Click += uncheckButton_Click;
            // 
            // certBox
            // 
            certBox.CheckBoxes = true;
            certBox.Location = new Point(6, 27);
            certBox.Name = "certBox";
            treeNode1.Name = "Soniczac7 Code Signing";
            treeNode1.Text = "Soniczac7 Code Signing";
            treeNode2.Checked = true;
            treeNode2.Name = "Soniczac7 CA";
            treeNode2.Text = "Soniczac7 CA";
            certBox.Nodes.AddRange(new TreeNode[] { treeNode2 });
            certBox.Size = new Size(422, 372);
            certBox.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 434);
            Controls.Add(certBox);
            Controls.Add(uncheckButton);
            Controls.Add(cancelButton);
            Controls.Add(installButton);
            Controls.Add(checkButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "Soniczac7 Certificate Installer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button checkButton;
        private Button installButton;
        private Button cancelButton;
        private Button uncheckButton;
        private TreeView certBox;
    }
}