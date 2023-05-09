using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    //���� �ε��� ��ȣ ����
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewgame()
    {
        NewGameScene();
    }
    public void OnClickLoad()
    {
        print("�ҷ�����");
    }
    public void OnClickQuit()
    {
        //����Ƽ������ �������� �ʱ� ������ ��ó���� ���ù�(�����Ұ�)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //�� ��ȯ
    public void NewGameScene()
    {
        //�����Ų mainscene�� 0�� �� ���ķ� +1��
        SceneManager.LoadScene(sceneIndex + 1);
    }


}
