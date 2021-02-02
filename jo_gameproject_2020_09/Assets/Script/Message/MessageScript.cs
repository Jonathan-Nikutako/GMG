using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


public class MessageScript : MonoBehaviour
{
    public Message messageScript;                            // Messageスクリプトを読み込む
    private Dictionary<string, MessageInfo> message_dic;     //メッセージ格納ディクショナリ

    void Awake()
    {
        message_dic = loadMessage();
    }

    public void Message(string Id)
    {
        messageScript.SetMessagePanel(message_dic[Id]);
    }

    //IEnumerator Message()// Messageコルーチン 
    //{
    //    yield return new WaitForSeconds(0.01f);// 0.01秒待つ
    //    messageScript.SetMessagePanel(message);// messageScriptのSetMessagePanelを実行する
    //}
    //csvからの読み込み
    private Dictionary<string, MessageInfo> loadMessage()
    {
        string[] load_message = null;

        //csvファイルの読み込み
        //StreamReader sr = new StreamReader(@"Assets/message.csv");
        //メッセージの取得
        // string get_message = sr.ReadLine();
        Encoding encoding = Encoding.GetEncoding("utf-8");
        string get_message = File.ReadAllText(@"Assets/message.csv", encoding);
        //Debug.Log(get_message);
        //改行コードを分割のコンマに変換
        get_message = get_message.Replace(System.Environment.NewLine, ",");
        //改行コードの変換によってつくられる最後のコンマを削除
        get_message = get_message.Remove(get_message.LastIndexOf(","));
        //メッセージのコンマで分割
        load_message = get_message.Split(',');

        //for(int i = 0; i < load_message.Length; i++)
        //{
        //    Debug.Log(load_message[i]);
        //}

        //ロードしたメッセージを格納
        Dictionary<string, MessageInfo> message = new Dictionary<string, MessageInfo>();
        for(int i = 0; i < load_message.Length; i++)
        {
            MessageInfo message_info = new MessageInfo();
            //メッセージid格納
            message_info.setId(load_message[i]);

            //メッセンジャー格納
            i++;
            message_info.setMessenger(load_message[i]);

            //メッセージ内容格納
            i++;
            message_info.setMessage(load_message[i]);

            //表示画像名格納
            i++;
            if (load_message[i].Equals(""))
            {
                message_info.setImage(null);
            }
            else
            {
            message_info.setImage(load_message[i]);
            }

            //keyの設定
            string key = message_info.getId();
            message.Add(key, message_info);
        }

        return message;

    }
}
