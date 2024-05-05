using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent OnEvent;

    private void Awake()
    {
        OnEvent = this;
    }

    public static event Action OnActive_GameOver;
    public static event Action OnActive_Win;
    public static event Action OnActiveHalfTime;

    public void Active_GameOver()
    {
        if (OnActive_GameOver != null) OnActive_GameOver();

    }

    public void Active_Win()
    {
        if (OnActive_Win != null) OnActive_Win();
    }

    public void HalfTime()
    {
        if (OnActiveHalfTime != null) OnActiveHalfTime();
        Debug.Log("hi");
    }

}
