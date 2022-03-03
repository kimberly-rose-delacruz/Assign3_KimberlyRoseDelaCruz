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
        private int countOfNotes = 0;
        private int noteId = 0;
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

        ValidationHelper newValidation = new ValidationHelper();

        private void EncounterNoteForm_Load(object sender, EventArgs e)
        {
            dateOfBirthPicker.CustomFormat = "dd MMM yyyy";

            List<EncounterNote> data = GetAllDataFromFile();
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

        public List<EncounterNote> GetAllDataFromFile()
        {
            string filePath = @"C:\PROG1815 - Programming 2\Assignment\Assignment3_KimberlyRoseDelaCruz\Assign3_KimberlyRoseDelaCruz\Assign3_KimberlyRoseDelaCruz\EncounterNotes\encounter-note.txt";

            List<string> lines = File.ReadLines(filePath).ToList();

            List<EncounterNote> encounterNotes = new List<EncounterNote>();

            foreach (string line in lines)
            {
                encounterNotes.Add(new EncounterNote(line));
                countOfNotes++;
            }

            return encounterNotes;
        }

        private void listOfPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string previousNoteId = txtBoxNoteId.Text;

            EncounterNote patientRecords = (EncounterNote)listOfPatients.SelectedItem;
            txtBoxNoteId.Text = patientRecords.NoteId.ToString();
            txtBoxPatientName.Text = patientRecords.PatientName.ToString();
            dateOfBirthPicker.Value = patientRecords.DateOfBirth;
            string[] notes = patientRecords.ListOfNotes.ToArray();
            string[] problems = patientRecords.NewProblem.Split(';');

            //clear the all richtextboxes first with the previous values
            richTextProblems.Clear();
            richTextBoxBPMeasurement.Clear();
            richTextBoxNotes.Clear();

            //print all the values in the problems richtextbox
            foreach(var problem in problems)
            {
                richTextProblems.Text += $"{problem.ToString()}\n";
            }

            //print all the values in the notes richtextbox
            foreach (var note in notes)
            {
                var stringText += $"{note.ToString()}\n";

                if (note.Contains("BP"))
                {
                    richTextBoxBPMeasurement.Text = $"{note}\n";
                }
            }

            //change state to modify state of encounter note fields
            ModifyStateMode(sender, e);
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
            listOfNotes.Clear();
            richTextNote = richTextBoxNotes.Text;

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

                                if (bloodPressureText == "bp" &&
                                    bloodPressureString[1].Contains('/') &&
                                    (bpValues[0].Length >= 2 || bpValues[0].Length <= 3) &&
                                    (bpValues[1].Length >= 2 || bpValues[1].Length <= 3) &&
                                    systolicValue > 0 && diastolicValue > 0)
                                {
                                    richTextBoxBPMeasurement.Text += $"{note}\n";
                                }
                            }

                        }
                    }

                    resultOfListOfNotes = newValidation.IsListOfNotesValid(listOfNotes);
                }
                else
                {
                    richTextBoxBPMeasurement.Clear();
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
            richTextProblems.Clear();
            richTextBoxBPMeasurement.Clear();
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
            richTextProblems.Clear();
            richTextBoxBPMeasurement.Clear();
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
            EncounterNote newPatientNote = new EncounterNote(noteId, name, dateOfBirth, listOfNewProblems, listOfNewProblems);

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

            string[] listOfProblems = richTextProblems.Text.Split('\n');
            listOfProblems = listOfProblems.Where(x =>!string.IsNullOrEmpty(x)).ToArray();

            listOfNewProblems.AddRange(listOfProblems);
            
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
                    newPatientNote.ListOfNewProblems.AddRange(listOfNewProblems);
                }

                if(listOfNotes != null)
                {
                    newPatientNote.ListOfNotes.AddRange(listOfNotes);
                }

            }

            lblErrorMsg.Text = errorMsg;
            lblSuccessMsg.Text = successMsg;
        }

        private void btnAddNewProblem_Click(object sender, EventArgs e)
        {
            //if there is new problem add in the richtextproblems
            string newProblemText = txtBoxNewProblem.Text;

            richTextProblems.Text += $"{newProblemText}\n";
            txtBoxNewProblem.Text = "";        
        }
    }
}
