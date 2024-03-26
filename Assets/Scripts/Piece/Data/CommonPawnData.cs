using UnityEngine;
using YokaiNoMori.Enumeration;



namespace YokaiNoMori.General
{
	[CreateAssetMenu(fileName = "Common Pawn Data", menuName = "Pawns/Common Pawn Data", order = 0)]
	public class CommonPawnData : ScriptableObject
	{
		[SerializeField]
		private EMovementType m_movementType;
		public EMovementType MovementType
		{
			get { return m_movementType; }
			private set { m_movementType = value; }
		}


		[SerializeField]
		private EPawnType m_pieceType;
		public EPawnType PieceType
		{
			get { return m_pieceType; }
			private set { m_pieceType = value; }
		}
	}

}
