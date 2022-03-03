/*
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
        private int countOfNotes = 0;
        private string name = "";
        private DateTime dateOfBirth = DateTime.Now;
        private string newProblem = "";
        private List<string> listOfNewProblems = new List<string>();
        private List<string> listOfNotes  = new List<string>();
        private string bpMeasurement = "";
        private string errorMsg = "";
        private  string successMsg = "";
        private bool resultOfListOfNotes = false;
        private string richTextNote = "";
        string joinNotes = "";
        ValidationHelper newValidation = new ValidationHelper();

        private void EncounterNoteForm_Load(object sender, EventArgs e)
        {
            NoteManager newNote = new NoteManager();

            dateOfBirthPicker.CustomFormat = "dd MMM yyyy";
            List<EncounterNote> data = newNote.GetAllDataFromFile(out countOfNotes);
            foreach (var note in data)
            {
                listOfPatients.Items.Add(note);
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

        private void listOfPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errorMsg = "";
            if(listOfPatients.SelectedIndex == -1)
            {
                errorMsg += "Please select list of notes in the listbox.";
            }
            else
            {
                string previousNoteId = txtBoxNoteId.Text;

                EncounterNote patientRecords = (EncounterNote)listOfPatients.SelectedItem;
                txtBoxNoteId.Text = patientRecords.NoteId.ToString();
                txtBoxPatientName.Text = patientRecords.PatientName.ToString();
                dateOfBirthPicker.Value = patientRecords.DateOfBirth;
                string[] notes = patientRecords.ListOfNotes.ToArray();
                string[] problems = patientRecords.NewProblem.Split(';');

                //clear the all richtextboxes first with the previous values
                listBoxNewProblems.Items.Clear();
                listBoxBPMeasurements.Items.Clear();
                richTextBoxNotes.Clear();

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
            EncounterNote patientRecords = (EncounterNote)listOfPatients.SelectedItem;

            patientRecords.PatientName = txtBoxPatientName.Text;
            //to do for updating the values of fields for selected note
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
                                    systolicValue > 0 && diastolicValue > 0)
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

            }catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong",ex.Message);
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
            int countOfSuccedingNote = countOfNotes + 1; //increment the noteId by 1 according to the updated list of notes.
            txtBoxNoteId.Text = countOfSuccedingNote.ToString();
            txtBoxPatientName.Text = "";
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
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
        }

        private void BrowseStateMode(object sender, EventArgs e)
        {
            txtBoxNoteId.Text = "";
            txtBoxPatientName.Text = "";
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
            lblErrorMsg.Text = "";
            lblSuccessMsg.Text = "";
        }

        private void btnStartNewNote_Click(object sender, EventArgs e)
        {
            //call this method to change the state of the encounter note form
            CreateStateMode(sender, e);
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            listOfNotes.Clear();
            listOfNewProblems.Clear();

            EncounterNote newPatientNote = new EncounterNote(noteId, name, dateOfBirth, listOfNewProblems, listOfNotes);

            //validate name field
            name = txtBoxPatientName.Text;


            bool resultOfName = newValidation.IsNameValid(name);
            if (name == string.Empty)
            {
                errorMsg += "Patient Name is required.\n";
            }
            else if(resultOfName == false)
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
                resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
            }
            else
            {
                string[] notes = richTextNote.Split('\n');
                listOfNotes.AddRange(notes);
                resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
            }

            if (resultOfListOfNotes == false)
            {
                errorMsg += "Note is required.";
            }

            string[] problems = listBoxNewProblems.Items.Cast<string>().ToArray();
            listOfNewProblems.AddRange(problems);

            if(resultOfName == true &&
                resultOfDateOfBirth == true &&
                resultOfListOfNotes == true)
            {
                //add the noteId from the textbox stored from create mode state
                newPatientNote.NoteId = int.Parse(txtBoxNoteId.Text);
                newPatientNote.PatientName = name;
                newPatientNote.DateOfBirth = dateOfBirth;

                if(listOfNewProblems != null)
                {
                    newPatientNote.ListOfNewProblems = listOfNewProblems;
                }

                if(listOfNotes != null)
                {
                    newPatientNote.ListOfNotes = listOfNotes;
                }

                string fullText = newPatientNote.FormatEncounterNoteToDataRow();

                //add the new record in the listOfPatients listbox then get all listOfPatients to be written in the text file       
                listOfPatients.Items.Add(newPatientNote);

                NoteManager updateNote = new NoteManager();
                updateNote.UpdateDataToTextFile(fullText);
                
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
    }
}
