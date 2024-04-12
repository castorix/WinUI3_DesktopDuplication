using D3D11;
using DXGI;
using GlobalStructures;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

using static DXGI.DXGITools;
using static GlobalStructures.GlobalTools;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3_DesktopDuplication
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    { 
        [Guid("045FA593-8799-42b8-BC8D-8968C6453507")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IMFMediaBuffer
        {
            HRESULT Lock(out IntPtr ppbBuffer, out int pcbMaxLength, out int pcbCurrentLength);
            HRESULT Unlock();
            HRESULT GetCurrentLength(out int pcbCurrentLength);
            HRESULT SetCurrentLength(int cbCurrentLength);
            HRESULT GetMaxLength(out int pcbMaxLength);
        }

        [ComImport]
        [Guid("7DC9D5F9-9ED9-44ec-9BBF-0600BB589FBB")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IMF2DBuffer
        {
            [PreserveSig]
            HRESULT Lock2D(out IntPtr ppbScanline0, out uint plPitch);
            HRESULT Unlock2D();
            HRESULT GetScanline0AndPitch(out IntPtr pbScanline0, out uint plPitch);
            HRESULT IsContiguousFormat(out bool pfIsContiguous);
            HRESULT GetContiguousLength(out uint pcbLength);
            HRESULT ContiguousCopyTo(out IntPtr pbDestBuffer, uint cbDestBuffer);
            HRESULT ContiguousCopyFrom(IntPtr pbSrcBuffer, uint cbSrcBuffer);
        }

        [DllImport("Mfplat.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT MFCreateDXGISurfaceBuffer([In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, 
            IntPtr punkSurface, uint uSubresourceIndex, bool fBottomUpWhenLinear, out IMFMediaBuffer ppBuffer);

        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        public static int LOWORD(int n)
        {
            return n & 0xffff;
        }

        public static byte LOBYTE(short nValue)
        {
            return (byte)(nValue & 0xFF);
        }

        public static byte HIBYTE(short nValue)
        {
            return (byte)(nValue >> 8);
        }

        public const int WM_COMMAND = 0x0111;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int EN_CHANGE = 0x0300;

        public const int WM_USER = 0x0400;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_GETHOTKEY = 0x0033;

        public const int HKM_SETHOTKEY = (WM_USER + 1);
        public const int HKM_GETHOTKEY = (WM_USER + 2);
        public const int HKM_SETRULES = (WM_USER + 3);

        public const int SC_HOTKEY = 0xF150;

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern short GlobalAddAtom(string atomName);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const int MOD_ALT = 0x1;
        public const int MOD_CONTROL = 0x2;
        public const int MOD_SHIFT = 0x4;
        public const int MOD_WIN = 0x8;
        public const int MOD_NOREPEAT = 0x4000;

        public const int WM_HOTKEY = 0x312;

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "SetWindowDisplayAffinity")]
        public static extern bool SWDA(IntPtr hWnd, uint dwAffinity);

        public const int WDA_NONE = 0x00000000;
        public const int WDA_MONITOR = 0x00000001;
        public const int WDA_EXCLUDEFROMCAPTURE = 0x00000011;

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        IDXGIDevice1 m_pDXGIDevice = null;
        IntPtr m_pD3D11DevicePtr = IntPtr.Zero;
        IntPtr m_pD3D11DeviceContextPtr = IntPtr.Zero;
        IDXGIOutputDuplication m_pDXGIOutputDuplication = null;
        D3D11.ID3D11Texture2D m_textureGDI = null;
        //D3D11.ID3D11Texture2D m_textureCPU = null;
        WriteableBitmap m_WriteableBitmapCapture = null;

        private SUBCLASSPROC SubClassDelegate;
        private IntPtr hWnd = IntPtr.Zero;

        private short m_nAtom;

        public MainWindow()
        {
            this.InitializeComponent();
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            ContainerPanel1.ContainerPanelInit(this, "msctls_hotkey32", "", hWnd);
            ContainerPanel1.SetOpacity(ContainerPanel1.hWndContainer, 100);
            m_nAtom = GlobalAddAtom("HotKey");

            SubClassDelegate = new SUBCLASSPROC(WindowSubClass);
            bool bRet = SetWindowSubclass(hWnd, SubClassDelegate, 0, 0);

            Task<HRESULT> hr = InitializeAsync();
  
            Application.Current.Resources["ButtonBackgroundPressed"] = new SolidColorBrush(Microsoft.UI.Colors.LightSteelBlue);
            Application.Current.Resources["ButtonBackgroundPointerOver"] = new SolidColorBrush(Microsoft.UI.Colors.RoyalBlue);

            //IntPtr hWndNotepad = FindWindow("Notepad", null);
            bRet = SWDA(hWnd, (uint)WDA_EXCLUDEFROMCAPTURE);
            //int nErr = Marshal.GetLastWin32Error();

            this.Closed += MainWindow_Closed;
        }

        private async Task<HRESULT> InitializeAsync()
        {
            HRESULT hr = HRESULT.S_OK;
            hr = CreateDeviceContext();
            if (hr == HRESULT.S_OK)
            {
                //IDXGIAdapter pDXGIAdapter = null;
                //IntPtr pDXGIAdapterPtr = IntPtr.Zero;
                //m_pDXGIDevice.GetParent(typeof(IDXGIFactory2).GUID, pDXGIAdapterPtr);
                IDXGIAdapter pDXGIAdapter;
                hr = m_pDXGIDevice.GetAdapter(out pDXGIAdapter);
                if (hr == HRESULT.S_OK)
                {
                    IDXGIOutput pDXGIOutput = null;
                    hr = pDXGIAdapter.EnumOutputs(0, ref pDXGIOutput);
                    if (hr == HRESULT.S_OK)
                    {
                        IDXGIOutput1 pDXGIOutput1 = null;
                        pDXGIOutput1 = (IDXGIOutput1)pDXGIOutput;
                        DXGI_OUTPUT_DESC outputDesc;
                        hr = pDXGIOutput1.GetDesc(out outputDesc);
                        hr = pDXGIOutput1.DuplicateOutput(m_pD3D11DevicePtr, out m_pDXGIOutputDuplication);
                        if (hr == HRESULT.S_OK)
                        {
                            DXGI_OUTDUPL_DESC outduplDesc = new DXGI_OUTDUPL_DESC();
                            m_pDXGIOutputDuplication.GetDesc(out outduplDesc);
                            this.Title = "Adapter : " + outputDesc.DeviceName + " (" + outduplDesc.ModeDesc.Width.ToString() +
                                "*" + outduplDesc.ModeDesc.Height.ToString() + "), " + outduplDesc.ModeDesc.RefreshRate.Numerator / outduplDesc.ModeDesc.RefreshRate.Denominator + " Hz";
                            ID3D11Device pD3D11Device = Marshal.GetObjectForIUnknown(m_pD3D11DevicePtr) as ID3D11Device;
                            D3D11.D3D11_TEXTURE2D_DESC textureDesc = new D3D11.D3D11_TEXTURE2D_DESC();
                            textureDesc.Width = outduplDesc.ModeDesc.Width;
                            textureDesc.Height = outduplDesc.ModeDesc.Height;
                            textureDesc.Format = outduplDesc.ModeDesc.Format;
                            textureDesc.ArraySize = 1;
                            textureDesc.BindFlags = D3D11_BIND_FLAG.D3D11_BIND_RENDER_TARGET;
                           // textureDesc.MiscFlags = D3D11_RESOURCE_MISC_FLAG.D3D11_RESOURCE_MISC_GDI_COMPATIBLE | D3D11_RESOURCE_MISC_FLAG.D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX | D3D11_RESOURCE_MISC_FLAG.D3D11_RESOURCE_MISC_SHARED_NTHANDLE;
                            textureDesc.MiscFlags = D3D11_RESOURCE_MISC_FLAG.D3D11_RESOURCE_MISC_GDI_COMPATIBLE;
                            textureDesc.SampleDesc.Count = 1;
                            textureDesc.SampleDesc.Quality = 0;
                            textureDesc.MipLevels = 1;
                            textureDesc.CPUAccessFlags = 0;
                            textureDesc.Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT;
                            hr = pD3D11Device.CreateTexture2D(textureDesc, IntPtr.Zero, out m_textureGDI);
  
                            //textureDesc.Width = outduplDesc.ModeDesc.Width;
                            //textureDesc.Height = outduplDesc.ModeDesc.Height;
                            //textureDesc.Format = outduplDesc.ModeDesc.Format;
                            //textureDesc.ArraySize = 1;
                            //textureDesc.BindFlags = 0;
                            //textureDesc.MiscFlags = 0;
                            //textureDesc.SampleDesc.Count = 1;
                            //textureDesc.SampleDesc.Quality = 0;
                            //textureDesc.MipLevels = 1;
                            //textureDesc.CPUAccessFlags = (D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_READ | D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE);
                            //textureDesc.Usage = D3D11.D3D11_USAGE.D3D11_USAGE_STAGING;
                            //hr = pD3D11Device.CreateTexture2D(textureDesc, IntPtr.Zero, out m_textureCPU);
                            SafeRelease(ref pD3D11Device);
                        }
                        SafeRelease(ref pDXGIOutput1);
                    }
                    SafeRelease(ref pDXGIAdapter);
                }
            }
            if (hr != HRESULT.S_OK)
            {
                string sError = "Could not initialize D3D11" + "\r\n" + "HRESULT = 0x" + string.Format("{0:X}", hr);
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
                _ = await md.ShowAsync();
            }
            return hr;
        }

        private async void CaptureFrame()
        {
            DXGI_OUTDUPL_FRAME_INFO frameInfo = new DXGI_OUTDUPL_FRAME_INFO();
            IDXGIResource pDXGIResource = null;
            HRESULT hr = m_pDXGIOutputDuplication.AcquireNextFrame(500, out frameInfo, out pDXGIResource);
            if (hr == HRESULT.S_OK)
            {
            //    DXGI_MAPPED_RECT mappedRect;
            //    hr = m_pDXGIOutputDuplication.MapDesktopSurface(out mappedRect);
            //    if (hr == HRESULT.S_OK)
            //    {
            //        hr = m_pDXGIOutputDuplication.UnMapDesktopSurface();
            //    }
            //    else if (hr == DXGI_ERROR_UNSUPPORTED)
                 {
                    D3D11.ID3D11Texture2D pD3D11Texture2D = (D3D11.ID3D11Texture2D)pDXGIResource;
                    D3D11.D3D11_TEXTURE2D_DESC texture2DDesc = new D3D11.D3D11_TEXTURE2D_DESC();
                    pD3D11Texture2D.GetDesc(out texture2DDesc); // MiscFlags	0x00002900	D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE D3D11_RESOURCE_MISC_SHARED_NTHANDLE D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX

                    ID3D11DeviceContext pD3D11DeviceContext = Marshal.GetObjectForIUnknown(m_pD3D11DeviceContextPtr) as ID3D11DeviceContext;
                    //D3D11.ID3D11Resource pResource = (D3D11.ID3D11Resource)m_textureGDI;
                    if (m_textureGDI != null)
                    {
                        try
                        {
                            pD3D11DeviceContext.CopyResource(m_textureGDI, pD3D11Texture2D);
                        }
                        catch (Exception ex)
                        {
                            string sError = ex.Message + "\r\n" + "HRESULT = 0x" + string.Format("{0:X}", ex.HResult);
                            System.Diagnostics.Debug.WriteLine(sError);
                            //Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                            //WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
                            //_ = await md.ShowAsync();
                        }
                        finally
                        {
                            //SafeRelease(ref pD3D11Texture2D);
                            //SafeRelease(ref pD3D11DeviceContext);
                            hr = m_pDXGIOutputDuplication.ReleaseFrame();
                        }

                        IntPtr pTexture = Marshal.GetIUnknownForObject(m_textureGDI);
                        IMFMediaBuffer pBuffer = null;
                        hr = MFCreateDXGISurfaceBuffer(typeof(D3D11.ID3D11Texture2D).GUID, pTexture, 0, false, out pBuffer);
                        if (hr == HRESULT.S_OK)
                        {
                            IMF2DBuffer p2DBuffer = (IMF2DBuffer)pBuffer;
                            IntPtr pData = IntPtr.Zero;
                            // hr = 0x887a0001 DXGI_ERROR_INVALID_CALL on pD3D11Texture2D
                            hr = p2DBuffer.Lock2D(out pData, out uint nPitch);
                            if (hr == HRESULT.S_OK)
                            {
                                int nSize = (int)(nPitch * texture2DDesc.Height);
                                byte[] pBytes = new byte[nSize];
                                Marshal.Copy(pData, pBytes, 0, nSize);
                                if (m_WriteableBitmapCapture != null)
                                    m_WriteableBitmapCapture.Invalidate();
                                m_WriteableBitmapCapture = new WriteableBitmap((int)texture2DDesc.Width, (int)texture2DDesc.Height);
                                await m_WriteableBitmapCapture.PixelBuffer.AsStream().WriteAsync(pBytes, 0, pBytes.Length);
                                img1.Source = m_WriteableBitmapCapture;
                                hr = p2DBuffer.Unlock2D();
                            }
                            SafeRelease(ref p2DBuffer);
                            SafeRelease(ref pBuffer);
                        }
                        Marshal.Release(pTexture);
                        SafeRelease(ref pD3D11DeviceContext);
                    }
                    SafeRelease(ref pDXGIResource);
                }
            }
        }

        //private void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    CaptureFrame();
        //    myButton.Content = "Clicked";
        //}

        public HRESULT CreateDeviceContext()
        {
            HRESULT hr = HRESULT.S_OK;
            uint nCreationFlags = (uint)D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;

            // Needs "Enable native code Debugging"
            nCreationFlags |= (uint)D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_DEBUG;

            int[] aD3D_FEATURE_LEVEL = new int[] { (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
                (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
                (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1};

            D3D_FEATURE_LEVEL featureLevel;
            hr = D3D11CreateDevice(null,    // specify null to use the default adapter
                D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
                IntPtr.Zero,
                nCreationFlags,              // optionally set debug and Direct2D compatibility flags
                aD3D_FEATURE_LEVEL,         // list of feature levels this app can support
                //(uint)Marshal.SizeOf(aD3D_FEATURE_LEVEL),  
                (uint)aD3D_FEATURE_LEVEL.Length, // number of possible feature levels
                D3D11_SDK_VERSION,
                out m_pD3D11DevicePtr,       // returns the Direct3D device created
                out featureLevel,            // returns feature level of device created
                out m_pD3D11DeviceContextPtr // returns the device immediate context
            );
            if (hr == HRESULT.S_OK)
            {
                m_pDXGIDevice = Marshal.GetObjectForIUnknown(m_pD3D11DevicePtr) as IDXGIDevice1;
            }
            return hr;
        }

        private int WindowSubClass(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData)
        {
            switch (uMsg)
            {
                case WM_COMMAND:
                    {
                        if (HIWORD((int)wParam) == EN_CHANGE)
                        {
                            short wHotkey = (short)SendMessage(ContainerPanel1.hWndContainer, HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                            if (wHotkey != 0)
                            {
                                //SendMessage(hWnd, WM_SETHOTKEY, wHotkey, IntPtr.Zero);
                                byte byteVirtualKey = LOBYTE((short)LOWORD(wHotkey));
                                byte byteKeyModifier = HIBYTE((short)LOWORD(wHotkey));
                                UnregisterHotKey(hWnd, m_nAtom);
                                bool bRet = RegisterHotKey(hWnd, m_nAtom, byteKeyModifier, byteVirtualKey);
                                if (!bRet)
                                {
                                    int nErr = Marshal.GetLastWin32Error();
                                    ShowError("Could not register Hotkey", nErr);
                                }
                            }
                        }
                    }
                    break;
                //case WM_SYSCOMMAND:
                //    {
                //        if ((int)wParam == SC_HOTKEY)
                //        {
                //            CaptureFrame();
                //            System.Threading.Thread.Sleep(1000);
                //            //Console.Beep(8000, 10);                           
                //            //return 1;
                //        }
                //    }
                //    break;
                case WM_HOTKEY:
                    {
                        if (wParam == (IntPtr)m_nAtom)
                        {
                            CaptureFrame();
                            Console.Beep(8000, 10);
                            //this.Activate();
                            SwitchToThisWindow(hWnd, true);
                        }
                    }
                    break;
            }
            return DefSubclassProc(hWnd, uMsg, wParam, lParam);
        }

        private async void ShowError(string sMessage, int nError)
        {
            Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sMessage + "\r\n" + "Error : " + nError.ToString(), "Information");
            WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
            _ = await md.ShowAsync();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbFile.Text == "")
            {
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog("File name must be filled", "Information");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
                _ = await md.ShowAsync();
            }
            else if (m_WriteableBitmapCapture == null)
            {
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog("No frame captured", "Information");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
                _ = await md.ShowAsync();
            }
            else
            {
                SaveCapture();
            }
        }

        private async Task<bool> SaveFrameDialogPicker()
        {
            var fsp = new Windows.Storage.Pickers.FileSavePicker();
            WinRT.Interop.InitializeWithWindow.Initialize(fsp, hWnd);
            fsp.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            fsp.SuggestedFileName = "New Document";

            fsp.FileTypeChoices.Add("JPG (*.jpg)", new List<string>() { ".jpg" });
            fsp.FileTypeChoices.Add("PNG Portable Network Graphics (*.png)", new List<string>() { ".png" });
            fsp.FileTypeChoices.Add("GIF Graphics Interchange Format (*.gif)", new List<string>() { ".gif" });
            fsp.FileTypeChoices.Add("BMP Windows Bitmap (*.bmp)", new List<string>() { ".bmp" });
            fsp.FileTypeChoices.Add("TIF Tagged Image File Format (*.tif)", new List<string>() { ".tif" });

            Windows.Storage.StorageFile file = await fsp.PickSaveFileAsync();
            if (file != null)
            {
                tbFile.Text = file.Path;
                return true;
            }
            else
                return false;
        }

        public async void SaveCapture()
        {
            try
            {
                using (File.Create(tbFile.Text)) { };
                var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(tbFile.Text);
                if (m_WriteableBitmapCapture != null)
                {
                    Guid guidCodec = Guid.Empty;
                    switch (file.FileType)
                    {
                        case ".jpg":
                            guidCodec = Windows.Graphics.Imaging.BitmapEncoder.JpegEncoderId;
                            break;
                        case ".png":
                            guidCodec = Windows.Graphics.Imaging.BitmapEncoder.PngEncoderId;
                            break;
                        case ".gif":
                            guidCodec = Windows.Graphics.Imaging.BitmapEncoder.GifEncoderId;
                            break;
                        case ".bmp":
                            guidCodec = Windows.Graphics.Imaging.BitmapEncoder.BmpEncoderId;
                            break;
                        case ".tif":
                            guidCodec = Windows.Graphics.Imaging.BitmapEncoder.TiffEncoderId;
                            break;
                    }
                    using (var ras = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite, Windows.Storage.StorageOpenOptions.None))
                    {
                        var stream = m_WriteableBitmapCapture.PixelBuffer.AsStream();
                        byte[] pBytes = new byte[stream.Length];
                        await stream.ReadAsync(pBytes, 0, pBytes.Length);
                        Windows.Graphics.Imaging.BitmapEncoder encoder = await Windows.Graphics.Imaging.BitmapEncoder.CreateAsync(guidCodec, ras);
                        encoder.SetPixelData(Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8, Windows.Graphics.Imaging.BitmapAlphaMode.Straight, (uint)m_WriteableBitmapCapture.PixelWidth, (uint)m_WriteableBitmapCapture.PixelHeight, 96.0, 96.0, pBytes);
                        await encoder.FlushAsync();
                    }
                }
            }
            catch (Exception e)
            {
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog("Cannot save file " + tbFile.Text + "\r\n" + "Exception : " + e.Message, "Information");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWnd);
                _ = await md.ShowAsync();
            }
        }

        private async void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            bool bRet = await SaveFrameDialogPicker();
        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            Clean();
            UnregisterHotKey(hWnd, m_nAtom);
        }

        void Clean()
        {
            SafeRelease(ref m_pDXGIDevice);
            if (m_pD3D11DevicePtr != IntPtr.Zero)
                Marshal.Release(m_pD3D11DevicePtr);
            if (m_pD3D11DeviceContextPtr != IntPtr.Zero)
                Marshal.Release(m_pD3D11DeviceContextPtr);
            SafeRelease(ref m_textureGDI);            
            SafeRelease(ref m_pDXGIOutputDuplication);          
        }
    }
}
