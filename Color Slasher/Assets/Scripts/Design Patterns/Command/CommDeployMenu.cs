using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommDeployMenu : Command
{
    static List<GameObject> menuAssets;
    public CommDeployMenu(List<GameObject> _menuAssets)
    {
        menuAssets = _menuAssets;
    }

    public void Execute()
    {
        foreach(GameObject obj in menuAssets) obj.SetActive(true);
    }
    public void Unexecute()
    {
        foreach(GameObject obj in menuAssets) obj.SetActive(false);
    }
}
