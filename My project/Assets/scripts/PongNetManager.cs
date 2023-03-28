using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PongNetManager : NetworkManager
{
   //мяч переделать
    public Transform RPos;
    public Transform LPos;
    //public int NumOfReady;
    //public GameObject Ball;
    GameObject ballObject;
    public LocalThingsForPlayer local;
    LocalThingsForPlayer localObject;
    List <Move> players = new List<Move>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn) {

        Transform startPos = 
            numPlayers == 1 ? LPos : RPos;
        
            GameObject player = Instantiate(playerPrefab, startPos.position, startPos.rotation);
            //NetworkServer.Spawn(player);
            //
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            players.Add(player.GetComponent<Move>());
            NetworkServer.AddPlayerForConnection(conn, player);
            if (numPlayers == 2) {
                localObject = Instantiate(local, new Vector2(0,0), Quaternion.identity);
                NetworkServer.Spawn(localObject.gameObject);
                /*ballObject = Instantiate(Ball, new Vector2(0,0), Quaternion.identity);
                NetworkServer.Spawn(ballObject);*/
            }
            //ButtonReady.onClick.AddListener(players[numPlayers - 1].GetReady);
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn) {
        base.OnServerDisconnect(conn);
        NetworkServer.Destroy(localObject.gameObject);
    }

    /*public override void OnStopClient() {
        print("OnStopClien");
    }
    public override void OnClientDisconnect() {
        print("OnClientDisconnect");
    }*/

    
    /*public void CounterOfReady() {
        
        //if (players[0].IsReady && players[1].IsReady) {
            ballObject = Instantiate(Ball, new Vector2(0,0), Quaternion.identity);
            NetworkServer.Spawn(ballObject);
        //}
    }*/
    
}
