using System.Text;

namespace Song
{
    public class VerseWriter
    {
        private string _firstLine;

        private string _uniqueLine;

        private string _middleLines;

        private string _lastLine;

        private LineWriter _lineWriter;

        public VerseWriter(LineWriter writer)
        {
            _firstLine = string.Empty;
            _uniqueLine = string.Empty;
            _middleLines = string.Empty;
            _lastLine = string.Empty;
            _lineWriter = writer;
        }

        public VerseWriter() : this(new LineWriter()) { }

        public virtual string WriteVerse(string animalName, string animalUniqueLine)
        {
            _firstLine = _lineWriter.WriteFirstLine(animalName);

            _uniqueLine = animalUniqueLine;

            _middleLines = _lineWriter.WriteMiddleLines(animalName);

            _lastLine = _lineWriter.WriteLastLine(animalName);

            return ToString();
        }

        public override string ToString()
        {
            if (_firstLine.Equals(string.Empty)) { return string.Empty; }

            if (_middleLines.Equals(string.Empty))
            {
                return 
$@"{_firstLine}
{_lastLine}";
            }

            return 
$@"{_firstLine}
{_uniqueLine}
{_middleLines}
{_lastLine}";
        }

        public virtual string FinalVerse(string animalName)
        {
            return 
@$"There was an old lady who swallowed a {animalName}...
...She's dead, of course!";
        }
    }
}
