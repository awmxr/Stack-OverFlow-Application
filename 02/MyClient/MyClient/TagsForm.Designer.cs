
namespace MyClient
{
    partial class TagsForm
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SerchTXT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.SerchTXT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(103, 112);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 38);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tags";
            // 
            // SerchTXT
            // 
            this.SerchTXT.Location = new System.Drawing.Point(486, 114);
            this.SerchTXT.Name = "SerchTXT";
            this.SerchTXT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerchTXT.Properties.Appearance.Options.UseFont = true;
            this.SerchTXT.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit1_Properties_KeyDown);
            this.SerchTXT.Size = new System.Drawing.Size(333, 38);
            this.SerchTXT.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(486, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Search :";
            // 
            // TagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SerchTXT);
            this.Controls.Add(this.labelControl2);
            this.Name = "TagsForm";
            this.Size = new System.Drawing.Size(1662, 851);
            this.Load += new System.EventHandler(this.TagsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SerchTXT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit SerchTXT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
