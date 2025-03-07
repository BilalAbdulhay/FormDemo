namespace FormDemo
{
    partial class Form1
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
         NormalButton = new Button();
         AsyncButton = new Button();
         textBox1 = new TextBox();
         TotalTimeLabel = new Label();
         SuspendLayout();
         // 
         // NormalButton
         // 
         NormalButton.Location = new Point(12,12);
         NormalButton.Name = "NormalButton";
         NormalButton.Size = new Size(75,23);
         NormalButton.TabIndex = 1;
         NormalButton.Text = "Normal";
         NormalButton.UseVisualStyleBackColor = true;
         NormalButton.Click += NormalButton_Click;
         // 
         // AsyncButton
         // 
         AsyncButton.Location = new Point(93,12);
         AsyncButton.Name = "AsyncButton";
         AsyncButton.Size = new Size(75,23);
         AsyncButton.TabIndex = 2;
         AsyncButton.Text = "Async";
         AsyncButton.UseVisualStyleBackColor = true;
         AsyncButton.Click += AsyncButton_Click;
         // 
         // textBox1
         // 
         textBox1.Location = new Point(12,41);
         textBox1.Multiline = true;
         textBox1.Name = "textBox1";
         textBox1.ReadOnly = true;
         textBox1.Size = new Size(475,192);
         textBox1.TabIndex = 3;
         // 
         // TotalTimeLabel
         // 
         TotalTimeLabel.AutoSize = true;
         TotalTimeLabel.Location = new Point(12,236);
         TotalTimeLabel.Name = "TotalTimeLabel";
         TotalTimeLabel.Size = new Size(116,15);
         TotalTimeLabel.TabIndex = 4;
         TotalTimeLabel.Text = "Total executed time :";
         // 
         // Form1
         // 
         AutoScaleDimensions = new SizeF(7F,15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(499,261);
         Controls.Add(TotalTimeLabel);
         Controls.Add(textBox1);
         Controls.Add(AsyncButton);
         Controls.Add(NormalButton);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "Form1";
         Text = "Async Example";
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private Button NormalButton;
      private Button AsyncButton;
      private TextBox textBox1;
      private Label TotalTimeLabel;
   }
}
