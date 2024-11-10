using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song.Tests
{
    public class ApprovalTest
    {
        [Fact]
        public Task Test()
        {
            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));

            Song.Program.Main(new string[] { });
            var output = fakeOutput.ToString();

            return Verifier.Verify(output);
        }
    }
}
