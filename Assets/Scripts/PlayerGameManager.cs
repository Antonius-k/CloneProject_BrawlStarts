using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�÷��̾� ���� �Ŵ������� �÷��̾��� ���� ���� ���� ���ش�.

public class PlayerGameManager : MonoBehaviour
{
    public static PlayerGameManager Instance = null;

    public int p_ZemCount;
    public int e_ZemCount;
    
    public int power = 20;

    //�÷��̾� ����ִ��� üũ
    public bool playerCheck;
    //�÷��̾� ��ġ(������ ��ġ)
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
        
        //ĳ���� ����Ʈ�� �ҷ���


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
