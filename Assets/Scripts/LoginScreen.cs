using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class LoginScreen : MonoBehaviour
{
    [Header("Login Screen canvas variables")]
    [SerializeReference] private Canvas loginScreen;
    [SerializeReference] private TMP_InputField username;
    [SerializeReference] private TMP_InputField password;
    [SerializeReference] private Telepathy.Client client;

    [Header("Server Mode canvas variables")]
    [SerializeReference] private Canvas serverMode;
    [SerializeReference] private Button startServer;
    [SerializeReference] private Button stopServer;
    [SerializeReference] private Button back;
    [SerializeReference] private NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnClickLogin()
    {
        Debug.Log("OnClickLogin function called. Trying to autenticate and join server");
        //Check which server is selected, it should be online and joinable

        //Encrypt username and password variables

        //Submit encrypted username and password to database to confirm authentication

        //Save authentication token/network identity?
        networkManager.StartClient();
        //Load next Scene

    }
    public void OnClickExitGame()
    {
        Debug.Log("OnClickExitGame function called. Quitting app");
        Application.Quit();
    }
    public void OnClickServerMode()
    {
        Debug.Log("OnClickServerMode function called. Hiding Canvas_LoginScreen and showing Canvas_ServerMode");
        //Hide/Deactivate Canvas_LoginScreen
        loginScreen.enabled = false;

        //Show/Activate Canvas_ServerMode
        serverMode.enabled = true;
    }
    public void OnClickBackToLoginScreen()
    {
        Debug.Log("OnClickBackToLoginScreen function called. Hiding Canvas_ServerMode and showing Canvas_LoginScreen");
        //Hide/Deactivate Canvas_ServerMode
        serverMode.enabled = false;

        //Show/Activate Canvas_LoginScreen
        loginScreen.enabled = true;
    }
    public void OnClickStartServer()
    {
        Debug.Log("OnClickStartServer function called. Disables Btn_StartServer and Btn_BackToLoginScreen. Starting server and then enables Btn_StopServer");
        //Disable Btn_StartServer
        startServer.interactable = false;
        //Disable Btn_BackToLoginScreen
        back.interactable = false;
        //Try to start server hosting
        networkManager.StartServer();
        //Enable Btn_StopServer
        stopServer.interactable = true;
    }
    public void OnClickStopServer()
    {
        Debug.Log("OnClickStopServer function called. Disables Btn_StopServer. Stops server and then enables Btn_StartServer and Btn_BackToLoginScreen");
        //Disable Btn_StopServer
        stopServer.interactable = false;
        //Stop server hosting
        networkManager.StopServer();
        //Enable Btn_StartServer
        startServer.interactable = true;
        //Enable Btn_BackToLoginScreen
        back.interactable = true;
    }
}
