/*
* Create by DeokwonKim
* Blog : proal.tistory.com
*/

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleCtrl : MonoBehaviour {

    [SerializeField]
    BubbleTextCtrl _bubbleText;

    [SerializeField]
    float _maxImageWidth = 0f; // zero to inf
    public float maxImageWidth { set { _maxImageWidth = value; } get { return _maxImageWidth; } }

    [SerializeField]
    float _maxImageHeight = 0f;
    public float maxImageHeight { set { _maxImageHeight = value; } get { return _maxImageHeight; } }

    [SerializeField]
    float _printSpeed = 0.1f;
    public float printSpeed { set { _printSpeed = value; } get { return _printSpeed; } }

    [SerializeField]
    bool _isSayToClear;
    public bool isSayToClear { set { _isSayToClear = value; } get { return _isSayToClear; } }

    LayoutElement _layoutElement;
    public LayoutElement layoutElement { get { return _layoutElement; } }

    ContentSizeFitter _contentSizeFitter;
    public ContentSizeFitter contentSizeFitter { get { return _contentSizeFitter; } }

    StringBuilder _builder = new StringBuilder();
    public bool isTextPrinting { private set; get; }

	void Start ()
    {
        isTextPrinting = false;
        _layoutElement = GetComponent<LayoutElement>();
        _contentSizeFitter = GetComponent<ContentSizeFitter>();
    }

    public void setText(string text)
    {
        StartCoroutine(printText(text, 0f));
    }

    public void setText(string text, float delay, bool isSayToClear = true)
    {
        _isSayToClear = isSayToClear;
        StartCoroutine(printText(text, delay));
    }

    IEnumerator printText(string text, float delay)
    {
        char[] words = text.ToCharArray();
        float speed = delay.Equals(0) ? _printSpeed : delay;

        if (_isSayToClear)
            _builder.Remove(0, _builder.Length);

        for (int i = 0; i < words.Length; i++)
        {
            _bubbleText.text.text = _builder.Append(words[i]).ToString();
            if (_bubbleText.text.preferredWidth + 100 < _maxImageWidth)
                _layoutElement.preferredWidth = _bubbleText.text.preferredWidth + 100;

            if (_bubbleText.text.preferredHeight + 100 < _maxImageHeight)
                _layoutElement.preferredHeight = _bubbleText.text.preferredHeight + 100;
            yield return new WaitForSeconds(speed);
        }
    }

    public void cleanBubbleText()
    {
        _bubbleText.text.text = string.Empty;
    }
}
