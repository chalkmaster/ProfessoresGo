using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour {

    private void Awake()
    {
        WorkflowHelper.Initialize();
        WorkflowHelper.Camera = GameObject.Find("ARCamera");
        WorkflowHelper.CamButtons = GameObject.Find("camButtons");
        WorkflowHelper.Timer = GameObject.Find("txtTime");
        WorkflowHelper.txtPistas = GameObject.Find("txtPista");
        WorkflowHelper.pPistas = GameObject.Find("pPistas");
        WorkflowHelper.txtQtd = GameObject.Find("txtQTD");
        WorkflowHelper.sombra = GameObject.Find("sombra");
        WorkflowHelper.MainCanvas = GameObject.Find("Canvas");

        WorkflowHelper.CamButtons.SetActive(false);
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
