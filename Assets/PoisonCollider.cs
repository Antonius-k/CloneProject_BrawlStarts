using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCollider : MonoBehaviour
{

    int playerHP;
    int enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        PoisonAreaFiledIn(other);
        
        /*if (other.gameObject.CompareTag("Player"))
        {
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //PoisonAreaFiledIn();
        }*/
    }


    float currentTime;
    //2들어오면 2초마다 -1데미지
    void PoisonAreaFiledIn(Collider other)
    {
        currentTime += Time.deltaTime;
        if (other.gameObject.CompareTag("Player"))
        {
            if(currentTime > 2f)
            {
                other.gameObject.GetComponent<Stat>().HP--; 
                    //= (other.gameObject.GetComponent<Stat>().HP)-1;
                Debug.Log(other.gameObject.GetComponent<Stat>().HP--);
                //playerHP -= 1;
                currentTime = 0;
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

        }

    }
    private void OnTriggerExit(Collider other)
    {
        print("exit");
    }
}
