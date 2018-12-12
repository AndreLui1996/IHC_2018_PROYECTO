using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class CGestures : MonoBehaviour
{
    public Controller Controller;
    // Use this for initialization
    void Start()
    {
        Controller = new Controller();
        Debug.Log("START");
        Controller.EnableGesture(Gesture.GestureType.TYPECIRCLE, true);
        Controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP, true);
        Controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP, true);
        Controller.EnableGesture(Gesture.GestureType.TYPESWIPE, true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");
        Frame frame = Controller.Frame();
        GestureList gestures = frame.Gestures();

        Debug.Log(" gestures: "+gestures.Count.ToString());

        for (int i = 0; i < gestures.Count; i++)
        {
            Gesture gesture = gestures[0];
            switch (gesture.Type)
            {
                case Gesture.GestureType.TYPECIRCLE:
                    Debug.Log("Circle");
                    break;
                case Gesture.GestureType.TYPEKEYTAP:
                    Debug.Log("keytap");
                    break;
                case Gesture.GestureType.TYPESWIPE:
                    Debug.Log("swipe");
                    break;
                case Gesture.GestureType.TYPE_SCREEN_TAP:
                    Debug.Log("screen tap");
                    break;
                default:
                    Debug.Log("Bad gesture type");
                    break;
            }
        }

    }
}
