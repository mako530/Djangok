using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkerObject : MonoBehaviour
{
    public Vector2 Position;
    public Vector2 Direction;
    public float ChanceToChange;

    public WalkerObject(Vector2 pos, Vector2 dir, float chanceToChange)
    {
        Position = pos;
        Direction = dir;
        ChanceToChange = chanceToChange;
    }
}

