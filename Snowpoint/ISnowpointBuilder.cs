using System;

namespace Snowpoint
{
    /// <summary>
    /// A builder for configuring <see cref="ISnowpoint"/>.
    /// </summary>
    public interface ISnowpointBuilder
    {
        /// <summary>
        /// Use the reference epoch for generated <see cref="Snowflake"/>'s.
        /// </summary>
        /// <param name="epoch">The reference epoch.</param>
        /// <returns>The <see cref="ISnowpointBuilder"/>.</returns>
        ISnowpointBuilder UseEpoch(DateTime epoch);

        /// <summary>
        /// Use the identity for generated <see cref="Snowflake"/>'s.
        /// </summary>
        /// <param name="identity">An identity string.</param>
        /// <returns>The <see cref="ISnowpointBuilder"/>.</returns>
        ISnowpointBuilder UseMachineIdentity(string identity);

        /// <summary>
        /// Builds an <see cref="ISnowpoint"/> that will produce <see cref="Snowflake"/>'s conforming to this <see cref="ISnowpointBuilder"/>.
        /// </summary>
        /// <returns></returns>
        ISnowpoint Build();
    }
}
