using System.Collections;
using System.Linq;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Movement : PlayerBase
{
    private bool _canMove = true;

    public float MoveDistance;
    public float MoveTimeSeconds;
    public TileBase[] ColliderTiles;

    public void FixedUpdate()
    {
        var dir = GetMoveDirection();
        MoveStepwise(dir);
    }

    private IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(MoveTimeSeconds);

        _canMove = true;
    }

    private void MoveStepwise(MoveDirection direction)
    {
        if (!_canMove) return;
        if (direction == MoveDirection.None) return;

        var nextCell = GetCurrentCell().AddDirection(direction);

        var nextTile = Tilemap.GetTile(nextCell);
        if (ColliderTiles.Contains(nextTile)) return;

        transform.Translate(direction, MoveDistance);
        _canMove = false;

        StartCoroutine(MoveCooldown());
    }

    private static MoveDirection GetMoveDirection()
    {
        const string Horizontal = "Horizontal";
        const string Vertical = "Vertical";

        if (Input.GetButton(Horizontal))
        {
            var move = Input.GetAxis(Horizontal).Unit();
            if (move < 0.0f) return MoveDirection.Left;
            if (move > 0.0f) return MoveDirection.Right;
        }

        if (Input.GetButton(Vertical))
        {
            var move = Input.GetAxis(Vertical).Unit();
            if (move < 0.0f) return MoveDirection.Up;
            if (move > 0.0f) return MoveDirection.Down;
        }

        return MoveDirection.None;
    }
}
