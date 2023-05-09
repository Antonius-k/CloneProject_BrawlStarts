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

            //�׳� 5�ʵڿ� ������ٷ� ó������..
            Destroy(bullet, 5f);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ABMove());
        }


    }
    
    //�߻� �� 2�� �� �Ѿ� ��ġ�� �ݿ��� �Ѿ� ������
    IEnumerator ABMove()
    {
        //1��° �Ѿ� ����
        GameObject arrowBullet = Instantiate(ArrowBullet, firePosition.transform.position, firePosition.transform.rotation);
        
        yield return new WaitForSeconds(0.5f);
        Transform tr = arrowBullet.transform; 
        float x = tr.rotation.x;
        //float y = tr.rotation.x;
        float z = tr.rotation.z;
        //1��° �Ѿ� ����
        Destroy(arrowBullet);
        for (int i = 0; i < 360; i += 13)
        {
            //2��° �Ѿ� ����
            //Y�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Y�� i�� �����Ѵ�.
            GameObject arrowBullet_2 = Instantiate(ArrowBullet, tr.transform.position, Quaternion.Euler(x, i, z));
            //arrowBullet_2.transform.position = tr.transform.position;
            //arrowBullet_2.transform.rotation = Quaternion.Euler(x, i, z);
            //�ι�° �Ѿ� 2�ʵ� ����
            Destroy(arrowBullet_2, 2f);
        }
        yield return null;
    }
}
