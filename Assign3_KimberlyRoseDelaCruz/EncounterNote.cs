﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assign3_KimberlyRoseDelaCruz
{
    public class EncounterNote
    {
        public int NoteId { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NewProblem { get; set; }
        public List<string> ListOfNewProblems = new List<string>();
        public List<string> ListOfNotes = new List<string>(); 
        public string BPMeasurement { get; set; }

        //Load all existing patients from the text file
        public EncounterNote(string line)
        {
            string[] arrayOfNotes = line.Split('|');

            this.NoteId = int.Parse(arrayOfNotes[0]);
            this.PatientName = arrayOfNotes[1];
            this.DateOfBirth = DateTime.Parse(arrayOfNotes[2]);
            string[] listProblems = arrayOfNotes[3].Split(';');
            ListOfNewProblems.AddRange(listProblems);
            string[] listNotes = arrayOfNotes[4].Split(';');
            ListOfNotes.AddRange(listNotes);
        }


        public EncounterNote(int noteId, string patientName, DateTime dateOfBirth, List<string> listOfNewProblems, List<string> listOfNotes)
        {
            this.NoteId = noteId;
            this.PatientName= patientName;
            this.DateOfBirth= dateOfBirth;
            this.ListOfNewProblems = listOfNewProblems;
            this.ListOfNotes = listOfNotes;
        }


        public string FormatEncounterNoteToDataRow()
        {
            string newProblemsFormatted = string.Join(";", this.ListOfNewProblems);
            string notesFormatter = string.Join(";", this.ListOfNotes);


            string fullText = $"{this.NoteId}|{this.PatientName}|{this.DateOfBirth.ToString("dd MMM yyyy")}|{newProblemsFormatted}|{notesFormatter}";

            return fullText;
        }

        public override string ToString()
        {
            return $"{this.PatientName} (Note:{this.NoteId})";
        }

    }
}
