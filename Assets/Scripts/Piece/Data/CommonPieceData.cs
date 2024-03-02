using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;


[CreateAssetMenu(fileName = "Common Piece Data", menuName = "Pieces/Common Piece Data", order = 0)]
public class CommonPieceData : ScriptableObject
{
	[SerializeField]
	private EMovementType m_movementType;
	public EMovementType MovementType
	{
		get { return m_movementType; }
		private set { m_movementType = value; }
	}


	[SerializeField]
	private EPieceType m_pieceType;
	public EPieceType PieceType
	{
		get { return m_pieceType; }
		private set { m_pieceType = value; }
	}
}
