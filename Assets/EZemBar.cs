using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EZemBar : MonoBehaviour
{
    public Text zemText;
    public Image[] zemFilled = new Image[10];

    Text ezText;

    public GameObject[] enemy = new GameObject[3];

    public GameObject e_zemCount;
    // Start is called before the first frame update
    void Start()
    {
        ezText = GameObject.Find("EZText").GetComponent<Text>();
        e_zemCount = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        ezText.text = EnemyManager.Instance.e_ZemCount.ToString();
        IncreaseEnemyZem();
    }

    void IncreaseEnemyZem()
    {
        if (GameObject.FindWithTag("Enemy"))//만약 에너미가 있다면
        {

            for (int i = 0; i < EnemyManager.Instance.e_ZemCount; i++)
            {
                if (EnemyManager.Instance.e_ZemCount > 10)
                {
                    break;
                }
                zemFilled[i].gameObject.SetActive(true);
            }


            int hp = GameObject.FindWithTag("Enemy").GetComponent<Enemy>().hp;
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
