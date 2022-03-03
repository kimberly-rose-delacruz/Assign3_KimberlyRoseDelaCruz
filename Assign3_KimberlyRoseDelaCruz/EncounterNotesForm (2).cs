namespace Assign3_KimberlyRoseDelaCruz
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartNewNote = new System.Windows.Forms.Button();
            this.listOfPatients = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteNote = new System.Windows.Forms.Button();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lblBPMeasurement = new System.Windows.Forms.Label();
            this.lblProblems = new System.Windows.Forms.Label();
            this.listBoxBPMeasurement = new System.Windows.Forms.ListBox();
            this.listBoxProblems = new System.Windows.Forms.ListBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.btnAddNewProblem = new System.Windows.Forms.Button();
            this.txtBoxNewProblem = new System.Windows.Forms.TextBox();
            this.lblNewProblem = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtBoxPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtBoxNoteId = new System.Windows.Forms.TextBox();
            this.lblNoteID = new System.Windows.Forms.Label();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.lblSuccessMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartNewNote
            // 
            this.btnStartNewNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnStartNewNote.Location = new System.Drawing.Point(24, 12);
            this.btnStartNewNote.Name = "btnStartNewNote";
            this.btnStartNewNote.Size = new System.Drawing.Size(134, 35);
            this.btnStartNewNote.TabIndex = 0;
            this.btnStartNewNote.Text = "Start New Note";
            this.btnStartNewNote.UseVisualStyleBackColor = true;
            // 
            // listOfPatients
            // 
            this.listOfPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.listOfPatients.FormattingEnabled = true;
            this.listOfPatients.ItemHeight = 18;
            this.listOfPatients.Location = new System.Drawing.Point(24, 53);
            this.listOfPatients.Name = "listOfPatients";
            this.listOfPatients.Size = new System.Drawing.Size(233, 616);
            this.listOfPatients.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteNote);
            this.groupBox1.Controls.Add(this.btnUpdateNote);
            this.groupBox1.Controls.Add(this.btnAddNote);
            this.groupBox1.Controls.Add(this.lblBPMeasurement);
            this.groupBox1.Controls.Add(this.lblProblems);
            this.groupBox1.Controls.Add(this.listBoxBPMeasurement);
            this.groupBox1.Controls.Add(this.listBoxProblems);
            this.groupBox1.Controls.Add(this.lblNotes);
            this.groupBox1.Controls.Add(this.listBoxNotes);
            this.groupBox1.Controls.Add(this.btnAddNewProblem);
            this.groupBox1.Controls.Add(this.txtBoxNewProblem);
            this.groupBox1.Controls.Add(this.lblNewProblem);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblDateOfBirth);
            this.groupBox1.Controls.Add(this.txtBoxPatientName);
            this.groupBox1.Controls.Add(this.lblPatientName);
            this.groupBox1.Controls.Add(this.txtBoxNoteId);
            this.groupBox1.Controls.Add(this.lblNoteID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox1.Location = new System.Drawing.Point(275, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 644);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit/Delete Encounter Note";
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.Location = new System.Drawing.Point(308, 596);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(116, 33);
            this.btnDeleteNote.TabIndex = 16;
            this.btnDeleteNote.Text = "Delete Note";
            this.btnDeleteNote.UseVisualStyleBackColor = true;
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Location = new System.Drawing.Point(175, 596);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(116, 33);
            this.btnUpdateNote.TabIndex = 15;
            this.btnUpdateNote.Text = "Update Note";
            this.btnUpdateNote.UseVisualStyleBackColor = true;
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(38, 596);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(116, 33);
            this.btnAddNote.TabIndex = 14;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            // 
            // lblBPMeasurement
            // 
            this.lblBPMeasurement.AutoSize = true;
            this.lblBPMeasurement.Location = new System.Drawing.Point(734, 18);
            this.lblBPMeasurement.Name = "lblBPMeasurement";
            this.lblBPMeasurement.Size = new System.Drawing.Size(123, 18);
            this.lblBPMeasurement.TabIndex = 13;
            this.lblBPMeasurement.Text = "BP Measurement";
            // 
            // lblProblems
            // 
            this.lblProblems.AutoSize = true;
            this.lblProblems.Location = new System.Drawing.Point(554, 18);
            this.lblProblems.Name = "lblProblems";
            this.lblProblems.Size = new System.Drawing.Size(76, 18);
            this.lblProblems.TabIndex = 12;
            this.lblProblems.Text = "Problems:";
            // 
            // listBoxBPMeasurement
            // 
            this.listBoxBPMeasurement.FormattingEnabled = true;
            this.listBoxBPMeasurement.ItemHeight = 18;
            this.listBoxBPMeasurement.Location = new System.Drawing.Point(737, 39);
            this.listBoxBPMeasurement.Name = "listBoxBPMeasurement";
            this.listBoxBPMeasurement.Size = new System.Drawing.Size(153, 166);
            this.listBoxBPMeasurement.TabIndex = 11;
            // 
            // listBoxProblems
            // 
            this.listBoxProblems.FormattingEnabled = true;
            this.listBoxProblems.ItemHeight = 18;
            this.listBoxProblems.Location = new System.Drawing.Point(557, 39);
            this.listBoxProblems.Name = "listBoxProblems";
            this.listBoxProblems.Size = new System.Drawing.Size(153, 166);
            this.listBoxProblems.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(35, 231);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(52, 18);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = "Notes:";
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.ItemHeight = 18;
            this.listBoxNotes.Location = new System.Drawing.Point(38, 262);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(852, 328);
            this.listBoxNotes.TabIndex = 8;
            // 
            // btnAddNewProblem
            // 
            this.btnAddNewProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnAddNewProblem.Location = new System.Drawing.Point(439, 178);
            this.btnAddNewProblem.Name = "btnAddNewProblem";
            this.btnAddNewProblem.Size = new System.Drawing.Size(62, 31);
            this.btnAddNewProblem.TabIndex = 3;
            this.btnAddNewProblem.Text = "Add";
            this.btnAddNewProblem.UseVisualStyleBackColor = true;
            // 
            // txtBoxNewProblem
            // 
            this.txtBoxNewProblem.Location = new System.Drawing.Point(161, 181);
            this.txtBoxNewProblem.Name = "txtBoxNewProblem";
            this.txtBoxNewProblem.Size = new System.Drawing.Size(235, 24);
            this.txtBoxNewProblem.TabIndex = 7;
            // 
            // lblNewProblem
            // 
            this.lblNewProblem.AutoSize = true;
            this.lblNewProblem.Location = new System.Drawing.Point(35, 184);
            this.lblNewProblem.Name = "lblNewProblem";
            this.lblNewProblem.Size = new System.Drawing.Size(102, 18);
            this.lblNewProblem.TabIndex = 6;
            this.lblNewProblem.Text = "New Problem:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 136);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(340, 24);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(35, 139);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(97, 18);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Date Of Birth:";
            // 
            // txtBoxPatientName
            // 
            this.txtBoxPatientName.Location = new System.Drawing.Point(161, 81);
            this.txtBoxPatientName.Name = "txtBoxPatientName";
            this.txtBoxPatientName.Size = new System.Drawing.Size(340, 24);
            this.txtBoxPatientName.TabIndex = 3;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(35, 84);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(101, 18);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Patient Name:";
            // 
            // txtBoxNoteId
            // 
            this.txtBoxNoteId.Location = new System.Drawing.Point(161, 39);
            this.txtBoxNoteId.Name = "txtBoxNoteId";
            this.txtBoxNoteId.Size = new System.Drawing.Size(100, 24);
            this.txtBoxNoteId.TabIndex = 1;
            // 
            // lblNoteID
            // 
            this.lblNoteID.AutoSize = true;
            this.lblNoteID.Location = new System.Drawing.Point(35, 42);
            this.lblNoteID.Name = "lblNoteID";
            this.lblNoteID.Size = new System.Drawing.Size(58, 18);
            this.lblNoteID.TabIndex = 0;
            this.lblNoteID.Text = "NoteID:";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Crimson;
            this.lblErrorMsg.Location = new System.Drawing.Point(21, 683);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(20, 18);
            this.lblErrorMsg.TabIndex = 3;
            this.lblErrorMsg.Text = "...";
            // 
            // lblSuccessMsg
            // 
            this.lblSuccessMsg.AutoSize = true;
            this.lblSuccessMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSuccessMsg.ForeColor = System.Drawing.Color.Green;
            this.lblSuccessMsg.Location = new System.Drawing.Point(21, 720);
            this.lblSuccessMsg.Name = "lblSuccessMsg";
            this.lblSuccessMsg.Size = new System.Drawing.Size(20, 18);
            this.lblSuccessMsg.TabIndex = 4;
            this.lblSuccessMsg.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 759);
            this.Controls.Add(this.lblSuccessMsg);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listOfPatients);
            this.Controls.Add(this.btnStartNewNote);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartNewNote;
        private System.Windows.Forms.ListBox listOfPatients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxNoteId;
        private System.Windows.Forms.Label lblNoteID;
        private System.Windows.Forms.TextBox txtBoxPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtBoxNewProblem;
        private System.Windows.Forms.Label lblNewProblem;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button btnAddNewProblem;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.Label lblSuccessMsg;
        private System.Windows.Forms.ListBox listBoxProblems;
        private System.Windows.Forms.ListBox listBoxBPMeasurement;
        private System.Windows.Forms.Label lblProblems;
        private System.Windows.Forms.Label lblBPMeasurement;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Button btnUpdateNote;
        private System.Windows.Forms.Button btnDeleteNote;
    }
}

