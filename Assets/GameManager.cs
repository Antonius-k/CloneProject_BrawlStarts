using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 게임의 진행 상태를 관리하고 싶다.
// 필요속성 : 현재상태, Ready, Start, Playing, GameOver
public class GameManager : MonoBehaviour
{
    // 필요속성 : 현재상태, Ready, Start, Playing, GameOver
    //[System.NonSerialized]
    public enum GameState
    {
        Ready,
        Start,
        Playing,
        GameOver
    };

    //[SerializeField]
    public GameState m_state = GameState.Ready;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_state)
        {
            case GameState.Ready:
                ReadyState();
                break;
            case GameState.Start:
                StartState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    // 2초간 기다리렸다가 상태를 Start 로 변경하고 싶다.
    float currentTime = 0;
    public float readyDelayTime = 4;
    public float startDelayTime = 2;
    public float gameOverDelayTime = 4;
    private void ReadyState()
    {
        // 2초간 기다리렸다가 상태를 Start 로 변경하고 싶다.
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 시간이 됐으니까.
        if (currentTime > readyDelayTime)
        {
            // 3. 상태를 Start 로 변경
            m_state = GameState.Start;
            currentTime = 0;
        }
    }

    // 2초간 기다리렸다가 상태를 Playing 로 변경하고 싶다.
    private void StartState()
    {
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 시간이 됐으니까.
        if (currentTime > startDelayTime)
        {
            m_state = GameState.Playing;
            currentTime = 0;
        }
    }

    private void PlayingState()
    {

    }

    private void GameOverState()
    {
        
    }
}
