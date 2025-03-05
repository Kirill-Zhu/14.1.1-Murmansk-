using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PhototnController : MonoBehaviour, IPunObservable {

    //public static PhototnController instance;
    private PhotonView _photonView;
    private RectTransform _rectTransform;
    private Transform _transform;
    private Image _image;

    public Vector3 networkScale;
    public Vector3 networkPostion;
    public bool AtCentre;
    private void Awake() {
        TryGetComponent<RectTransform>(out _rectTransform);
        _transform = GetComponent<Transform>();

        _photonView = GetComponent<PhotonView>();
        transform.parent = ImageListenScale.Instance.gameObject.transform;
        _image = GetComponent<Image>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {

            stream.SendNext(networkScale);
            stream.SendNext(networkPostion);

        } else {

            networkScale = (Vector3)stream.ReceiveNext();
            networkPostion = (Vector3)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame  
    void Update() {


        if (!_photonView.IsMine) {
            _rectTransform.localScale = networkScale;
            _rectTransform.localPosition = networkPostion;
        } else {
            networkScale = _rectTransform.localScale;
            networkPostion = _rectTransform.localPosition;
        }
    }

}
