using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundQuad : MonoBehaviour
{
    //MeshRenderer>Material>OffsetY
    MeshRenderer meshRenderer;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMeshRendererGet();
    }

    void BackgroundMeshRendererGet()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        //��׶��� �����Ӹ��� ���������� �̵�
        //material.mainTextureOffset += Vector2.up + Vector2.right * 0.1f * Time.deltaTime;
    }
}
