using CustomerPortal.Properties;
using Microsoft.Graph;

namespace b2c_ms_graph
{
   public static class B2cCustomAttributeHelper
    {
        public static string GetCompleteAttributeName(string attributeName)
        {
            if (string.IsNullOrWhiteSpace(attributeName))
            {
                throw new System.ArgumentException("Parameter cannot be null", nameof(attributeName));
            }

            return $"extension_{Settings.Default.B2cExtensionAppClientId.Replace("-", "")}_{attributeName}";
        }

       
    }
}
