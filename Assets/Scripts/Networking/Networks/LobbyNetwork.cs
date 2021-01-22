using UnityEngine;

public class LobbyNetwork : MonoBehaviour{

    //Photon API: 31d933cd-12fd-4d61-8d45-3379b394905b

    void Start()    {
        print("Connecting to server..");
        PhotonNetwork.ConnectUsingSettings("0.0.0");
    }
    private void OnConnectedToMaster() {
        print("Connected to master.");
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    private void OnJoinedLobby()
    {
        print("Joined lobby.");
    }
}
