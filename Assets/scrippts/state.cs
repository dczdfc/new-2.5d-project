using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour
{
    public virtual void update(){}
    public virtual void fixedupdate(){}
    public virtual void start(){}


    public virtual void exitState(){  }
}
