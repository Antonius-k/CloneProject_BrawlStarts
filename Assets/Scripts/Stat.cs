using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//해당 캐릭터의 스텟관리
public class Stat : MonoBehaviour
{
    //해당 오브젝트 캐릭터의 스텟이야
    public int hp = 100;
    public int power = 20;
    public int zem;
    public int trophy = 0;

    int damage; //공격받은 데미지

    //슬라이더에서 사용할거
    float hpMax = 100;
    //public GameObject sliderBar;
    public Slider hpslider;


    //캐릭터 애니메이션
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
            // 처음 필드에 깔린 Enemy들이 다죽으면 오류뜸
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
            //가지고 있는 보석 수만큼 그자리에 떨궈주고 초기화 시켜주고
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
            
            //에너미불렛제거
            Destroy(collision.gameObject);
            
            if (PlayerGameManager.Instance.playerCheck)
            {
                GameObject hudText = Instantiate(playerHud);
                // 생성한 텍스트 오브젝트의 부모를 hudPos(캔버스)로 지정한다.
                hudText.transform.SetParent(playerHudPos);
                hudText.transform.position = playerHudPos.position;
                hudText.GetComponent<PlayerDamageText>().playerDamage = enemy.GetComponent<Enemy>().enemyPower;
            }
        }
    }
}
