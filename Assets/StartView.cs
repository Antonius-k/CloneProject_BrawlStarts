using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    //������ ���� ������Ʈ ������ ã�´�
    GameObject blueImg;
    GameObject redImg;
    GameObject center;

    //ó����ġ
    Vector3 bluestartPosition;
    Vector3 redstartPosition;

    //������
    Vector3 blueDestination;
    Vector3 RedDestination;
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.GetChild(0).gameObject;
        redImg = transform.GetChild(1).gameObject;
        blueImg = transform.GetChild(2).gameObject;

        //ó����ġ
        redstartPosition = redImg.transform.position;
        bluestartPosition = blueImg.transform.position;
        //������
        RedDestination = new Vector3(1430, redImg.transform.position.y, 0);
        blueDestination = new Vector3(175, blueImg.transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        //������Ʈ�� false���
        if (center.activeSelf == false)
        {
            print("3");
            return;
        }
        redImg.transform.position = Vector3.MoveTowards(redImg.transform.position, RedDestination, 2f);
        blueImg.transform.position = Vector3.MoveTowards(blueImg.transform.position, blueDestination, 2f);

        time += Time.deltaTime;
        //Ư�� ��ġ���� �������� �̵�
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


        /*//ƨ���
        else if(time < 1f)
        {
            BlueImg.transform.position = new Vector3(time-1f, BlueImg.transform.position.y, 0)*4;

        }
        //���ڸ�
        else if(time < 1.6f)
        {
            BlueImg.transform.position = new Vector3(1.6f-time, BlueImg.transform.position.y, 0)*4;
        }else if(time < 2f)
        {
            BlueImg.transform.position = tr.transform.position;
        }*/


        /*
        Red team
        RectTr Destination Transform.x = 527 > 179����
        Blue Team
        RectTr Destination TRansform.x = 523 > -175����
        */
    }
}
