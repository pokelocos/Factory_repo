using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFactory : MonoBehaviour
{
    Controller c;
    public EntityFactory prefab;

    // Start is called before the first frame update
    void Start()
    {
        c = FindObjectOfType<Controller>();
        var b = this.GetComponent<Button>();
        b.onClick.AddListener(() =>{ c.ObjToSet = prefab; });
    }


}
