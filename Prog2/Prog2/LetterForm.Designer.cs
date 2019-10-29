namespace UPVApp
{
    partial class LetterForm
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
            this.originLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.costBox = new System.Windows.Forms.TextBox();
            this.originAddressComboBox = new System.Windows.Forms.ComboBox();
            this.destinationComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // originLabel
            // 
            this.originLabel.AutoSize = true;
            this.originLabel.Location = new System.Drawing.Point(45, 31);
            this.originLabel.Name = "originLabel";
            this.originLabel.Size = new System.Drawing.Size(78, 13);
            this.originLabel.TabIndex = 7;
            this.originLabel.Tag = "";
            this.originLabel.Text = "Origin Address:";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(19, 58);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(104, 13);
            this.destinationLabel.TabIndex = 8;
            this.destinationLabel.Tag = "";
            this.destinationLabel.Text = "Destination Address:";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(64, 85);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(59, 13);
            this.costLabel.TabIndex = 9;
            this.costLabel.Tag = "";
            this.costLabel.Text = "Fixed Cost:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(157, 127);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cancel_MouseDown);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(67, 127);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // costBox
            // 
            this.costBox.Location = new System.Drawing.Point(129, 82);
            this.costBox.Name = "costBox";
            this.costBox.Size = new System.Drawing.Size(121, 20);
            this.costBox.TabIndex = 3;
            this.costBox.Validating += new System.ComponentModel.CancelEventHandler(this.Cost_Validating);
            this.costBox.Validated += new System.EventHandler(this.Cost_Validated);
            // 
            // originAddressComboBox
            // 
            this.originAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originAddressComboBox.FormattingEnabled = true;
            this.originAddressComboBox.Location = new System.Drawing.Point(129, 28);
            this.originAddressComboBox.Name = "originAddressComboBox";
            this.originAddressComboBox.Size = new System.Drawing.Size(121, 21);
            this.originAddressComboBox.TabIndex = 1;
            this.originAddressComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.Origin_Validating);
            this.originAddressComboBox.Validated += new System.EventHandler(this.Origin_Validated);
            // 
            // destinationComboBox
            // 
            this.destinationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationComboBox.FormattingEnabled = true;
            this.destinationComboBox.Location = new System.Drawing.Point(129, 55);
            this.destinationComboBox.Name = "destinationComboBox";
            this.destinationComboBox.Size = new System.Drawing.Size(121, 21);
            this.destinationComboBox.TabIndex = 2;
            this.destinationComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.Destination_Validating);
            this.destinationComboBox.Validated += new System.EventHandler(this.Destination_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 185);
            this.Controls.Add(this.destinationComboBox);
            this.Controls.Add(this.originAddressComboBox);
            this.Controls.Add(this.costBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.originLabel);
            this.Name = "LetterForm";
            this.Text = "LetterForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label originLabel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox costBox;
        private System.Windows.Forms.ComboBox originAddressComboBox;
        private System.Windows.Forms.ComboBox destinationComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}