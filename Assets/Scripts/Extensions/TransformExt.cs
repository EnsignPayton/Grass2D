using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Extensions
{
    public static class TransformExt
    {
        public static void Translate(this Transform transform, MoveDirection dir, float distance = 1.0f)
        {
            transform.Translate(dir.ToTranslateVector(distance));
        }
    }
}
