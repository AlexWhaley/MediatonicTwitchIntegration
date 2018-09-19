using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TwitchChat : MonoBehaviour
{
    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;

    [SerializeField]
    private string _username;
    [SerializeField]
    private string _password;
    [SerializeField]
    private string _channelName;

    [SerializeField]
    private Text _twithChatBox;

    private const string TwitchHostname = "irc.chat.twitch.tv";


    void Start ()
    {
        Connect();
    }

    private void Update()
    {
        if (!_twitchClient.Connected)
        {
            Debug.Log("Not connected to twitch chat attempting to reconnect.");
            Connect();
        }

        ReadChat();
    }
    
    private void Connect()
    {
        _twitchClient = new TcpClient(TwitchHostname, 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine("PASS " + _password);
        _writer.WriteLine("NICK " + _username);
        _writer.WriteLine("USER " + _username + " 8 * :" + _username);
        _writer.WriteLine("JOIN #" + _channelName);
        _writer.Flush();
    }

    private void ReadChat()
    {
        if (_twitchClient.Available > 0)
        {
            var message = _reader.ReadLine();

            if (message.Contains("PRIVMSG"))
            {
                //Get the users name by splitting it from the string
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //Get users message by splitting it from the string
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);

                _twithChatBox.text = _twithChatBox.text + "\n" + string.Format("{0}: {1}", chatName, message);
            }
        }
    }
}
