using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // �̵��ӵ�
    public float speed = 5f;
    // Ÿ��
    public Transform target;
    // Enemy �Ѿ˰���
    public GameObject bulletFactory;
    // �ѱ���ġ
    public GameObject firePosition;
    
    // ���
    NavMeshAgent agent;

    // Enemy ü��
    public int hp = 100;
    // Enemy �ִ� ü��
    int maxHP = 100;
    // Enemy HP Slider ����
    public Slider hpSlider;

    // Enemy�� ���ݷ�
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

    // �ǰ� ����Ʈ
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
        //���� �÷��̾ ������ �Ʒ��� �� �ȵ���
        if (player == null) return; 
        
        target = player.transform;

        // ���� hp�� HP Slider�� value�� �ݿ��Ѵ�.
        hpSlider.value = (float)hp / maxHP;

        // ���� ���¸� üũ�� �ش� ���º��� ������ ����� �����ϰ� �ϰ� �ʹ�.
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

        // target �������� �̵��ϴٰ� target�� ���ݰŸ��ȿ� ������ Attack���� �����ϰ� �ʹ�.
        // 1. target �������� �̵��ϰ� �ʹ�. 
        Vector3 dir = (target.position - transform.position).normalized;
        agent.destination = target.position;
        // 2. ���� target�� �Ÿ��� ���ؼ�
        float distance = Vector3.Distance(transform.position, target.position);
        // 3. ���� �� �Ÿ��� ���ݰŸ����� ������
        if (distance < attackDistance)
        {
            // 4. Attack���·� �����ϰ� �ʹ�.
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
                // ������ �ð����� �÷��̾ �����Ѵ�.
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
        // hp�� ��´�.
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
            // ������ �����ڸ����� ������ �ִ� ������ ��Ʈ���� ����ϰ� �ʹ�.
            StartCoroutine(ZemRespawnManager.Instance.EnemyDieZemRespawn(EnemyManager.Instance.e_ZemCount, gameObject));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �ε��� �༮�� �Ѿ��̶��
        //if (collision.gameObject.tag=="PlayerBullet") ����
        if (collision.gameObject.tag == "Bullet")
        {
            //0721
            GameObject hit_Effect = Instantiate(hitEffect);
            hit_Effect.transform.position = transform.position;
            Destroy(hit_Effect, 2f);

            // Bullet ����
            Destroy(collision.gameObject);
            // hp�� ��´�.

            Damaged();
            GameObject hudText = Instantiate(hud);
            // ������ �ؽ�Ʈ ������Ʈ�� �θ� hudPos(ĵ����)�� �����Ѵ�.
            hudText.transform.SetParent(hudPos);
            hudText.transform.position = hudPos.position;
            hudText.GetComponent<DamageText>().damage = player.GetComponent<Stat>().POWER;
            
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            //���̾�� �����Ұ�
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