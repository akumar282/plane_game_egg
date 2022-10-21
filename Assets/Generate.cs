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
    public int A = 0;
    public int B = 0;
    public int C = 0;
    public int D = 0;
    public int D = 0;
    public int F = 0;

    // Start is called before the first frame update
    void Create()
    {
        Vector3 randomCreate = new Vector3(Random.Range(-140, 140), Random.Range(-90, 90), 0);
        Instantiate(prefab, randomCreate, Quaternion.identity);
    }
    void Start()
    {
        Vector3 Create = new Vector3(Random.Range(-140, 140), Random.Range(-90, 90), 0);
        for (int i = 0; i < totalPlanes; i++)
        {
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
