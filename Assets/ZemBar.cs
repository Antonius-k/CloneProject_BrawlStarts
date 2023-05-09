using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZemBar : MonoBehaviour
{
    public Text zemText;
    public Image[] zemFilled = new Image[10];

    Text pzText;

    public GameObject p_zemCount;
    // Start is called before the first frame update
    void Start()
    {
        pzText = GameObject.Find("PZText").GetComponent<Text>();
        //ezText = GameObject.Find("EZText").GetComponent<Text>();

        p_zemCount = GameObject.Find("Player_Jester");

        //zemFiled_2[0].SetActive(true);
        //zemFilled[1].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        pzText.text = PlayerGameManager.Instance.p_ZemCount.ToString();
        //ezText.text = PlayerGameManager.Instance.e_ZemCount.ToString();
        IncreasePlayerZem(); 



    }

    void IncreasePlayerZem()
    {
        for (int i = 0; i < PlayerGameManager.Instance.p_ZemCount; i++)
        {
            if(PlayerGameManager.Instance.p_ZemCount > 10)
            {
                break;
            }

            zemFilled[i].gameObject.SetActive(true);
        }


        if (PlayerGameManager.Instance.playerCheck)
        {
            int hp = GameObject.FindWithTag("Player").GetComponent<Stat>().HP;
            if (hp <= 0)
            {
                for (int i = 0; i < zemFilled.Length; i++)
                {
                    zemFilled[i].gameObject.SetActive(false);
                }
            }
            
            

        }
    }
}
