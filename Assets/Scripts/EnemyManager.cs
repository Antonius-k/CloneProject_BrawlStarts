using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // 적 캐릭터가 출현할 위치를 담을 배열
    public Transform[] point;
    // 적 캐릭터 프리팹을 저장할 변수
    public GameObject[] enemy;
    // 적 캐릭터를 생성할 주기
    public float createTime = 2.0f;
    // 적 캐릭터의 최대 생성 개수
    public int maxEnemy = 3;
    // 게임 종료 여부를 판단
    public bool isGameOver = false;

    public int enemyPoolSize = 3;
    public List<GameObject> enemyPool = new List<GameObject>();
    public static EnemyManager Instance;

    public bool enemyCheck;
    // Enemy 위치(마지막 위치)
    public Transform enemyPosition;
    //0721 PlayGameManager에 있는 e_ZemCount를 EnemyManager에 관리
    public int e_ZemCount;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 에너미를 enemyPool에 할당 하고 싶다.
        enemyPool.Clear();
        enemyPool.Add(Instantiate(Resources.Load("Prefabs/Heroes/1S") as GameObject));
        enemyPool.Add(Instantiate(Resources.Load("Prefabs/Heroes/204") as GameObject));
        enemyPool.Add(Instantiate(Resources.Load("Prefabs/Heroes/206") as GameObject));

        StartCoroutine(CreateEnemy());
    }

    void Update()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            enemyPosition = transform;
        }
        enemyGameObjectCheck();
    }
    void enemyGameObjectCheck()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            enemyPosition = GameObject.FindWithTag("Enemy").transform;
            enemyCheck = true;
        }
        else
        {
            enemyCheck = false;
        }
    }
    IEnumerator CreateEnemy()
    {

        while (!isGameOver)
        {
            
            List<int> dieIndex = new List<int>();

            for (int i = 0; i < enemyPool.Count; i++)
            {
                if (!enemyPool[i].activeInHierarchy)
                {
                    dieIndex.Add(i);
                }
            }

            if (dieIndex.Count > 0)
            {
                yield return new WaitForSeconds(createTime);

                for (int i = 0; i < dieIndex.Count; i++)
                {
                    enemyPool[dieIndex[i]].SetActive(true);
                    enemyPool[dieIndex[i]].transform.position = point[dieIndex[i]].position;

                }
            }
            else yield return null;
            //yield return null;
        }
    }
}
