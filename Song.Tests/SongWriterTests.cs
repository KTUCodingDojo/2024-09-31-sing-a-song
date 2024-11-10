namespace Song.Tests
{
    public class SongWriterTests
    {
        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]
        public void Sing_SingleAnimal_WorksAsExpected(string animal)
        {
            string expected = $"{animal} verse";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns($"{animal} verse");

            var songWriter = new SongWriter(verseWriterMock.Object);

            string actual = songWriter.Sing("fly", "");

            actual.Should().Be(expected);
        }

        [Fact]
        public void Sing_TwoAnimals_WorksAsExpected()
        {
            string expected = 
@"fly verse

spider verse";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns("fly verse");
            verseWriterMock.Setup(vw => vw.WriteVerse("spider", "")).Returns("spider verse");

            var songWriter = new SongWriter(verseWriterMock.Object);

            songWriter.Sing("fly", "");
            string actual = songWriter.Sing("spider", "");

            actual.Should().Be(expected);
        }

        [Fact]
        public void Sing_TwoAnimalsAndFinish_WorksAsExpected()
        {
            string expected =
@"fly verse

spider verse

horse final verse";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns("fly verse");
            verseWriterMock.Setup(vw => vw.WriteVerse("spider", "")).Returns("spider verse");
            verseWriterMock.Setup(vw => vw.FinalVerse("horse")).Returns("horse final verse");

            var writer = new SongWriter(verseWriterMock.Object);

            writer.Sing("fly", "");
            writer.Sing("spider", "");
            string actual = writer.FinishSong("horse");

            actual.Should().Be(expected);
        }

        [Fact]
        public void ToString_EmptySong_ReturnsEmptyString()
        {
            var songWriter = new SongWriter();

            songWriter.ToString().Should().Be(string.Empty);
        }
    }
}