using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : MonoBehaviour
{
    float speed = 10f;


    //총알을 생성후 Target에게 날아갈 변수
    public Transform target;
    //발사될 총알 오브젝트
    
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        //transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
        Vector3 dir = transform.forward;
        transform.position += dir * speed * Time.deltaTime;

        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

}
