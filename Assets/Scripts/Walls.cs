using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ����� �Ѿ��̶��
        if(other.gameObject.name.Contains("Bullet"))
        {
            //�ε��� (�Ѿ�)false
            other.gameObject.SetActive(false);
            //�Ѿ� ����
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletPool.Add(other.gameObject);
        }
    }
    
}
