using System.Text;

namespace Song
{
    public class LineWriter
    {
        private string _previousAnimalName;

        private List<string> _middleLines;

        private string _lastLine;
        public LineWriter() 
        {
            _previousAnimalName = string.Empty;
            _middleLines = new List<string>();
            _lastLine = string.Empty;
        }

        public virtual string WriteFirstLine(string animalName)
        {
            if (_previousAnimalName.Equals(string.Empty))
            {
                return $"There was an old lady who swallowed a {animalName}.";
            }

            return $"There was an old lady who swallowed a {animalName};";
        }

        public virtual string WriteMiddleLines(string animalName) 
        {
            if (_previousAnimalName.Equals(string.Empty))
            {
                _previousAnimalName = animalName;
                return string.Empty;
            }
            
            _middleLines.Insert(0, $"She swallowed the {animalName} to catch the {_previousAnimalName}");
            _previousAnimalName = animalName;

            return MiddleLinesToString();
        }

        private string MiddleLinesToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _middleLines.Count - 1; i++)
            {
                sb.AppendLine(_middleLines[i] + ",");
            }

            sb.Append(_middleLines[_middleLines.Count - 1] + ";");

            return sb.ToString();
        }

        public virtual string WriteLastLine(string animalName)
        {
            if (_lastLine.Equals(string.Empty))
            {
                _lastLine = $"I don't know why she swallowed a {animalName} - perhaps she'll die!";
            }

            return _lastLine;
        }
    }
}
