using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFire : MonoBehaviour
{   
    //총알 공장
    public GameObject bulletFactory;

    //총구 위치
    public GameObject firePosition;

    //탄창에 넣을 총알 개수
    public int bulletPoolSize = 10;
    //오브젝트풀 배열
    public List<GameObject> bulletPool = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletPool.Add(bullet);
            bullet.SetActive(false);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        // 발사 버튼을 누르면 총알이 발사되게 하고싶다.
        // 1. 만약, 발사 버튼을 눌렀으면
        if (Input.GetButtonDown("Fire1"))
        {
            //탄창에 총알이 있다면
            if (bulletPool.Count > 0)
            {
                //3. 비활성화된 총알을 하나 가져온다.
                GameObject bullet = bulletPool[0];
                bullet.SetActive(true);
                bulletPool.Remove(bullet);
                
                //총알 총구위치로
                bullet.transform.position = firePosition.transform.position;
                bullet.transform.rotation = firePosition.transform.rotation;
            }
        }else if (Input.GetButtonDown("Fire2"))
        {
            //폭탄 던지기 처리
        }
    }    
}
