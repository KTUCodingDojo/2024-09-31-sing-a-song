namespace Song.Tests
{
    public class SongWriterTests
    {
        [Fact]
        public void Sing_SingleAnimal_WorksAsExpected()
        {
            string expected =
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns(
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!"
            );

            var songWriter = new SongWriter(verseWriterMock.Object);

            string actual = songWriter.Sing("fly", "");

            actual.Should().Be(expected);
        }

        [Fact]
        public void Sing_TwoAnimals_WorksAsExpected()
        {
            string expected =
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns(
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!"
            );
            verseWriterMock.Setup(vw => vw.WriteVerse("spider", "That wriggled and wiggled and tickled inside her.")).Returns(
@"There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!"
            );

            var songWriter = new SongWriter(verseWriterMock.Object);

            songWriter.Sing("fly", "");
            string actual = songWriter.Sing("spider", "That wriggled and wiggled and tickled inside her.");

            actual.Should().Be(expected);
        }

        [Fact]
        public void Sing_TwoAnimalsAndFinish_WorksAsExpected()
        {
            string expected =
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a horse...
...She's dead, of course!";

            var verseWriterMock = new Mock<VerseWriter>();
            verseWriterMock.Setup(vw => vw.WriteVerse("fly", "")).Returns(
@"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!"
            );
            verseWriterMock.Setup(vw => vw.WriteVerse("spider", "That wriggled and wiggled and tickled inside her.")).Returns(
@"There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!"
            );
            verseWriterMock.Setup(vw => vw.FinalVerse("horse")).Returns(
@"There was an old lady who swallowed a horse...
...She's dead, of course!"
            );

            var writer = new SongWriter(verseWriterMock.Object);

            writer.Sing("fly", "");
            writer.Sing("spider", "That wriggled and wiggled and tickled inside her.");
            string actual = writer.FinishSong("horse");

            actual.Should().Be(expected);
        }
    }
}