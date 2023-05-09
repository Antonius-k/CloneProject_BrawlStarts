using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print("sceneIndex:" + sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        PlayScene();
    }
    
    //�÷��̾��̵�
    public void PlayScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    //�ڷΰ��� �Լ� �ٸ�������� ��ư ����� �ְ�
    public void PreviousScene()
    {
        //�ڷΰ���
        SceneManager.LoadScene(sceneIndex - 1);
    }
}
