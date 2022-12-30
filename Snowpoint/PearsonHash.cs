using System.Linq;
using System.Text;

namespace Snowpoint
{
    /// <summary>
    /// An 8-bit hash function producing a value strongly dependent on all input bytes.
    /// </summary>
    internal static class PearsonHash
    {
        /// <summary>
        /// Internal substitition cipher table for all possible 8-bit values.
        /// </summary>
        private static readonly byte[] T =
        {
            197, 93, 84, 190, 249, 204, 220, 11, 114, 201,
            203, 71, 13, 241, 109, 17, 232, 102, 55, 243,
            187, 209, 205, 214, 254, 18, 14, 132, 255, 28,
            91, 253, 185, 189, 153, 10, 128, 237, 83, 77,
            96, 224, 47, 113, 57, 42, 98, 60, 247, 178,
            119, 235, 233, 184, 62, 33, 23, 51, 229, 64,
            162, 101, 207, 231, 160, 206, 111, 65, 25, 107,
            164, 106, 59, 245, 76, 49, 85, 161, 141, 103,
            54, 183, 130, 157, 140, 152, 252, 80, 21, 122,
            131, 167, 239, 251, 15, 110, 75, 216, 16, 219,
            78, 115, 46, 169, 173, 43, 116, 120, 112, 180,
            94, 133, 175, 147, 123, 228, 215, 72, 27, 73,
            148, 165, 170, 126, 95, 86, 211, 222, 146, 66,
            172, 104, 6, 246, 188, 63, 174, 163, 176, 144,
            9, 118, 19, 5, 179, 198, 168, 45, 149, 99,
            67, 81, 117, 200, 129, 61, 2, 236, 74, 191,
            244, 150, 40, 143, 53, 8, 30, 156, 248, 227,
            0, 186, 26, 134, 155, 158, 69, 217, 22, 70,
            89, 181, 50, 136, 137, 240, 212, 3, 182, 208,
            97, 108, 31, 218, 195, 139, 223, 24, 79, 1,
            221, 225, 29, 34, 192, 88, 142, 202, 32, 44,
            38, 127, 37, 151, 68, 193, 138, 250, 39, 135,
            58, 90, 35, 159, 100, 105, 92, 125, 121, 199,
            87, 145, 7, 52, 36, 124, 177, 238, 196, 4,
            56, 194, 12, 20, 82, 154, 41, 48, 234, 210,
            213, 226, 242, 230, 166, 171
        };

        /// <summary>
        /// Compute the Pearson hash of <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The value to hash.</param>
        /// <returns>The Pearson hash of <paramref name="input"/>.</returns>
        public static byte Compute(string input)
        {
            return Encoding.UTF8.GetBytes(input).Aggregate((byte)0, (a, b) => T[a ^ b]);
        }
    }
}
