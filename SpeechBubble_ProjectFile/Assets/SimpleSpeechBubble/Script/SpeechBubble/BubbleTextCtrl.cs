using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTextCtrl : MonoBehaviour {

    [SerializeField]
    float _widthMargin = 0f;

    [SerializeField]
    float _heightMargin = 0f;

    RectTransform _mine;
    RectTransform _parent;
    Text _text;
    public Text text { get { return _text; } }

    void Start ()
    {
        _text = GetComponent<Text>();
        _mine = GetComponent<RectTransform>();
        _parent = transform.parent.GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        _mine.sizeDelta = new Vector2(_parent.rect.width - _widthMargin, _parent.rect.height - _heightMargin);
    }
}
