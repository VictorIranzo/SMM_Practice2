using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Transform player;
    private Vector3 offset;
    public float speed = 0.1f;
    private static float t = 0.0f;

    private Vector3 To, From;

    private float TARGET_WIDTH, TARGET_HEIGHT;

    // Use this for initialization
    void Start()
    {
        string selectedCharacter = DataController.GetCharacter();

        if (selectedCharacter == "girl")
        {
            player = GameObject.Find("Player_Girl").transform;
        }
        else
        {
            player = GameObject.Find("Player").transform;
        }

        AdjustScreenSize();
    }

    // Runs for every frame, but when we update position of the camera we ensure that the player has moved to that frame.
    void Update()
    {
        To = player.position;
        From = transform.position;
        transform.position = new Vector3(Mathf.Lerp(From.x, To.x, t), Mathf.Lerp(From.y, To.y, t), -10);

        t += speed * Time.deltaTime;
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < 0.2f) t = 0f;

        if (TARGET_WIDTH != Screen.width && TARGET_HEIGHT != Screen.height) AdjustScreenSize();
    }

    private void AdjustScreenSize() {
        TARGET_WIDTH = Screen.width;
        TARGET_HEIGHT = Screen.height;
        int PIXELS_TO_UNITS = 30; // 1:1 ratio of pixels to units

        float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
        float currentRatio = (float)Screen.width / (float)Screen.height;

        if (currentRatio >= desiredRatio)
        {
            // Our resolution has plenty of width, so we just need to use the height to determine the camera size
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
        }
        else
        {
            // Our camera needs to zoom out further than just fitting in the height of the image.
            // Determine how much bigger it needs to be, then apply that to our original algorithm.
            float differenceInSize = desiredRatio / currentRatio;
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * differenceInSize;
        }
        Camera.main.aspect = TARGET_WIDTH / TARGET_HEIGHT;
    }
}
