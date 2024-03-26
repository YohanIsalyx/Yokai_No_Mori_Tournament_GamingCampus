using UnityEngine;


namespace YokaiNoMori.General
{

	[CreateAssetMenu(fileName = "Evolving Piece Data", menuName = "Pieces/Evolving Piece Data", order = 2)]
	public class EvolvingPawnData : CommonPawnData
	{
		[SerializeField]
		private EvolvePawnData m_devolvePawnData;
		public EvolvePawnData DevolvePawnData
		{
			get { return m_devolvePawnData; }
			set { m_devolvePawnData = value; }
		}
	}
}