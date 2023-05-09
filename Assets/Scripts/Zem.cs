using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zem : MonoBehaviour
{
    Text[] texts;
    float currentTime;
    
    GameObject CanvasplayerZemCount;

    // Start is called before the first frame update
    void Start()
    {
        GameObject screenCanvas = GameObject.FindGameObjectWithTag("ScreenCanvas");
        texts = screenCanvas.GetComponentsInChildren<Text>();
        
        
        
    }

    void Update()
    {

    }

    //보석 충돌 트리거 처리
    private void OnTriggerEnter(Collider other)
    {
        //ZemCount 시작
        if (other.gameObject.CompareTag("Player")){
            //Zem삭제
            Destroy(gameObject);

            if (PlayerGameManager.Instance.playerCheck)
            {
                //player잼 카운트 시작
                PlayerGameManager.Instance.p_ZemCount++;

                texts[0].text = $"PlayerZemCount: {PlayerGameManager.Instance.p_ZemCount.ToString()}";
                //Player > PlayerCanvas > PlayerZemCount
                CanvasplayerZemCount = GameObject.Find("PlayerZemText");
                CanvasplayerZemCount.GetComponent<Text>().text = PlayerGameManager.Instance.p_ZemCount.ToString();
            }
        }
        if(other.gameObject.CompareTag("Enemy")){
            
            Destroy(gameObject);
            //Enemy잼 카운트 시작
            EnemyManager.Instance.e_ZemCount++;
            texts[1].text = $"EnemyZemCount: {EnemyManager.Instance.e_ZemCount.ToString()}";
        }

        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }  
    }
}
