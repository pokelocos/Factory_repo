using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public int sizeX = 20;
    public int sizeY  = 20;
    public int sizeZ = 20;

    EntityFactory[,,] map;

    

    private void Awake()
    {
        map = new EntityFactory[sizeX, sizeY, sizeZ];
    }

    public void Start()
    {
        
    }

    public EntityFactory AddEntity(EntityFactory entity, int x, int y, int z,Vector3 clamp)
    {
        if(x >= sizeX || x < 0 || y >= sizeY || y < 0 || z >= sizeZ || z < 0 )
        {
            Debug.Log("Add entity error. Cannot place objects off the map.");
            return null;
        }

        if(map[x,y,z] != null)
        {
            Debug.Log("Add entity error. tThat place is already occupied.");
            return null;
        }

        var ent = Instantiate(entity,new Vector3(x * clamp.x,y * clamp.y,z * clamp.z),Quaternion.identity);
        map[x, y, z] = ent;
        return ent;
    }

    public void RemoveEntity(EntityFactory entity)
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                for (int k = 0; k < sizeZ; k++)
                {
                    if(entity == map[i,j,k])
                    {
                        Destroy(map[i,j,k].gameObject);
                        map[i, j, k] = null;
                        return;
                    }
                }
            }
        }
    }

    public void RemoveEntity(int x, int y, int z)
    {
        if (x >= sizeX || x < 0 || y >= sizeY || y < 0 || z >= sizeZ || z < 0)
        {
            Debug.Log("Remove entity error. Cannot remove objects off the map.");
            return;
        }

        Destroy(map[x, y, z].gameObject);
        map[x, y, z] = null;
    }

}
