using System;

namespace Snowpoint
{
    /// <summary>
    /// Default <see cref="Snowpoint"/> builder.
    /// </summary>
    internal class SnowpointBuilder : ISnowpointBuilder
    {
        private DateTime epoch;
        private string identity;

        /// <summary>
        /// Initialises a new instance of the <see cref="SnowpointBuilder"/> class.
        /// </summary>
        public SnowpointBuilder()
        {
            // default epoch is 12midnight, 30th December 2022.
            epoch = new DateTime(2022, 12, 30);

            // default identity is a random guid.
            identity = Guid.NewGuid().ToString();
        }

        /// <inheritdoc/>
        public ISnowpoint Build()
        {
            return new Snowpoint(epoch, identity);
        }

        /// <inheritdoc/>
        public ISnowpointBuilder UseEpoch(DateTime epoch)
        {
            this.epoch = epoch;
            return this;
        }

        /// <inheritdoc/>
        public ISnowpointBuilder UseMachineIdentity(string identity)
        {
            this.identity = identity;
            return this;
        }
    }
}
