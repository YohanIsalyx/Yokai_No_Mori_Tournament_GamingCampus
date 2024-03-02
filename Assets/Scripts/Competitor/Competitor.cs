using YokaiNoMori.Enumeration;

public abstract class Competitor
{
	public string CompetitorName
	{
		get { return m_competitorName; }
		protected set { m_competitorName = value; }
	}

	public ECampType Camp
	{
		get { return m_camp; }
		protected set { m_camp = value; }
	}


	public abstract void Init(ECampType camp);

    public abstract void StartTurn();
    public abstract void StopTurn();


    private string m_competitorName;
    private ECampType m_camp;

}
