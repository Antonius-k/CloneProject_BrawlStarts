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

    //���� �浹 Ʈ���� ó��
    private void OnTriggerEnter(Collider other)
    {
        //ZemCount ����
        if (other.gameObject.CompareTag("Player")){
            //Zem����
            Destroy(gameObject);

            if (PlayerGameManager.Instance.playerCheck)
            {
                //player�� ī��Ʈ ����
                PlayerGameManager.Instance.p_ZemCount++;

                texts[0].text = $"PlayerZemCount: {PlayerGameManager.Instance.p_ZemCount.ToString()}";
                //Player > PlayerCanvas > PlayerZemCount
                CanvasplayerZemCount = GameObject.Find("PlayerZemText");
                CanvasplayerZemCount.GetComponent<Text>().text = PlayerGameManager.Instance.p_ZemCount.ToString();
            }
        }
        if(other.gameObject.CompareTag("Enemy")){
            
            Destroy(gameObject);
            //Enemy�� ī��Ʈ ����
            EnemyManager.Instance.e_ZemCount++;
            texts[1].text = $"EnemyZemCount: {EnemyManager.Instance.e_ZemCount.ToString()}";
        }

        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }  
    }
}
