using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//�ش� ĳ������ ���ݰ���
public class Stat : MonoBehaviour
{
    //�ش� ������Ʈ ĳ������ �����̾�
    public int hp = 100;
    public int power = 20;
    public int zem;
    public int trophy = 0;

    int damage; //���ݹ��� ������

    //�����̴����� ����Ұ�
    float hpMax = 100;
    //public GameObject sliderBar;
    public Slider hpslider;


    //ĳ���� �ִϸ��̼�
    Animator animator;
    public int p_zemCount;
    public GameObject hitEffect;
    
    GameObject enemy;
    public GameObject playerHud;
    public Transform playerHudPos;

    public int HP
    {
        get{return hp;}
        set
        {
            hp = value;
            
        }
    }
    public int POWER
    {
        get { return power; }
        set
        {
            power = value;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    GameObject enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemyDamage = GameObject.FindWithTag("Enemy");
        if (enemyDamage != null)
        {
            // ó�� �ʵ忡 �� Enemy���� �������� ������
            damage = enemyDamage.GetComponent<Enemy>().enemyPower;
        }        
        hpslider.value = HP / hpMax;
        Die();
    }

    void Die()
    {
        if(HP <= 0)
        {
            animator.SetBool("isDie", true);
            //������ �ִ� ���� ����ŭ ���ڸ��� �����ְ� �ʱ�ȭ �����ְ�
            StartCoroutine(ZemRespawnManager.Instance.PlayerDieZemRespawn(PlayerGameManager.Instance.p_ZemCount, gameObject));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            HP -= damage;
            HitManager.Instance.Hit();
            GameObject addObject = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(addObject, 2f);
            
            //���ʹ̺ҷ�����
            Destroy(collision.gameObject);
            
            if (PlayerGameManager.Instance.playerCheck)
            {
                GameObject hudText = Instantiate(playerHud);
                // ������ �ؽ�Ʈ ������Ʈ�� �θ� hudPos(ĵ����)�� �����Ѵ�.
                hudText.transform.SetParent(playerHudPos);
                hudText.transform.position = playerHudPos.position;
                hudText.GetComponent<PlayerDamageText>().playerDamage = enemy.GetComponent<Enemy>().enemyPower;
            }
        }
    }
}
