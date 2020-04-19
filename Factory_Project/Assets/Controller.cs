using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Camera cam;

    public PreViewer preViewer;
    public float clampDistance;
    public float offset;

    private Map map;

    private EntityFactory objToSet;
    public EntityFactory ObjToSet { get { return objToSet; } internal set { objToSet = value; } }

    // lvl constructor
    public Vector3Int inputPos;
    public Vector3Int outputPos; 
    public EntityFactory inputPipe_pref;
    public EntityFactory OutputPipe_pref;

    public InputPipe ip_ref;
    public OutputPipe op_ref;

    // PARCHE
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        map = GetComponent<Map>();
        ip_ref = map.AddEntity(inputPipe_pref, inputPos.x, inputPos.y, inputPos.z, Vector3.one).GetComponent<InputPipe>();
        op_ref = map.AddEntity(OutputPipe_pref, outputPos.x, outputPos.y, outputPos.z, Vector3.one).GetComponent<OutputPipe>();
        playButton.onClick.AddListener(()=> { ip_ref.Begin(); });
    }

    // Update is called once per frame
    void Update()
    {
        this.PC_ControlUpdate();
    }

    public void PC_ControlUpdate()
    {
        var hit = CastRay(Input.mousePosition);
        Vector3Int vec;
        

        if (hit.collider != null)
        {
            preViewer.gameObject.SetActive(true);
            var dis_offset = hit.normal * offset;

            vec = WorldToMapCord(hit.point, Vector3.one * clampDistance);
            preViewer.SetClampedPosition(hit.point, Vector3.one * clampDistance, dis_offset);

            if (Input.GetMouseButtonDown(0) && objToSet != null)
            {
                map.AddEntity(objToSet, vec.x, vec.y, vec.z, Vector3.one * clampDistance);
            }

            if (Input.GetMouseButtonDown(1))
            {
                objToSet.NextOrientation();
            }
        }
        else
        {
            preViewer.gameObject.SetActive(false);
        }

    }

    public Vector3Int WorldToMapCord(Vector3 WorldPosition, Vector3 clamp)
    {
        var x = Mathf.Round(WorldPosition.x * (1 / clamp.x));
        var y = Mathf.Round(WorldPosition.y * (1 / clamp.y));
        var z = Mathf.Round(WorldPosition.z * (1 / clamp.z));

       return new Vector3Int((int)x, (int)y,(int) z);

    }

    public RaycastHit CastRay(Vector3 vec3)
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(vec3);

        if (Physics.Raycast(ray, out hit))
        {
            return hit;
        }

        return default(RaycastHit);
    }
}
