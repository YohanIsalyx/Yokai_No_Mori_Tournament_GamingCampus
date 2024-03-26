using UnityEngine;


namespace YokaiNoMori.General
{
	[CreateAssetMenu(fileName = "Evolve Piece Data", menuName = "Pieces/Evolve Piece Data", order = 1)]
	public class EvolvePawnData : CommonPawnData
	{
		[SerializeField]
		private EvolvingPawnData m_evolutionPiece;

		public EvolvingPawnData EvolutionPiece
		{
			get { return m_evolutionPiece; }
			private set { m_evolutionPiece = value; }
		}
	}
}