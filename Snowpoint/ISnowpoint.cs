namespace Snowpoint
{
    /// <summary>
    /// A <see cref="Snowflake"/> producer.
    /// </summary>
    public interface ISnowpoint
    {
        /// <summary>
        /// Get the next <see cref="Snowflake"/>.
        /// </summary>
        /// <returns>A unique 64-bit identifier.</returns>
        Snowflake Next();
    }
}
