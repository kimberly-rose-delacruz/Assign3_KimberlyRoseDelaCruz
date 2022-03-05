using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assign3_KimberlyRoseDelaCruz
{
    public class NoteManager
    {
        private string filePath = @"C:\PROG1815 - Programming 2\Assignment\Assignment3_KimberlyRoseDelaCruz\Assign3_KimberlyRoseDelaCruz\Assign3_KimberlyRoseDelaCruz\EncounterNotes\encounter-note.txt";
         

        //Reading all data from text file to be stored into the EncounterNote Class
        public List<EncounterNote> GetAllDataFromFile()
        {
            List<string> lines = File.ReadLines(filePath).ToList();

            List<EncounterNote> encounterNotes = new List<EncounterNote>();

            foreach (string line in lines)
            {
                encounterNotes.Add(new EncounterNote(line));
            }

            return encounterNotes;
        }

        public void UpdateDataToTextFile(string fullText)
        {
            //appendtext in the text file
            
            File.AppendAllText(filePath, $"\n{fullText}");
        }

        public void WriteAllDataToTextFile(string fullText)
        {
            //write all text in the text file
            File.WriteAllText(filePath, fullText);
        }
    }
}
