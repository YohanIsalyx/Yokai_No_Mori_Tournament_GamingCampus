using System;
using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;
using YokaiNoMori.Interface;

public class GameManager : MonoBehaviour, IGameManager
{
    #region Singleton
    private static GameManager m_instance = null;
    public static GameManager Instance => m_instance;
    #endregion

    #region Properties

    #region Managers
    public CompetitorsManager CompetitorsManager
    {
        get { return m_competitorsManager; }
        private set { m_competitorsManager = value; }
    }


    public BoardManager BoardManager
    {
        get { return m_boardManager; }
        private set { m_boardManager = value; }
    }


    public MovementManager MovementManager
    {
        get { return m_movementManager; }
        private set { m_movementManager = value; }
    }


    public GraveyardManager GraveyardManager
    {
        get { return m_graveyardManage; }
        private set { m_graveyardManage = value; }
    }


    public FightManager FightManager
    {
        get { return m_fightManager; }
        private set { m_fightManager = value; }
    }



    public TournamentManager TournamentManager
    {
        get { return m_tournamentManager; }
        private set { m_tournamentManager = value; }
    }

    #endregion


    public ICompetitor CurrentPlayer
    {
        get { return m_currentPlayerTurn; }
        private set { m_currentPlayerTurn = value; }
    }


    #endregion


    #region Unity Methods

    private void Awake()
    {
        #region Singleton
        if (m_instance != null && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            m_instance = this;
        }
        DontDestroyOnLoad(gameObject);
        #endregion
    }

    private void Start()
    {
        BoardManager = new BoardManager(m_boardData);
    }


    private void Update()
    {
        switch (m_currentGameState)
        {
            case EGameState.INIT: InitUpdate();
                break;
            case EGameState.CHOICE_PLAYERS: ChoicePlayerUpdate();
                break;
            case EGameState.NEW_GAME: NewGameUpdate();
                break;
            case EGameState.TURN_PLAYER: TurnPlayerUpdate();
                break;
            case EGameState.VALIDATION_ACTION: ValidationActionUpdate();
                break;
            case EGameState.CHECK_WIN_CONDITION: CheckWinConditionUpdate();
                break;
            case EGameState.UNEXPECTED_ACTION: UnexpectedActionUpdate();
                break;
            case EGameState.NEXT_PLAYER: NextPlayerUpdate();
                break;
            case EGameState.FINISH_GAME: FinishGameUpdate();
                break;
            case EGameState.NEXT_GAME: NextGameUpdate();
                break;
            case EGameState.END_GAME: EndTournamentUpdate();
                break;
            default: throw new Exception("ERROR : This state cannot exist");
        }
    }




    #endregion


    #region STATES

    private void InitUpdate()
    {
        BoardManager.InitBoard();
        SetCurrentState(EGameState.CHOICE_PLAYERS);
    }

    private void ChoicePlayerUpdate()
    {
        CompetitorsManager.InitPlayer();

        SetCurrentState(EGameState.NEW_GAME);
    }

    private void NewGameUpdate()
    {
        if(m_isFirstTimeInState)
        {
            CurrentPlayer = CompetitorsManager.PlayerOne;
            Debug.Log($"{CompetitorsManager.PlayerOne.GetName()} VS {CompetitorsManager.PlayerOne.GetName()}");
            GraveyardManager.InitGraveyard();
        }

        if (m_currentTimer > 10f)
            SetCurrentState(EGameState.TURN_PLAYER);
        else
            m_currentTimer += Time.deltaTime;

    }

    private void TurnPlayerUpdate()
    {
        if(m_isFirstTimeInState)
        {
            m_isFirstTimeInState = false;
        }

        CurrentPlayer.StartTurn();
    }

