using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public Transform target;
    public GameObject ArrowBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);

            bullet.transform.position = firePosition.transform.position;
            bullet.transform.rotation = firePosition.transform.rotation;

            //그냥 5초뒤에 사라진다로 처리하자..
            Destroy(bullet, 5f);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ABMove());
        }


    }
    
    //발사 후 2초 뒤 총알 위치에 반원의 총알 퍼지게
    IEnumerator ABMove()
    {
        //1번째 총알 생성
        GameObject arrowBullet = Instantiate(ArrowBullet, firePosition.transform.position, firePosition.transform.rotation);
        
        yield return new WaitForSeconds(0.5f);
        Transform tr = arrowBullet.transform; 
        float x = tr.rotation.x;
        //float y = tr.rotation.x;
        float z = tr.rotation.z;
        //1번째 총알 삭제
        Destroy(arrowBullet);
        for (int i = 0; i < 360; i += 13)
        {
            //2번째 총알 생성
            //Y에 값이 변해야 회전이 이루어지므로, Y에 i를 대입한다.
            GameObject arrowBullet_2 = Instantiate(ArrowBullet, tr.transform.position, Quaternion.Euler(x, i, z));
            //arrowBullet_2.transform.position = tr.transform.position;
            //arrowBullet_2.transform.rotation = Quaternion.Euler(x, i, z);
            //두번째 총알 2초뒤 삭제
            Destroy(arrowBullet_2, 2f);
        }
        yield return null;
    }
}
