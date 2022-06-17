namespace Radio
{
    internal static class WM
    {
        public const int WM_POWERBROADCAST          = 0x218;
        public const int PBT_APMPOWERSTATUSCHANGE   = 0xA;
        public const int PBT_APMRESUMEAUTOMATIC     = 0x12;
        public const int PBT_APMRESUMESUSPEND       = 0x7;
        public const int PBT_APMSUSPEND             = 0x4;
        public const int PBT_POWERSETTINGCHANGE     = 0x8013;
    }
}