using System;

namespace Song
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SongWriter songWriter = new SongWriter();

            var animals = new List<(string, string)>
            {
                ("fly", ""),
                ("spider", "That wriggled and wiggled and tickled inside her."),
                ("bird", "How absurd to swallow a bird."),
                ("cat", "Fancy that to swallow a cat!"),
                ("dog", "What a hog, to swallow a dog!"),
                ("cow", "I don't know how she swallowed a cow!"),
            };

            foreach (var animal in animals)
            {
                songWriter.Sing(animal.Item1, animal.Item2);
            }

            Console.WriteLine(songWriter.FinishSong("horse"));
        }
    }
}