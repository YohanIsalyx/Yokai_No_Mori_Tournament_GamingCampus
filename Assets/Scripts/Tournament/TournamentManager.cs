using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Interface;

public class TournamentManager : MonoBehaviour
{

	public List<ICompetitor> CompetitorsList
	{
		get { return m_competitorsList; }
		private set { m_competitorsList = value; }
	}



    private void Awake()
    {
		m_victoryCounter = new Dictionary<ICompetitor, int>();

        foreach (ICompetitor competitor in CompetitorsList)
        {
            m_victoryCounter.Add(competitor, 0);
        }
    }


    public void AddVictory(ICompetitor competitor)
	{
		m_victoryCounter[competitor]++;
	}


    public void AddError(ICompetitor competitor)
    {
        m_errorOccured[competitor]++;
    }



    [SerializeField]
    private List<ICompetitor> m_competitorsList;

    private Dictionary<ICompetitor, int> m_victoryCounter;
    private Dictionary<ICompetitor, int> m_errorOccured;

}
