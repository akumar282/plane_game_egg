using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private string[] kWayPointNames = {
            "A_Walk", "B_Walk", "C_Walk",
            "D_Walk", "E_Walk", "F_Walk"};

    private GameObject[] mWayPoints;
    private const int kNumWayPoints = 6;
    public GameObject A_Walk;
    private float speed = 20f;
    int Health = 100;
    bool jtr = false;
    int seq = 0;
    int tempRan = 9;
    int ran;
    public float rotationModifier = 90;
    void Start()
    {
        ran = Random.Range(0, 5);
        Color color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        color.a -= 0.1f;
        mWayPoints = new GameObject[kWayPointNames.Length];
        int i = 0;
        foreach (string s in kWayPointNames)
        {
            mWayPoints[i] = GameObject.FindWithTag(kWayPointNames[i]);
            Debug.Assert(mWayPoints[i] != null);
            i++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            if (jtr == false)
            {
                jtr = true;
                ran = Random.Range(0, 5);
            }
            else
            {
                jtr = false;
                seq = 0;
            }

        }
        if (!jtr)
        {
            ran = 7;
            mWayPoints[seq] = GameObject.FindWithTag(kWayPointNames[seq]);
            if (mWayPoints[seq] != null)
            {
                Vector3 vectorToTarget = mWayPoints[seq].transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, mWayPoints[seq].transform.position, step);
            }
        }
        else if (jtr)
        {
            seq = 6;
            if (ran != tempRan)
            {
                mWayPoints[ran] = GameObject.FindWithTag(kWayPointNames[ran]);
                if (mWayPoints[ran] != null)
                {
                    Vector3 vectorToTarget = mWayPoints[ran].transform.position - transform.position;
                    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
                    float step = speed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, mWayPoints[ran].transform.position, step);
                }
            }
            else
            {
                ran = Random.Range(0, 5);
            }

        }
    }
    void Rmove()
    {
        tempRan = ran;
        ran = Random.Range(0, 5);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "A_Walk" && seq == 0 || ran == 0)
        {
            seq = 1;
            if (ran == 0)
            {
                Rmove();
            }
            return;
        }
        else if (col.gameObject.tag == "B_Walk" && (seq == 1 || ran == 1))
        {
            seq = 2;
            if (ran == 1)
            {
                Rmove();
            }
            return;
        }
        else if (col.gameObject.tag == "C_Walk" && (seq == 2 || ran == 2))
        {
            seq = 3;
            if (ran == 2)
            {
                Rmove();
            }
            return;
        }
        else if (col.gameObject.tag == "D_Walk" && (seq == 3 || ran == 3))
        {
            seq = 1;
            seq = 4;
            if (ran == 3)
            {
                Rmove();
            }
            return;
        }
        else if (col.gameObject.tag == "E_Walk" && (seq == 4 || ran == 4))
        {
            seq = 1;
            seq = 5;
            if (ran == 4)
            {
                Rmove();
            }
            return;
        }
        else if (col.gameObject.tag == "F_Walk" && (seq == 5 || ran == 5))
        {
            seq = 1;
            seq = 0;
            if (ran == 5)
            {
                Rmove();
            }
            return;
        }
        if (col.gameObject.name == "GreenUp")
        {
            col.gameObject.SendMessage("JetPlane", 1);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "EggoWaffle")
        {
            Health -= 25;
            GetComponent<Renderer>().material.SetAlpha(GetComponent<Renderer>().material.color.a - .25F);
            Destroy(col.gameObject);
            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
public static class ExtensionMethods
{
    public static void SetAlpha(this Material material, float value)
    {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }
}