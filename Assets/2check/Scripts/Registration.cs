using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour {
    public static Dictionary<string, bool> isValid = new Dictionary<string, bool>
    {
        {"Name",false},
        {"School",false},
        {"PhoneNumber",false},
        {"CertificateNumber",false},
        {"CertificateYear", true },
        {"Pin",false},
        {"SchoolCertificateNumber", false },
        {"SchoolMark", false },
        {"Understand", false }
    };
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Submit()
    {

    }
}
