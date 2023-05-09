using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // �� ĳ���Ͱ� ������ ��ġ�� ���� �迭
    public Transform[] point;
    // �� ĳ���� �������� ������ ����
    public GameObject[] enemy;
    // �� ĳ���͸� ������ �ֱ�
    public float createTime = 2.0f;
    // �� ĳ������ �ִ� ���� ����
    public int maxEnemy = 3;
    // ���� ���� ���θ� �Ǵ�
    public bool isGameOver = false;

    public int enemyPoolSize = 3;
    public List<GameObject> enemyPool = new List<GameObject>();
    public static EnemyManager Instance;

    public bool enemyCheck;
    // Enemy ��ġ(������ ��ġ)
    public Transform enemyPosition;
    //0721 PlayGameManager�� �ִ� e_ZemCount�� EnemyManager�� ����
    public int e_ZemCount;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���ʹ̸� enemyPool�� �Ҵ� �ϰ� �ʹ�.
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
