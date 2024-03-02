using UnityEngine;
using YokaiNoMori.Interface;

public class CompetitorsManager
{

    #region Properties
    public ICompetitor PlayerOne
    {
        get { return m_playerOne; }
        private set { m_playerOne = value; }
    }

    public ICompetitor PlayerTwo
    {
        get { return m_playerTwo; }
        private set { m_playerTwo = value; }
    }
    #endregion



    #region Private Methods

    private void SelectPlayers()
    {
        int rdm = Random.Range(0, 10);

        if(rdm % 2 == 0)
        {
            PlayerOne = GameManager.Instance.TournamentManager.CompetitorsList[m_currentIndexFirstPlayer];
            PlayerTwo = GameManager.Instance.TournamentManager.CompetitorsList[m_currentIndexSecondPlayer];
            Debug.Log("PAIRE");
        }
        else
        {
            PlayerTwo = GameManager.Instance.TournamentManager.CompetitorsList[m_currentIndexFirstPlayer];
            PlayerOne = GameManager.Instance.TournamentManager.CompetitorsList[m_currentIndexSecondPlayer];
            Debug.Log("IMPAIR");
        }
    }


    #endregion



    #region Public Methods
    public void InitPlayer()
    {
        m_currentIndexFirstPlayer = 0;
        m_currentIndexSecondPlayer = 1;

        SelectPlayers();
    }

    public void NextPlayers()
    {
        if (m_currentIndexSecondPlayer >= GameManager.Instance.TournamentManager.CompetitorsList.Count)
        {
            m_currentIndexFirstPlayer++;
            m_currentIndexSecondPlayer = m_currentIndexFirstPlayer + 1;
        }
        SelectPlayers();
    }
    #endregion



    #region Private members
    // COMPETITORS SELECTIONS
    int m_currentIndexFirstPlayer;
    int m_currentIndexSecondPlayer;

    // PLAYERS
    private ICompetitor m_playerOne;
    private ICompetitor m_playerTwo;

    #endregion
}
