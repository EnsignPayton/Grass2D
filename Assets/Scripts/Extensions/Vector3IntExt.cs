using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Extensions
{
    public static class Vector3IntExt
    {
        public static Vector3Int With(this Vector3Int value, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(x ?? value.x, y ?? value.y, z ?? value.z);

        public static Vector3Int Move(this Vector3Int value, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(value.x + x ?? value.x, value.y + y ?? value.y, value.z + z ?? value.z);

        public static Vector3Int AddDirection(this Vector3Int value, MoveDirection dir)
        {
            switch (dir)
            {
                case MoveDirection.Left:
                    return value.Move(x: -1);
                case MoveDirection.Right:
                    return value.Move(x: 1);
                case MoveDirection.Up:
                    return value.Move(y: -1);
                case MoveDirection.Down:
                    return value.Move(y: 1);
                default:
                    return value.Move();
            }
        }
    }
}
