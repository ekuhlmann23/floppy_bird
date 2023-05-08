namespace FloppyBird.Domain.Drivers
{
    /// <summary>
    /// Interface to interact with the current environment.
    /// </summary>
    public interface IEnvironmentManager
    {
        /// <summary>
        /// Fetches variables set in the current environment.
        /// </summary>
        /// <param name="variableName">Name of the environment variable.</param>
        /// <returns>Value of the environment variable.</returns>
        public string GetEnvironmentVariable(string variableName);
    }
}