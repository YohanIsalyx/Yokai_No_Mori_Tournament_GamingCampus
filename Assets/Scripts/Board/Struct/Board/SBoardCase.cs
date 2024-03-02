using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;

[Serializable]
public struct SBoardCase
{
    public Vector2 Position;
    public EPieceType PieceToSpawn;
    public CommonPieceData PieceData;
    public ECampType Camp;
}
