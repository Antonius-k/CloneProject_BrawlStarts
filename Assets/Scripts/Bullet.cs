using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 앞으로 날아가는 총알을 만들고 싶다.
//필요 성분 : 총알속도
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    //사정거리
    public float fireDistance = 10f;

    //총알 초기 위치
    Transform fireTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 앞으로 날아가는 총알을 만들고 싶다.
        // 1. 방향을 구한다.
        Vector3 dir = transform.forward;
        // 2. 날아가고 싶다.
        transform.position += dir * speed * Time.deltaTime;
    }


      
    
    
}
