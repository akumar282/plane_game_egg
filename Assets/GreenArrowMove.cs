using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreenArrowMove : MonoBehaviour
{
    [SerializeField] Vector3 _axis = Vector3.forward;
    private int speed = 20;
    public bool mpress = false; 
    public double times = .2;
    public int jetCount = 0;
    public int eggCount = 0;
    public GameObject prefab;
    public TMP_Text EggTxt;
    public TMP_Text PlaneTxt;
    void Start()
    {
        
    }
    void MouseMovement()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    void KeyControl()
    {

        if (!mpress){
            return;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("d") && mpress)
        {
            transform.Rotate(_axis.normalized * -45f * Time.deltaTime);
        }
        if (Input.GetKey("a") && mpress)
        {
            transform.Rotate(_axis.normalized * 45f * Time.deltaTime);
        }
        if (Input.GetKey("w") && mpress)
        {
            speed += 1;
        }
        if (Input.GetKey("s") && mpress)
        {
            if (speed != 0)
            {
                speed -= 1;
            }
        }
    }

    void EggShoot() {
        times -= 1 * Time.deltaTime;
        if(times <= 0){
            Instantiate(prefab, transform.position + (transform.forward*2), transform.rotation);
            times = .2f;
        }
    }
    int EggCount() {
        GameObject[] pln = GameObject.FindGameObjectsWithTag("EggoWaffle");
        int count = pln.Length;
        return count;
    }


    int JetPlane(int value) {
        return jetCount += value;
    }

    void Update()
    {
        EggTxt.text = "EGGS on screen: " + EggCount();
        PlaneTxt.text = "Planes Hero Destroyed: " + jetCount;
        if(Input.GetKey("m"))
        {   
            mpress = mpress ? false : true;
        }
        if(!mpress){
            MouseMovement();
        } else { 
            KeyControl();
        }
        if(Input.GetKey("space"))
        {
            EggShoot();
        }
        if(Input.GetKey("q"))
        {
            Application.Quit();
        }
    }
}
