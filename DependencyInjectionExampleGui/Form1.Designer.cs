
namespace DependencyInjectionExampleGui
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
			this.lboxClient = new System.Windows.Forms.ListBox();
			this.btAddClient = new System.Windows.Forms.Button();
			this.btRemoveClient = new System.Windows.Forms.Button();
			this.lbLastName = new System.Windows.Forms.Label();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			this.gbAddClient = new System.Windows.Forms.GroupBox();
			this.lbClientId = new System.Windows.Forms.Label();
			this.lbClientIdLabel = new System.Windows.Forms.Label();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpClient = new System.Windows.Forms.TabPage();
			this.btResetSelectedClient = new System.Windows.Forms.Button();
			this.tpPhone = new System.Windows.Forms.TabPage();
			this.btResetSelectionPhones = new System.Windows.Forms.Button();
			this.lboxPhones = new System.Windows.Forms.ListBox();
			this.gbPhones = new System.Windows.Forms.GroupBox();
			this.cbPhoneClients = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbPhoneClientId = new System.Windows.Forms.Label();
			this.lbPhoneClientIdLabel = new System.Windows.Forms.Label();
			this.lbPhoneId = new System.Windows.Forms.Label();
			this.lbPhoneIdLabel = new System.Windows.Forms.Label();
			this.btPhoneDelete = new System.Windows.Forms.Button();
			this.tbLocation = new System.Windows.Forms.TextBox();
			this.lbPhoneNumber = new System.Windows.Forms.Label();
			this.btPhoneCreateUpdate = new System.Windows.Forms.Button();
			this.tbPhoneNumber = new System.Windows.Forms.TextBox();
			this.lbLocation = new System.Windows.Forms.Label();
			this.gbAddClient.SuspendLayout();
			this.tcMain.SuspendLayout();
			this.tpClient.SuspendLayout();
			this.tpPhone.SuspendLayout();
			this.gbPhones.SuspendLayout();
			this.SuspendLayout();
			// 
			// lboxClient
			// 
			this.lboxClient.FormattingEnabled = true;
			this.lboxClient.ItemHeight = 25;
			this.lboxClient.Location = new System.Drawing.Point(30, 33);
			this.lboxClient.Name = "lboxClient";
			this.lboxClient.Size = new System.Drawing.Size(437, 529);
			this.lboxClient.TabIndex = 0;
			this.lboxClient.SelectedIndexChanged += new System.EventHandler(this.lboxClient_SelectedIndexChanged);
			// 
			// btAddClient
			// 
			this.btAddClient.Location = new System.Drawing.Point(95, 304);
			this.btAddClient.Name = "btAddClient";
			this.btAddClient.Size = new System.Drawing.Size(244, 34);
			this.btAddClient.TabIndex = 1;
			this.btAddClient.Text = "Actualizar";
			this.btAddClient.UseVisualStyleBackColor = true;
			this.btAddClient.Click += new System.EventHandler(this.btAddClient_Click);
			// 
			// btRemoveClient
			// 
			this.btRemoveClient.Location = new System.Drawing.Point(95, 387);
			this.btRemoveClient.Name = "btRemoveClient";
			this.btRemoveClient.Size = new System.Drawing.Size(244, 34);
			this.btRemoveClient.TabIndex = 3;
			this.btRemoveClient.Text = "Eliminar";
			this.btRemoveClient.UseVisualStyleBackColor = true;
			this.btRemoveClient.Click += new System.EventHandler(this.btRemoveClient_Click);
			// 
			// lbLastName
			// 
			this.lbLastName.AutoSize = true;
			this.lbLastName.Location = new System.Drawing.Point(19, 167);
			this.lbLastName.Name = "lbLastName";
			this.lbLastName.Size = new System.Drawing.Size(78, 25);
			this.lbLastName.TabIndex = 5;
			this.lbLastName.Text = "Apellido";
			// 
			// tbLastName
			// 
			this.tbLastName.Location = new System.Drawing.Point(104, 164);
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(244, 31);
			this.tbLastName.TabIndex = 6;
			// 
			// tbFirstName
			// 
			this.tbFirstName.Location = new System.Drawing.Point(104, 111);
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(244, 31);
			this.tbFirstName.TabIndex = 7;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(19, 111);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(78, 25);
			this.lbName.TabIndex = 8;
			this.lbName.Text = "Nombre";
			// 
			// gbAddClient
			// 
			this.gbAddClient.Controls.Add(this.lbClientId);
			this.gbAddClient.Controls.Add(this.lbClientIdLabel);
			this.gbAddClient.Controls.Add(this.btRemoveClient);
			this.gbAddClient.Controls.Add(this.tbLastName);
			this.gbAddClient.Controls.Add(this.lbName);
			this.gbAddClient.Controls.Add(this.btAddClient);
			this.gbAddClient.Controls.Add(this.tbFirstName);
			this.gbAddClient.Controls.Add(this.lbLastName);
			this.gbAddClient.Location = new System.Drawing.Point(572, 33);
			this.gbAddClient.Name = "gbAddClient";
			this.gbAddClient.Size = new System.Drawing.Size(448, 522);
			this.gbAddClient.TabIndex = 9;
			this.gbAddClient.TabStop = false;
			this.gbAddClient.Text = "Cliente";
			// 
			// lbClientId
			// 
			this.lbClientId.AutoSize = true;
			this.lbClientId.Location = new System.Drawing.Point(104, 59);
			this.lbClientId.Name = "lbClientId";
			this.lbClientId.Size = new System.Drawing.Size(44, 25);
			this.lbClientId.TabIndex = 12;
			this.lbClientId.Text = "N/A";
			// 
			// lbClientIdLabel
			// 
			this.lbClientIdLabel.AutoSize = true;
			this.lbClientIdLabel.Location = new System.Drawing.Point(19, 59);
			this.lbClientIdLabel.Name = "lbClientIdLabel";
			this.lbClientIdLabel.Size = new System.Drawing.Size(28, 25);
			this.lbClientIdLabel.TabIndex = 11;
			this.lbClientIdLabel.Text = "Id";
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpClient);
			this.tcMain.Controls.Add(this.tpPhone);
			this.tcMain.Location = new System.Drawing.Point(23, 34);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(1051, 689);
			this.tcMain.TabIndex = 10;
			this.tcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcMain_Selected);
			// 
			// tpClient
			// 
			this.tpClient.Controls.Add(this.btResetSelectedClient);
			this.tpClient.Controls.Add(this.gbAddClient);
			this.tpClient.Controls.Add(this.lboxClient);
			this.tpClient.Location = new System.Drawing.Point(4, 34);
			this.tpClient.Name = "tpClient";
			this.tpClient.Padding = new System.Windows.Forms.Padding(3);
			this.tpClient.Size = new System.Drawing.Size(1043, 651);
			this.tpClient.TabIndex = 0;
			this.tpClient.Text = "Clients";
			this.tpClient.UseVisualStyleBackColor = true;
			// 
			// btResetSelectedClient
			// 
			this.btResetSelectedClient.Location = new System.Drawing.Point(30, 580);
			this.btResetSelectedClient.Name = "btResetSelectedClient";
			this.btResetSelectedClient.Size = new System.Drawing.Size(200, 34);
			this.btResetSelectedClient.TabIndex = 10;
			this.btResetSelectedClient.Text = "Reiniciar Selección";
			this.btResetSelectedClient.UseVisualStyleBackColor = true;
			this.btResetSelectedClient.Click += new System.EventHandler(this.btResetSelectedClient_Click);
			// 
			// tpPhone
			// 
			this.tpPhone.Controls.Add(this.btResetSelectionPhones);
			this.tpPhone.Controls.Add(this.lboxPhones);
			this.tpPhone.Controls.Add(this.gbPhones);
			this.tpPhone.Location = new System.Drawing.Point(4, 34);
			this.tpPhone.Name = "tpPhone";
			this.tpPhone.Padding = new System.Windows.Forms.Padding(3);
			this.tpPhone.Size = new System.Drawing.Size(1043, 651);
			this.tpPhone.TabIndex = 1;
			this.tpPhone.Text = "Phones";
			this.tpPhone.UseVisualStyleBackColor = true;
			// 
			// btResetSelectionPhones
			// 
			this.btResetSelectionPhones.Location = new System.Drawing.Point(27, 584);
			this.btResetSelectionPhones.Name = "btResetSelectionPhones";
			this.btResetSelectionPhones.Size = new System.Drawing.Size(191, 34);
			this.btResetSelectionPhones.TabIndex = 12;
			this.btResetSelectionPhones.Text = "Reiniciar Selección";
			this.btResetSelectionPhones.UseVisualStyleBackColor = true;
			this.btResetSelectionPhones.Click += new System.EventHandler(this.btResetSelectionPhones_Click);
			// 
			// lboxPhones
			// 
			this.lboxPhones.FormattingEnabled = true;
			this.lboxPhones.ItemHeight = 25;
			this.lboxPhones.Location = new System.Drawing.Point(27, 35);
			this.lboxPhones.Name = "lboxPhones";
			this.lboxPhones.Size = new System.Drawing.Size(437, 529);
			this.lboxPhones.TabIndex = 11;
			this.lboxPhones.SelectedIndexChanged += new System.EventHandler(this.lboxPhones_SelectedIndexChanged);
			// 
			// gbPhones
			// 
			this.gbPhones.Controls.Add(this.cbPhoneClients);
			this.gbPhones.Controls.Add(this.label4);
			this.gbPhones.Controls.Add(this.lbPhoneClientId);
			this.gbPhones.Controls.Add(this.lbPhoneClientIdLabel);
			this.gbPhones.Controls.Add(this.lbPhoneId);
			this.gbPhones.Controls.Add(this.lbPhoneIdLabel);
			this.gbPhones.Controls.Add(this.btPhoneDelete);
			this.gbPhones.Controls.Add(this.tbLocation);
			this.gbPhones.Controls.Add(this.lbPhoneNumber);
			this.gbPhones.Controls.Add(this.btPhoneCreateUpdate);
			this.gbPhones.Controls.Add(this.tbPhoneNumber);
			this.gbPhones.Controls.Add(this.lbLocation);
			this.gbPhones.Location = new System.Drawing.Point(551, 42);
			this.gbPhones.Name = "gbPhones";
			this.gbPhones.Size = new System.Drawing.Size(448, 522);
			this.gbPhones.TabIndex = 10;
			this.gbPhones.TabStop = false;
			this.gbPhones.Text = "Cliente";
			// 
			// cbPhoneClients
			// 
			this.cbPhoneClients.FormattingEnabled = true;
			this.cbPhoneClients.Location = new System.Drawing.Point(103, 125);
			this.cbPhoneClients.Name = "cbPhoneClients";
			this.cbPhoneClients.Size = new System.Drawing.Size(236, 33);
			this.cbPhoneClients.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 25);
			this.label4.TabIndex = 13;
			this.label4.Text = "Cliente";
			// 
			// lbPhoneClientId
			// 
			this.lbPhoneClientId.AutoSize = true;
			this.lbPhoneClientId.Location = new System.Drawing.Point(103, 81);
			this.lbPhoneClientId.Name = "lbPhoneClientId";
			this.lbPhoneClientId.Size = new System.Drawing.Size(44, 25);
			this.lbPhoneClientId.TabIndex = 12;
			this.lbPhoneClientId.Text = "N/A";
			// 
			// lbPhoneClientIdLabel
			// 
			this.lbPhoneClientIdLabel.AutoSize = true;
			this.lbPhoneClientIdLabel.Location = new System.Drawing.Point(10, 81);
			this.lbPhoneClientIdLabel.Name = "lbPhoneClientIdLabel";
			this.lbPhoneClientIdLabel.Size = new System.Drawing.Size(86, 25);
			this.lbPhoneClientIdLabel.TabIndex = 11;
			this.lbPhoneClientIdLabel.Text = "Id Cliente";
			// 
			// lbPhoneId
			// 
			this.lbPhoneId.AutoSize = true;
			this.lbPhoneId.Location = new System.Drawing.Point(103, 43);
			this.lbPhoneId.Name = "lbPhoneId";
			this.lbPhoneId.Size = new System.Drawing.Size(44, 25);
			this.lbPhoneId.TabIndex = 10;
			this.lbPhoneId.Text = "N/A";
			// 
			// lbPhoneIdLabel
			// 
			this.lbPhoneIdLabel.AutoSize = true;
			this.lbPhoneIdLabel.Location = new System.Drawing.Point(10, 43);
			this.lbPhoneIdLabel.Name = "lbPhoneIdLabel";
			this.lbPhoneIdLabel.Size = new System.Drawing.Size(28, 25);
			this.lbPhoneIdLabel.TabIndex = 9;
			this.lbPhoneIdLabel.Text = "Id";
			// 
			// btPhoneDelete
			// 
			this.btPhoneDelete.Location = new System.Drawing.Point(103, 382);
			this.btPhoneDelete.Name = "btPhoneDelete";
			this.btPhoneDelete.Size = new System.Drawing.Size(244, 34);
			this.btPhoneDelete.TabIndex = 3;
			this.btPhoneDelete.Text = "Eliminar";
			this.btPhoneDelete.UseVisualStyleBackColor = true;
			this.btPhoneDelete.Click += new System.EventHandler(this.btPhoneDelete_Click);
			// 
			// tbLocation
			// 
			this.tbLocation.Location = new System.Drawing.Point(103, 235);
			this.tbLocation.Name = "tbLocation";
			this.tbLocation.Size = new System.Drawing.Size(244, 31);
			this.tbLocation.TabIndex = 6;
			// 
			// lbPhoneNumber
			// 
			this.lbPhoneNumber.AutoSize = true;
			this.lbPhoneNumber.Location = new System.Drawing.Point(10, 183);
			this.lbPhoneNumber.Name = "lbPhoneNumber";
			this.lbPhoneNumber.Size = new System.Drawing.Size(79, 25);
			this.lbPhoneNumber.TabIndex = 8;
			this.lbPhoneNumber.Text = "Teléfono";
			// 
			// btPhoneCreateUpdate
			// 
			this.btPhoneCreateUpdate.Location = new System.Drawing.Point(103, 301);
			this.btPhoneCreateUpdate.Name = "btPhoneCreateUpdate";
			this.btPhoneCreateUpdate.Size = new System.Drawing.Size(244, 34);
			this.btPhoneCreateUpdate.TabIndex = 1;
			this.btPhoneCreateUpdate.Text = "Actualizar";
			this.btPhoneCreateUpdate.UseVisualStyleBackColor = true;
			this.btPhoneCreateUpdate.Click += new System.EventHandler(this.btPhoneCreateUpdate_Click);
			// 
			// tbPhoneNumber
			// 
			this.tbPhoneNumber.Location = new System.Drawing.Point(103, 177);
			this.tbPhoneNumber.Name = "tbPhoneNumber";
			this.tbPhoneNumber.Size = new System.Drawing.Size(244, 31);
			this.tbPhoneNumber.TabIndex = 7;
			// 
			// lbLocation
			// 
			this.lbLocation.AutoSize = true;
			this.lbLocation.Location = new System.Drawing.Point(6, 241);
			this.lbLocation.Name = "lbLocation";
			this.lbLocation.Size = new System.Drawing.Size(89, 25);
			this.lbLocation.TabIndex = 5;
			this.lbLocation.Text = "Ubicación";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1105, 766);
			this.Controls.Add(this.tcMain);
			this.Name = "Form1";
			this.Text = "Form1";
			this.gbAddClient.ResumeLayout(false);
			this.gbAddClient.PerformLayout();
			this.tcMain.ResumeLayout(false);
			this.tpClient.ResumeLayout(false);
			this.tpPhone.ResumeLayout(false);
			this.gbPhones.ResumeLayout(false);
			this.gbPhones.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lboxClient;
		private System.Windows.Forms.Button btAddClient;
		private System.Windows.Forms.Button btRemoveClient;
		private System.Windows.Forms.Label lbLastName;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.TextBox tbFirstName;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.GroupBox gbAddClient;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpClient;
		private System.Windows.Forms.TabPage tpPhone;
		private System.Windows.Forms.ListBox lboxPhones;
		private System.Windows.Forms.GroupBox gbPhones;
		private System.Windows.Forms.Button btPhoneDelete;
		private System.Windows.Forms.TextBox tbLocation;
		private System.Windows.Forms.Label lbPhoneNumber;
		private System.Windows.Forms.Button btPhoneCreateUpdate;
		private System.Windows.Forms.TextBox tbPhoneNumber;
		private System.Windows.Forms.Label lbLocation;
		private System.Windows.Forms.Label lbPhoneIdLabel;
		private System.Windows.Forms.Label lbPhoneId;
		private System.Windows.Forms.Label lbPhoneClientIdLabel;
		private System.Windows.Forms.Label lbPhoneClientId;
		private System.Windows.Forms.Label lbClientId;
		private System.Windows.Forms.Label lbClientIdLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbPhoneClients;
		private System.Windows.Forms.Button btResetSelectedClient;
		private System.Windows.Forms.Button btResetSelectionPhones;
	}
}

