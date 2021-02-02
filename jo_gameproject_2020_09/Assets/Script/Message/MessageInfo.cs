using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageInfo : MonoBehaviour
{
    // Start is called before the first frame update
    string Id = null;                  //メッセージID
    string messenger = null;           //メッセージ発信者
    string message = null;             //メッセージ内容
    string image = null;               //表示画像名

    public string getId()
    {
        return this.Id;
    }
    public void setId(string Id)
    {
        this.Id = Id;
    }
    public string getMessenger()
    {
        return this.messenger;
    }
    public void setMessenger(string messenger)
    {
        this.messenger = messenger;
    }
    public string getMessage()
    {
        return this.message;
    }
    public void setMessage(string message)
    {
        this.message = message;
    }
    public string getImage()
    {
        return this.image;
    }
    public void setImage(string image)
    {
        this.image = image;
    }
}
