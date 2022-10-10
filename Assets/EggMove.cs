using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggMove : MonoBehaviour
{
    public Text Egg;
    void Start()
    {
        
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        int speed = 40;
        transform.Translate( Vector3.up* speed * Time.deltaTime); 
    }
}
