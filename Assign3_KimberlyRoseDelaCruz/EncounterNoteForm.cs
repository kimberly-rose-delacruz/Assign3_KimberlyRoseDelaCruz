﻿/*Program ID: Assign3_KimberlyRoseDelaCruz.cs
 * 
 * Purpose: To program an assignment about File i/o, OOP concepts and Collections
 * 
 * Revision History:
 *          Debugging and Fixing bugs on March 5, 2022 by Kim
 *          Testing on March 4, 2022 by Kim
 *          Created on March 3, 2022 by Kimberly Dela Cruz
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign3_KimberlyRoseDelaCruz
{
    public partial class EncounterNoteForm : Form
    {
        public EncounterNoteForm()
        {
            InitializeComponent();
        }

        //private properties
        private int noteId = 0;
        private string name = "";
        private DateTime dateOfBirth = DateTime.Now;
        private List<string> listOfNewProblems = new List<string>();
        private List<string> listOfNotes = new List<string>();
        private bool resultOfListOfNotes = false;
        private string richTextNote = "";
        string joinNotes = "";
        ValidationHelper newValidation = new ValidationHelper();

        private void EncounterNoteForm_Load(object sender, EventArgs e)
        {
            NoteManager newNote = new NoteManager();

            dateOfBirthPicker.CustomFormat = "dd MMM yyyy";
            dateOfBirthPicker.Value = DateTime.Now;

            List<EncounterNote> data = newNote.GetAllDataFromFile();
            foreach (var note in data)
            {
                listOfPatientsNotes.Items.Add(note);
            }

            txtBoxNoteId.Enabled = false;
            txtBoxPatientName.Enabled = false;
            txtBoxNewProblem.Enabled = false;
            btnAddNewProblem.Enabled = false;
            richTextBoxNotes.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;
            dateOfBirthPicker.Enabled = false;
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";

        }

        private void listOfPatientsNotes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBoxNewProblems.Items.Clear();
            listBoxBPMeasurements.Items.Clear();

            //condition where if the selectedItem is null skip the logic
            if (listOfPatientsNotes.SelectedItem == null)
            {
                return;

            }

            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
            string errorMsg = "";

            if (listOfPatientsNotes.SelectedIndex == -1)
            {
                errorMsg += "Please select list of notes in the listbox.";
            }
            else
            {
                EncounterNote patientRecords = (EncounterNote)listOfPatientsNotes.SelectedItem;
                txtBoxNoteId.Text = patientRecords.NoteId.ToString();
                txtBoxPatientName.Text = patientRecords.PatientName.ToString();
                dateOfBirthPicker.Value = patientRecords.DateOfBirth;
                string[] notes = patientRecords.ListOfNotes.ToArray();
                string[] problems = patientRecords.ListOfNewProblems.ToArray();

                //print all the values in the problems richtextbox
                listBoxNewProblems.Items.AddRange(problems);

                //print all the values in the notes richtextbox
                joinNotes = String.Join("\n", notes);
                richTextBoxNotes.Text = joinNotes;

                //change state to modify state of encounter note fields
                ModifyStateMode(sender, e);
            }

            lblErrorMsg.Text = errorMsg;
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
            listOfNotes.Clear();
            listOfNewProblems.Clear();
            string errorMsg = "";
            string successMsg = "";
            //declare variables for update of fields
            string updateName = "";
            DateTime updateDateOfBirth = DateTime.Now;
            string updateRichTextNote = "";
            EncounterNote updatePatientNotes = (EncounterNote)listOfPatientsNotes.SelectedItem;

            //validate updated name in the textbox if correct or not
            updateName = txtBoxPatientName.Text;

            bool resultOfName = newValidation.IsNameValid(updateName);
            if (updateName == string.Empty)
            {
                errorMsg += "Patient Name is required.\n";
            }
            else if (resultOfName == false)
            {
                errorMsg += "Patient Name is invalid. Format of Name should be First Name + Last Name.\n";
            }

            //validate updated date of birth 

            updateDateOfBirth = dateOfBirthPicker.Value;
            updateDateOfBirth.ToString("dd MMM yyyy");

            bool resultOfDateOfBirth = newValidation.IsDateOfBirthValid(updateDateOfBirth);

            if (resultOfDateOfBirth == false)
            {
                errorMsg += "Patient Date Of Birth is invalid.\n";

            }

            //validate if updated listOfNotes have been added as an update on note
            updateRichTextNote = richTextBoxNotes.Text;

            if (updateRichTextNote == string.Empty)
            {
                resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
            }
            else
            {
                string[] updatedNotes = updateRichTextNote.Split('\n');
                listOfNotes.AddRange(updatedNotes);
                resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
            }

            if (resultOfListOfNotes == false)
            {
                errorMsg += "Note is required.";
            }

            //prepare list of problems if there is added new problem
            string[] updatedProblems = listBoxNewProblems.Items.Cast<string>().ToArray();
            listOfNewProblems.AddRange(updatedProblems);

            if (resultOfName == true &&
                resultOfDateOfBirth == true &&
                resultOfListOfNotes == true)
            {
                //add the noteId from the textbox stored from create mode state
                updatePatientNotes.NoteId = int.Parse(txtBoxNoteId.Text);
                updatePatientNotes.PatientName = updateName;
                updatePatientNotes.DateOfBirth = updateDateOfBirth;

                if (listOfNewProblems != null)
                {
                    updatePatientNotes.ListOfNewProblems = listOfNewProblems;
                }

                if (listOfNotes != null)
                {
                    updatePatientNotes.ListOfNotes = listOfNotes;
                }

                NoteManager updateNote = new NoteManager();
                var patientsNotes = listOfPatientsNotes.Items.Cast<EncounterNote>();

                string joinedPatientsNotes = String.Join("\n", patientsNotes.Select(x => x.FormatEncounterNoteToDataRow()));

                //write all text to the file with the updated note.
                updateNote.WriteAllDataToTextFile(joinedPatientsNotes);

                listOfPatientsNotes.Items.Clear();

                EncounterNoteForm_Load(sender, e);

                successMsg = "Note has been updated successfully.";
            }

            BrowseStateMode(sender, e);

            lblErrorMsg.Text = errorMsg;
            lblSuccessMsg.Text = successMsg;
        }

        private void richTextBoxNotes_TextChanged(object sender, EventArgs e)
        {
            //create a identification of blood pressure extraction where it starts with BP from notes
            //where it should follow with 2-3 digits systolic over (/) 2-3 digits
            richTextNote = richTextBoxNotes.Text;
            listOfNotes.Clear();
            listBoxBPMeasurements.Items.Clear();

            //included 
            try
            {
                if (richTextNote != string.Empty)
                {
                    string[] notes = richTextNote.Split('\n');
                    notes = notes.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    listOfNotes.AddRange(notes);

                    foreach (var note in listOfNotes)
                    {
                        string noteLowerCase = note.ToLower();
                        if (noteLowerCase.Contains("bp"))
                        {
                            if (noteLowerCase.Contains(" "))
                            {
                                string[] bloodPressureString = noteLowerCase.Split(' ');
                                string bloodPressureText = bloodPressureString[0];
                                string bloodPressureValue = bloodPressureString[1];

                                string[] bpValues = bloodPressureValue.Split('/');

                                int systolicValue = int.Parse(bpValues[0]);
                                int diastolicValue = int.Parse(bpValues[1]);

                                if (bloodPressureText.Contains("bp") &&
                                    bloodPressureString[1].Contains('/') &&
                                    (bpValues[0].Length >= 2 || bpValues[0].Length <= 3) &&
                                    (bpValues[1].Length >= 2 || bpValues[1].Length <= 3) &&
                                    systolicValue >= 10 && diastolicValue >= 10)
                                {
                                    listBoxBPMeasurements.Items.Add(note);
                                }
                            }

                        }
                    }

                    resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
                }
                else
                {
                    listBoxBPMeasurements.Items.Clear();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong", ex.Message);
            }

        }

        private void ModifyStateMode(object sender, EventArgs e)
        {
            txtBoxNoteId.Enabled = false;
            txtBoxPatientName.Enabled = true;
            dateOfBirthPicker.Enabled = true;
            txtBoxNewProblem.Enabled = true;
            btnAddNewProblem.Enabled = true;
            richTextBoxNotes.Enabled = true;

            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = true;
            btnDeleteNote.Enabled = true;
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
        }

        private void CreateStateMode(object sender, EventArgs e)
        {
            var patientsNotes = listOfPatientsNotes.Items.Cast<EncounterNote>();
            int noteIdNumber = patientsNotes.Select(x => x.NoteId).Max();
            int uniqueNoteId = noteIdNumber + 1; //increment the noteId by 1 according to the updated list of notes.

            txtBoxNoteId.Text = uniqueNoteId.ToString();
            txtBoxPatientName.Text = "";
            dateOfBirthPicker.Value = DateTime.Now;
            dateOfBirthPicker.CustomFormat = "dd MMM yyyy";

            txtBoxNewProblem.Text = "";
            listBoxNewProblems.Items.Clear();
            listBoxBPMeasurements.Items.Clear();
            richTextBoxNotes.Text = "";

            txtBoxNoteId.Enabled = false;
            txtBoxPatientName.Enabled = true;
            dateOfBirthPicker.Enabled = true;

            txtBoxNewProblem.Enabled = true;
            btnAddNewProblem.Enabled = true;
            richTextBoxNotes.Enabled = true;

            btnAddNote.Enabled = true;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;

        }

        private void BrowseStateMode(object sender, EventArgs e)
        {
            txtBoxNoteId.Text = "";
            txtBoxPatientName.Text = "";
            dateOfBirthPicker.Value = DateTime.Now;
            dateOfBirthPicker.CustomFormat = "dd MMM yyyy";


            txtBoxNewProblem.Text = "";
            listBoxNewProblems.Items.Clear();
            listBoxBPMeasurements.Items.Clear();
            richTextBoxNotes.Text = "";

            txtBoxNoteId.Enabled = false;
            txtBoxPatientName.Enabled = false;
            txtBoxNewProblem.Enabled = false;
            btnAddNewProblem.Enabled = false;
            richTextBoxNotes.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;
            dateOfBirthPicker.Enabled = false;
        }

        private void btnStartNewNote_Click(object sender, EventArgs e)
        {
            //call this method to change the state of the encounter note form
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
            CreateStateMode(sender, e);
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            string successMsg = "";
            List<string> newListOfNotes = new List<string>();

            listOfNotes.Clear();
            listOfNewProblems.Clear();
            lblErrorMsg.Text = errorMsg;
            lblSuccessMsg.Text = successMsg;

            EncounterNote newPatientNote = new EncounterNote(noteId, name, dateOfBirth, listOfNewProblems, listOfNotes);

            //validate name field
            name = txtBoxPatientName.Text;
            bool resultOfName = newValidation.IsNameValid(name);
            if (name == string.Empty)
            {
                errorMsg += "Patient Name is required.\n";
            }
            else if (resultOfName == false)
            {
                errorMsg += "Patient Name is invalid. Format of Name should be First Name + Last Name.\n";
            }

            //validate date field

            dateOfBirth = dateOfBirthPicker.Value;
            dateOfBirth.ToString("dd MMM yyyy");

            bool resultOfDateOfBirth = newValidation.IsDateOfBirthValid(dateOfBirth);

            if (resultOfDateOfBirth == false)
            {
                errorMsg += "Patient Date Of Birth is invalid.\n";

            }

            //validate if listOfNotes have been added as new note
            richTextNote = richTextBoxNotes.Text;

            if (richTextNote == string.Empty)
            {
                errorMsg += "Note is required.";
            }
            else
            {
                string[] notes = richTextNote.Split('\n');
                newListOfNotes.AddRange(notes);
                resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
                if (resultOfListOfNotes == false)
                {
                    errorMsg += "Note is invalid.";
                }
            }


            string[] problems = listBoxNewProblems.Items.Cast<string>().ToArray();
            listOfNewProblems.AddRange(problems);

            if (resultOfName == true &&
                resultOfDateOfBirth == true &&
                resultOfListOfNotes == true)
            {
                //add the noteId from the textbox stored from create mode state
                newPatientNote.NoteId = int.Parse(txtBoxNoteId.Text);
                newPatientNote.PatientName = name;
                newPatientNote.DateOfBirth = dateOfBirth;

                if (listOfNewProblems != null)
                {
                    newPatientNote.ListOfNewProblems = listOfNewProblems;
                }

                if (newListOfNotes != null)
                {
                    newPatientNote.ListOfNotes = newListOfNotes;
                }

                string fullText = newPatientNote.FormatEncounterNoteToDataRow();

                //add the new record in the listOfPatientsNotes listbox then get all listOfPatientsNotes to be written in the text file       
                listOfPatientsNotes.Items.Add(newPatientNote);

                NoteManager updateNote = new NoteManager();
                updateNote.UpdateDataToTextFile(fullText);

                successMsg = "Note has been added successfully.";

                BrowseStateMode(sender, e);

            }


            lblErrorMsg.Text = errorMsg;
            lblSuccessMsg.Text = successMsg;
        }

        private void btnAddNewProblem_Click(object sender, EventArgs e)
        {
            //if there is new problem add in the richtextproblems
            string newProblemText = txtBoxNewProblem.Text;

            listBoxNewProblems.Items.Add(newProblemText);
            txtBoxNewProblem.Text = "";
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            //Clear the data and form labels
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
            listOfNotes.Clear();
            listOfNewProblems.Clear();
            string successMsg = "";

            //get all the data from the listOfPatientsNotes to get the selectem item for deletion

            listOfPatientsNotes.Items.Remove(listOfPatientsNotes.SelectedItem);

            NoteManager deleteNote = new NoteManager();

            var patientsNotes = listOfPatientsNotes.Items.Cast<EncounterNote>();

            string joinedPatientsNotes = String.Join("\n", patientsNotes.Select(x => x.FormatEncounterNoteToDataRow()));

            //write all text to the file with the updated note.
            deleteNote.WriteAllDataToTextFile(joinedPatientsNotes);

            listOfPatientsNotes.Items.Clear();

            EncounterNoteForm_Load(sender, e);
            successMsg = "Note has been deleted successfully.";

            BrowseStateMode(sender, e);

            lblSuccessMsg.Text = successMsg;
        }
    }
}
