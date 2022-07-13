
namespace MyClient
{
    partial class QuestionForm
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
            this.QuestionLabel = new DevExpress.XtraEditors.LabelControl();
            this.QuestionDes = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Usernamelbl = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.Viewlbl = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Appearance.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Appearance.Options.UseFont = true;
            this.QuestionLabel.Location = new System.Drawing.Point(112, 147);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(160, 32);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "labelControl1";
            this.QuestionLabel.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // QuestionDes
            // 
            this.QuestionDes.Appearance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionDes.Appearance.Options.UseFont = true;
            this.QuestionDes.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.QuestionDes.Location = new System.Drawing.Point(112, 198);
            this.QuestionDes.Name = "QuestionDes";
            this.QuestionDes.Size = new System.Drawing.Size(664, 19);
            this.QuestionDes.TabIndex = 1;
            this.QuestionDes.Text = "1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(112, 42);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Back";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Usernamelbl
            // 
            this.Usernamelbl.Location = new System.Drawing.Point(112, 125);
            this.Usernamelbl.Name = "Usernamelbl";
            this.Usernamelbl.Size = new System.Drawing.Size(75, 16);
            this.Usernamelbl.TabIndex = 6;
            this.Usernamelbl.Text = "labelControl2";
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.SvgImage = global::MyClient.Properties.Resources.refresh;
            this.simpleButton4.Location = new System.Drawing.Point(371, 42);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(125, 54);
            this.simpleButton4.TabIndex = 8;
            this.simpleButton4.Text = "Refresh";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // Viewlbl
            // 
            this.Viewlbl.Location = new System.Drawing.Point(454, 125);
            this.Viewlbl.Name = "Viewlbl";
            this.Viewlbl.Size = new System.Drawing.Size(28, 16);
            this.Viewlbl.TabIndex = 10;
            this.Viewlbl.Text = "View";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Viewlbl);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.Usernamelbl);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.QuestionDes);
            this.Controls.Add(this.QuestionLabel);
            this.Name = "QuestionForm";
            this.Size = new System.Drawing.Size(1763, 722);
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl QuestionLabel;
        private DevExpress.XtraEditors.LabelControl QuestionDes;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl Usernamelbl;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.LabelControl Viewlbl;
    }
}
