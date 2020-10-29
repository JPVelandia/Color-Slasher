using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    static Transform[] walls;

    private void Awake()
    {
        walls = GetComponentsInChildren<Transform>();

        Platform.OnSwitchTouch -= TurnOffWall;
        Platform.OnSwitchTouch += TurnOffWall;
    }

    void TurnOffWall(int index)
    {
        walls[index].gameObject.SetActive(false);
    }
}
