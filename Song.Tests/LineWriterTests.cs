namespace Song.Tests
{
    public class LineWriterTests
    {
        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]
        public void WriteFirstLine_NoMiddleLines_WorksAsExpected(string animal)
        {
            string expected = $"There was an old lady who swallowed a {animal}.";

            var writer = new LineWriter();

            string actual = writer.WriteFirstLine($"{animal}");

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]
        public void WriteFirstLine_WithMiddleLines_WorksAsExpected(string animal)
        {
            string expected = $"There was an old lady who swallowed a {animal};";

            var writer = new LineWriter();

            writer.WriteMiddleLines("junk");

            string actual = writer.WriteFirstLine($"{animal}");

            actual.Should().Be(expected);
        }

        [Fact]
        public void WriteMiddleLines_SingleAnimal_ReturnsEmptyString()
        {
            string expected = "";

            var writer = new LineWriter();

            string actual = writer.WriteMiddleLines("animal1");

            actual.Should().Be(expected);
        }

        [Fact]
        public void WriteMiddleLines_MultipleAnimals_WorksAsExpected()
        {
            string expected =
@"She swallowed the animal4 to catch the animal3,
She swallowed the animal3 to catch the animal2,
She swallowed the animal2 to catch the animal1;";

            var writer = new LineWriter();

            writer.WriteMiddleLines("animal1");
            writer.WriteMiddleLines("animal2");
            writer.WriteMiddleLines("animal3");
            string actual = writer.WriteMiddleLines("animal4");


            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]
        public void WriteLastLines_SingleAnimal_WorksAsExpected(string animalName)
        {
            string expected = $"I don't know why she swallowed a {animalName} - perhaps she'll die!";

            var writer = new LineWriter();

            string actual = writer.WriteLastLine(animalName);

            actual.Should().Be(expected);
        }

        [Fact]
        public void WriteLastLines_MultipleAnimals_OnlyEverWritesFirstAnimal()
        {
            string expected = $"I don't know why she swallowed a animal1 - perhaps she'll die!";

            var writer = new LineWriter();

            string actual = writer.WriteLastLine("animal1");
            actual = writer.WriteLastLine("animal2");
            actual = writer.WriteLastLine("animal3");

            actual.Should().Be(expected);
        }
    }
}
