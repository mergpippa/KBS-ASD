using System;
using Newtonsoft.Json;

namespace KBS.Configuration
{
    public abstract class BaseConfiguration
    {
        /// <summary>
        /// Memoized version of the GetCommandLineArgs string that is converted to a JSON object
        /// </summary>
        public static dynamic CommandLineArgumentConfiguration = JsonConvert.DeserializeObject("{}");

        /// <summary>
        /// Tries to get the value matching given key from arguments first, then from environment.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        public static T GetFromAny<T>(string key)
        {
            var value = GetFromArguments<T>(key);

            // Try to get the value from the environment if it's not defined
            if (value.Equals(default(T)))
                value = GetFromEnvironment<T>(key);

            return value;
        }

        /// <summary>
        /// Tries to get the value matching given key from arguments first, then from environment.
        /// The fallback will be returned if the value is the default of specified type
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        /// <param name="fallback">
        /// </param>
        public static T GetFromAny<T>(string key, T fallback)
        {
            var value = GetFromAny<T>(key);

            return value.Equals(default(T)) ? fallback : value;
        }

        /// <summary>
        /// Gets value from environment variable. The value will be converted to the type of T
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
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
        /// <param name="fallback">
        /// </param>
        public static T GetFromEnvironment<T>(string key, T fallback)
        {
            var value = GetFromEnvironment<T>(key);

            return value.Equals(default(T)) ? fallback : value;
        }

        /// <summary>
        /// Gets value from command line arguments. The value will be converted to the type of T
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="key">
        /// </param>
        public static T GetFromArguments<T>(string key)
        {
            var value = CommandLineArgumentConfiguration[key];

            if (value == null)
                return default(T);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Gets value from command line arguments. The fallback will be returned if the value is the
        /// default of specified type type of T
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="fallback">
        /// </param>
        public static T GetFromArguments<T>(string key, T fallback)
        {
            var value = GetFromArguments<T>(key);

            if (value == null || value.Equals(default(T)))
                return fallback;

            return value;
        }

        /// <summary>
        /// Convert given json string to a dynamic object which can later be used to retreive
        /// configuration values. This value is memoized because it can take over 100ms to
        /// deserialize jsonString.
        /// </summary>
        /// <param name="jsonString">
        /// </param>
        public static void SetCommandLineArgsConfiguration(string jsonString)
        {
            if (jsonString == string.Empty)
                return;

            // Memoize the deserialized object because it can take over 100ms to finish this operation
            CommandLineArgumentConfiguration = JsonConvert.DeserializeObject<dynamic>(jsonString);
        }
    }
}
