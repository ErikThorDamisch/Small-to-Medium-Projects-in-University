using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private Camera overworldCamera;
    private Camera underworldCamera;
    private Ray ray;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject antStatsScreen;
    private GameObject tempStatScreen;

    private void Update()
    {
        if (overworldCamera != null && underworldCamera != null)
        {
            if (overworldCamera.transform.parent.gameObject.activeSelf)
            {
                ray = overworldCamera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                ray = underworldCamera.ScreenPointToRay(Input.mousePosition);
            }
            RaycastHit hitInfo;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
                {
                    GameObject temp = hitInfo.collider.gameObject;
                    if (StatScript.statScreenIsActive)
                    {
                        tempStatScreen.GetComponent<StatScript>().ant = hitInfo.transform.GetComponent<AmeisenTypen.Arbeiter>();
                    }
                    else
                    {
                        tempStatScreen = antStatsScreen;
                        tempStatScreen = Instantiate(antStatsScreen, GameObject.Find("Canvas").transform);
                        tempStatScreen.GetComponent<StatScript>().ant = hitInfo.transform.GetComponent<AmeisenTypen.Arbeiter>();
                        StatScript.statScreenIsActive = true;
                    }
                    Debug.Log(hitInfo.collider.gameObject.name);
                }
            }
        }
        else if (GameManager.overworldCamera != null && GameManager.underworldCamera != null)
        {
            overworldCamera = GameManager.overworldCamera.transform.GetChild(0).GetComponent<Camera>();
            underworldCamera = GameManager.underworldCamera.GetComponent<Camera>();
        }
    }
}