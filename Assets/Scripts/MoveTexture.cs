using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    private float moveSpeed = 0.2f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Time.time * moveSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector3(0, move, 0));
    }
}
