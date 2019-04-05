using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace BTAI{
    public class BT{
        public enum STATUS {SUCCESS,FAILURE,RUNNING};
        public Condition If(bool predicate){
            if(predicate){
                return new ConditionT();
            }
            return new ConditionF();
        }
        // public Sequence seq;
    }

    public interface Condition{
        BT.STATUS Do(params Func<BT.STATUS>[] actions);
    }

    public class ConditionT: Condition {
        public BT.STATUS Do(params Func<BT.STATUS>[] actions){
            for(int i = 0;i<actions.Length;i++){
                if((BT.STATUS)actions[i].DynamicInvoke() != BT.STATUS.SUCCESS){
                    return BT.STATUS.FAILURE;
                }
            }
            return BT.STATUS.SUCCESS;
        }
    }
    public class ConditionF: Condition{
       public  BT.STATUS Do(params Func<BT.STATUS>[] actions){
            return BT.STATUS.SUCCESS;
        }

    }
    public class Sequence{
        public List<Action> actions = new List<Action>();
        
    }
    // public struct Action{
    //     public BT.STATUS status;
        
    // }
}
