using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Camera camera;

    private void Start()
    {
        camera.orthographicSize = PlayerPrefs.GetFloat("Field Of View");
    }

    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -1);
    }
}