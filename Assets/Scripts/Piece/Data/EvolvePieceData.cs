using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evolve Piece Data", menuName = "Pieces/Evolve Piece Data", order = 1)]
public class EvolvePieceData : CommonPieceData
{
	[SerializeField]
	private EvolvingPieceData m_evolutionPiece;

	public EvolvingPieceData EvolutionPiece
	{
		get { return m_evolutionPiece; }
		private set { m_evolutionPiece = value; }
	}
}
