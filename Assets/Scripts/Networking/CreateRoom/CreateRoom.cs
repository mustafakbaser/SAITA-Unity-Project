using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            isVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };

        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("create room request successfully sent.");
        }
        else
        {
            print("create room request failed to sent.");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("create room failed" + codeAndMessage[1]); //catch
    }

    private void OnCreatedRoom()
    {
        print("Room create successfully.");
    }
}
