using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    [SerializeField]
    string _url;

    public void onClickButton()
    {
        Application.OpenURL(_url);
    }
}
