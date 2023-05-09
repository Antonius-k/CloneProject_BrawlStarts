using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //ºÎµúÈù ´ë»óÀÌ ÃÑ¾ËÀÌ¶ó¸é
        if(other.gameObject.name.Contains("Bullet"))
        {
            //ºÎµúÈù (ÃÑ¾Ë)false
            other.gameObject.SetActive(false);
            //ÃÑ¾Ë ÀåÀü
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletPool.Add(other.gameObject);
        }
    }
    
}
