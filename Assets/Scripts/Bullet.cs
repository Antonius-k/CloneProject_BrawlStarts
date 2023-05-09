using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���ư��� �Ѿ��� ����� �ʹ�.
//�ʿ� ���� : �Ѿ˼ӵ�
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    //�����Ÿ�
    public float fireDistance = 10f;

    //�Ѿ� �ʱ� ��ġ
    Transform fireTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���ư��� �Ѿ��� ����� �ʹ�.
        // 1. ������ ���Ѵ�.
        Vector3 dir = transform.forward;
        // 2. ���ư��� �ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }


      
    
    
}
