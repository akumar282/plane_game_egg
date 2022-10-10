using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Generate : MonoBehaviour
{
    public GameObject prefab;
    public TMP_Text PlaneNumber;
    public int totalPlanes = 10;
    public int NumPlanes = 0;
    // Start is called before the first frame update
    void Create() 
    {
        Vector3 randomCreate = new Vector3(Random.Range(-140, 140), Random.Range(-90, 90), 0);
        Instantiate(prefab, randomCreate, Quaternion.identity);
    }
    void Start()
    {
        for(int i = 0; i < totalPlanes; i++){
            Create();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] pln = GameObject.FindGameObjectsWithTag("JetPlane");
        int count = pln.Length;
        PlaneNumber.text = "Planes Destroyed " + NumPlanes;
        while (count < 10)
        {
            Create();
            NumPlanes++;
            count++;
        }
    }
}
