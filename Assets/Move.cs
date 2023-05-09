using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1;
    Transform modelObj;

    Vector3 dir;

    Rigidbody rigid;
    Animator animator;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * speed * Time.deltaTime;

        //움직이지만 않으면 됨
        animator.SetBool("isRun", dir != Vector3.zero);

        transform.LookAt(transform.position + dir);

        //점프 누르면 승리 모션
        if(Input.GetButtonDown("Jump")){
            animator.SetBool("isVictory",true);
        }
        if(Input.GetButtonUp("Jump"))
        {
            animator.SetBool("isVictory", false);
        }
    }
}
