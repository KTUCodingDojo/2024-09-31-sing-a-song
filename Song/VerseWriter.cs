using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song
{
    public class VerseWriter
    {
        private List<string> _lines;
        private string _lastAnimalName;
        public VerseWriter() 
        {
            _lines = new List<string>();
            _lastAnimalName = string.Empty;
        }
        public string WriteVerse(string animalName, string animalUniqueLine)
        {
            if(_lines.Count == 0)
            {
                _lines.Add($"There was an old lady who swallowed a {animalName}.");
                _lines.Add($"I don't know why she swallowed a {animalName} - perhaps she'll die!");
                _lastAnimalName = animalName;
                return VerseToString();
            }

            _lines[0] = $"There was an old lady who swallowed a {animalName};";

            if (_lines.Count == 2) 
            {
                _lines.Insert(1, animalUniqueLine);
            }
            else
            {
                _lines[1] = animalUniqueLine;
            }

            _lines.Insert(2, $"She swallowed the {animalName} to catch the {_lastAnimalName}");

            _lastAnimalName = animalName;
            return VerseToString();
        }

        private string VerseToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(_lines[0]);
            
            if(_lines.Count > 2)
            {
                sb.AppendLine(_lines[1]);

                for (int i = 2; i < _lines.Count - 2; i++)
                {
                    sb.AppendLine(_lines[i] + ",");
                }

                sb.AppendLine(_lines[_lines.Count - 2] + ";");
            }

            sb.Append(_lines[_lines.Count - 1]);

            return sb.ToString();
        }

        public string FinalVerse(string animalName)
        {
            return 
@$"There was an old lady who swallowed a {animalName}...
...She's dead, of course!";
        }
    }
}
