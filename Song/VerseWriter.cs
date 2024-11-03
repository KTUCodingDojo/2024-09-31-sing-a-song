using System.Text;

namespace Song
{
    public class VerseWriter
    {
        private string _firstLine;

        private string _uniqueLine;

        private List<string> _middleLines;

        private string _lastLine;

        private string _lastAnimalName;

        public VerseWriter() 
        {
            _firstLine = string.Empty;
            _uniqueLine = string.Empty;
            _middleLines = new List<string>();
            _lastLine = string.Empty;
            _lastAnimalName = string.Empty;
        }
        public virtual string WriteVerse(string animalName, string animalUniqueLine)
        {
            if(_firstLine.Equals(string.Empty))
            {
                _firstLine = $"There was an old lady who swallowed a {animalName}.";
                _lastLine = $"I don't know why she swallowed a {animalName} - perhaps she'll die!";
                _lastAnimalName = animalName;
                return ToString();
            }

            _firstLine = $"There was an old lady who swallowed a {animalName};";
            
            _uniqueLine = animalUniqueLine;

            _middleLines.Insert(0, $"She swallowed the {animalName} to catch the {_lastAnimalName}");

            _lastAnimalName = animalName;
            return ToString();
        }

        public override string ToString()
        {
            if(_firstLine == string.Empty) { return string.Empty; }

            StringBuilder sb = new StringBuilder();

            if (_middleLines.Count == 0) 
            {
                sb.AppendLine(_firstLine);
                sb.Append(_lastLine);
                return sb.ToString();
            }

            sb.AppendLine(_firstLine);
            sb.AppendLine(_uniqueLine);

            for (int i = 0; i < _middleLines.Count; i++)
            {
                sb.AppendLine(_middleLines[i] + (i == _middleLines.Count - 1 ? ";" : ","));
            }

            sb.Append(_lastLine);

            return sb.ToString();
        }

        public virtual string FinalVerse(string animalName)
        {
            return 
@$"There was an old lady who swallowed a {animalName}...
...She's dead, of course!";
        }
    }
}
