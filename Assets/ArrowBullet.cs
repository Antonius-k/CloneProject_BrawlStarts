using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : MonoBehaviour
{
    float speed = 10f;


    //�Ѿ��� ������ Target���� ���ư� ����
    public Transform target;
    //�߻�� �Ѿ� ������Ʈ
    
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        //�ι�° �Ķ���Ϳ� Space.World�� �������ν� Rotation�� ���� ���� ������ ������
        //transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
        Vector3 dir = transform.forward;
        transform.position += dir * speed * Time.deltaTime;

        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

}
