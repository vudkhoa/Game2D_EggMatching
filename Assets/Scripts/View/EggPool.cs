using System.Collections.Generic;
using UnityEngine;

public class EggPool : MonoBehaviour
{
    public GameObject eggPrefab;
    private int poolSize = 10;
    private Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(eggPrefab);   
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            pool.Enqueue(obj);

        }
    }

    public GameObject GetObject() 
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(eggPrefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);
    }
}
