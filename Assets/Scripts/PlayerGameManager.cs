using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//플레이어 게임 매니저에서 플레이어의 보석 갯수 관리 해준다.

public class PlayerGameManager : MonoBehaviour
{
    public static PlayerGameManager Instance = null;

    public int p_ZemCount;
    public int e_ZemCount;
    
    public int power = 20;

    //플레이어 살아있는지 체크
    public bool playerCheck;
    //플레이어 위치(마지막 위치)
    public Transform playerPosition;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
        //캐릭터 리스트를 불러와


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            playerPosition = transform;
        }
        playerGameObjectCheck();
    }
    
    void playerGameObjectCheck() {
        if (GameObject.FindWithTag("Player"))
        {
            playerPosition = GameObject.FindWithTag("Player").transform;
            playerCheck = true;
        }else
        {
            playerCheck = false;
        }

    }
   
}
