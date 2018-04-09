namespace ChallongeStats {
    partial class Principal {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.btnGenerar = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelGuardarEn = new System.Windows.Forms.Label();
            this.btnGuardarEn = new System.Windows.Forms.Button();
            this.txtGuardarEn = new System.Windows.Forms.TextBox();
            this.labelJug1 = new System.Windows.Forms.Label();
            this.txtJug1 = new System.Windows.Forms.TextBox();
            this.txtJug2 = new System.Windows.Forms.TextBox();
            this.labelJug2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSwapNames = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.cbDoStats = new System.Windows.Forms.CheckBox();
            this.cbDoPlayerData = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(180, 193);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(228, 48);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(23, 47);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(152, 17);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "Identificador Challonge";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(181, 47);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(227, 22);
            this.txtId.TabIndex = 2;
            // 
            // labelGuardarEn
            // 
            this.labelGuardarEn.AutoSize = true;
            this.labelGuardarEn.Location = new System.Drawing.Point(23, 76);
            this.labelGuardarEn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGuardarEn.Name = "labelGuardarEn";
            this.labelGuardarEn.Size = new System.Drawing.Size(81, 17);
            this.labelGuardarEn.TabIndex = 3;
            this.labelGuardarEn.Text = "Guardar en";
            // 
            // btnGuardarEn
            // 
            this.btnGuardarEn.Location = new System.Drawing.Point(306, 94);
            this.btnGuardarEn.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarEn.Name = "btnGuardarEn";
            this.btnGuardarEn.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarEn.TabIndex = 4;
            this.btnGuardarEn.Text = "Seleccionar";
            this.btnGuardarEn.UseVisualStyleBackColor = true;
            this.btnGuardarEn.Click += new System.EventHandler(this.BtnGuardarEn_Click);
            // 
            // txtGuardarEn
            // 
            this.txtGuardarEn.Location = new System.Drawing.Point(22, 97);
            this.txtGuardarEn.Margin = new System.Windows.Forms.Padding(4);
            this.txtGuardarEn.Name = "txtGuardarEn";
            this.txtGuardarEn.Size = new System.Drawing.Size(276, 22);
            this.txtGuardarEn.TabIndex = 3;
            // 
            // labelJug1
            // 
            this.labelJug1.AutoSize = true;
            this.labelJug1.Location = new System.Drawing.Point(20, 133);
            this.labelJug1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJug1.Name = "labelJug1";
            this.labelJug1.Size = new System.Drawing.Size(126, 17);
            this.labelJug1.TabIndex = 6;
            this.labelJug1.Text = "Nombre Jugador 1";
            // 
            // txtJug1
            // 
            this.txtJug1.Location = new System.Drawing.Point(21, 154);
            this.txtJug1.Margin = new System.Windows.Forms.Padding(4);
            this.txtJug1.Name = "txtJug1";
            this.txtJug1.Size = new System.Drawing.Size(163, 22);
            this.txtJug1.TabIndex = 5;
            this.txtJug1.Enter += new System.EventHandler(this.txtJug1_Enter);
            this.txtJug1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJug1_KeyPress);
            this.txtJug1.Leave += new System.EventHandler(this.txtJug1_Leave);
            this.txtJug1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtJug1_MouseUp);
            // 
            // txtJug2
            // 
            this.txtJug2.Location = new System.Drawing.Point(243, 154);
            this.txtJug2.Margin = new System.Windows.Forms.Padding(4);
            this.txtJug2.Name = "txtJug2";
            this.txtJug2.Size = new System.Drawing.Size(163, 22);
            this.txtJug2.TabIndex = 6;
            this.txtJug2.Enter += new System.EventHandler(this.txtJug2_Enter);
            this.txtJug2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJug2_KeyPress);
            this.txtJug2.Leave += new System.EventHandler(this.txtJug2_Leave);
            this.txtJug2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtJug2_MouseUp);
            // 
            // labelJug2
            // 
            this.labelJug2.AutoSize = true;
            this.labelJug2.Location = new System.Drawing.Point(240, 133);
            this.labelJug2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJug2.Name = "labelJug2";
            this.labelJug2.Size = new System.Drawing.Size(126, 17);
            this.labelJug2.TabIndex = 9;
            this.labelJug2.Text = "Nombre Jugador 2";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Destino de ficheros de texto";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(433, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(186, 22);
            this.lblEstado.Text = "Easanles 2018 - Versión 1.0";
            // 
            // btnSwapNames
            // 
            this.btnSwapNames.Location = new System.Drawing.Point(191, 154);
            this.btnSwapNames.Name = "btnSwapNames";
            this.btnSwapNames.Size = new System.Drawing.Size(45, 23);
            this.btnSwapNames.TabIndex = 10;
            this.btnSwapNames.Text = "<->";
            this.btnSwapNames.UseVisualStyleBackColor = true;
            this.btnSwapNames.Click += new System.EventHandler(this.BtnSwapNames_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clave API (No mostrar)";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(181, 13);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(227, 22);
            this.txtApiKey.TabIndex = 1;
            this.txtApiKey.UseSystemPasswordChar = true;
            // 
            // cbDoStats
            // 
            this.cbDoStats.AutoSize = true;
            this.cbDoStats.Checked = true;
            this.cbDoStats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDoStats.Location = new System.Drawing.Point(23, 193);
            this.cbDoStats.Name = "cbDoStats";
            this.cbDoStats.Size = new System.Drawing.Size(150, 21);
            this.cbDoStats.TabIndex = 7;
            this.cbDoStats.Text = "Estadísticas torneo";
            this.cbDoStats.UseVisualStyleBackColor = true;
            // 
            // cbDoPlayerData
            // 
            this.cbDoPlayerData.AutoSize = true;
            this.cbDoPlayerData.Checked = true;
            this.cbDoPlayerData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDoPlayerData.Location = new System.Drawing.Point(23, 220);
            this.cbDoPlayerData.Name = "cbDoPlayerData";
            this.cbDoPlayerData.Size = new System.Drawing.Size(142, 21);
            this.cbDoPlayerData.TabIndex = 8;
            this.cbDoPlayerData.Text = "Datos del jugador";
            this.cbDoPlayerData.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 285);
            this.Controls.Add(this.cbDoPlayerData);
            this.Controls.Add(this.cbDoStats);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSwapNames);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelJug2);
            this.Controls.Add(this.txtJug2);
            this.Controls.Add(this.txtJug1);
            this.Controls.Add(this.labelJug1);
            this.Controls.Add(this.txtGuardarEn);
            this.Controls.Add(this.btnGuardarEn);
            this.Controls.Add(this.labelGuardarEn);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.btnGenerar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Estadísticas de Challonge";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labelGuardarEn;
        private System.Windows.Forms.Button btnGuardarEn;
        private System.Windows.Forms.TextBox txtGuardarEn;
        private System.Windows.Forms.Label labelJug1;
        private System.Windows.Forms.TextBox txtJug1;
        private System.Windows.Forms.TextBox txtJug2;
        private System.Windows.Forms.Label labelJug2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.Button btnSwapNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.CheckBox cbDoStats;
        private System.Windows.Forms.CheckBox cbDoPlayerData;
    }
}

