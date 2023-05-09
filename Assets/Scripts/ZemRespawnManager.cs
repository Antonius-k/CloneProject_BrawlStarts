using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZemRespawnManager : MonoBehaviour
{
    //랜덤 생성할 바닥 사이즈
    BoxCollider rangeCollider;
    
    //소환할 젬
    public GameObject zem;
    
    //최대 젬 스폰 갯수
    public int zemSpawnLimit;
    
    //생성된 젬 갯수
    GameObject[] zemCount;

    public static ZemRespawnManager Instance = null;

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
        StartCoroutine(RandomRespawn_Coroutine(zemSpawnLimit));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            return;
        }
        

        //생성된 젬 카운트
        zemCount = GameObject.FindGameObjectsWithTag("Zem");
    }

    //코루틴으로 5번 반복
    IEnumerator RandomRespawn_Coroutine(int zemSpawnLimit)
    {
        yield return new WaitForSeconds(4f);
        int i = 0;
        while (i < zemSpawnLimit)
        {
            GameObject instantZem = Instantiate(zem, transform.position, Quaternion.identity);
            Rigidbody rb = instantZem.GetComponent<Rigidbody>();

            rb.AddForce(new Vector3(Random.Range(-7, 7), Random.Range(-7, 7), Random.Range(-7, 7)) * 1, ForceMode.Impulse);

            //만약 만들어진 젬이 5개를 넘어가면 멈춘다.
            //이 위치에서 랜덤값을
            yield return new WaitForSeconds(4f);
            i++;
        } 
    }
    // 시간
    public float time;
    // 사잇각
    float deltaAngle;
    // 보석 시간 간격
    //public float deltaFireTime = 2f;
    float currentTime;
    Vector3 dir;
    // 누적 각도
    float currentAngle;
    //죽으면 보석 플레이어 위치에서 주위로 파파팍 튀는거
    public IEnumerator PlayerDieZemRespawn(int playerZemCount,GameObject gameObject)
    {

        yield return new WaitForSeconds(2f);
        PlayerGameManager.Instance.p_ZemCount = 0;
        Destroy(gameObject);

        //없으면 time만큼 있다가 생성,있어야 바로 생성
        currentTime = time;
        
        deltaAngle = playerZemCount / 360;

        // 누적 각도를 초기화
        currentAngle = 0;
        
        for (int i = 0; i < playerZemCount; i++)
        {
            //GameObject zemGameObject = Instantiate(zem, PlayerGameManager.Instance.playerPosition.transform.position, Quaternion.identity);
            //쿼터니언.오일러 * 벡터 = 쿼터니언오일러 앵글에서 회전시킨 값에 벡터 001;
            //Vector3 x = Quaternion.Euler(0, currentAngle, 13) * Vector3.up;

            GameObject zemGameObject = Instantiate(zem, PlayerGameManager.Instance.playerPosition.transform.position, Quaternion.Euler(0, deltaAngle, 0));


            // 총각도 , deltaAngel = 한번에 돌아간 각
            currentAngle += deltaAngle;
            
            zemGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1,1), ForceMode.Impulse);
        }
        //프레임을 건너뛰어줄수 있게
        yield return null;
    }

    public IEnumerator EnemyDieZemRespawn(int enemyZemCount, GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        EnemyManager.Instance.e_ZemCount = 0;
        //Destroy(gameObject);

        //없으면 time만큼 있다가 생성,있어야 바로 생성
        currentTime = time;

        deltaAngle = enemyZemCount / 360;

        // 누적 각도를 초기화
        currentAngle = 0;

        for (int i = 0; i < enemyZemCount; i++)
        {
            GameObject zemGameObject = Instantiate(zem, EnemyManager.Instance.enemyPosition.transform.position, Quaternion.identity);
            //쿼터니언.오일러 * 벡터 = 쿼터니언오일러 앵글에서 회전시킨 값에 벡터 001;
            //Vector3 x = Quaternion.Euler(0, currentAngle, 20) * Vector3.forward;
            //수정중
            Vector3 x = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward;

            // 총각도 , deltaAngel = 한번에 돌아간 각
            currentAngle += deltaAngle;

            zemGameObject.GetComponent<Rigidbody>().AddForce(x * 1, ForceMode.Impulse);
        }
        gameObject.SetActive(false);
        //프레임을 건너뛰어줄수 있게
        yield return null;
    }
}
