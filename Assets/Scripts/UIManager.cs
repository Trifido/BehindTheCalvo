using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages UI
/// </summary>
public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text m_player1ScoreText;

    [SerializeField]
    private Text m_player2ScoreText;

    [SerializeField]
    private Text m_timerText;
    

    private GameTimer m_timer;

    public static UIManager Instance;

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_timer = new GameTimer();
    }

    private void Update()
    {
        m_timer.UpdateTimer();
    }

    /// <summary>
    /// Sets player 1 score
    /// </summary>
    /// <param name="score"></param>
    public void SetPlayer1Score(float score)
    {
        m_player1ScoreText.text = score.ToString();
    }

    /// <summary>
    /// Sets player 2 score
    /// </summary>
    /// <param name="score"></param>
    public void SetPlayer2Score(float score)
    {
        m_player2ScoreText.text = score.ToString();
    }

    /// <summary>
    /// Sets both players scores
    /// </summary>
    /// <param name="score1"></param>
    /// <param name="score2"></param>
    public void SetPlayersScores(float score1, float score2)
    {
        m_player1ScoreText.text = score1.ToString();
        m_player2ScoreText.text = score2.ToString();
    }

    /// <summary>
    /// Begins Timer
    /// </summary>
    /// <param name="seconds"></param>
    public void InitTimer(float seconds)
    {
        m_timerText.text = seconds.ToString();
        m_timer.Init(seconds);
    }

    
    /// <summary>
    /// Timer
    /// </summary>
    private class GameTimer
    {
        private float m_time;
        private bool m_playing = false;

        public void Init(float seconds)
        {
            m_time = seconds;
            m_playing = true;
        }

        public void Stop()
        {
            m_playing = false;
        }

        public void UpdateTimer()
        {
            if (m_playing)
            {
                m_time -= Time.deltaTime; 
            }
        }
    }
}
