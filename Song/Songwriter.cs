using System.Text;

namespace Song
{
    public class SongWriter
    {
        private StringBuilder _song;
        private VerseWriter _verseWriter;
        public SongWriter(VerseWriter verseWriter) 
        {
            _song = new StringBuilder();
            _verseWriter = verseWriter;
        }

        public SongWriter() : this(new VerseWriter()) { }

        public string Sing(string animal, string uniqueLine)
        {
            if(_song.Length != 0)
            {
                _song.Append(Environment.NewLine + Environment.NewLine);
            }
           
            string verse = _verseWriter.WriteVerse(animal, uniqueLine);
            _song.Append(verse);

            return ToString();
        }

        public string FinishSong(string animal)
        {
            _song.Append(Environment.NewLine + Environment.NewLine);

            _song.Append(_verseWriter.FinalVerse(animal));

            return ToString();
        }

        public override string ToString()
        {
            return _song.ToString();
        }
    }
}
