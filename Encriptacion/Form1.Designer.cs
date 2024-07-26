namespace Encriptacion
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
            Cifrar = new Button();
            Descifrar = new Button();
            label1 = new Label();
            label2 = new Label();
            palabra = new TextBox();
            label3 = new Label();
            convertir = new Button();
            llave = new TextBox();
            palabraC = new TextBox();
            label4 = new Label();
            reiniciar = new Button();
            criptoM1 = new RichTextBox();
            criptoM2 = new RichTextBox();
            SuspendLayout();
            // 
            // Cifrar
            // 
            Cifrar.Location = new Point(586, 54);
            Cifrar.Name = "Cifrar";
            Cifrar.Size = new Size(128, 29);
            Cifrar.TabIndex = 0;
            Cifrar.Text = "Cifrar";
            Cifrar.UseVisualStyleBackColor = true;
            Cifrar.Click += Cifrar_Click;
            // 
            // Descifrar
            // 
            Descifrar.Location = new Point(586, 112);
            Descifrar.Name = "Descifrar";
            Descifrar.Size = new Size(128, 29);
            Descifrar.TabIndex = 1;
            Descifrar.Text = "Descifrar";
            Descifrar.UseVisualStyleBackColor = true;
            Descifrar.Click += Descifrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 19);
            label1.Name = "label1";
            label1.Size = new Size(198, 20);
            label1.TabIndex = 2;
            label1.Text = "Cifrado o decifrado de texto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 86);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 3;
            label2.Text = "Palabra:";
            // 
            // palabra
            // 
            palabra.Location = new Point(163, 87);
            palabra.Name = "palabra";
            palabra.Size = new Size(277, 27);
            palabra.TabIndex = 4;
            palabra.KeyPress += palabra_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 149);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 5;
            label3.Text = "Llave:";
            // 
            // convertir
            // 
            convertir.Location = new Point(586, 163);
            convertir.Name = "convertir";
            convertir.Size = new Size(127, 29);
            convertir.TabIndex = 8;
            convertir.Text = "Convertir";
            convertir.UseVisualStyleBackColor = true;
            convertir.Click += convertir_Click;
            // 
            // llave
            // 
            llave.Location = new Point(163, 149);
            llave.Name = "llave";
            llave.Size = new Size(277, 27);
            llave.TabIndex = 9;
            llave.KeyPress += llave_KeyPress;
            // 
            // palabraC
            // 
            palabraC.Location = new Point(163, 207);
            palabraC.Name = "palabraC";
            palabraC.Size = new Size(277, 27);
            palabraC.TabIndex = 10;
            palabraC.KeyPress += palabraC_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 214);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 11;
            label4.Text = "Palabra cifrada";
            // 
            // reiniciar
            // 
            reiniciar.Location = new Point(587, 239);
            reiniciar.Name = "reiniciar";
            reiniciar.Size = new Size(127, 29);
            reiniciar.TabIndex = 12;
            reiniciar.Text = "Reiniciar";
            reiniciar.UseVisualStyleBackColor = true;
            reiniciar.Click += reiniciar_Click;
            // 
            // criptoM1
            // 
            criptoM1.Location = new Point(67, 304);
            criptoM1.Name = "criptoM1";
            criptoM1.Size = new Size(111, 158);
            criptoM1.TabIndex = 18;
            criptoM1.Text = "";
            // 
            // criptoM2
            // 
            criptoM2.Location = new Point(197, 304);
            criptoM2.Name = "criptoM2";
            criptoM2.Size = new Size(111, 158);
            criptoM2.TabIndex = 19;
            criptoM2.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 502);
            Controls.Add(criptoM2);
            Controls.Add(criptoM1);
            Controls.Add(reiniciar);
            Controls.Add(label4);
            Controls.Add(palabraC);
            Controls.Add(llave);
            Controls.Add(convertir);
            Controls.Add(label3);
            Controls.Add(palabra);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Descifrar);
            Controls.Add(Cifrar);
            Name = "Form1";
            Text = "Cifrado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cifrar;
        private Button Descifrar;
        private Label label1;
        private Label label2;
        private TextBox palabra;
        private Label label3;
        private Button convertir;
        private TextBox llave;
        private TextBox palabraC;
        private Label label4;
        private Button reiniciar;
        private RichTextBox criptoM1;
        private RichTextBox criptoM2;
    }
}
