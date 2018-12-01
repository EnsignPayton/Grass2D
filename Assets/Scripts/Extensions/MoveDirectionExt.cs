using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Extensions
{
    public static class MoveDirectionExt
    {
        public static Vector3 ToTranslateVector(this MoveDirection dir, float distance = 1.0f)
        {
            switch (dir)
            {
                case MoveDirection.Left:
                    return new Vector3(-distance, 0.0f);
                case MoveDirection.Right:
                    return new Vector3(distance, 0.0f);
                case MoveDirection.Up:
                    return new Vector3(0.0f, -distance);
                case MoveDirection.Down:
                    return new Vector3(0.0f, distance);
                default:
                    return Vector3.zero;
            }
        }
    }
}
