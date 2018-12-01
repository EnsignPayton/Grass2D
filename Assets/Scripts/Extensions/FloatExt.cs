using System;

namespace Assets.Scripts.Extensions
{
    public static class FloatExt
    {
        public static bool IsNaN(this float value) => float.IsNaN(value);

        public static float Unit(this float value, float e = 0.01f)
        {
            if (value.IsNaN()) return value;

            if (Math.Abs(value) < e) return 0.0f;

            return value > 0.0f ? 1.0f : -1.0f;
        }

        public static float Clamp(this float value, float min, float max)
        {
            if (value.IsNaN()) return value;
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
