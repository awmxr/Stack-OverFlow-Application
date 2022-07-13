
namespace MyClient
{
    partial class AskQuestionForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.HeadTextBox = new DevExpress.XtraEditors.TextEdit();
            this.DescribTextBox = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gc1Control = new DevExpress.XtraEditors.GroupControl();
            this.ErrorLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescribTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1Control)).BeginInit();
            this.gc1Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(132, 581);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit3_Properties_KeyDown);
            this.textEdit3.Size = new System.Drawing.Size(667, 26);
            this.textEdit3.TabIndex = 2;
            this.textEdit3.Click += new System.EventHandler(this.textEdit3_Click);
            this.textEdit3.Enter += new System.EventHandler(this.textEdit3_Enter);
            // 
            // HeadTextBox
            // 
            this.HeadTextBox.Location = new System.Drawing.Point(132, 148);
            this.HeadTextBox.Name = "HeadTextBox";
            this.HeadTextBox.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadTextBox.Properties.Appearance.Options.UseFont = true;
            this.HeadTextBox.Size = new System.Drawing.Size(667, 30);
            this.HeadTextBox.TabIndex = 0;
            // 
            // DescribTextBox
            // 
            this.DescribTextBox.Location = new System.Drawing.Point(132, 227);
            this.DescribTextBox.Name = "DescribTextBox";
            this.DescribTextBox.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescribTextBox.Properties.Appearance.Options.UseFont = true;
            this.DescribTextBox.Size = new System.Drawing.Size(667, 312);
            this.DescribTextBox.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(132, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(200, 35);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Ask a Question";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(132, 126);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Header :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(132, 204);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Describ : ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(132, 558);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 16);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Tags :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(132, 756);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 47);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Submit";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 31);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 16);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "labelControl5";
            // 
            // gc1Control
            // 
            this.gc1Control.AutoSize = true;
            this.gc1Control.Controls.Add(this.labelControl5);
            this.gc1Control.Location = new System.Drawing.Point(132, 625);
            this.gc1Control.Name = "gc1Control";
            this.gc1Control.Size = new System.Drawing.Size(667, 104);
            this.gc1Control.TabIndex = 12;
            this.gc1Control.Text = "Tags";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Location = new System.Drawing.Point(289, 772);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(75, 16);
            this.ErrorLabel.TabIndex = 13;
            this.ErrorLabel.Text = "labelControl6";
            // 
            // AskQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.gc1Control);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DescribTextBox);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.HeadTextBox);
            this.Name = "AskQuestionForm";
            this.Size = new System.Drawing.Size(1288, 819);
            this.Load += new System.EventHandler(this.AskQuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescribTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc1Control)).EndInit();
            this.gc1Control.ResumeLayout(false);
            this.gc1Control.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit HeadTextBox;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.MemoEdit DescribTextBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl gc1Control;
        private DevExpress.XtraEditors.LabelControl ErrorLabel;
    }
}
