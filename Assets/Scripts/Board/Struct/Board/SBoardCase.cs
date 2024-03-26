using System;
using UnityEngine;
using YokaiNoMori.Enumeration;


namespace YokaiNoMori.General
{
    [Serializable]
    public struct SBoardCase
    {
        public Vector2 Position;
        public EPawnType PieceToSpawn;
        public CommonPawnData PieceData;
        public ECampType Camp;
    }
}
