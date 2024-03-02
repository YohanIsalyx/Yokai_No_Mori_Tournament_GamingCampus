using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evolving Piece Data", menuName = "Pieces/Evolving Piece Data", order = 2)]
public class EvolvingPieceData : CommonPieceData
{
    [SerializeField]
    private EvolvePieceData m_divolvePiece;
	public EvolvePieceData DivolvePiece
	{
		get { return m_divolvePiece; }
		set { m_divolvePiece = value; }
	}
}
