using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArea : MonoBehaviour
{
    public GameObject poisonCollider1;
    public GameObject poisonCollider2;

    Transform tr1;
    Transform tr2;
    
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        poisonCollider1.SetActive(false);
        poisonCollider2.SetActive(false);
        tr1 = poisonCollider1.transform;
        tr2 = poisonCollider2.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            return;
        }

        PoisonAreaMove();
    }

    void PoisonAreaMove()
    {
        currentTime += Time.deltaTime;
        if(tr1.position.z < 30)
        {
            return;
        }
        if(currentTime > 2f)
        {
            poisonCollider1.SetActive(true);
            poisonCollider2.SetActive(true);
            tr1.position += new Vector3(0, 0, -1) * Time.deltaTime * 100;
            tr2.position += new Vector3(0, 0, 1) * Time.deltaTime * 100;
            currentTime = 0;
        }
    }
}
