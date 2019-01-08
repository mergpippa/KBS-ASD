using System;
using Newtonsoft.Json;

namespace KBS.Configuration
{
    public abstract class BaseConfiguration
    {
        /// <summary>
        /// Memoized version of the GetCommandLineArgs string that is converted to a JSON object
        /// </summary>
        private static dynamic _commandLineArgumentConfiguration;

        public static T GetFromAny<T>(string key)
        {
            var value = GetFromArguments<T>(key);

            // Try to get the value from the environment if it's not defined
            if (value.Equals(default(T)))
                value = GetFromEnvironment<T>(key);

            return value;
        }

        public static T GetFromAny<T>(string key, T fallback)
        {
            var value = GetFromAny<T>(key);

            if (value.Equals(default(T)))
                return fallback;

            return value;
        }

        /// <summary>
        /// Gets value from environment variable. The value will be converted to the type of T
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        public static T GetFromEnvironment<T>(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);

            if (value == null)
                return default(T);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Gets value from environment variable. The fallback will be returned if the value is the
        /// default of specified type
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        public static T GetFromEnvironment<T>(string key, T fallback)
        {
            var value = GetFromArguments<T>(key);

            if (value.Equals(default(T)))
                return fallback;

            return value;
        }

        /// <summary>
        /// Gets value from command line arguments. The value will be converted to the type of T
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        public static T GetFromArguments<T>(string key)
        {
            var value = _commandLineArgumentConfiguration[key];

            if (value == null)
                return default(T);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Gets value from command line arguments. The fallback will be returned if the value is the
        /// default of specified type type of T
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <param name="fallback">
        /// </param>
        /// <returns>
        /// </returns>
        public static T GetFromArguments<T>(string key, T fallback)
        {
            var value = GetFromArguments<T>(key);

            if (value.Equals(default(T)))
                return fallback;

            return value;
        }

        /// <summary>
        /// Convert given json string to a dynamic object which can later be used to retreive
        /// configuration values. This value is memoized because it can take over 100ms to
        /// deserialize jsonString.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <param name="fallback">
        /// </param>
        /// <returns>
        /// </returns>
        public static void SetCommandLineArgsConfiguration(string jsonString)
        {
            // Memoize the deserialized object because it can take over 100ms to finish this operation
            _commandLineArgumentConfiguration = JsonConvert.DeserializeObject<dynamic>(jsonString);
        }
    }
}
