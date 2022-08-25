using System;
using System.Text;
using System.Runtime.InteropServices;

using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;

namespace PvNET
{
	/// <summary>
	/// .NET interface to Prosilica Vision API
	/// </summary>
	
	public enum tErr :uint //32
	{
		eErrSuccess       = 0,        // No error
		eErrCameraFault   = 1,        // Unexpected camera fault
		eErrInternalFault = 2,        // Unexpected fault in PvApi or driver
		eErrBadHandle     = 3,        // Camera handle is invalid
		eErrBadParameter  = 4,        // Bad parameter to API call
		eErrBadSequence   = 5,        // Sequence of API calls is incorrect
		eErrNotFound      = 6,        // Camera or attribute not found
		eErrAccessDenied  = 7,        // Camera cannot be opened in the specified mode
		eErrUnplugged     = 8,        // Camera was unplugged
		eErrInvalidSetup  = 9,        // Setup is invalid (an attribute is invalid)
		eErrResources     = 10,       // System/network resources or memory not available
		eErrBandwidth     = 11,       // 1394 bandwidth not available
		eErrQueueFull     = 12,       // Too many frames on queue
		eErrBufferTooSmall= 13,       // Frame buffer is too small
		eErrCancelled     = 14,       // Frame cancelled by user
		eErrDataLost      = 15,       // The data for the frame was lost
		eErrDataMissing   = 16,       // Some data in the frame is missing
		eErrTimeout       = 17,       // Timeout during wait
		eErrOutOfRange    = 18,       // Attribute value is out of the expected range
		eErrWrongType     = 19,       // Attribute is not this type (wrong access function) 
		eErrForbidden     = 20,       // Attribute write forbidden at this time
		eErrUnavailable   = 21,       // Attribute is not available at this time	
	};

	public enum tAccessFlags :uint //32
	{
		eAccessMonitor        = 2, // Monitor access: no control, read & listen only
		eAccessMaster         = 4  // Master access: full control
	};

	public enum tInterface :uint //32
	{
		eInterfaceFirewire    = 1,
		eInterfaceEthernet    = 2
	};

	public enum tLinkEvent :uint //32
	{
		eLinkAdd          = 1, // A camera was plugged in
		eLinkRemove       = 2, // A camera was unplugged
	}; 

	public enum tDatatype :uint //32
	{
		eDatatypeUnknown    = 0,
		eDatatypeCommand    = 1,
		eDatatypeRaw        = 2,
		eDatatypeString     = 3,
		eDatatypeEnum       = 4,
		eDatatypeUint32     = 5,
		eDatatypeFloat32    = 6,
		ePvDatatypeInt64    = 7,
		ePvDatatypeBoolean  = 8

	};

	public enum tIpConfig :uint //32
	{
		eIpConfigPersistent   = 1,            // Use persistent IP settings
		eIpConfigDhcp         = 2,            // Use DHCP, fallback to AutoIP
		eIpConfigAutoIp       = 4             // Use AutoIP only
	};

	public enum tImageFormat :uint //32
	{
		eFmtMono8           = 0,            // Monochrome, 8 bits
		eFmtMono16          = 1,            // Monochrome, 16 bits, data is LSB aligned
		eFmtBayer8          = 2,            // Bayer-color, 8 bits
		eFmtBayer16         = 3,            // Bayer-color, 16 bits, data is LSB aligned
		eFmtRgb24           = 4,            // RGB, 8 bits x 3
		eFmtRgb48           = 5,            // RGB, 16 bits x 3, data is LSB aligned
		eFmtYuv411          = 6,            // YUV 411
		eFmtYuv422          = 7,            // YUV 422
		eFmtYuv444          = 8,            // YUV 444
		eFmtBgr24           = 9,            // BGR, 8 bits x 3
		eFmtRgba32          = 10,           // RGBA, 8 bits x 4
		eFmtBgra32          = 11,           // BGRA, 8 bits x 4
		eFmtMono12Packed    = 12,           // Monochrome, 12 bits, 
		eFmtBayer12Packed   = 13            // Bayer-color, 12 bits, packed 
	};

