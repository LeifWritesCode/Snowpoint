using System;

namespace Snowpoint
{
    /// <summary>
    /// A 64-bit unsigned identifier.
    /// </summary>
    /// <remarks>
    /// The format of a generated Snowflake looks like the following:
    /// 
    /// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBBBBBCCCCCCCC
    /// |                                              |       |      |
    /// 64                                             16      8      1
    /// 
    /// Wherein:
    ///     (A) is the timestamp in milliseconds since the epoch,
    ///     (B) is the producer identity, and
    ///     (C) is a sequence number.
    /// </remarks>
    public struct Snowflake
    {
        /// <summary>
        /// The time elapsed since some reference epoch at time of original generation.
        /// </summary>
        public TimeSpan Offset { get; private set; }

        /// <summary>
        /// The 8-bit unsigned identity value.
        /// </summary>
        public byte Identity { get; private set; }

        /// <summary>
        /// The 8-bit unsigned sequence value.
        /// </summary>
        public byte Sequence { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Snowflake"/> struct.
        /// </summary>
        /// <param name="offset">The time elapsed since some reference epoch.</param>
        /// <param name="identity">An 8-bit identity value.</param>
        /// <param name="sequence">An 8-bit sequence value.</param>
        public Snowflake(TimeSpan offset, byte identity, byte sequence)
        {
            Offset = offset;
            Identity = identity;
            Sequence = sequence;
        }

        /// <summary>
        /// Encode the given <see cref="Snowflake"/> as a 64-bit signed integer.
        /// </summary>
        /// <param name="rhs">A <see cref="Snowflake"/>.</param>
        public static implicit operator long(Snowflake rhs) => ((long)rhs.Offset.TotalMilliseconds << 16) | ((long)rhs.Identity << 8) | rhs.Sequence;

        /// <summary>
        /// Decode the given value to a <see cref="Snowflake"/>.
        /// </summary>
        /// <param name="rhs">A 64-bit signed integer.</param>
        public static implicit operator Snowflake(long rhs) => new Snowflake(TimeSpan.FromMilliseconds(rhs >> 16), (byte)((rhs >> 8) & 0xFF), (byte)(rhs & 0xFF));
    }
}
