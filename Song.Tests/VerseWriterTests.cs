namespace Song.Tests
{
    public class VerseWriterTests
    {
        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]

        public void WriteVerse_SingleAnimal_WorksAsExpected(string animal)
        {
            string expected =
@$"{animal} first line.
{animal} last line.";

            var lineWriterMock = new Mock<LineWriter>();
            lineWriterMock.Setup(vw => vw.WriteFirstLine($"{animal}")).Returns($"{animal} first line.");
            lineWriterMock.Setup(vw => vw.WriteMiddleLines($"{animal}")).Returns("");
            lineWriterMock.Setup(vw => vw.WriteLastLine($"{animal}")).Returns($"{animal} last line.");

            var writer = new VerseWriter(lineWriterMock.Object);

            string actual = writer.WriteVerse(animal, "");

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("fly", "spider")]
        [InlineData("horse", "goat", "manatee")]
        [InlineData("dragonfly", "unicorn", "python", "human")]
        public void WriteVerse_MultipleAnimals_WorksAsExpected(params string[] animals)
        {
            string expected =
@$"first line
{animals[animals.Length - 1]} unique line
middle lines
last line";

            var lineWriterMock = new Mock<LineWriter>();
            foreach (var animal in animals)
            {
                lineWriterMock.Setup(vw => vw.WriteFirstLine($"{animal}")).Returns($"first line");
                lineWriterMock.Setup(vw => vw.WriteMiddleLines($"{animal}")).Returns($"middle lines");
                lineWriterMock.Setup(vw => vw.WriteLastLine($"{animal}")).Returns($"last line");
            }

            var verseWriter = new VerseWriter(lineWriterMock.Object);

            string actual = "";

            foreach (var animal in animals)
            {
                actual = verseWriter.WriteVerse($"{animal}", $"{animal} unique line");
            }

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("horse")]
        [InlineData("spider")]
        [InlineData("fly")]
        public void FinalVerse_WorksAsExpected(string animal)
        {
            string expected =
@$"There was an old lady who swallowed a {animal}...
...She's dead, of course!";

            var verseWriter = new VerseWriter();

            string actual = verseWriter.FinalVerse(animal);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ToString_EmptyVerse_ReturnsEmptyString()
        {
            var writer = new VerseWriter();

            writer.ToString().Should().Be(string.Empty);
        }
    }
}