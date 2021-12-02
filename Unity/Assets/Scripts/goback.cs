using UnityEngine;
using System.Collections;

public class goback : MonoBehaviour {
    
	public void gobackhistory () {
        WebManager.instance._webView.GoBack();
	}
}
