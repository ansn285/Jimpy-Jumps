using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[10];
    [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[10];
    [SerializeField] private Button startGameButton = null, stateButton = null; //mapButton = null, 
    [SerializeField] private Image mapImage = null;

    [SerializeField] private Sprite readyImage, notReadyImage;

    [SerializeField] private Color red = new Color(1f, 0.326f, 0.326f, 1);
    [SerializeField] private Color green = new Color(0.61f, 1f, 0.61f, 1);
    [SerializeField] private Color waitColor;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    private bool isLeader;

    public bool IsLeader
    {
        set
        {
            isLeader = value;
            startGameButton.gameObject.SetActive(value);
            //mapButton.interactable = value;
        }
    }

    private NetworkManagerLobby room;

    private NetworkManagerLobby Room
    {
        get
        {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as NetworkManagerLobby;
        }
    }

    public override void OnStartAuthority()
    {
        // Here we can add checks for validating the name of the player
        // For now there is no check

        CmdSetDisplayName(PlayerNameInput.DisplayName);

        lobbyUI.SetActive(true);
    }

    public override void OnStartClient()
    {
        Room.RoomPlayers.Add(this);

        UpdateDisplay();
    }

    public override void OnStopClient()
    {
        Room.RoomPlayers.Remove(this);

        UpdateDisplay();
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();
    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

    private void UpdateDisplay()
    {
        if (!hasAuthority)
        {
            foreach (var player in Room.RoomPlayers)
            {
                if (player.hasAuthority)
                {
                    player.UpdateDisplay();
                    break;
                }
            }

            return;
        }

        for (int i = 0; i < playerNameTexts.Length; i++)
        {
            playerNameTexts[i].text = "Waiting...";
            playerNameTexts[i].fontSize = 25;
            playerNameTexts[i].color = waitColor;
            playerReadyTexts[i].text = string.Empty;
        }

        for (int i = 0; i < Room.RoomPlayers.Count; i++)
        {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            playerNameTexts[i].color = new Color(waitColor.r, waitColor.g, waitColor.b, 1);
            playerNameTexts[i].fontSize = 36;
            //playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady ?
            //    "<color = green>Ready</color>" :
            //    "<color = red>Not Ready</color>";

            if (Room.RoomPlayers[i].IsReady)
            {
                playerReadyTexts[i].text = "Ready";
                playerReadyTexts[i].color = green;
            }

            else
            {
                playerReadyTexts[i].text = "Not Ready";
                playerReadyTexts[i].color = red;
            }
        }
    }

    public void HandleReadyToStart(bool readyToStart)
    {
        if (!isLeader) { return; }

        startGameButton.interactable = readyToStart;
    }

    [Command]
    private void CmdSetDisplayName(string displayName)
    {
        DisplayName = displayName;
    }

    [Command]
    public void CmdReadyUp()
    {
        IsReady = !IsReady;
        
        UpdateStateButton();
        Room.NotifyPlayersOfReadyState();
    }

    [Command]
    public void CmdStartGame()
    {
        if (Room.RoomPlayers[0].connectionToClient != connectionToClient) { return; }
        
        // Start Game
        Room.StartGame(mapImage.sprite.name);
    }

    private void UpdateStateButton()
    {
        if (IsReady)
        {
            stateButton.image.color = red;
            stateButton.transform.Find("Image").GetComponent<Image>().sprite = notReadyImage;
        }

        else
        {
            stateButton.image.color = green;
            stateButton.transform.Find("Image").GetComponent<Image>().sprite = readyImage;
        }
    }

    public void UpdateStateButton(Button btn)
    {
        if (!isLeader)
        {
            if (!IsReady)
            {
                btn.image.color = red;
                btn.transform.Find("Image").GetComponent<Image>().sprite = notReadyImage;
            }

            else
            {
                btn.image.color = green;
                btn.transform.Find("Image").GetComponent<Image>().sprite = readyImage;
            }
        }
    }
}
