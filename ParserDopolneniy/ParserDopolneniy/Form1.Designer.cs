namespace ParserDopolneniy
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
            ListTitles = new ListBox();
            StartPoint = new Label();
            NumericStart = new NumericUpDown();
            NumericEnd = new NumericUpDown();
            EndPoint = new Label();
            ButtonStart = new Button();
            ButtonAbort = new Button();
            ((System.ComponentModel.ISupportInitialize)NumericStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericEnd).BeginInit();
            SuspendLayout();
            // 
            // ListTitles
            // 
            ListTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ListTitles.FormattingEnabled = true;
            ListTitles.Location = new Point(12, 12);
            ListTitles.Name = "ListTitles";
            ListTitles.Size = new Size(590, 439);
            ListTitles.TabIndex = 0;
            ListTitles.SelectedIndexChanged += ListTitles_SelectedIndexChanged;
            // 
            // StartPoint
            // 
            StartPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartPoint.AutoSize = true;
            StartPoint.Location = new Point(619, 25);
            StartPoint.Name = "StartPoint";
            StartPoint.Size = new Size(62, 15);
            StartPoint.TabIndex = 1;
            StartPoint.Text = "Start Point";
            // 
            // NumericStart
            // 
            NumericStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NumericStart.Location = new Point(619, 43);
            NumericStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericStart.Name = "NumericStart";
            NumericStart.Size = new Size(120, 23);
            NumericStart.TabIndex = 2;
            NumericStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NumericEnd
            // 
            NumericEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NumericEnd.Location = new Point(619, 98);
            NumericEnd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericEnd.Name = "NumericEnd";
            NumericEnd.Size = new Size(120, 23);
            NumericEnd.TabIndex = 4;
            NumericEnd.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // EndPoint
            // 
            EndPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EndPoint.AutoSize = true;
            EndPoint.Location = new Point(619, 80);
            EndPoint.Name = "EndPoint";
            EndPoint.Size = new Size(58, 15);
            EndPoint.TabIndex = 3;
            EndPoint.Text = "End Point";
            // 
            // ButtonStart
            // 
            ButtonStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonStart.Location = new Point(619, 158);
            ButtonStart.Name = "ButtonStart";
            ButtonStart.Size = new Size(120, 26);
            ButtonStart.TabIndex = 5;
            ButtonStart.Text = "Start";
            ButtonStart.UseVisualStyleBackColor = true;
            ButtonStart.Click += ButtonStart_Click;
            // 
            // ButtonAbort
            // 
            ButtonAbort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonAbort.Location = new Point(619, 190);
            ButtonAbort.Name = "ButtonAbort";
            ButtonAbort.Size = new Size(120, 26);
            ButtonAbort.TabIndex = 6;
            ButtonAbort.Text = "Abort";
            ButtonAbort.UseVisualStyleBackColor = true;
            ButtonAbort.Click += ButtonAbort_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 644);
            Controls.Add(ButtonAbort);
            Controls.Add(ButtonStart);
            Controls.Add(NumericEnd);
            Controls.Add(EndPoint);
            Controls.Add(NumericStart);
            Controls.Add(StartPoint);
            Controls.Add(ListTitles);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumericStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericEnd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListTitles;
        private Label StartPoint;
        private NumericUpDown NumericStart;
        private NumericUpDown NumericEnd;
        private Label EndPoint;
        private Button ButtonStart;
        private Button ButtonAbort;
    }
}
