using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject A_Walk;
    Vector3 A = new Vector3(-66, 65, 0);
    public GameObject B_Walk;
    Vector3 B = new Vector3(73, -60, 0);

    public GameObject C_Walk;
    Vector3 C = new Vector3(39, -1, 0);
    public GameObject D_Walk;
    Vector3 D = new Vector3(-74, -55, 0);
    public GameObject E_Walk;
    Vector3 E = new Vector3(61, 65, 0);
    public GameObject F_Walk;
    Vector3 F = new Vector3(-41, 1, 0);
    int Health = 100;
    // Start is called before the first frame update
    Renderer test;
    void Start()
    {
        Color color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        color.a -= 0.1f;
    }
    // Update is called once per frame
    void Wayspawn(GameObject s, Vector3 point)
    {
        point[0] += Random.Range(-15, 15);
        point[1] += Random.Range(-15, 15);
        Instantiate(s, point, Quaternion.identity);
        GetComponent<Renderer>().material.SetAlpha(GetComponent<Renderer>().material.color.a + 1F);
    }

    void Update()
    {
        test = GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown("h"))
        {
            if (test.enabled == true)
            {
                test.enabled = false;
            }
            else if (test.enabled == false)
            {
                test.enabled = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EggoWaffle")
        {
            Health -= 25;
            GetComponent<Renderer>().material.SetAlpha(GetComponent<Renderer>().material.color.a - .25F);
            Destroy(col.gameObject);
            if (Health == 0)
            {
                Debug.Log(gameObject.name);
                if (gameObject.tag == "A_Walk") { Wayspawn(A_Walk, A); }
                else if (gameObject.tag == "B_Walk") { Wayspawn(B_Walk, B); }
                else if (gameObject.tag == "C_Walk") { Wayspawn(C_Walk, C); }
                else if (gameObject.tag == "D_Walk") { Wayspawn(D_Walk, D); }
                else if (gameObject.tag == "E_Walk") { Wayspawn(E_Walk, E); }
                else if (gameObject.tag == "F_Walk") { Wayspawn(F_Walk, F); }
                Destroy(gameObject);
            }
        }
    }
}