    private void ValidationActionUpdate()
    {
        //m_isValidationAccepted = false;

        //if (m_isAskParachute)
        //{
        //    if (MovementValidator.CheckParachutage(m_currentPiecePlayed, m_newPositionAsked, BoardManager.BOARD_ROWS, BoardManager.BOARD_COLUMNS))
        //    {
        //        m_isValidationAccepted = true;
        //        m_currentPiecePlayed.DoMove(m_newPositionAsked);
        //    }
        //    else
        //    {
        //        SetCurrentState(EGameState.UNEXPECTED_ACTION);
        //        m_isValidationAccepted = false;
        //    }
        //}
        //else if(m_isAskMove)
        //{
        //    if (MovementValidator.CheckMovement(m_currentPiecePlayed, m_newPositionAsked, BoardManager.BOARD_ROWS, BoardManager.BOARD_COLUMNS))
        //    {
        //        m_isValidationAccepted = true;
        //    }
        //    else
        //    {
        //        SetCurrentState(EGameState.UNEXPECTED_ACTION);
        //        m_isValidationAccepted = false;
        //    }
        //}
        //else
        //{
        //    throw new Exception("ERROR : Cannot exist !");
        //}

        //if (m_isValidationAccepted)
        //{
        //    MovementManager.DoMovement(m_currentPiecePlayed, m_newPositionAsked);
        //    SetCurrentState(EGameState.CHECK_WIN_CONDITION);
        //}
    }

    private void CheckWinConditionUpdate()
    {
        // CHECK SI ROI SUR DERNIERE LIGNE MANGEABLE AU TOUR SUIVANT

        if (true)
        {
            SetCurrentState(EGameState.FINISH_GAME);
        }
    }

    private void UnexpectedActionUpdate()
    {
        TournamentManager.AddError(CurrentPlayer);
        SetCurrentState(EGameState.NEXT_PLAYER);
    }

    private void NextPlayerUpdate()
    {
        CurrentPlayer = CurrentPlayer is null || CurrentPlayer.GetCamp() == ECampType.PLAYER_TWO ? CompetitorsManager.PlayerOne : CompetitorsManager.PlayerTwo;
        SetCurrentState(EGameState.TURN_PLAYER);
    
    }

    private void FinishGameUpdate()
    {
        TournamentManager.AddVictory(CurrentPlayer);
        SetCurrentState(EGameState.NEXT_GAME);
    }

    private void NextGameUpdate()
    {
        CompetitorsManager.NextPlayers();
        SetCurrentState(EGameState.NEW_GAME);
    }

    private void EndTournamentUpdate()
    {
        if(m_isFirstTimeInState)
        {
            // SHOW RESULT

        }
    }


    private void SetCurrentState(EGameState nextState)
    {
        m_currentGameState = nextState;
        m_isFirstTimeInState = true;
        m_currentTimer = 0f;
    }


    #endregion


    #region Public Methods
    //public void AskToMove(IPawn piece, Vector2 newPosition)
    //{
    //    m_isAskMove = true;
    //    AskAction(piece as Piece, newPosition);
    //}

    //public void AskToParachute(IParachutable piece, Vector2 newPosition)
    //{
    //    m_isAskParachute = true;
    //    AskAction(piece as Piece, newPosition);
    //}

    //private void AskAction(Piece piece, Vector2 newPosition)
    //{
    //    m_currentPiecePlayed = piece;
    //    m_newPositionAsked = newPosition;


    //    SetCurrentState(EGameState.VALIDATION_ACTION);
    //}

    public int GetOrientationFromPawn(IPawn pawn)
    {
        return pawn.GetCurrentOwner().GetCamp() == ECampType.PLAYER_ONE ? 1 : -1;
    }

    public List<IPawn> GetAllPawn()
    {
        // RETURN ALL PAWN IN BOARD

        throw new NotImplementedException();
    }

    public List<IBoardCase> GetAllBoardCase()
    {
        throw new NotImplementedException();
    }

    public void DoAction(IPawn pawnTarget, Vector2Int position, EActionType actionType)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Private members
    private BoardManager m_boardManager;
    private CompetitorsManager m_competitorsManager;
    private MovementManager m_movementManager;
    private GraveyardManager m_graveyardManage;
    private FightManager m_fightManager;
    private TournamentManager m_tournamentManager;

    [SerializeField]
    private BoardData m_boardData;


    //private IPawn m_currentPiecePlayed;
    //private bool m_isAskParachute;
    //private bool m_isAskMove;
    //private Vector2 m_newPositionAsked;
    //private bool m_isValidationAccepted;


    private EGameState m_currentGameState;
    //private EGameState m_nextGameState;


    private float m_currentTimer;
    private bool m_isFirstTimeInState = true;

    private ICompetitor m_currentPlayerTurn;
    #endregion

}
