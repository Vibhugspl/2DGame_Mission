using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gameplay : MonoBehaviour
{
	[Header("Url_Links")]
	public string Link;

	[Header("LoginInfo")]
	public InputField Name;
	public InputField User_Passward;
	public Text Message_For_User;


	[Header("RegistrationInfo")]
	public InputField userName_register;
	public InputField Passward_Register;
	public InputField Email;
	public InputField confirm_Passward;
	public Text Message_For_registration_text;

	[Header("RegistrationInfo_Internal")]
	protected string Confirm_Passward_text;
	protected string Email_text=null;
	protected string user_Registration_name;
	protected string Registered_Passward_text;

	[Header("LoginInfo_Internal")]
	protected string Name_Filed=null;
	protected string Passward=null;

	[Header("DataBase")]
	[HideInInspector]
	public Dictionary<string,string> userName=new Dictionary<string,string>();  //Protected method Can be accesed within the class it's declared, it can also be accesed from the instance of derived class
	protected List<string> Email_id=new List<string>();


	[Header("AllTexts")]
	public List<Text> Alltexts_=new List<Text>();

//.............................................................//.........................................................................................................................................................
	public static Gameplay Instance {
		get;
		private set;
	}



//.............................................................//.........................................................................................................................................................
	private	void Awake()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else 
		{
			Destroy (gameObject);
		}
	}

	public void OpenYoutube()
	{
		Application.OpenURL (Link);

	}

	public void QuitGame()
	{

		Application.Quit ();

	}

	public void saveName()
	{
		user_Registration_name = userName_register.GetComponent<InputField> ().text;
		Registered_Passward_text = Passward_Register.GetComponent<InputField> ().text;
		Email_text = Email.GetComponent<InputField> ().text;
		Confirm_Passward_text = confirm_Passward.GetComponent<InputField> ().text;

		if(user_Registration_name!="" && Registered_Passward_text!="" && Email_text !="" && Confirm_Passward_text!="")
		{

		if ((!(userName.ContainsKey (user_Registration_name) && Email_id.Contains (Email_text))) && Registered_Passward_text==Confirm_Passward_text) 
		{
			userName.Add (user_Registration_name, Registered_Passward_text);
			Email_id.Add (Email_text);
			Message_For_registration_text.text = "Successfully Registered";
			RemoveAllTexts ();
		}
		
		}
		else
		{
			Message_For_registration_text.text = "Please fill All details";
			RemoveAllTexts ();
		}
			
		print (userName.Count);
		Name_Filed = null;
		Passward = null;
	}



	public void Login()
	{
		Name_Filed = Name.GetComponent<InputField> ().text;
		Passward = User_Passward.GetComponent<InputField> ().text;


		print (Name_Filed +":"+ Passward);
		if (Name_Filed != "" && Passward != "") 
		{

			if (userName.ContainsKey (Name_Filed) && (userName.ContainsValue (Passward))) 
			{
				Message_For_User.text = "Login Succesfull";
				Message_For_User.color = Color.blue;
				RemoveAllTexts ();
			}
			else if (!(userName.ContainsValue (Name_Filed) && (userName.ContainsKey (Passward)))) 
			{
				Message_For_User.text = "Login Failed Please Register";
				Message_For_User.color = Color.red;
				RemoveAllTexts ();
			}
		}
		else if(Name_Filed == "" || Passward == "")
		{
			Message_For_User.text = "Please Fill All Detals";
			RemoveAllTexts ();
		}

	}

	public void RemoveAllTexts()
	{
		for (int i = 0; i < Alltexts_.Count; i++)
		{
			Alltexts_ [i].text = "";
		}
	}
}
