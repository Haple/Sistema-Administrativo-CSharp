namespace TrailerPaulista
{
    partial class MensagensForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensagensForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lista_pedidos = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lista_mensagens = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lista_pedidos);
            this.panel2.Location = new System.Drawing.Point(28, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 335);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pedidos:";
            // 
            // lista_pedidos
            // 
            this.lista_pedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.lista_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lista_pedidos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_pedidos.ForeColor = System.Drawing.Color.White;
            this.lista_pedidos.FormattingEnabled = true;
            this.lista_pedidos.ItemHeight = 17;
            this.lista_pedidos.Location = new System.Drawing.Point(5, 37);
            this.lista_pedidos.Name = "lista_pedidos";
            this.lista_pedidos.Size = new System.Drawing.Size(379, 289);
            this.lista_pedidos.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.lista_mensagens);
            this.panel1.Location = new System.Drawing.Point(435, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 269);
            this.panel1.TabIndex = 0;
            // 
            // lista_mensagens
            // 
            this.lista_mensagens.BackColor = System.Drawing.SystemColors.Control;
            this.lista_mensagens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lista_mensagens.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_mensagens.FormattingEnabled = true;
            this.lista_mensagens.HorizontalScrollbar = true;
            this.lista_mensagens.ItemHeight = 17;
            this.lista_mensagens.Location = new System.Drawing.Point(38, 33);
            this.lista_mensagens.Name = "lista_mensagens";
            this.lista_mensagens.Size = new System.Drawing.Size(329, 170);
            this.lista_mensagens.TabIndex = 0;
            // 
            // MensagensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "MensagensForm";
            this.Size = new System.Drawing.Size(856, 400);
            this.Load += new System.EventHandler(this.MensagensForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lista_pedidos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lista_mensagens;
    }
}
