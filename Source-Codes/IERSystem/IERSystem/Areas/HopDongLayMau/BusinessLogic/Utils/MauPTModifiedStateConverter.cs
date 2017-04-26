using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.Utils
{
    public enum MauPTModifiedState
    {
        NoChange, Edited, Deleted
    }

    public static class MauPTModifiedStateConverter
    {
        public static MauPTModifiedState ToTinhTrangMau(byte mauptmodifedstate_data)
        {
            switch (mauptmodifedstate_data)
            {
                case 0: return MauPTModifiedState.NoChange;
                case 1: return MauPTModifiedState.Edited;
                case 2: return MauPTModifiedState.Deleted;
                default: return MauPTModifiedState.NoChange;
            }
        }

        public static byte ToByte(MauPTModifiedState mauptmodifedstate_data)
        {
            switch (mauptmodifedstate_data)
            {
                case MauPTModifiedState.NoChange: return 0;
                case MauPTModifiedState.Edited: return 1;
                case MauPTModifiedState.Deleted: return 2;
                default: return 3;
            }
        }
    }
}