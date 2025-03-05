using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PageController _generalPageControllr;
    [SerializeField] private bool _IsInSleepMode;

    public float SecToGoSleep = 90;
    public float timer;
    private void Start() {
#if UNITY_STANDALONE_WIN
        Cursor.visible = false;

#endif

        timer = SecToGoSleep;
    }
    private void Update() {
        if (timer > 0)
            timer -= Time.deltaTime;


        if (timer <= 0)
            EnterSleepMode();

        if (Input.touchCount > 0)
            ExitSleepMode();
        if (Input.GetKeyDown(KeyCode.M))
            Cursor.visible = !Cursor.visible;
    }

    private void EnterSleepMode() {
        if (!_IsInSleepMode) {
            _IsInSleepMode = true;
            _generalPageControllr.OpenPage(0);
        }
    }
    private void ExitSleepMode() {
        timer = SecToGoSleep;

        _IsInSleepMode = false;
    }
}
