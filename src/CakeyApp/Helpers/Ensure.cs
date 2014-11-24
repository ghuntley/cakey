using System;

namespace FloJoCore.Helpers
{
    public static class Ensure
    {
        public static void ArgumentInRange(int value, int minValue, string name)
        {
            if (value >= minValue)
            {
                return;
            }

            string message = string.Format("The value '{0}' for '{1}' must be greater than or equal to '{2}'",
                (object) value, (object) name,
                (object) minValue);

            throw new ArgumentOutOfRangeException(name, message);
        }

        public static void ArgumentInRange(int value, int minValue, int maxValue, string name)
        {
            if (value >= minValue && value <= maxValue)
            {
                return;
            }

            string message =
                string.Format(
                    "The value '{0}' for '{1}' must be greater than or equal to '{2}' and less than or equal to '{3}'",
                    (object) value, (object) name, (object) minValue, (object) maxValue);

            throw new ArgumentOutOfRangeException(name, message);
        }

        public static void ArgumentIsOfType(object value, Type type, string name)
        {
            ArgumentNotNull(value, name);

            if (value.GetType() == type)
            {
                return;
            }

            string message = string.Format("The value '{0}' for '{1}' must be of type '{2}",
                value, (object) name, (object) type);

            throw new ArgumentException(name, message);
        }

        public static void ArgumentNonNegative(int value, string name)
        {
            if (value > -1)
            {
                return;
            }

            throw new ArgumentException(
                string.Format("The value for '{0}' must be non-negative", new object[1]
                {
                    name
                }), name);
        }

        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            string message = string.Format("Failed Null Check on '{0}'", new object[1]
            {
                name
            });

            throw new ArgumentNullException(name, message);
        }

        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);
            if (value.Length > 0)
            {
                return;
            }

            throw new ArgumentException(
                string.Format("The value for '{0}' must not be empty", new object[1]
                {
                    name
                }), name);
        }
    }
}