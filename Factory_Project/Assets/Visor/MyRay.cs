using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRay : MonoBehaviour
{

    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    public List<GameObject> instObj = new List<GameObject>();
    public int numValue;

    public float maxDistance;
    public MeshRenderer visor;
    public MeshFilter visorMesh;

    public bool clampMode;

    Vector3 _pos = new Vector3();
    Vector3 _normal = new Vector3();
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { numValue = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { numValue = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { numValue = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { numValue = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { numValue = 4; }

        SetMesh(numValue);

        if (Input.GetMouseButtonDown(0) && visor.gameObject.activeInHierarchy)
        {

             SetBlock(numValue);
           
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            _pos = hit.point;
            _normal = hit.normal * 0.4f + hit.point;

            visor.gameObject.SetActive(true);

            if (clampMode)
            {
                ShowClampPreview(hit);
            }
            else
            {
                ShowPreview(hit);
            }
        }
        else
        {
            visor.gameObject.SetActive(false);
        }
    }

    private void SetMesh(int i)
    {
        if (i < instObj.Count && i >= 0)
        {
            if (visorMesh != null)
            {
                visorMesh.sharedMesh = instObj[i].GetComponent<MeshFilter>().sharedMesh;
            }
        }
    }

    private void SetBlock(int i)
    {
        if (i < instObj.Count && i >= 0)
        {
            GameObject g = Instantiate(instObj[i]);
            g.transform.position = visor.transform.position;
            g.transform.rotation = visor.transform.rotation;
            g.transform.localScale = g.transform.localScale;
        }
    }

    private void ShowClampPreview(RaycastHit hit)
    {
        Vector3 PivotPos = hit.point + (hit.normal * 0.5f);
        visor.gameObject.transform.position = new Vector3((int)PivotPos.x, (int)PivotPos.y, (int)PivotPos.z);        
    }

    private void ShowPreview(RaycastHit hit)
    {
        Quaternion pivotRot = Quaternion.FromToRotation(Vector3.right, hit.normal);
        visor.gameObject.transform.rotation = pivotRot;

        Vector3 pivotPos = hit.point + hit.normal*(visor.bounds.size.y/2) ;
        //Vector3 pivotPos = hit.point;
        visor.gameObject.transform.position = pivotPos;

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(_pos,_normal);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_pos,0.03f);
    }
}
