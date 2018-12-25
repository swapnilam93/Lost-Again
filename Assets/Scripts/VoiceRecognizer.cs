using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognizer : MonoBehaviour {

	private string[] keywords;

	public bool blowDetected;

	private KeywordRecognizer recognizer;

	// Use this for initialization
	void Start () {
		blowDetected = false;
		keywords = new string[1];
		keywords[0] = "Foo";
		recognizer = new KeywordRecognizer(keywords);
		recognizer.OnPhraseRecognized += OnPhraseRecognized;
		recognizer.Start();
	}
	
	private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		Debug.Log("sound heard");
		Debug.Log(args.text);
		if(args.text == keywords[0]) {
			blowDetected = true;
		}
		recognizer.Stop();
	}
}
