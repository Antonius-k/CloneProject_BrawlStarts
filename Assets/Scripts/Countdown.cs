using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    //ī��Ʈ �ٿ� �ð�
    public float setTime = 10f;
    GameObject countdown;
    Text[] countText;
    //���� x�� �̻� ���� ä�� ī��Ʈ�ٿ�� 0���϶��
    int currentCount;

    // Start is called before the first frame update
    void Start()
    {
        //ã�Ƽ� �ð������ϰ�
        countText = GameObject.Find("ScreenCanvas").GetComponentsInChildren<Text>();
        countText[2].text = setTime.ToString();

        //ã�Ƽ� ������
        countdown = GameObject.Find("Countdown");
        //countText_t.text = setTime.ToString();
        countdown.SetActive(false);
    }

    public int missionZemCount;
    // Update is called once per frame
    void Update()
    {
        
        //playerJam�� 10�� �̻��̶��
        if (PlayerGameManager.Instance.p_ZemCount >= missionZemCount)
        {
            countDown();
            //ī��Ʈ�ٿ� ȭ�鿡 ����ְ�
            countText[2].text = Mathf.Round(setTime).ToString();
            //�� ī��Ʈ �ٿ� int�� ��ȯ ��Ű�� ����ְ�
            currentCount = int.Parse(countText[2].text);
            //�÷��̾� �� ȹ���� 10�� �̻� && ����ð��� 0���ϸ�
            if (PlayerGameManager.Instance.p_ZemCount >= missionZemCount && currentCount <= 0)
            {
                countText[2].text = "��ġ ����";
                SceneManager.LoadScene(3);
            }
        }else if(PlayerGameManager.Instance.e_ZemCount >= missionZemCount)
        {
            countDown();
            countText[2].text = Mathf.Round(setTime).ToString();
            currentCount = int.Parse(countText[2].text);
            
            if (PlayerGameManager.Instance.e_ZemCount >= missionZemCount && currentCount <= 0)
            {
                countText[2].text = "��ġ ����";
                Invoke("sceneChange", 5f);

            }
        }
    }

    

    void countDown()
    {
        countdown.SetActive(true);
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if (setTime <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}
