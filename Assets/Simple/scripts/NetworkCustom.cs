using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkCustom : NetworkManager
{
    NetworkIdentity m_Identity;
    public int chosenCharacter = 0;
    //    public GameObject[] characters = ;
    public GameObject[] characters;

    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);
        Debug.Log(characters.Length);
        GameObject player;
        Transform startPos = GetStartPosition();

        if (startPos != null)
        {
            player = Instantiate(characters[chosenCharacter], startPos.position, startPos.rotation) as GameObject;
        }
        else
        {
            player = Instantiate(characters[chosenCharacter], Vector3.zero, Quaternion.identity) as GameObject;

        }
        //NetworkServer.SpawnWithClientAuthority(player, m_Identity.connectionToClient);
        ClientScene.RegisterPrefab(player);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        NetworkServer.SendToClient(conn.connectionId, MsgTypes.PlayerPrefab, message);

        //GameObject go = (GameObject)Instantiate(player, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        //NetworkServer.SpawnWithClientAuthority(go, player);
        //ClientScene.AddPlayer(client.connection, 0);


    }

    /*
    private void OnServerConnect(NetworkMessage networkMessage)
    {
        ClientScene.RegisterPrefab(characters);
        GameObject thePlayer = (GameObject)Instantiate(prefabPlayer, new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.AddPlayerForConnection(networkMessage.conn, thePlayer, 0);
    }
    */
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Entro a OnClientConnect");
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;
        //ClientScene.AddPlayer(conn, 0, test);
        ClientScene.AddPlayer(client.connection, 0, test);

        Debug.Log("Paso");

       // ClientScene.AddPlayer(client.connection, 0,test);
        //Debug.Log("Llego");

    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }
    public void Btn1()
    {
        chosenCharacter = 0;
    }


    public void Btn2()
    {
        chosenCharacter = 1;
    }

    public class MsgTypes
    {
        public const short PlayerPrefab = MsgType.Highest + 1;
        public class PlayerPrefabMsg : MessageBase
        {
            public short controllerID;
            public short prefabIndex;
        }
    }
}