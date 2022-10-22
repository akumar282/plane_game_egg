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
    private string[] kWayPointNames = {
            "A_Walk", "B_Walk", "C_Walk",
            "D_Walk", "E_Walk", "F_Walk"};
    public GameObject[] mWayPoints;
    private const int kNumWayPoints = 6;
    // Start is called before the first frame update
    void Create()
    {
        Vector3 randomCreate = new Vector3(Random.Range(-140, 140), Random.Range(-90, 90), 0);
        Instantiate(prefab, randomCreate, Quaternion.identity);
    }
    void Wayspawn(GameObject s, Vector3 point)
    {
        point[0] += Random.Range(-15, 15);
        point[1] += Random.Range(-15, 15);
        Instantiate(s, point, Quaternion.identity);
    }
    void Start()
    {
        mWayPoints = new GameObject[kWayPointNames.Length];
        for (int j = 0; j < totalPlanes; j++)
        {
            Create();
        }
        int i = 0;
        foreach (string s in kWayPointNames)
        {
            mWayPoints[i] = GameObject.Find(kWayPointNames[i]);
            Debug.Assert(mWayPoints[i] != null);
            i++;
        }
        SeqRand.text = "WAYPOINTS: (SEQUANCE)";
    }

    // Update is called once per frame
    bool seqOrRand = true;
    public TMP_Text SeqRand;
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            if (seqOrRand)
            {
                SeqRand.text = "WAYPOINTS: (Random)";
                seqOrRand = false;
            }
            else
            {
                SeqRand.text = "WAYPOINTS: (Sequance)";
                seqOrRand = true;
            }

        }
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