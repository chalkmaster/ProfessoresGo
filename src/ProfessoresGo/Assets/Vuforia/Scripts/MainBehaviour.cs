using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour {

    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Use this for initialization
    void Start () {
        WorkflowHelper.Load();
    }

    private void OnApplicationPause(bool pause)
    {

    }
    private void OnApplicationQuit()
    {
        WorkflowHelper.Save();
    }

    void Update()
    {
        WorkflowHelper.UpdateTime();
    }
}
