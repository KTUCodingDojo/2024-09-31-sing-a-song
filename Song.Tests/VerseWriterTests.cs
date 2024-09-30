﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Tests
{
    public class VerseWriterTests
    {
        [Fact]
        public void WriteFirstVerse()
        {
            string expected = @"There was an old lady who swallowed a fly.
I don't know why she swallowed a fly - perhaps she'll die!";
            VerseWriter writer = new VerseWriter();

            string animal = "fly";
            string animalLine = "";

            string actual = writer.WriteVerse(animal, animalLine);
            
            Assert.Equal(expected, actual);

        }
    }
}
