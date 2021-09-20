using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    //private NetworkManagerLobby room;
    //private NetworkManagerLobby Room
    //{
    //    get
    //    {
    //        if (room != null) { return room; }
    //        return room = NetworkManager.singleton as NetworkManagerLobby;
    //    }
    //}

    private void Awake()
    {
        animator.Play("RoundSystem");
        Time.timeScale = 0;
    }

    public void CountdownEnded()
    {
        animator.enabled = false;
        Time.timeScale = 1;
    }


    //#region Server
    //public override void OnStartServer()
    //{
    //    NetworkManagerLobby.OnServerStopped += CleanUpServer;
    //    NetworkManagerLobby.OnServerReadied += CheckToStartRound;
    //}

    //[ServerCallback]

    //private void OnDestroy() => CleanUpServer();

    //[Server]
    //private void CleanUpServer()
    //{
    //    NetworkManagerLobby.OnServerStopped -= CleanUpServer;
    //    NetworkManagerLobby.OnServerReadied -= CheckToStartRound;
    //}

    //[ServerCallback]
    //public void StartRound()
    //{
    //    RpcStartRound();
    //}


    //[Server]
    //private void CheckToStartRound(NetworkConnection conn)
    //{
    //    if (Room.GamePlayers.Count(x => x.connectionToClient.isReady) != Room.GamePlayers.Count) { return; }

    //    animator.enabled = true;
    //    RpcStartCountdown();
    //}

    //#endregion



    
    //#region Client

    //[ClientRpc]
    //private void RpcStartCountdown()
    //{
    //    animator.enabled = true;
    //}

    //[ClientRpc]
    //private void RpcStartRound()
    //{
    //    InputManager.Remove(ActionMapNames.Player);
    //}

    //#endregion
}