	public enum tBayerPattern :uint  //32
	{
		eBayerRGGB        = 0,            // First line RGRG, second line GBGB...
		eBayerGBRG        = 1,            // First line GBGB, second line RGRG...
		eBayerGRBG        = 2,            // First line GRGR, second line BGBG...
		eBayerBGGR        = 3             // First line BGBG, second line GRGR...
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tIpSettings
	{
		// IP configuration mode: persistent, DHCP & AutoIp, or AutoIp only.
		public tIpConfig	 ConfigMode;
		// IP configuration mode supported by the camera
		public UInt32       ConfigModeSupport;

		// Current IP configuration.  Ignored for PvCameraIpSettingsChange().  All
		// values are in network byte order (i.e. big endian).
		public UInt32       CurrentIpAddress;
		public UInt32       CurrentIpSubnet;
		public UInt32       CurrentIpGateway;

		// Persistent IP configuration.  See "ConfigMode" to enable persistent IP
		// settings.  All values are in network byte order.
		public UInt32       PersistentIpAddr;
		public UInt32       PersistentIpSubnet;
		public UInt32       PersistentIpGateway;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public UInt32[]		_reserved1;         // Always zero
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tCameraInfo
	{
		public UInt32       UniqueId;         // Unique value for each camera
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
		public string		SerialString;     // Camera's serial number
		public UInt32       PartNumber;       // Camera part number
		public UInt32       PartVersion;      // Camera part version
		public UInt32       PermittedAccess;  // A combination of tPvAccessFlags
		public UInt32       InterfaceId;      // Unique value for each interface or bus
		public tInterface	InterfaceType;    // Interface type; see tPvInterface
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=16)]
		public string		DisplayName;     // People-friendly camera name
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
		public UInt32[]		_reserved;         // Always zero
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tAttributeInfo
	{
        public tDatatype Datatype;       // Data type
        public UInt32 Flags;          // Combination of tPvAttribute flags
        public IntPtr Category;       // Advanced: see documentation
        public IntPtr Impact;         // Advanced: see documentation
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] _reserved;      // Always zero
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tFrameCtx
	{
		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;				
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tFrameRes1
	{
		public UInt32 _reserved00;
		public UInt32 _reserved01;
		public UInt32 _reserved02;
		public UInt32 _reserved03;
		public UInt32 _reserved04;
		public UInt32 _reserved05;
		public UInt32 _reserved06;
		public UInt32 _reserved07;					
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tFrameRes2
	{
		public UInt32 _reserved00;
		public UInt32 _reserved01;
		public UInt32 _reserved02;
		public UInt32 _reserved03;
		public UInt32 _reserved04;
		public UInt32 _reserved05;
		public UInt32 _reserved06;
		public UInt32 _reserved07;
		public UInt32 _reserved08;
		public UInt32 _reserved09;
		public UInt32 _reserved10;
		public UInt32 _reserved11;
		public UInt32 _reserved12;
		public UInt32 _reserved13;
		public UInt32 _reserved14;
		public UInt32 _reserved15;
		public UInt32 _reserved16;
		public UInt32 _reserved17;
		public UInt32 _reserved18;
		public UInt32 _reserved19;
		public UInt32 _reserved20;
		public UInt32 _reserved21;
		public UInt32 _reserved22;
		public UInt32 _reserved23;
		public UInt32 _reserved24;
		public UInt32 _reserved25;
		public UInt32 _reserved26;
		public UInt32 _reserved27;
		public UInt32 _reserved28;
		public UInt32 _reserved29;
		public UInt32 _reserved30;
		public UInt32 _reserved31;				
	};

	[StructLayout(LayoutKind.Sequential, Pack=8, CharSet=CharSet.Ansi)]
	public struct tFrame
	{
		//----- In -----
		public IntPtr			ImageBuffer;		// Your image buffer
		public UInt32			ImageBufferSize;    // Size of your image buffer in bytes
		public IntPtr           AncillaryBuffer;    // Your buffer to capture associated 
		//   header & trailer data for this image.
		public UInt32			AncillaryBufferSize;// Size of your ancillary buffer in bytes
		//   (can be 0 for no buffer).
		public tFrameCtx		Context;

		tFrameRes1				_Reserved1;			// Reserved data (always 0)

		//----- Out -----

		public tErr				Status;             // Status of this frame

		public UInt32			ImageSize;          // Image size, in bytes
		public UInt32			AncillarySize;      // Ancillary data size, in bytes

		public UInt32			Width;              // Image width
		public UInt32			Height;             // Image height
		public UInt32			RegionX;            // Start of readout region (left)
		public UInt32			RegionY;            // Start of readout region (top)
		public tImageFormat		Format;             // Image format
		public UInt32			BitDepth;           // Number of significant bits
		public tBayerPattern	BayerPattern;       // Bayer pattern, if bayer format

		public UInt32			FrameCount;         // Rolling frame counter
		public UInt32			TimestampLo;        // Time stamp, lower 32-bits
		public UInt32			TimestampHi;        // Time stamp, upper 32-bits

		tFrameRes2				_Reserved2;			// Reserved data (always 0)
	};

	public delegate void tLinkCallback(IntPtr Context,tInterface Interface,tLinkEvent Event,UInt32 UniqueId);
	public delegate void tFrameCallback(IntPtr pFrame);


	public class CPv
	{

        [DllImport("PvAPI.dll", EntryPoint = "PvInitialize", ExactSpelling = false)]   //,CallingConvention=CallingConvention.StdCall)
		public static extern tErr Initialize();

        [DllImport("PvAPI.dll", EntryPoint = "PvInitializeNoDiscovery", ExactSpelling = false)]  //, CallingConvention = CallingConvention.StdCall
		public static extern tErr InitializeNoDiscovery();

        [DllImport("PvAPI.dll", EntryPoint = "PvUnInitialize", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern void UnInitialize();

        [DllImport("PvAPI.dll", EntryPoint = "PvVersion", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern void Version(ref UInt32 Major ,ref UInt32 Minor);

        [DllImport("PvAPI.dll", EntryPoint = "PvLinkCallbackRegister", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr LinkCallbackRegister(tLinkCallback Callback,tLinkEvent Event,IntPtr Context);

        [DllImport("PvAPI.dll", EntryPoint = "PvLinkCallbackUnRegister", ExactSpelling = false)] //, CallingConvention = CallingConvention.StdCall
		public static extern tErr LinkCallbackUnregister(tLinkCallback Callback,tLinkEvent Event);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraCount", ExactSpelling = false)]    ///, CallingConvention = CallingConvention.StdCall
		public static extern UInt32 CameraCount();

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraInfo", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraInfo(UInt32 UniqueId,ref tCameraInfo Info);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraInfoByAddr", ExactSpelling = false)] //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraInfoByAddr(UInt32 IpAddr,ref tCameraInfo Info,ref tIpSettings IpSettings);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraList", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern UInt32 CameraList([MarshalAs(UnmanagedType.LPArray)] [In,Out] tCameraInfo[] Info,UInt32 ListLength,ref UInt32 ConnectedNum);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraListUnreachable", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern UInt32 CameraListUnreachable([MarshalAs(UnmanagedType.LPArray)] [In,Out] tCameraInfo[] Info,UInt32 ListLength,ref UInt32 ConnectedNum);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraIpSettingsGet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraIpSettingsGet(UInt32 UniqueId,ref tIpSettings Settings);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraIpSettingsChange", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraIpSettingsSet(UInt32 UniqueId,ref tIpSettings Settings);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraOpen", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraOpen(UInt32 UniqueId,tAccessFlags AccessFlag,out UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraOpenByAddr", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraOpenByAddr(UInt32 IpAddr,tAccessFlags AccessFlag,out UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCameraClose", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CameraClose(UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureStart", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureStart(UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureEnd", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureEnd(UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureQuery", ExactSpelling = false)] //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureQuery(UInt32 Camera,ref UInt32 IsStarted);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureAdjustPacketSize", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureAdjustPacketSize(UInt32 Camera,UInt32 MaxSize);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureQueueFrame", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureQueueFrame(UInt32 Camera,[In,Out] IntPtr Frame,tFrameCallback Callback);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureQueueClear", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureQueueClear(UInt32 Camera);

        [DllImport("PvAPI.dll", EntryPoint = "PvCaptureWaitForFrameDone", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CaptureWaitForFrameDone(UInt32 Camera,[In,Out]IntPtr Frame,UInt32 Timeout);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrList", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrList(UInt32 Camera,ref IntPtr ListPtr,ref UInt32 Length);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrInfo", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrInfo(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,ref tAttributeInfo Info);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrExists", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrExists(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrIsAvailable", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrIsAvailable(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrIsValid", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrIsValid(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrRangeEnum", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrRangeEnum(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,StringBuilder String,UInt32 BufferSize,ref UInt32 Size);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrRangeUint32", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrRangeUint32(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,ref UInt32 Min,ref UInt32 Max);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrRangeInt64", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrRangeInt64(UInt32 Camera, [MarshalAs(UnmanagedType.LPStr)] String Name, ref Int64 Min, ref Int64 Max);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrRangeFloat32", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrRangeFloat32(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,ref float Min,ref float Max);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrStringGet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrStringGet(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,StringBuilder String,UInt32 BufferSize,ref UInt32 Size);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrStringSet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrStringSet(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,[MarshalAs(UnmanagedType.LPStr)] String Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrEnumGet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrEnumGet(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,StringBuilder String,UInt32 BufferSize,ref UInt32 Size);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrEnumSet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrEnumSet(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,[MarshalAs(UnmanagedType.LPStr)] String Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrBooleanGet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrBooleanGet(UInt32 Camera, [MarshalAs(UnmanagedType.LPStr)] String Name, [In, Out] ref Boolean Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrBooleanSet", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrBooleanSet(UInt32 Camera, [MarshalAs(UnmanagedType.LPStr)] String Name, Boolean Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrUint32Get", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrUint32Get(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,[In,Out] ref UInt32 Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrUint32Set", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrUint32Set(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,UInt32 Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrInt64Get", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrInt64Get(UInt32 Camera, [MarshalAs(UnmanagedType.LPStr)] String Name, [In, Out] ref Int64 Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrInt64Set", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrInt64Set(UInt32 Camera, [MarshalAs(UnmanagedType.LPStr)] String Name, Int64 Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrFloat32Get", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrFloat32Get(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,ref float Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvAttrFloat32Set", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern tErr AttrFloat32Set(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name,float Value);

        [DllImport("PvAPI.dll", EntryPoint = "PvCommandRun", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern tErr CommandRun(UInt32 Camera,[MarshalAs(UnmanagedType.LPStr)] String Name);

        [DllImport("PvAPI.dll", EntryPoint = "PvUtilityColorInterpolate", ExactSpelling = false)]    ///, CallingConvention = CallingConvention.StdCall
		public static extern void ColorInterpolate([In,Out]IntPtr pFrame,IntPtr BufferRed,IntPtr BufferGreen,IntPtr BufferBlue,UInt32 PixelPadding,UInt32 LinePadding);

        [DllImport("PvAPI.dll", EntryPoint = "_Pv_Factory_Test_11", ExactSpelling = false)]    //, CallingConvention = CallingConvention.StdCall
		public static extern UInt32 RegisterWrite(UInt32 Camera, UInt32 NumWrites, [MarshalAs(UnmanagedType.LPArray)] [In] UInt32[] AddressArray, [MarshalAs(UnmanagedType.LPArray)] [In] UInt32[] DataArray, ref UInt32 NumComplete);

        [DllImport("PvAPI.dll", EntryPoint = "_Pv_Factory_Test_10", ExactSpelling = false)]   //, CallingConvention = CallingConvention.StdCall
		public static extern UInt32 RegisterRead(UInt32 Camera, UInt32 NumReads, [MarshalAs(UnmanagedType.LPArray)] [In] UInt32[] AddressArray, [MarshalAs(UnmanagedType.LPArray)] [Out] UInt32[] DataArray, ref UInt32 NumComplete);
		

		    
//		public CPv()
//		{
//			//
//			// TODO: 여기에 생성자 논리를 추가합니다.
//			//
//			
//		}
	}


	public class CKid
	{

        [DllImport("gdi32.dll")]     //, CallingConvention = CallingConvention.Cdecl)
		private static extern bool DeleteObject(IntPtr hObject);        

		public struct tCamera
		{
			public UInt32 UID;
			public UInt32 Handle;
			public tFrame Frame;
			public GCHandle GC;
			public byte[] Buffer;
		};

		static void FrameDummyCB(IntPtr pFrame)
		{
		}

		// wait for a camera to be detected
		public static bool WaitForCamera()
		{

			int timeOutCount = 0;
			int timeOutLimit = 3000;
			int loopDelay = 250;
			//System.Console.WriteLine("waiting for a camera ");
			while (CPv.CameraCount() == 0)
			{
				// System.Console.Write(".");
				Thread.Sleep(loopDelay);

				timeOutCount += loopDelay;

				if (timeOutCount >= timeOutLimit)
				{
					return false;
				}
			}
			//System.Console.WriteLine("");
			return true;
		}

		// get the UID of the first camera listed
		public static bool CameraGet(ref tCamera Camera)
		{
			UInt32 count, connected = 0;
			tCameraInfo[] list = new tCameraInfo[1];

			if ((count = CPv.CameraList(list, 1, ref connected)) != 0)
			{
				Camera.UID = list[0].UniqueId;
				return true;
			}
			else
				return false;
		}
		
		public static unsafe bool AttrInfoRead(ref  tCamera Camera)  //unsafe
		{
			UInt32 FrameSize = 0;
			if (CPv.AttrUint32Get(Camera.Handle, "TotalBytesPerFrame", ref FrameSize) == 0)
			{
                
			}
			return true;
		}

		// open the camera
		public static bool CameraOpen(ref tCamera Camera)
		{
			return CPv.CameraOpen(Camera.UID, tAccessFlags.eAccessMaster, out Camera.Handle) == 0;
		}

		// close the camera
		public static void CameraClose(ref tCamera Camera)
		{
			// reset the trigger mode
			CPv.AttrEnumSet(Camera.Handle, "FrameStartTriggerMode", "Freerun");
			// close the camera
			CPv.CameraClose(Camera.Handle);
			// delete the allocated buffer
			Camera.GC.Free();
			// reset the handle
			Camera.Handle = 0;
		}

		// change the camera gain value (using register access)
		public static void CameraChangeGainBy(ref tCamera Camera, UInt32 Value)
		{
			UInt32 Done = 0;
			UInt32[] Data = new UInt32[1];
			UInt32[] Address = new UInt32[1];

			Address[0] = 0x14150;
			Data[0] = 0;

			CPv.RegisterRead(Camera.Handle, 1, Address, Data, ref Done);  // == 0)

			//    System.Console.WriteLine("value of register {0} is {1} {2}", Address[0], Data[0], Done);
			//else
			//    System.Console.WriteLine("Failed to read register {0}", Address[0]);

			Data[0] += Value;

			CPv.RegisterWrite(Camera.Handle, 1, Address, Data, ref Done);
			//    System.Console.WriteLine("register {0} was written to {1} {2}", Address[0], Data[0], Done);
			//else
			//    System.Console.WriteLine("Failed to write register {0}", Address[0]);

		}

		// setup the camera for capture
		public static bool CameraSetup(ref tCamera Camera)
		{
			UInt32 FrameSize = 0;

			// get the bytes size of the buffer we beed to allocated
			if (CPv.AttrUint32Get(Camera.Handle, "TotalBytesPerFrame", ref FrameSize) == 0)
			{
				Camera.Buffer = new byte[FrameSize];
				Camera.GC = GCHandle.Alloc(Camera.Buffer, GCHandleType.Pinned);

				Camera.Frame.ImageBuffer = Camera.GC.AddrOfPinnedObject();  // @ of the pinned buffer
				Camera.Frame.ImageBufferSize = FrameSize;						// buffer size

				System.Console.WriteLine("Frame size = {0} bytes", FrameSize);

				// start the capture mode
				if (CPv.CaptureStart(Camera.Handle) == 0)
				{
					// set the camera in software acquisition mode
					if (CPv.AttrEnumSet(Camera.Handle, "FrameStartTriggerMode", "Software") == 0)
					{
						// and set the acquisition mode into continuous
						if (CPv.CommandRun(Camera.Handle, "AcquisitionStart") != 0)
						{
							// if that fail, we reset the camera to non capture mode
							CPv.CaptureEnd(Camera.Handle);
							return false;
						}
						else
							return true;
					}
					else
						return false;
				}
				else
					return true;
			}
			else
				return false;
		}

		// snap a frame from the camera
		public static bool CameraSnap(ref tCamera Camera)
		{
			bool result;
			GCHandle pFrame = GCHandle.Alloc(Camera.Frame, GCHandleType.Pinned);
			//tFrameCallback FrameCB = new tFrameCallback(FrameDummyCB);

            try
            {
                // queue the frame
                if (CPv.CaptureQueueFrame(Camera.Handle, pFrame.AddrOfPinnedObject(), null) == 0)
                {
                    // trigger the capture
                    if (CPv.CommandRun(Camera.Handle, "FrameStartTriggerSoftware") == 0)
                    {
                        // then wait for the frame to be returned
                        if (CPv.CaptureWaitForFrameDone(Camera.Handle, pFrame.AddrOfPinnedObject(), 0) == 0)
                        {
                            // copy the frame structure back in the frame we have
                            Camera.Frame = (tFrame)Marshal.PtrToStructure(pFrame.AddrOfPinnedObject(), typeof(tFrame));

                            // check the status flag
                            if (!(result = (Camera.Frame.Status == tErr.eErrSuccess)))
                                System.Console.WriteLine("frame captured un-succesfully {0}", Camera.Frame.Status);
                        }
                        else
                        {
                            CPv.CaptureQueueClear(Camera.Handle);
                            result = false;
                        }
                    }
                    else
                    {
                        CPv.CaptureQueueClear(Camera.Handle);
                        result = false;
                    }
                }
                else
                    result = false;
            }
            catch
            {
                result = false;
            }
            

			pFrame.Free();

			return result;
		}

	
		 static unsafe bool Frame2Data(ref tCamera Camera, ref BitmapData Data) //unsafe
		{
			switch (Camera.Frame.Format)   
			{
				case tImageFormat.eFmtMono8:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;

					while (lOffset < Camera.Frame.ImageBufferSize)
					{
						lDst[lPos] = Camera.Buffer[lOffset];
						lDst[lPos + 1] = Camera.Buffer[lOffset];
						lDst[lPos + 2] = Camera.Buffer[lOffset];

						lOffset++;
						lPos += 3;

						// take care of the padding in the destination bitmap
						if ((lOffset % Camera.Frame.Width) == 0)
							lPos += (UInt32)Data.Stride - (Camera.Frame.Width * 3);
					}

					return true;
				}
				case tImageFormat.eFmtMono16:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;
					byte bitshift = (byte)((int)Camera.Frame.BitDepth - 8);
					UInt16* lSrc = (UInt16*)Camera.Frame.ImageBuffer;

					while (lOffset < Camera.Frame.Width * Camera.Frame.Height)
					{
						lDst[lPos] = (byte)(lSrc[lOffset] >> bitshift);
						lDst[lPos + 1] = lDst[lPos];
						lDst[lPos + 2] = lDst[lPos];

						lOffset++;
						lPos += 3;

						// take care of the padding in the destination bitmap
						if ((lOffset % Camera.Frame.Width) == 0)
							lPos += (UInt32)Data.Stride - (Camera.Frame.Width * 3);
					}

					return true;
				}
				case tImageFormat.eFmtBayer8:
				{
					UInt32 WidthSize = Camera.Frame.Width * 3;
					GCHandle pFrame = GCHandle.Alloc(Camera.Frame, GCHandleType.Pinned);
					UInt32 remainder = (((WidthSize + 3U) & ~3U) - WidthSize);

					// interpolate the colors
					IntPtr pRed = (IntPtr)((byte*)Data.Scan0 + 2);
					IntPtr pGreen = (IntPtr)((byte*)Data.Scan0 + 1);
					IntPtr pBlue = (IntPtr)((byte*)Data.Scan0);
					CPv.ColorInterpolate(pFrame.AddrOfPinnedObject(), pRed, pGreen, pBlue, 2, remainder);

					pFrame.Free();

					return true;
				}
				case tImageFormat.eFmtBayer16:
				{
					UInt32 WidthSize = Camera.Frame.Width * 3;
					UInt32 lOffset = 0;
					byte bitshift = (byte)((int)Camera.Frame.BitDepth - 8);
					UInt16* lSrc = (UInt16*)Camera.Frame.ImageBuffer;
					byte* lDst = (byte*)Camera.Frame.ImageBuffer;
					UInt32 remainder = (((WidthSize + 3U) & ~3U) - WidthSize);
					GCHandle pFrame;

					Camera.Frame.Format = tImageFormat.eFmtBayer8;

					pFrame = GCHandle.Alloc(Camera.Frame, GCHandleType.Pinned);

					// shift the pixel
					while (lOffset < Camera.Frame.Width * Camera.Frame.Height)
						lDst[lOffset] = (byte)(lSrc[lOffset++] >> bitshift);

					// interpolate the colors
					IntPtr pRed = (IntPtr)((byte*)Data.Scan0 + 2);
					IntPtr pGreen = (IntPtr)((byte*)Data.Scan0 + 1);
					IntPtr pBlue = (IntPtr)((byte*)Data.Scan0);
					CPv.ColorInterpolate(pFrame.AddrOfPinnedObject(), pRed, pGreen, pBlue, 2, remainder);

					pFrame.Free();

					return true;
				}
				case tImageFormat.eFmtRgb24:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;

					while (lOffset < Camera.Frame.ImageBufferSize)
					{
						// copy the data
						lDst[lPos] = Camera.Buffer[lOffset + 2];
						lDst[lPos + 1] = Camera.Buffer[lOffset + 1];
						lDst[lPos + 2] = Camera.Buffer[lOffset];

						lOffset += 3;
						lPos += 3;
						// take care of the padding in the destination bitmap
						if ((lOffset % (Camera.Frame.Width * 3)) == 0)
							lPos += (UInt32)Data.Stride - (Camera.Frame.Width * 3);
					}

					return true;
				}
				case tImageFormat.eFmtRgb48:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					UInt32 lLength = Camera.Frame.ImageBufferSize / sizeof(UInt16);
					UInt16* lSrc = (UInt16*)Camera.Frame.ImageBuffer;
					byte* lDst = (byte*)Data.Scan0;
					byte bitshift = (byte)((int)Camera.Frame.BitDepth - 8);

					while (lOffset < lLength)
					{
						// copy the data
						lDst[lPos] = (byte)(lSrc[lOffset + 2] >> bitshift);
						lDst[lPos + 1] = (byte)(lSrc[lOffset + 1] >> bitshift);
						lDst[lPos + 2] = (byte)(lSrc[lOffset] >> bitshift);

						lOffset += 3;
						lPos += 3;

						// take care of the padding in the destination bitmap
						if ((lOffset % (Camera.Frame.Width * 3)) == 0)
							lPos += (UInt32)Data.Stride - (Camera.Frame.Width * 3);
					}

					return true;
				}
				case tImageFormat.eFmtYuv411:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;
					int y1, y2, y3, y4, u, v;
					int r, g, b;

					r = g = b = 0;

					while (lOffset < Camera.Frame.ImageBufferSize)
					{
						u = Camera.Buffer[lOffset++];
						y1 = Camera.Buffer[lOffset++];
						y2 = Camera.Buffer[lOffset++];
						v = Camera.Buffer[lOffset++];
						y3 = Camera.Buffer[lOffset++];
						y4 = Camera.Buffer[lOffset++];

						YUV2RGB(y1, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
						YUV2RGB(y2, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
						YUV2RGB(y3, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
						YUV2RGB(y4, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
					}

					return true;
				}
				case tImageFormat.eFmtYuv422:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;
					int y1, y2, u, v;
					int r, g, b;

					r = g = b = 0;

					while (lOffset < Camera.Frame.ImageBufferSize)
					{
						u = Camera.Buffer[lOffset++];
						y1 = Camera.Buffer[lOffset++];
						v = Camera.Buffer[lOffset++];
						y2 = Camera.Buffer[lOffset++];

						YUV2RGB(y1, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
						YUV2RGB(y2, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
					}

					return true;
				}
				case tImageFormat.eFmtYuv444:
				{
					UInt32 lOffset = 0;
					UInt32 lPos = 0;
					byte* lDst = (byte*)Data.Scan0;
					int y1, y2, u, v;
					int r, g, b;

					r = g = b = 0;

					while (lOffset < Camera.Frame.ImageBufferSize)
					{
						u = Camera.Buffer[lOffset++];
						y1 = Camera.Buffer[lOffset++];
						v = Camera.Buffer[lOffset++];
						lOffset++;
						y2 = Camera.Buffer[lOffset++];
						lOffset++;

						YUV2RGB(y1, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
						YUV2RGB(y2, u, v, ref r, ref g, ref b);
						lDst[lPos++] = (byte)b;
						lDst[lPos++] = (byte)g;
						lDst[lPos++] = (byte)r;
					}

					return true;
				}
				default:
					return false;
			}
		}


		static void YUV2RGB(int y, int u, int v, ref int r, ref int g, ref int b)
		{
			// u and v are +-0.577
			u -= 128;
			v -= 128;

			// Conversion (clamped to 0..255)
			r = Math.Min(Math.Max(0, (int)(y + 1.370705 * (float)v)), 255);
			g = Math.Min(Math.Max(0, (int)(y - 0.698001 * (float)v - 0.337633 * (float)u)), 255);
			b = Math.Min(Math.Max(0, (int)(y + 1.732446 * (float)u)), 255);
		}
static public Bitmap gBitmapData = new Bitmap(1280,960,PixelFormat.Format24bppRgb);
	
		static public Bitmap FrameSave(ref tCamera Camera)
		{
			Bitmap lBitmap = new Bitmap((int)Camera.Frame.Width, (int)Camera.Frame.Height, PixelFormat.Format24bppRgb);
			Rectangle lRect = new Rectangle(new Point(0, 0), new Size((int)Camera.Frame.Width, (int)Camera.Frame.Height));
			BitmapData lData = lBitmap.LockBits(lRect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


            try
            {

              	if (Frame2Data(ref Camera, ref lData))
		     	{
				lBitmap.UnlockBits(lData);
								
				//if (sw1 == true)
				//    lBitmap.Save(file);
				//else
				//    img = lBitmap;
			gBitmapData = lBitmap.Clone(lRect,PixelFormat.Format24bppRgb);
				lBitmap.Dispose();
				return lBitmap;
			 }
			 else
			 {
				lBitmap.UnlockBits(lData);
				gBitmapData = lBitmap.Clone(lRect,PixelFormat.Format24bppRgb);
				lBitmap.Dispose();
				return lBitmap;
			 }


            }
            catch
            {

                lBitmap.Dispose();
                return lBitmap;

            }


	
			//lBitmap.Dispose();
           
		}

		
//		public CKid()
//		{
//			//
//			// TODO: 여기에 생성자 논리를 추가합니다.
//			//
//		}
	}


}
