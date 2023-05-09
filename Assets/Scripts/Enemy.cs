using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // 이동속도
    public float speed = 5f;
    // 타겟
    public Transform target;
    // Enemy 총알공장
    public GameObject bulletFactory;
    // 총구위치
    public GameObject firePosition;
    
    // 요원
    NavMeshAgent agent;

    // Enemy 체력
    public int hp = 100;
    // Enemy 최대 체력
    int maxHP = 100;
    // Enemy HP Slider 변수
    public Slider hpSlider;

    // Enemy의 공격력
    public int enemyPower = 20;
    

    public GameObject hud;
    public Transform hudPos;

    Transform firstPosition;
    GameObject player;

    public State state;
    Rigidbody rb;

    float currentTime = 0;
    float attackDelay = 1f;
    float attackDistance = 8f;

    //Animator
    Animator animator;
    public Transform enemyTransform;

    public int p_zemCount;

    // 피격 이펙트
    public GameObject hitEffect;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Damaged,
        Die
    }

    private void OnEnable()
    {
        hp = maxHP;
        state = State.Idle;
        agent = GetComponent<NavMeshAgent>();

        // NavMesh off
        agent.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        firstPosition = transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            return;
        }

        animator.SetBool("isRun", enemyTransform.position != Vector3.zero);
        player = GameObject.FindWithTag("Player");
        //만약 플레이어가 없으면 아래로 쭉 안돌게
        if (player == null) return; 
        
        target = player.transform;

        // 현재 hp를 HP Slider의 value애 반영한다.
        hpSlider.value = (float)hp / maxHP;

        // 현재 상태를 체크해 해당 상태별로 정해진 기능을 수행하게 하고 싶다.
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Damaged:
                Damaged();
                break;
            case State.Die:
                Die();
                break;
        }
    }

    private void Idle()
    {
        state = State.Move;
    }


    private void Move()
    {
        if (agent.enabled == false)
            agent.enabled = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // target 방향으로 이동하다가 target이 공격거리안에 들어오면 Attack으로 전이하고 싶다.
        // 1. target 방향으로 이동하고 싶다. 
        Vector3 dir = (target.position - transform.position).normalized;
        agent.destination = target.position;
        // 2. 나와 target의 거리를 구해서
        float distance = Vector3.Distance(transform.position, target.position);
        // 3. 만약 그 거리가 공격거리보다 작으면
        if (distance < attackDistance)
        {
            // 4. Attack상태로 전이하고 싶다.
            state = State.Attack;
            //currentTime = attackDelay;
        }
    }

   
    private void Attack()
    {
        if (PlayerGameManager.Instance.playerCheck)
        {
            agent.destination = target.position;
            if (Vector3.Distance(transform.position, target.position) < attackDistance)
            {
                // 일정한 시간마다 플레이어를 공격한다.
                currentTime += Time.deltaTime;
                if (currentTime > attackDelay)
                {
                    //print(Time.time);
                    GameObject bullet = Instantiate(bulletFactory);
                    bullet.transform.position = firePosition.transform.position;
                    bullet.transform.rotation = firePosition.transform.rotation;

                    Destroy(bullet, 2f);
                    currentTime = 0;
                }
            }
            else
            {
                state = State.Move;
                currentTime = 0;
            }
        }
        else{
            agent.destination = firstPosition.transform.position;
        }
    }


    private void Damaged()
    {
        // hp를 깎는다.
        //hp -= PlayerGameManager.Instance.power;
        if (PlayerGameManager.Instance.playerCheck)
        {
            hp -= GameObject.FindWithTag("Player").GetComponent<Stat>().POWER;
        }
        if (hp <= 0)
        {
            state = State.Die;
            print("DieDie");
            agent.enabled = false;
        }
    }
    private void Die()
    {
        if (hp <= 0)
        {
            animator.SetBool("isDie", true);
            // 죽으면 죽은자리에서 가지고 있는 보석을 퍼트려서 드롭하고 싶다.
            StartCoroutine(ZemRespawnManager.Instance.EnemyDieZemRespawn(EnemyManager.Instance.e_ZemCount, gameObject));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 만약 부딪힌 녀석이 총알이라면
        //if (collision.gameObject.tag=="PlayerBullet") 수정
        if (collision.gameObject.tag == "Bullet")
        {
            //0721
            GameObject hit_Effect = Instantiate(hitEffect);
            hit_Effect.transform.position = transform.position;
            Destroy(hit_Effect, 2f);

            // Bullet 제거
            Destroy(collision.gameObject);
            // hp를 깎는다.

            Damaged();
            GameObject hudText = Instantiate(hud);
            // 생성한 텍스트 오브젝트의 부모를 hudPos(캔버스)로 지정한다.
            hudText.transform.SetParent(hudPos);
            hudText.transform.position = hudPos.position;
            hudText.GetComponent<DamageText>().damage = player.GetComponent<Stat>().POWER;
            
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            //레이어로 변경할것
        }
    }

    /* 
    private void OnCollisionExit(Collision collision)
    {
        if(target != null)
        {
            rb.velocity = Vector3.zero;
            agent.enabled = true;
            agent.SetDestination(target.position);

        }
    }*/
}