using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    //움직일 아직 오브젝트 세개를 찾는다
    GameObject blueImg;
    GameObject redImg;
    GameObject center;

    //처음위치
    Vector3 bluestartPosition;
    Vector3 redstartPosition;

    //목적지
    Vector3 blueDestination;
    Vector3 RedDestination;
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.GetChild(0).gameObject;
        redImg = transform.GetChild(1).gameObject;
        blueImg = transform.GetChild(2).gameObject;

        //처음위치
        redstartPosition = redImg.transform.position;
        bluestartPosition = blueImg.transform.position;
        //목적지
        RedDestination = new Vector3(1430, redImg.transform.position.y, 0);
        blueDestination = new Vector3(175, blueImg.transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        //오브젝트가 false라면
        if (center.activeSelf == false)
        {
            print("3");
            return;
        }
        redImg.transform.position = Vector3.MoveTowards(redImg.transform.position, RedDestination, 2f);
        blueImg.transform.position = Vector3.MoveTowards(blueImg.transform.position, blueDestination, 2f);

        time += Time.deltaTime;
        //특정 위치에서 원점으로 이동
        if (time > 5f){
            print("1");
            center.GetComponent<Text>().text = "VS";
            if(time > 10f)
            {
                print("2");
                redImg.SetActive(false);
                blueImg.SetActive(false);
                center.GetComponent<Text>().fontSize = 30;
                center.GetComponent<Text>().text = "BRAWL";

                if (time > 15f)
                {
                    center.SetActive(false);
                }
                //redImg.transform.position = Vector3.MoveTowards(redImg.transform.position, redstartPosition, 0.001f);
                //blueImg.transform.position = Vector3.MoveTowards(blueImg.transform.position,bluestartPosition, 0.001f);
            }
        }


        /*//튕기고
        else if(time < 1f)
        {
            BlueImg.transform.position = new Vector3(time-1f, BlueImg.transform.position.y, 0)*4;

        }
        //제자리
        else if(time < 1.6f)
        {
            BlueImg.transform.position = new Vector3(1.6f-time, BlueImg.transform.position.y, 0)*4;
        }else if(time < 2f)
        {
            BlueImg.transform.position = tr.transform.position;
        }*/


        /*
        Red team
        RectTr Destination Transform.x = 527 > 179까지
        Blue Team
        RectTr Destination TRansform.x = 523 > -175까지
        */
    }
}
