using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Gameplay Settings")]

    [SerializeField]
    private ScriptPlayer[] m_players;
    
    [SerializeField]
    private bool m_restartScoreIfBossTouchesPlayer = true;
    
    [SerializeField]
    private int m_timerTime = 90;
    

    private float m_player1Score;

    private float m_player2Score;

    private Enumerations.GameState m_state;

    public ScriptPlayer[] Players { get => m_players; set => m_players = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }

        InitializeMainMenu();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(m_state == Enumerations.GameState.Gameplay)
        {
            InitializeGameplay();
            InitializeGameplayUI();
        }
    }

    /// <summary>
    /// Initializes Game Manager
    /// </summary>
    private void InitializeMainMenu()
    {
        m_state = Enumerations.GameState.MainMenu;
    }

    /// <summary>
    /// Initializes Game Manager
    /// </summary>
    private void InitializeGameplay()
    {
        m_player1Score = 0;
        m_player2Score = 0;
    }

    /// <summary>
    ///  Initializes UI relation to GM
    /// </summary>
    private void InitializeGameplayUI()
    {
        UIManager.Instance.SetPlayersScores(m_player1Score, m_player2Score);
        UIManager.Instance.InitTimer(m_timerTime);
    }

    /// <summary>
    /// Called when boss touches a player
    /// </summary>
    /// <param name="player"></param>
    public void BossTouchedPlayer(Enumerations.Player player)
    {
        if(m_restartScoreIfBossTouchesPlayer)
        {
            switch (player)
            {
                case Enumerations.Player.Player1:
                    m_player1Score = 0;
                    UIManager.Instance.SetPlayer1Score(m_player1Score);
                    break;

                case Enumerations.Player.Player2:
                    m_player2Score = 0;
                    UIManager.Instance.SetPlayer1Score(m_player2Score);
                    break;
            }
        }
        else
        {
            // 
        }
    }

    public void GoToGameplayScene()
    {
        m_state = Enumerations.GameState.Gameplay;
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenuScene()
    {
        m_state = Enumerations.GameState.MainMenu;
        SceneManager.LoadScene(0);
    }

    public void GoalReached(Enumerations.Player player)
    {

    }
}
