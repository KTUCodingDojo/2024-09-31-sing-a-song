namespace Song.Tests
{
    public class VerseWriterTests
    {
        [Theory]
        [InlineData("fly")]
        [InlineData("spider")]
        [InlineData("horse")]

        public void WriteVerse_SingleAnimalVerse_WorksAsExpected(string animal)
        {
            var writer = new VerseWriter();
            
            string expected =
@$"There was an old lady who swallowed a {animal}.
I don't know why she swallowed a {animal} - perhaps she'll die!";

            string actual = writer.WriteVerse(animal, "");

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AnimalTestCases))]
        public void WriteVerse_MultipleAnimals_WorksAsExpected(List<(string, string)> input, string expected)
        {
            VerseWriter writer = new VerseWriter();

            string actual = "";
            foreach ((string, string) animal in input)
            {
                actual = writer.WriteVerse(animal.Item1, animal.Item2);
            }

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> AnimalTestCases => new List<object[]>
        {
            new object[] 
            {
                new List<(string, string)>(
                [ 
                    ("fly", ""), 
                    ("spider", "That wriggled and wiggled and tickled inside her."),
                    ("bird", "How absurd to swallow a bird.")
                ]),

@"There was an old lady who swallowed a bird;
How absurd to swallow a bird.
She swallowed the bird to catch the spider,
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!"
            },

            new object[]
            {
                new List<(string, string)>(
                [
                    ("fly", ""),
                    ("bird", "How absurd to swallow a bird."),
                    ("spider", "That wriggled and wiggled and tickled inside her."),
                ]),

@"There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the bird,
She swallowed the bird to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!"
            },

            new object[]
            {
                new List<(string, string)>(
                [
                    ("a", "ALine"),
                    ("b", "BLine"),
                    ("c", "CLine"),
                    ("d", "DLine"),

                ]),

@"There was an old lady who swallowed a d;
DLine
She swallowed the d to catch the c,
She swallowed the c to catch the b,
She swallowed the b to catch the a;
I don't know why she swallowed a a - perhaps she'll die!"
            }
        };

        [Theory]
        [InlineData("horse")]
        [InlineData("spider")]
        [InlineData("fly")]
        public void FinalVerse_WorksAsExpected(string animal)
        {
            string expected =
@$"There was an old lady who swallowed a {animal}...
...She's dead, of course!";

            var writer = new VerseWriter();

            string actual = writer.FinalVerse(animal);

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