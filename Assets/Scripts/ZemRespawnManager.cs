using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZemRespawnManager : MonoBehaviour
{
    //���� ������ �ٴ� ������
    BoxCollider rangeCollider;
    
    //��ȯ�� ��
    public GameObject zem;
    
    //�ִ� �� ���� ����
    public int zemSpawnLimit;
    
    //������ �� ����
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
        

        //������ �� ī��Ʈ
        zemCount = GameObject.FindGameObjectsWithTag("Zem");
    }

    //�ڷ�ƾ���� 5�� �ݺ�
    IEnumerator RandomRespawn_Coroutine(int zemSpawnLimit)
    {
        yield return new WaitForSeconds(4f);
        int i = 0;
        while (i < zemSpawnLimit)
        {
            GameObject instantZem = Instantiate(zem, transform.position, Quaternion.identity);
            Rigidbody rb = instantZem.GetComponent<Rigidbody>();

            rb.AddForce(new Vector3(Random.Range(-7, 7), Random.Range(-7, 7), Random.Range(-7, 7)) * 1, ForceMode.Impulse);

            //���� ������� ���� 5���� �Ѿ�� �����.
            //�� ��ġ���� ��������
            yield return new WaitForSeconds(4f);
            i++;
        } 
    }
    // �ð�
    public float time;
    // ���հ�
    float deltaAngle;
    // ���� �ð� ����
    //public float deltaFireTime = 2f;
    float currentTime;
    Vector3 dir;
    // ���� ����
    float currentAngle;
    //������ ���� �÷��̾� ��ġ���� ������ ������ Ƣ�°�
    public IEnumerator PlayerDieZemRespawn(int playerZemCount,GameObject gameObject)
    {

        yield return new WaitForSeconds(2f);
        PlayerGameManager.Instance.p_ZemCount = 0;
        Destroy(gameObject);

        //������ time��ŭ �ִٰ� ����,�־�� �ٷ� ����
        currentTime = time;
        
        deltaAngle = playerZemCount / 360;

        // ���� ������ �ʱ�ȭ
        currentAngle = 0;
        
        for (int i = 0; i < playerZemCount; i++)
        {
            //GameObject zemGameObject = Instantiate(zem, PlayerGameManager.Instance.playerPosition.transform.position, Quaternion.identity);
            //���ʹϾ�.���Ϸ� * ���� = ���ʹϾ���Ϸ� �ޱۿ��� ȸ����Ų ���� ���� 001;
            //Vector3 x = Quaternion.Euler(0, currentAngle, 13) * Vector3.up;

            GameObject zemGameObject = Instantiate(zem, PlayerGameManager.Instance.playerPosition.transform.position, Quaternion.Euler(0, deltaAngle, 0));


            // �Ѱ��� , deltaAngel = �ѹ��� ���ư� ��
            currentAngle += deltaAngle;
            
            zemGameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1,1), ForceMode.Impulse);
        }
        //�������� �ǳʶپ��ټ� �ְ�
        yield return null;
    }

    public IEnumerator EnemyDieZemRespawn(int enemyZemCount, GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        EnemyManager.Instance.e_ZemCount = 0;
        //Destroy(gameObject);

        //������ time��ŭ �ִٰ� ����,�־�� �ٷ� ����
        currentTime = time;

        deltaAngle = enemyZemCount / 360;

        // ���� ������ �ʱ�ȭ
        currentAngle = 0;

        for (int i = 0; i < enemyZemCount; i++)
        {
            GameObject zemGameObject = Instantiate(zem, EnemyManager.Instance.enemyPosition.transform.position, Quaternion.identity);
            //���ʹϾ�.���Ϸ� * ���� = ���ʹϾ���Ϸ� �ޱۿ��� ȸ����Ų ���� ���� 001;
            //Vector3 x = Quaternion.Euler(0, currentAngle, 20) * Vector3.forward;
            //������
            Vector3 x = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward;

            // �Ѱ��� , deltaAngel = �ѹ��� ���ư� ��
            currentAngle += deltaAngle;

            zemGameObject.GetComponent<Rigidbody>().AddForce(x * 1, ForceMode.Impulse);
        }
        gameObject.SetActive(false);
        //�������� �ǳʶپ��ټ� �ְ�
        yield return null;
    }
}
