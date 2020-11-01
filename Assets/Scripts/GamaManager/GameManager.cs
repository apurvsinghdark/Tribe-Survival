using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if( instance != this)
        {
            Destroy(this);
        }
    }

    //public GameObject Player;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public GameObject localPlayerPrefeb;
    public GameObject playerPrefeb;

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if(_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefeb, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefeb, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;

        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
