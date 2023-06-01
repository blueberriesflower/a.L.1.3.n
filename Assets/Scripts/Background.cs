using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public RawImage BgImage;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        BgImage.uvRect = new Rect(
            BgImage.uvRect.position + new Vector2(0.00005f, 0), 
            BgImage.uvRect.size);
    }
}
