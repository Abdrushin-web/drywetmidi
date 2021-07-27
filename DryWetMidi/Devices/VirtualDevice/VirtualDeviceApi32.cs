﻿using System;
using System.Runtime.InteropServices;

namespace Melanchall.DryWetMidi.Devices
{
    internal sealed class VirtualDeviceApi32 : VirtualDeviceApi
    {
        #region Constants

        private const string LibraryName = LibraryName32;

        #endregion

        #region Extern functions

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern API_TYPE GetApiType();

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern VIRTUAL_OPENRESULT OpenVirtualDevice_Apple(IntPtr name, IntPtr sessionHandle, Callback_Apple callback, out IntPtr info);

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern VIRTUAL_CLOSERESULT CloseVirtualDevice(IntPtr info);

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern VIRTUAL_SENDBACKRESULT SendDataBackFromVirtualDevice(IntPtr pktlist, IntPtr readProcRefCon);

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern IntPtr GetInputDeviceInfoFromVirtualDevice(IntPtr info);

        [DllImport(LibraryName, ExactSpelling = true)]
        private static extern IntPtr GetOutputDeviceInfoFromVirtualDevice(IntPtr info);

        #endregion

        #region Methods

        public override API_TYPE Api_GetApiType()
        {
            return GetApiType();
        }

        public override VIRTUAL_OPENRESULT Api_OpenDevice_Apple(string name, IntPtr sessionHandle, Callback_Apple callback, out IntPtr info)
        {
            var namePointer = Marshal.StringToHGlobalAnsi(name);
            return OpenVirtualDevice_Apple(namePointer, sessionHandle, callback, out info);
        }

        public override VIRTUAL_CLOSERESULT Api_CloseDevice(IntPtr info)
        {
            return CloseVirtualDevice(info);
        }

        public override VIRTUAL_SENDBACKRESULT Api_SendDataBack(IntPtr pktlist, IntPtr readProcRefCon)
        {
            return SendDataBackFromVirtualDevice(pktlist, readProcRefCon);
        }

        public override IntPtr Api_GetInputDeviceInfo(IntPtr info)
        {
            return GetInputDeviceInfoFromVirtualDevice(info);
        }

        public override IntPtr Api_GetOutputDeviceInfo(IntPtr info)
        {
            return GetOutputDeviceInfoFromVirtualDevice(info);
        }

        #endregion
    }
}
