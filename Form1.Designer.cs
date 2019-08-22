namespace UartToFcb32
{
    partial class UartToFCB
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LablePortOpen = new System.Windows.Forms.Label();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.addressBox = new System.Windows.Forms.TextBox();
            this.dataBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите COM-порт";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "9600",
            "57600",
            "115200",
            "230400",
            "460800",
            "560800",
            "921600",
            "1036800"});
            this.comboBox2.Location = new System.Drawing.Point(111, 152);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Скорость передачи (boad/s)";
            // 
            // LablePortOpen
            // 
            this.LablePortOpen.AutoSize = true;
            this.LablePortOpen.Location = new System.Drawing.Point(234, 157);
            this.LablePortOpen.Name = "LablePortOpen";
            this.LablePortOpen.Size = new System.Drawing.Size(0, 13);
            this.LablePortOpen.TabIndex = 9;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(311, 152);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonWrite.TabIndex = 11;
            this.buttonWrite.Text = "Записать";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(415, 152);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 11;
            this.buttonRead.Text = "Прочитать";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(311, 108);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(92, 20);
            this.addressBox.TabIndex = 12;
            this.addressBox.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // dataBox
            // 
            this.dataBox.Location = new System.Drawing.Point(415, 108);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(92, 20);
            this.dataBox.TabIndex = 12;
            this.dataBox.TextChanged += new System.EventHandler(this.DataBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Адрес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Данные";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Записать массив";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Прочитать массив";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // UartToFCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.LablePortOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "UartToFCB";
            this.Text = "UartToFCB_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LablePortOpen;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox dataBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

