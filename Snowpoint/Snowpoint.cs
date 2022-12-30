using System;
using System.Timers;

namespace Snowpoint
{
    /// <summary>
    /// Default <see cref="ISnowpoint"/> implemenation, producing simple <see cref="Snowflake"/>'s.
    /// </summary>
    internal class Snowpoint : ISnowpoint
    {
        private readonly DateTime epoch;
        private readonly byte identity;
        private readonly Timer resetSequenceTimer;
        private byte sequence;

        /// <summary>
        /// Initialises a new instance of the <see cref="Snowpoint"/> class.
        /// </summary>
        /// <param name="epoch">A reference epoch for generated <see cref="Snowflake"/>'s.</param>
        /// <param name="identity">The identity for generated <see cref="Snowflake"/>'s</param>
        public Snowpoint(DateTime epoch, string identity)
        {
            this.epoch = epoch;
            this.identity = PearsonHash.Compute(identity);

            resetSequenceTimer = new Timer
            {
                Interval = 1000
            };
            resetSequenceTimer.Elapsed += ResetSequenceTimerElapsed;
            resetSequenceTimer.Start();
        }

        /// <summary>
        /// Internal sequence timer.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void ResetSequenceTimerElapsed(object sender, ElapsedEventArgs e)
        {
            sequence = 0;
        }

        /// <inheritdoc/>
        public Snowflake Next()
        {
            var timeSpan = DateTime.UtcNow - epoch;
            return new Snowflake(timeSpan, identity, sequence++);
        }
    }
}
