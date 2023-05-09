using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    //카운트 다운 시간
    public float setTime = 10f;
    GameObject countdown;
    Text[] countText;
    //보석 x개 이상 가진 채로 카운트다운값이 0이하라면
    int currentCount;

    // Start is called before the first frame update
    void Start()
    {
        //찾아서 시간셋팅하고
        countText = GameObject.Find("ScreenCanvas").GetComponentsInChildren<Text>();
        countText[2].text = setTime.ToString();

        //찾아서 꺼놓고
        countdown = GameObject.Find("Countdown");
        //countText_t.text = setTime.ToString();
        countdown.SetActive(false);
    }

    public int missionZemCount;
    // Update is called once per frame
    void Update()
    {
        
        //playerJam이 10개 이상이라면
        if (PlayerGameManager.Instance.p_ZemCount >= missionZemCount)
        {
            countDown();
            //카운트다운 화면에 띄워주고
            countText[2].text = Mathf.Round(setTime).ToString();
            //젬 카운트 다운 int로 변환 시키고 담아주고
            currentCount = int.Parse(countText[2].text);
            //플레이어 젬 획득이 10개 이상 && 경과시간이 0이하면
            if (PlayerGameManager.Instance.p_ZemCount >= missionZemCount && currentCount <= 0)
            {
                countText[2].text = "매치 종료";
                SceneManager.LoadScene(3);
            }
        }else if(PlayerGameManager.Instance.e_ZemCount >= missionZemCount)
        {
            countDown();
            countText[2].text = Mathf.Round(setTime).ToString();
            currentCount = int.Parse(countText[2].text);
            
            if (PlayerGameManager.Instance.e_ZemCount >= missionZemCount && currentCount <= 0)
            {
                countText[2].text = "매치 종료";
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
