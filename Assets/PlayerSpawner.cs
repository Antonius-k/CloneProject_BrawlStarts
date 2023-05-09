using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    //������ �÷��̾� ������

    //��ȯ ��ġ
    public Transform spawnPoint;
    //public PlayerData[] playerDatas;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGameManager.Instance.playerCheck == false)
        {
            GameObject player = Instantiate(Resources.Load("Prefabs/Heroes/Player_Jester") as GameObject);
            player.transform.position = spawnPoint.position;
        }
    }
}
