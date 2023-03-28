using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Move : NetworkBehaviour
{
     public int speed;
     public bool IsReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer) {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(0, speed*vertical*Time.deltaTime, 0);
        }
        
    }
    public void GetReady() {
        IsReady = true;
    }
}
