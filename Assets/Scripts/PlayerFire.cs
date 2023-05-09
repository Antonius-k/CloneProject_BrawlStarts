using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFire : MonoBehaviour
{   
    //�Ѿ� ����
    public GameObject bulletFactory;

    //�ѱ� ��ġ
    public GameObject firePosition;

    //źâ�� ���� �Ѿ� ����
    public int bulletPoolSize = 10;
    //������ƮǮ �迭
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
        // �߻� ��ư�� ������ �Ѿ��� �߻�ǰ� �ϰ�ʹ�.
        // 1. ����, �߻� ��ư�� ��������
        if (Input.GetButtonDown("Fire1"))
        {
            //źâ�� �Ѿ��� �ִٸ�
            if (bulletPool.Count > 0)
            {
                //3. ��Ȱ��ȭ�� �Ѿ��� �ϳ� �����´�.
                GameObject bullet = bulletPool[0];
                bullet.SetActive(true);
                bulletPool.Remove(bullet);
                
                //�Ѿ� �ѱ���ġ��
                bullet.transform.position = firePosition.transform.position;
                bullet.transform.rotation = firePosition.transform.rotation;
            }
        }else if (Input.GetButtonDown("Fire2"))
        {
            //��ź ������ ó��
        }
    }    
}
