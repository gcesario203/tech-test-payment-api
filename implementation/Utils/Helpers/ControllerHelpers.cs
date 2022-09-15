using Microsoft.AspNetCore.Mvc;
using static implementation.Utils.Helpers.ReflectionHelpers;

namespace implementation.Utils.Helpers
{
    public static class ControllerHelpers
    {
        public static T HandleActionResult<T>(IActionResult result) => GetValue<T>(result, "Value");
    }
}