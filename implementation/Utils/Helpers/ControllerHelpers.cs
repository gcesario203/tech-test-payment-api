using Microsoft.AspNetCore.Mvc;

namespace implementation.Utils.Helpers
{
    public static class ControllerHelpers
    {
        public static T HandleActionResult<T>(IActionResult result)
        {
            var formatedResult = result.GetType().GetProperty("Value").GetValue(result);
            
            return (T)formatedResult;
        }
    }
}