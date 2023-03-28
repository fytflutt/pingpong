using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class LocalThingsForPlayer : NetworkBehaviour
{
    [SyncVar] public int NumberOfReady;
    public GameObject Ball;
    GameObject ballObj;
    public Button ButtonReady;
    // Start is called before the first frame update
    void Start()
    {
        //NetworkManager.singleton.onclientconn += ButtonOnClientConnect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //это значит что эта функция будет исполняться на серваке
    //requiresAutority = false - разрешает всем вызывать эту функцию
    [Command(requiresAuthority = false)] 
    public void CreateBall() {
        NumberOfReady++;
        if(NumberOfReady == 2) {
            ballObj = Instantiate(Ball, new Vector2(0,0), Quaternion.identity);
            NetworkServer.Spawn(ballObj);
        }
            
    }
    public override void OnStopClient()
        {
        print("кфищефуе");
            NumberOfReady--;
            if (ballObj!=null) {
                NetworkServer.Destroy(ballObj);
            }
            //identity это как трансформ (относительно. через то, что брать)
            /*players.Remove(conn.identity.GetComponent<Move>());
            NetworkServer.DestroyPlayerForConnection(conn);*/
        }
    public override void OnStartClient() {
        ButtonReady.interactable = true;
    }
    /*void ButtonOnClientConnect() {
        Button.SetActive(true);
    }*/
    //можно написвть свое событие в понге оверрайдить онклиентконнект и вызвать событие оттуда (подписаться тут по примеру подписки нс неудачное)
    //вижуал студио!!!!!!!
}
