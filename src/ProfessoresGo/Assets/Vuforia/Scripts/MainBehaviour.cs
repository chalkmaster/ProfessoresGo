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
        Debug.Log("Start");
    }

    void Update()
    {
        WorkflowHelper.UpdateTime();
    }
}
