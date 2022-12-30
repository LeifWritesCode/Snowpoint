# Snowpoint

A Snowflake implentation

## Usage

Add the Snowpoint NuGet package to your project, then in your services startup call `IServiceCollection.AddSnowpoint()`. You can further configure Snowpoint using the returned `ISnowpointBuilder` object. Internally, the builder is used to generate `ISnowpoint` objects at runtime.

Once Snowpoint has been configured, you can inject the `ISnowpoint` interface into any class that should use it. The `ISnowpoint` interface provides facilities to get the next sequential snowflake value, and to interpret existing snowflakes.

Please refer to the xmldoc for further information.

## License

Snowpoint is written by, and the copyright &copy; of, Leif Walker-Grant. The library is made available free-of-charge, as-is, and without warranty. Usage of Snowpoint is governed by the Mozilla Public License 2.0, see [LICENSE](LICENSE).