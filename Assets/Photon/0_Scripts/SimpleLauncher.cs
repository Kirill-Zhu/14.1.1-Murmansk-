using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SimpleLauncher : MonoBehaviourPunCallbacks, IPunObservable {

    public PhotonView playerPrefab;
    public RectTransform container;

    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined a room.");
        var obj = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(container);
        var UI = obj.GetComponent<RectTransform>();
        UI.SetParent(container);

        UI.GetComponent<Image>().SetNativeSize();


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        throw new System.NotImplementedException();
    }
}