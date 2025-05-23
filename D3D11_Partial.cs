using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using GlobalStructures;
using DXGI;
using static DXGI.DXGITools;
using System.Reflection.Metadata;
using Microsoft.UI.Xaml.Controls;
using System.Runtime.CompilerServices;

namespace D3D11
{
    public class D3D11Tools
    {
        [DllImport("D3D11.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint D3D11CalcSubresource(uint MipSlice, uint ArraySlice, uint MipLevels);
    }

    [ComImport]
    [Guid("1841e5c8-16b0-489b-bcc8-44cfb0d5deae")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DeviceChild
    {
        [PreserveSig]
        void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
    }

    [ComImport]
    [Guid("dc8e63f3-d12b-4952-b47b-5e45026a862d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Resource : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        [PreserveSig]
        void SetEvictionPriority(uint EvictionPriority);
        [PreserveSig]
        uint GetEvictionPriority();
    }

    public enum D3D11_RESOURCE_DIMENSION
    {
        D3D11_RESOURCE_DIMENSION_UNKNOWN = 0,
        D3D11_RESOURCE_DIMENSION_BUFFER = 1,
        D3D11_RESOURCE_DIMENSION_TEXTURE1D = 2,
        D3D11_RESOURCE_DIMENSION_TEXTURE2D = 3,
        D3D11_RESOURCE_DIMENSION_TEXTURE3D = 4
    }

    [ComImport]
    [Guid("48570b85-d1ee-4fcd-a250-eb350722b037")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Buffer : ID3D11Resource
    {

        #region ID3D11Resource
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        [PreserveSig]
        new void SetEvictionPriority(uint EvictionPriority);
        [PreserveSig]
        new uint GetEvictionPriority();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_BUFFER_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_BUFFER_DESC
    {
        public uint ByteWidth;
        public D3D11_USAGE Usage;
        public D3D11_BIND_FLAG BindFlags;
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
        public uint StructureByteStride;
    }

    public enum D3D11_USAGE
    {
        D3D11_USAGE_DEFAULT = 0,
        D3D11_USAGE_IMMUTABLE = 1,
        D3D11_USAGE_DYNAMIC = 2,
        D3D11_USAGE_STAGING = 3
    }

    [ComImport]
    [Guid("839d1216-bb2e-412b-b7f4-a9dbebe08ed1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11View : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetResource(out ID3D11Resource ppResource);
    }

    [ComImport]
    [Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ShaderResourceView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);

        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_SHADER_RESOURCE_VIEW_DESC pDesc);
    }

    //typedef D3D_SRV_DIMENSION D3D11_SRV_DIMENSION;
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_SHADER_RESOURCE_VIEW_DESC
    {
        public DXGI_FORMAT Format;
        //public D3D11_SRV_DIMENSION ViewDimension;
        public D3D_SRV_DIMENSION ViewDimension;

        //    union 
        //    {
        //    D3D11_BUFFER_SRV Buffer;
        //    D3D11_TEX1D_SRV Texture1D;
        //    D3D11_TEX1D_ARRAY_SRV Texture1DArray;
        //    D3D11_TEX2D_SRV Texture2D;
        //    D3D11_TEX2D_ARRAY_SRV Texture2DArray;
        //    D3D11_TEX2DMS_SRV Texture2DMS;
        //    D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray;
        //    D3D11_TEX3D_SRV Texture3D;
        //    D3D11_TEXCUBE_SRV TextureCube;
        //    D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray;
        //    D3D11_BUFFEREX_SRV BufferEx;
        //};
    }

    public enum D3D_SRV_DIMENSION
    {
        D3D_SRV_DIMENSION_UNKNOWN = 0,
        D3D_SRV_DIMENSION_BUFFER = 1,
        D3D_SRV_DIMENSION_TEXTURE1D = 2,
        D3D_SRV_DIMENSION_TEXTURE1DARRAY = 3,
        D3D_SRV_DIMENSION_TEXTURE2D = 4,
        D3D_SRV_DIMENSION_TEXTURE2DARRAY = 5,
        D3D_SRV_DIMENSION_TEXTURE2DMS = 6,
        D3D_SRV_DIMENSION_TEXTURE2DMSARRAY = 7,
        D3D_SRV_DIMENSION_TEXTURE3D = 8,
        D3D_SRV_DIMENSION_TEXTURECUBE = 9,
        D3D_SRV_DIMENSION_TEXTURECUBEARRAY = 10,
        D3D_SRV_DIMENSION_BUFFEREX = 11,
        D3D10_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,
        D3D10_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,
        D3D10_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,
        D3D10_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,
        D3D10_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,
        D3D10_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,
        D3D10_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,
        D3D10_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,
        D3D10_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,
        D3D10_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,
        D3D10_1_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,
        D3D10_1_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,
        D3D10_1_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,
        D3D10_1_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,
        D3D10_1_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,
        D3D10_1_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,
        D3D10_1_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,
        D3D10_1_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,
        D3D10_1_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,
        D3D10_1_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,
        D3D10_1_SRV_DIMENSION_TEXTURECUBEARRAY = D3D_SRV_DIMENSION_TEXTURECUBEARRAY,
        D3D11_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,
        D3D11_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,
        D3D11_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,
        D3D11_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,
        D3D11_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,
        D3D11_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,
        D3D11_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,
        D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,
        D3D11_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,
        D3D11_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,
        D3D11_SRV_DIMENSION_TEXTURECUBEARRAY = D3D_SRV_DIMENSION_TEXTURECUBEARRAY,
        D3D11_SRV_DIMENSION_BUFFEREX = D3D_SRV_DIMENSION_BUFFEREX
    }

    [ComImport]
    [Guid("ea82e40d-51dc-4f33-93d4-db7c9125ae8c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11PixelShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ClassInstance : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetClassLinkage(out ID3D11ClassLinkage ppLinkage);
        [PreserveSig]
        void GetDesc(out D3D11_CLASS_INSTANCE_DESC pDesc);
        [PreserveSig]
        void GetInstanceName(out System.Text.StringBuilder pInstanceName, ref uint pBufferLength);
        [PreserveSig]
        void GetTypeName(out System.Text.StringBuilder pTypeName, ref uint pBufferLength);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_CLASS_INSTANCE_DESC
    {
        public uint InstanceId;
        public uint InstanceIndex;
        public uint TypeId;
        public uint ConstantBuffer;
        public uint BaseConstantBufferOffset;
        public uint BaseTexture;
        public uint BaseSampler;
        public bool Created;
    }

    [ComImport]
    [Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ClassLinkage : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        HRESULT GetClassInstance(string pClassInstanceName, uint InstanceIndex, out ID3D11ClassInstance ppInstance);
        [PreserveSig]
        HRESULT CreateClassInstance(string pClassTypeName, uint ConstantBufferOffset, uint ConstantVectorOffset, uint TextureOffset, uint SamplerOffset, out ID3D11ClassInstance ppInstance);
    }

    [ComImport]
    [Guid("da6fea51-564c-4487-9810-f0d0f9b4e3a5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11SamplerState : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_SAMPLER_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_SAMPLER_DESC
    {
        D3D11_FILTER Filter;
        D3D11_TEXTURE_ADDRESS_MODE AddressU;
        D3D11_TEXTURE_ADDRESS_MODE AddressV;
        D3D11_TEXTURE_ADDRESS_MODE AddressW;
        public float MipLODBias;
        public uint MaxAnisotropy;
        D3D11_COMPARISON_FUNC ComparisonFunc;
        [MarshalAs(UnmanagedType.R4, SizeConst = 4)]
        public float BorderColor;
        public float MinLOD;
        public float MaxLOD;
    }

    public enum D3D11_FILTER
    {
        D3D11_FILTER_MIN_MAG_MIP_POINT = 0,
        D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1,
        D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,
        D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5,
        D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,
        D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11,
        D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,
        D3D11_FILTER_MIN_MAG_MIP_LINEAR = 0x15,
        D3D11_FILTER_ANISOTROPIC = 0x55,
        D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,
        D3D11_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81,
        D3D11_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,
        D3D11_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85,
        D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,
        D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,
        D3D11_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,
        D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95,
        D3D11_FILTER_COMPARISON_ANISOTROPIC = 0xd5,
        D3D11_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,
        D3D11_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101,
        D3D11_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,
        D3D11_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105,
        D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,
        D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111,
        D3D11_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,
        D3D11_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,
        D3D11_FILTER_MINIMUM_ANISOTROPIC = 0x155,
        D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,
        D3D11_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,
        D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,
        D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,
        D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,
        D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,
        D3D11_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,
        D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,
        D3D11_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5
    }

    public enum D3D11_TEXTURE_ADDRESS_MODE
    {
        D3D11_TEXTURE_ADDRESS_WRAP = 1,
        D3D11_TEXTURE_ADDRESS_MIRROR = 2,
        D3D11_TEXTURE_ADDRESS_CLAMP = 3,
        D3D11_TEXTURE_ADDRESS_BORDER = 4,
        D3D11_TEXTURE_ADDRESS_MIRROR_ONCE = 5
    }

    public enum D3D11_COMPARISON_FUNC
    {
        D3D11_COMPARISON_NEVER = 1,
        D3D11_COMPARISON_LESS = 2,
        D3D11_COMPARISON_EQUAL = 3,
        D3D11_COMPARISON_LESS_EQUAL = 4,
        D3D11_COMPARISON_GREATER = 5,
        D3D11_COMPARISON_NOT_EQUAL = 6,
        D3D11_COMPARISON_GREATER_EQUAL = 7,
        D3D11_COMPARISON_ALWAYS = 8
    }

    [ComImport]
    [Guid("3b301d64-d678-4289-8897-22f8928b72f3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VertexShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }   

    [ComImport]
    [Guid("e4819ddc-4cf0-4025-bd26-5de82a3e07b7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11InputLayout : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("38325b96-effb-4022-ba02-2e795b70275c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11GeometryShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("4b35d0cd-1e15-4258-9c98-1b1333f6dd3b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Asynchronous : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        uint GetDataSize();
    }

    [ComImport]
    [Guid("d6c00747-87b7-425e-b84d-44d108560afd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Query : ID3D11Asynchronous
    {
        #region ID3D11Asynchronous
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new uint GetDataSize();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_QUERY_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_QUERY_DESC
    {
        public D3D11_QUERY Query;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }

    public enum D3D11_QUERY
    {
        D3D11_QUERY_EVENT = 0,
        D3D11_QUERY_OCCLUSION = (D3D11_QUERY_EVENT + 1),
        D3D11_QUERY_TIMESTAMP = (D3D11_QUERY_OCCLUSION + 1),
        D3D11_QUERY_TIMESTAMP_DISJOINT = (D3D11_QUERY_TIMESTAMP + 1),
        D3D11_QUERY_PIPELINE_STATISTICS = (D3D11_QUERY_TIMESTAMP_DISJOINT + 1),
        D3D11_QUERY_OCCLUSION_PREDICATE = (D3D11_QUERY_PIPELINE_STATISTICS + 1),
        D3D11_QUERY_SO_STATISTICS = (D3D11_QUERY_OCCLUSION_PREDICATE + 1),
        D3D11_QUERY_SO_OVERFLOW_PREDICATE = (D3D11_QUERY_SO_STATISTICS + 1),
        D3D11_QUERY_SO_STATISTICS_STREAM0 = (D3D11_QUERY_SO_OVERFLOW_PREDICATE + 1),
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0 = (D3D11_QUERY_SO_STATISTICS_STREAM0 + 1),
        D3D11_QUERY_SO_STATISTICS_STREAM1 = (D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0 + 1),
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1 = (D3D11_QUERY_SO_STATISTICS_STREAM1 + 1),
        D3D11_QUERY_SO_STATISTICS_STREAM2 = (D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1 + 1),
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2 = (D3D11_QUERY_SO_STATISTICS_STREAM2 + 1),
        D3D11_QUERY_SO_STATISTICS_STREAM3 = (D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2 + 1),
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM3 = (D3D11_QUERY_SO_STATISTICS_STREAM3 + 1)
    }

    [ComImport]
    [Guid("9eb576dd-9f77-4d86-81aa-8bab5fe490e2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Predicate : ID3D11Query
    {
        #region ID3D11Query
        #region ID3D11Asynchronous
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion
        [PreserveSig]
        new uint GetDataSize();
        #endregion
        [PreserveSig]
        new void GetDesc(out D3D11_QUERY_DESC pDesc);
        #endregion
    }

    [ComImport]
    [Guid("dfdba067-0b8d-4865-875b-d7b4516cc164")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11RenderTargetView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion
        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_RENDER_TARGET_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_RENDER_TARGET_VIEW_DESC
    {
        public DXGI_FORMAT Format;
        public D3D11_RTV_DIMENSION ViewDimension;
        //    union 
        //    {
        //    D3D11_BUFFER_RTV Buffer;
        //    D3D11_TEX1D_RTV Texture1D;
        //    D3D11_TEX1D_ARRAY_RTV Texture1DArray;
        //    D3D11_TEX2D_RTV Texture2D;
        //    D3D11_TEX2D_ARRAY_RTV Texture2DArray;
        //    D3D11_TEX2DMS_RTV Texture2DMS;
        //    D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;
        //    D3D11_TEX3D_RTV Texture3D;
        //};
    }

    public enum D3D11_RTV_DIMENSION
    {
        D3D11_RTV_DIMENSION_UNKNOWN = 0,
        D3D11_RTV_DIMENSION_BUFFER = 1,
        D3D11_RTV_DIMENSION_TEXTURE1D = 2,
        D3D11_RTV_DIMENSION_TEXTURE1DARRAY = 3,
        D3D11_RTV_DIMENSION_TEXTURE2D = 4,
        D3D11_RTV_DIMENSION_TEXTURE2DARRAY = 5,
        D3D11_RTV_DIMENSION_TEXTURE2DMS = 6,
        D3D11_RTV_DIMENSION_TEXTURE2DMSARRAY = 7,
        D3D11_RTV_DIMENSION_TEXTURE3D = 8
    }

    [ComImport]
    [Guid("9fdac92a-1876-48c3-afad-25b94f84a9b6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DepthStencilView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_DEPTH_STENCIL_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_DEPTH_STENCIL_VIEW_DESC
    {
        public DXGI_FORMAT Format;
        public D3D11_DSV_DIMENSION ViewDimension;
        public uint Flags;
        //    union 
        //    {
        //    D3D11_TEX1D_DSV Texture1D;
        //    D3D11_TEX1D_ARRAY_DSV Texture1DArray;
        //    D3D11_TEX2D_DSV Texture2D;
        //    D3D11_TEX2D_ARRAY_DSV Texture2DArray;
        //    D3D11_TEX2DMS_DSV Texture2DMS;
        //    D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray;
        //};
    }

    public enum D3D11_DSV_DIMENSION
    {
        D3D11_DSV_DIMENSION_UNKNOWN = 0,
        D3D11_DSV_DIMENSION_TEXTURE1D = 1,
        D3D11_DSV_DIMENSION_TEXTURE1DARRAY = 2,
        D3D11_DSV_DIMENSION_TEXTURE2D = 3,
        D3D11_DSV_DIMENSION_TEXTURE2DARRAY = 4,
        D3D11_DSV_DIMENSION_TEXTURE2DMS = 5,
        D3D11_DSV_DIMENSION_TEXTURE2DMSARRAY = 6
    }

    [ComImport]
    [Guid("28acf509-7f5c-48f6-8611-f316010a6380")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11UnorderedAccessView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_UNORDERED_ACCESS_VIEW_DESC
    {
        public DXGI_FORMAT Format;
        public D3D11_UAV_DIMENSION ViewDimension;
        //    union 
        //    {
        //    D3D11_BUFFER_UAV Buffer;
        //    D3D11_TEX1D_UAV Texture1D;
        //    D3D11_TEX1D_ARRAY_UAV Texture1DArray;
        //    D3D11_TEX2D_UAV Texture2D;
        //    D3D11_TEX2D_ARRAY_UAV Texture2DArray;
        //    D3D11_TEX3D_UAV Texture3D;
        //};

    }

    public enum D3D11_UAV_DIMENSION
    {
        D3D11_UAV_DIMENSION_UNKNOWN = 0,
        D3D11_UAV_DIMENSION_BUFFER = 1,
        D3D11_UAV_DIMENSION_TEXTURE1D = 2,
        D3D11_UAV_DIMENSION_TEXTURE1DARRAY = 3,
        D3D11_UAV_DIMENSION_TEXTURE2D = 4,
        D3D11_UAV_DIMENSION_TEXTURE2DARRAY = 5,
        D3D11_UAV_DIMENSION_TEXTURE3D = 8
    }

    [ComImport]
    [Guid("75b68faa-347d-4159-8f45-a0640f01cd9a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11BlendState : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_BLEND_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_BLEND_DESC
    {
        public bool AlphaToCoverageEnable;
        public bool IndependentBlendEnable;
        [MarshalAs(UnmanagedType.LPStruct, SizeConst = 8)]
        public D3D11_RENDER_TARGET_BLEND_DESC RenderTarget;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_RENDER_TARGET_BLEND_DESC
    {
        public bool BlendEnable;
        public D3D11_BLEND SrcBlend;
        public D3D11_BLEND DestBlend;
        public D3D11_BLEND_OP BlendOp;
        public D3D11_BLEND SrcBlendAlpha;
        public D3D11_BLEND DestBlendAlpha;
        public D3D11_BLEND_OP BlendOpAlpha;
        public byte RenderTargetWriteMask;
    }

    public enum D3D11_BLEND
    {
        D3D11_BLEND_ZERO = 1,
        D3D11_BLEND_ONE = 2,
        D3D11_BLEND_SRC_COLOR = 3,
        D3D11_BLEND_INV_SRC_COLOR = 4,
        D3D11_BLEND_SRC_ALPHA = 5,
        D3D11_BLEND_INV_SRC_ALPHA = 6,
        D3D11_BLEND_DEST_ALPHA = 7,
        D3D11_BLEND_INV_DEST_ALPHA = 8,
        D3D11_BLEND_DEST_COLOR = 9,
        D3D11_BLEND_INV_DEST_COLOR = 10,
        D3D11_BLEND_SRC_ALPHA_SAT = 11,
        D3D11_BLEND_BLEND_FACTOR = 14,
        D3D11_BLEND_INV_BLEND_FACTOR = 15,
        D3D11_BLEND_SRC1_COLOR = 16,
        D3D11_BLEND_INV_SRC1_COLOR = 17,
        D3D11_BLEND_SRC1_ALPHA = 18,
        D3D11_BLEND_INV_SRC1_ALPHA = 19
    }

    public enum D3D11_BLEND_OP
    {
        D3D11_BLEND_OP_ADD = 1,
        D3D11_BLEND_OP_SUBTRACT = 2,
        D3D11_BLEND_OP_REV_SUBTRACT = 3,
        D3D11_BLEND_OP_MIN = 4,
        D3D11_BLEND_OP_MAX = 5
    }

    [ComImport]
    [Guid("03823efb-8d8f-4e1c-9aa2-f64bb2cbfdf1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DepthStencilState : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_DEPTH_STENCIL_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_DEPTH_STENCIL_DESC
    {
        public bool DepthEnable;
        public D3D11_DEPTH_WRITE_MASK DepthWriteMask;
        public D3D11_COMPARISON_FUNC DepthFunc;
        public bool StencilEnable;
        public byte StencilReadMask;
        public byte StencilWriteMask;
        public D3D11_DEPTH_STENCILOP_DESC FrontFace;
        public D3D11_DEPTH_STENCILOP_DESC BackFace;
    }

    public enum D3D11_DEPTH_WRITE_MASK
    {
        D3D11_DEPTH_WRITE_MASK_ZERO = 0,
        D3D11_DEPTH_WRITE_MASK_ALL = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_DEPTH_STENCILOP_DESC
    {
        public D3D11_STENCIL_OP StencilFailOp;
        public D3D11_STENCIL_OP StencilDepthFailOp;
        public D3D11_STENCIL_OP StencilPassOp;
        public D3D11_COMPARISON_FUNC StencilFunc;
    }
    public enum D3D11_STENCIL_OP
    {
        D3D11_STENCIL_OP_KEEP = 1,
        D3D11_STENCIL_OP_ZERO = 2,
        D3D11_STENCIL_OP_REPLACE = 3,
        D3D11_STENCIL_OP_INCR_SAT = 4,
        D3D11_STENCIL_OP_DECR_SAT = 5,
        D3D11_STENCIL_OP_INVERT = 6,
        D3D11_STENCIL_OP_INCR = 7,
        D3D11_STENCIL_OP_DECR = 8
    }

    [ComImport]
    [Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11RasterizerState : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_RASTERIZER_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_RASTERIZER_DESC
    {
        public D3D11_FILL_MODE FillMode;
        public D3D11_CULL_MODE CullMode;
        public bool FrontCounterClockwise;
        public int DepthBias;
        public float DepthBiasClamp;
        public float SlopeScaledDepthBias;
        public bool DepthClipEnable;
        public bool ScissorEnable;
        public bool MultisampleEnable;
        public bool AntialiasedLineEnable;
    }

    public enum D3D11_FILL_MODE
    {
        D3D11_FILL_WIREFRAME = 2,
        D3D11_FILL_SOLID = 3
    }

    public enum D3D11_CULL_MODE
    {
        D3D11_CULL_NONE = 1,
        D3D11_CULL_FRONT = 2,
        D3D11_CULL_BACK = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIEWPORT
    {
        public float TopLeftX;
        public float TopLeftY;
        public float Width;
        public float Height;
        public float MinDepth;
        public float MaxDepth;
    }

    [ComImport]
    [Guid("a24bc4d1-769e-43f7-8013-98ff566c18e2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11CommandList : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        uint GetContextFlags();
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_BOX
    {
        public uint left;
        public uint top;
        public uint front;
        public uint right;
        public uint bottom;
        public uint back;
    }

    [ComImport]
    [Guid("8e5c6061-628a-4c8e-8264-bbe45cb3d5dd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11HullShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("f582c508-0f36-490c-9977-31eece268cfa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DomainShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("4f5b196e-c2bd-495e-bd01-1fded38e4969")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ComputeShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion        
    }

    public enum D3D11_DEVICE_CONTEXT_TYPE
    {
        D3D11_DEVICE_CONTEXT_IMMEDIATE = 0,
        D3D11_DEVICE_CONTEXT_DEFERRED = (D3D11_DEVICE_CONTEXT_IMMEDIATE + 1)
    }

    [ComImport]
    [Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DeviceContext : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void VSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void PSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void PSSetShader(ID3D11PixelShader pPixelShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void PSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void VSSetShader(ID3D11VertexShader pVertexShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);
        [PreserveSig]
        void Draw(uint VertexCount, uint StartVertexLocation);
        [PreserveSig]
        HRESULT Map(ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);
        [PreserveSig]
        void Unmap(ID3D11Resource pResource, uint Subresource);
        [PreserveSig]
        void PSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void IASetInputLayout(ID3D11InputLayout pInputLayout);
        [PreserveSig]
        void IASetVertexBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppVertexBuffers, uint pStrides, uint pOffsets);
        [PreserveSig]
        void IASetIndexBuffer(ID3D11Buffer pIndexBuffer, DXGI_FORMAT Format, uint Offset);
        [PreserveSig]
        void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        void GSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void GSSetShader(ID3D11GeometryShader pShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        //void IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY Topology);
        [PreserveSig]
        void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);
        [PreserveSig]
        void VSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void VSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void Begin(ID3D11Asynchronous pAsync);
        [PreserveSig]
        void End(ID3D11Asynchronous pAsync);
        [PreserveSig]
        HRESULT GetData(ID3D11Asynchronous pAsync, out IntPtr pData, uint DataSize, uint GetDataFlags);
        [PreserveSig]
        void SetPredication(ID3D11Predicate pPredicate, bool PredicateValue);
        [PreserveSig]
        void GSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void GSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        //void OMSetRenderTargets(uint NumViews, IntPtr ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);
        [PreserveSig]
        void OMSetRenderTargets(uint NumViews, [In, Out, MarshalAs(UnmanagedType.LPArray)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);
        [PreserveSig]
        void OMSetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, ID3D11RenderTargetView ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView,
            uint UAVStartSlot, uint NumUAVs, ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        //   _In_opt_  const FLOAT BlendFactor[ 4 ],
        [PreserveSig]
        void OMSetBlendState(ID3D11BlendState pBlendState, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, uint SampleMask);
        [PreserveSig]
        void OMSetDepthStencilState(ID3D11DepthStencilState pDepthStencilState, uint StencilRef);
        [PreserveSig]
        void SOSetTargets(uint NumBuffers, ID3D11Buffer ppSOTargets, uint pOffsets);
        [PreserveSig]
        void DrawAuto();
        [PreserveSig]
        void DrawIndexedInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void DrawInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);
        [PreserveSig]
        void DispatchIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void RSSetState(ID3D11RasterizerState pRasterizerState);
        [PreserveSig]
        void RSSetViewports(uint NumViewports, [In, Out, MarshalAs(UnmanagedType.LPArray)] D3D11_VIEWPORT[] pViewports);
        ////void RSSetScissorRects(uint NumRects, D3D11_RECT pRects);
        [PreserveSig]
        void RSSetScissorRects(uint NumRects, ref RECT pRects);
        [PreserveSig]
        void CopySubresourceRegion(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, D3D11_BOX pSrcBox);
        [PreserveSig]
        void CopyResource(ID3D11Resource pDstResource, ID3D11Resource pSrcResource);
        [PreserveSig]
        void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, D3D11_BOX pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);
        [PreserveSig]
        void CopyStructureCount(ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ID3D11UnorderedAccessView pSrcView);
        // float ColorRGBA[ 4 ]
        //void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] ColorRGBA);
        [PreserveSig]
        void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] ColorRGBA);
        // uint Values[ 4 ]
        [PreserveSig]
        void ClearUnorderedAccessViewUint(ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] Values);
        // float Values[ 4 ]
        [PreserveSig]
        void ClearUnorderedAccessViewFloat(ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] Values);
        [PreserveSig]
        void ClearDepthStencilView(ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);
        [PreserveSig]
        void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);
        [PreserveSig]
        void SetResourceMinLOD(ID3D11Resource pResource, float MinLOD);
        [PreserveSig]
        float GetResourceMinLOD(ID3D11Resource pResource);
        [PreserveSig]
        void ResolveSubresource(ID3D11Resource pDstResource, uint DstSubresource, ID3D11Resource pSrcResource, uint SrcSubresource, DXGI_FORMAT Format);
        [PreserveSig]
        void ExecuteCommandList(ID3D11CommandList pCommandList, bool RestoreContextState);
        [PreserveSig]
        void HSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void HSSetShader(ID3D11HullShader pHullShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void HSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void HSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void DSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void DSSetShader(ID3D11DomainShader pDomainShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void DSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void DSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void CSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void CSSetUnorderedAccessViews(uint StartSlot, uint NumUAVs, ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        [PreserveSig]
        void CSSetShader(ID3D11ComputeShader pComputeShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void CSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void CSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void PSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void PSGetShader(out ID3D11PixelShader ppPixelShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        [PreserveSig]
        void PSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void VSGetShader(out ID3D11VertexShader ppVertexShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        [PreserveSig]
        void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);
        [PreserveSig]
        void IAGetVertexBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppVertexBuffers, out uint pStrides, out uint pOffsets);
        [PreserveSig]
        void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);
        [PreserveSig]
        void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void GSGetShader(out ID3D11GeometryShader ppGeometryShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        //void IAGetPrimitiveTopology(out D3D11_PRIMITIVE_TOPOLOGY pTopology);
        [PreserveSig]
        void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);
        [PreserveSig]
        void VSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void VSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void GetPredication(out ID3D11Predicate ppPredicate, out bool pPredicateValue);
        [PreserveSig]
        void GSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void GSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void OMGetRenderTargets(uint NumViews, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);
        [PreserveSig]
        void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        //  float BlendFactor[ 4 ]
        //void OMGetBlendState(out ID3D11BlendState ppBlendState, out float[] BlendFactor, out uint pSampleMask);
        //void OMGetBlendState(out ID3D11BlendState ppBlendState, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] BlendFactor, out uint pSampleMask);
        [PreserveSig]
        void OMGetBlendState(out ID3D11BlendState ppBlendState, out IntPtr BlendFactor, out uint pSampleMask);
        [PreserveSig]
        void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, out uint pStencilRef);
        [PreserveSig]
        void SOGetTargets(uint NumBuffers, out ID3D11Buffer ppSOTargets);
        [PreserveSig]
        void RSGetState(out ID3D11RasterizerState ppRasterizerState);
        [PreserveSig]
        void RSGetViewports(ref uint pNumViewports, out D3D11_VIEWPORT pViewports);
        //void RSGetScissorRects(ref uint pNumRects, out D3D11_RECT pRects);
        [PreserveSig]
        void RSGetScissorRects(ref uint pNumRects, out RECT pRects);
        [PreserveSig]
        void HSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void HSGetShader(out ID3D11HullShader ppHullShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        [PreserveSig]
        void HSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void DSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void DSGetShader(out ID3D11DomainShader ppDomainShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        [PreserveSig]
        void DSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void CSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        [PreserveSig]
        void CSGetShader(out ID3D11ComputeShader ppComputeShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        [PreserveSig]
        void CSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void ClearState();
        [PreserveSig]
        void Flush();
        [PreserveSig]
        D3D11_DEVICE_CONTEXT_TYPE GetType();
        [PreserveSig]
        uint GetContextFlags();
        [PreserveSig]
        HRESULT FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);
    }

    public enum D3D11_MAP
    {
        D3D11_MAP_READ = 1,
        D3D11_MAP_WRITE = 2,
        D3D11_MAP_READ_WRITE = 3,
        D3D11_MAP_WRITE_DISCARD = 4,
        D3D11_MAP_WRITE_NO_OVERWRITE = 5
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_MAPPED_SUBRESOURCE
    {
        public IntPtr pData;
        public uint RowPitch;
        public uint DepthPitch;
    }

    //typedef D3D_PRIMITIVE_TOPOLOGY D3D11_PRIMITIVE_TOPOLOGY;
    public enum D3D_PRIMITIVE_TOPOLOGY
    {
        D3D_PRIMITIVE_TOPOLOGY_UNDEFINED = 0,
        D3D_PRIMITIVE_TOPOLOGY_POINTLIST = 1,
        D3D_PRIMITIVE_TOPOLOGY_LINELIST = 2,
        D3D_PRIMITIVE_TOPOLOGY_LINESTRIP = 3,
        D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST = 4,
        D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = 5,
        D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10,
        D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = 11,
        D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = 12,
        D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = 13,
        D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33,
        D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = 34,
        D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = 35,
        D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = 36,
        D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = 37,
        D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = 38,
        D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = 39,
        D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = 40,
        D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = 41,
        D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = 42,
        D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = 43,
        D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = 44,
        D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = 45,
        D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = 46,
        D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = 47,
        D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = 48,
        D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = 49,
        D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = 50,
        D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = 51,
        D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = 52,
        D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = 53,
        D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = 54,
        D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = 55,
        D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = 56,
        D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = 57,
        D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = 58,
        D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = 59,
        D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = 60,
        D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = 61,
        D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = 62,
        D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = 63,
        D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = 64,
        D3D10_PRIMITIVE_TOPOLOGY_UNDEFINED = D3D_PRIMITIVE_TOPOLOGY_UNDEFINED,
        D3D10_PRIMITIVE_TOPOLOGY_POINTLIST = D3D_PRIMITIVE_TOPOLOGY_POINTLIST,
        D3D10_PRIMITIVE_TOPOLOGY_LINELIST = D3D_PRIMITIVE_TOPOLOGY_LINELIST,
        D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP,
        D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST,
        D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,
        D3D10_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,
        D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,
        D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,
        D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,
        D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED = D3D_PRIMITIVE_TOPOLOGY_UNDEFINED,
        D3D11_PRIMITIVE_TOPOLOGY_POINTLIST = D3D_PRIMITIVE_TOPOLOGY_POINTLIST,
        D3D11_PRIMITIVE_TOPOLOGY_LINELIST = D3D_PRIMITIVE_TOPOLOGY_LINELIST,
        D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP,
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST,
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,
        D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,
        D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,
        D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,
        D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST,
        D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST
    }

    [ComImport]
    [Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Device
    {
        [PreserveSig]
        HRESULT CreateBuffer(ref D3D11_BUFFER_DESC pDesc, IntPtr pInitialData, out ID3D11Buffer ppBuffer);
        [PreserveSig]
        HRESULT CreateTexture1D(ref D3D11_TEXTURE1D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture1D ppTexture1D);
        [PreserveSig]
        HRESULT CreateTexture2D(ref D3D11_TEXTURE2D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture2D ppTexture2D);
        [PreserveSig]
        HRESULT CreateTexture3D(ref D3D11_TEXTURE3D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture3D ppTexture3D);
        [PreserveSig]
        HRESULT CreateShaderResourceView(ID3D11Resource pResource, D3D11_SHADER_RESOURCE_VIEW_DESC pDesc, out ID3D11ShaderResourceView ppSRView);
        [PreserveSig]
        HRESULT CreateUnorderedAccessView(ID3D11Resource pResource, D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc, out ID3D11UnorderedAccessView ppUAView);
        //HRESULT CreateRenderTargetView(ID3D11Resource pResource, D3D11_RENDER_TARGET_VIEW_DESC pDesc, out ID3D11RenderTargetView ppRTView);
        [PreserveSig]
        HRESULT CreateRenderTargetView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11RenderTargetView ppRTView);
        [PreserveSig]
        HRESULT CreateDepthStencilView(ID3D11Resource pResource, D3D11_DEPTH_STENCIL_VIEW_DESC pDesc, out ID3D11DepthStencilView ppDepthStencilView);
        [PreserveSig]
        HRESULT CreateInputLayout(ref D3D11_INPUT_ELEMENT_DESC pInputElementDescs, uint NumElements, IntPtr pShaderBytecodeWithInputSignature, uint BytecodeLength, out ID3D11InputLayout ppInputLayout);
        [PreserveSig]
        HRESULT CreateVertexShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11VertexShader ppVertexShader);
        [PreserveSig]
        HRESULT CreateGeometryShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);
        [PreserveSig]
        HRESULT CreateGeometryShaderWithStreamOutput(ID3D11Resource pResource, D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc, out ID3D11UnorderedAccessView ppUAView);
        [PreserveSig]
        HRESULT CreatePixelShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11PixelShader ppPixelShader);
        [PreserveSig]
        HRESULT CreateHullShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11HullShader ppHullShader);
        [PreserveSig]
        HRESULT CreateDomainShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage,  out ID3D11DomainShader ppDomainShader);
        [PreserveSig]
        HRESULT CreateComputeShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11ComputeShader ppComputeShader);
        [PreserveSig]
        HRESULT CreateClassLinkage(out ID3D11ClassLinkage ppLinkage);
        [PreserveSig]
        HRESULT CreateBlendState(ref D3D11_BLEND_DESC pBlendStateDesc, out ID3D11BlendState ppBlendState);
        [PreserveSig]
        HRESULT CreateDepthStencilState(ref D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, out ID3D11DepthStencilState ppDepthStencilState);
        [PreserveSig]
        HRESULT CreateRasterizerState(ref D3D11_RASTERIZER_DESC pRasterizerDesc, out ID3D11RasterizerState ppRasterizerState);
        [PreserveSig]
        HRESULT CreateSamplerState(ref D3D11_SAMPLER_DESC pSamplerDesc, out ID3D11SamplerState ppSamplerState);
        [PreserveSig]
        HRESULT CreateQuery(ref D3D11_QUERY_DESC pQueryDesc, out ID3D11Query ppQuery);
        [PreserveSig]
        HRESULT CreatePredicate(ref D3D11_QUERY_DESC pPredicateDesc, out ID3D11Predicate ppPredicate);
        [PreserveSig]
        HRESULT CreateCounter(ref D3D11_COUNTER_DESC pCounterDesc, out ID3D11Counter ppCounter);
        [PreserveSig]
        HRESULT CreateDeferredContext(uint ContextFlags, out ID3D11DeviceContext ppDeferredContext);
        [PreserveSig]
        HRESULT OpenSharedResource(IntPtr hResource, ref Guid ReturnedInterface, out IntPtr ppResource);
        [PreserveSig]
        HRESULT CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);
        [PreserveSig]
        HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);
        [PreserveSig]
        void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);
        [PreserveSig]
        HRESULT CheckCounter(ref D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters,
            out string szName, ref uint pNameLength, out string szUnits, ref uint pUnitsLength, out string szDescription, ref uint pDescriptionLength);
        [PreserveSig]
        HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, out IntPtr pFeatureSupportData, uint FeatureSupportDataSize);
        [PreserveSig]
        HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        [PreserveSig]
        HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        [PreserveSig]
        D3D_FEATURE_LEVEL GetFeatureLevel();
        [PreserveSig]
        uint GetCreationFlags();
        [PreserveSig]
        HRESULT GetDeviceRemovedReason();
        [PreserveSig]
        void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);
        [PreserveSig]
        HRESULT SetExceptionMode(uint RaiseFlags);
        [PreserveSig]
        uint GetExceptionMode();
    }

    public enum D3D11_CPU_ACCESS_FLAG
    {
        D3D11_CPU_ACCESS_WRITE = 0x10000,
        D3D11_CPU_ACCESS_READ = 0x20000
    };

    public enum D3D11_BIND_FLAG
    {
        D3D11_BIND_VERTEX_BUFFER = 0x1,
        D3D11_BIND_INDEX_BUFFER = 0x2,
        D3D11_BIND_CONSTANT_BUFFER = 0x4,
        D3D11_BIND_SHADER_RESOURCE = 0x8,
        D3D11_BIND_STREAM_OUTPUT = 0x10,
        D3D11_BIND_RENDER_TARGET = 0x20,
        D3D11_BIND_DEPTH_STENCIL = 0x40,
        D3D11_BIND_UNORDERED_ACCESS = 0x80,
        D3D11_BIND_DECODER = 0x200,
        D3D11_BIND_VIDEO_ENCODER = 0x400
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_SUBRESOURCE_DATA
    {
        public IntPtr pSysMem;
        public uint SysMemPitch;
        public uint SysMemSlicePitch;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEXTURE1D_DESC
    {
        public uint Width;
        public uint MipLevels;
        public uint ArraySize;
        public DXGI_FORMAT Format;
        public D3D11_USAGE Usage;
        public D3D11_BIND_FLAG BindFlags;
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEXTURE2D_DESC
    {
        public uint Width;
        public uint Height;
        public uint MipLevels;
        public uint ArraySize;
        public DXGI_FORMAT Format;
        public DXGI_SAMPLE_DESC SampleDesc;
        public D3D11_USAGE Usage;
        public D3D11_BIND_FLAG BindFlags;
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }

    public enum D3D11_RESOURCE_MISC_FLAG
    {
        D3D11_RESOURCE_MISC_GENERATE_MIPS = 0x1,
        D3D11_RESOURCE_MISC_SHARED = 0x2,
        D3D11_RESOURCE_MISC_TEXTURECUBE = 0x4,
        D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS = 0x10,
        D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS = 0x20,
        D3D11_RESOURCE_MISC_BUFFER_STRUCTURED = 0x40,
        D3D11_RESOURCE_MISC_RESOURCE_CLAMP = 0x80,
        D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX = 0x100,
        D3D11_RESOURCE_MISC_GDI_COMPATIBLE = 0x200,
        D3D11_RESOURCE_MISC_SHARED_NTHANDLE = 0x800,
        D3D11_RESOURCE_MISC_RESTRICTED_CONTENT = 0x1000,
        D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE = 0x2000,
        D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER = 0x4000,
        D3D11_RESOURCE_MISC_GUARDED = 0x8000,
        D3D11_RESOURCE_MISC_TILE_POOL = 0x20000,
        D3D11_RESOURCE_MISC_TILED = 0x40000,
        D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000,
        D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE,
        D3D11_RESOURCE_MISC_SHARED_EXCLUSIVE_WRITER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEXTURE3D_DESC
    {
        public uint Width;
        public uint Height;
        public uint Depth;
        public uint MipLevels;
        public DXGI_FORMAT Format;
        public D3D11_USAGE Usage;
        public D3D11_BIND_FLAG BindFlags;
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_INPUT_ELEMENT_DESC
    {
        public string SemanticName;
        public uint SemanticIndex;
        public DXGI_FORMAT Format;
        public uint InputSlot;
        public uint AlignedByteOffset;
        public D3D11_INPUT_CLASSIFICATION InputSlotClass;
        public uint InstanceDataStepRate;
    }

    public enum D3D11_INPUT_CLASSIFICATION
    {
        D3D11_INPUT_PER_VERTEX_DATA = 0,
        D3D11_INPUT_PER_INSTANCE_DATA = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_COUNTER_DESC
    {
        public D3D11_COUNTER Counter;
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;
    }

    public enum D3D11_COUNTER
    {
        D3D11_COUNTER_DEVICE_DEPENDENT_0 = 0x40000000
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_COUNTER_INFO
    {
        public D3D11_COUNTER LastDeviceDependentCounter;
        public uint NumSimultaneousCounters;
        public byte NumDetectableParallelUnits;
    }

    public enum D3D11_COUNTER_TYPE
    {
        D3D11_COUNTER_TYPE_FLOAT32 = 0,
        D3D11_COUNTER_TYPE_UINT16 = (D3D11_COUNTER_TYPE_FLOAT32 + 1),
        D3D11_COUNTER_TYPE_UINT32 = (D3D11_COUNTER_TYPE_UINT16 + 1),
        D3D11_COUNTER_TYPE_UINT64 = (D3D11_COUNTER_TYPE_UINT32 + 1)
    }

    public enum D3D11_FEATURE
    {
        D3D11_FEATURE_THREADING = 0,
        D3D11_FEATURE_DOUBLES = (D3D11_FEATURE_THREADING + 1),
        D3D11_FEATURE_FORMAT_SUPPORT = (D3D11_FEATURE_DOUBLES + 1),
        D3D11_FEATURE_FORMAT_SUPPORT2 = (D3D11_FEATURE_FORMAT_SUPPORT + 1),
        D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS = (D3D11_FEATURE_FORMAT_SUPPORT2 + 1),
        D3D11_FEATURE_D3D11_OPTIONS = (D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS + 1),
        D3D11_FEATURE_ARCHITECTURE_INFO = (D3D11_FEATURE_D3D11_OPTIONS + 1),
        D3D11_FEATURE_D3D9_OPTIONS = (D3D11_FEATURE_ARCHITECTURE_INFO + 1),
        D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT = (D3D11_FEATURE_D3D9_OPTIONS + 1),
        D3D11_FEATURE_D3D9_SHADOW_SUPPORT = (D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT + 1),
        D3D11_FEATURE_D3D11_OPTIONS1 = (D3D11_FEATURE_D3D9_SHADOW_SUPPORT + 1),
        D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT = (D3D11_FEATURE_D3D11_OPTIONS1 + 1),
        D3D11_FEATURE_MARKER_SUPPORT = (D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT + 1),
        D3D11_FEATURE_D3D9_OPTIONS1 = (D3D11_FEATURE_MARKER_SUPPORT + 1),
        D3D11_FEATURE_D3D11_OPTIONS2 = (D3D11_FEATURE_D3D9_OPTIONS1 + 1),
        D3D11_FEATURE_D3D11_OPTIONS3 = (D3D11_FEATURE_D3D11_OPTIONS2 + 1),
        D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT = (D3D11_FEATURE_D3D11_OPTIONS3 + 1),
        D3D11_FEATURE_D3D11_OPTIONS4 = (D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT + 1),
        D3D11_FEATURE_SHADER_CACHE = (D3D11_FEATURE_D3D11_OPTIONS4 + 1),
        D3D11_FEATURE_D3D11_OPTIONS5 = (D3D11_FEATURE_SHADER_CACHE + 1)
    }

    [ComImport]
    [Guid("6e8c49fb-a371-4770-b440-29086022b741")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Counter : ID3D11Asynchronous
    {
        #region ID3D11Asynchronous
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new uint GetDataSize();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_COUNTER_DESC pDesc);
    }

    [ComImport]
    [Guid("f8fb5c27-c6b3-4f75-a4c8-439af2ef564c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture1D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);       
        #endregion

        [PreserveSig]
        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        [PreserveSig]
        new void SetEvictionPriority(uint EvictionPriority);
        [PreserveSig]
        new uint GetEvictionPriority();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_TEXTURE1D_DESC pDesc);
    }

    [ComImport]
    [Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture2D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        [PreserveSig]
        new void SetEvictionPriority(uint EvictionPriority);
        [PreserveSig]
        new uint GetEvictionPriority();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_TEXTURE2D_DESC pDesc);
    }

    [ComImport]
    [Guid("037e866e-f56d-4357-a8af-9dabbe6e250e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture3D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        [PreserveSig]
        new void SetEvictionPriority(uint EvictionPriority);
        [PreserveSig]
        new uint GetEvictionPriority();
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_TEXTURE3D_DESC pDesc);
    }

    [ComImport, Guid("61f21c45-3c0e-4a74-9cea-67100d9ad5e4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface ID3D11VideoContext : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        HRESULT GetDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);
        [PreserveSig]
        HRESULT ReleaseDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);
        [PreserveSig]
        HRESULT DecoderBeginFrame(ID3D11VideoDecoder pDecoder, ID3D11VideoDecoderOutputView pView, uint ContentKeySize, IntPtr pContentKey);
        [PreserveSig]
        HRESULT DecoderEndFrame(ID3D11VideoDecoder pDecoder);
        [PreserveSig]
        HRESULT SubmitDecoderBuffers(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);
        [PreserveSig]
        int DecoderExtension(ID3D11VideoDecoder pDecoder, ref D3D11_VIDEO_DECODER_EXTENSION pExtensionData);
        [PreserveSig]
        void VideoProcessorSetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, bool Enable, IntPtr pRect);
        [PreserveSig]
        void VideoProcessorSetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, bool YCbCr, ref D3D11_VIDEO_COLOR pColor);
        [PreserveSig]
        void VideoProcessorSetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        [PreserveSig]
        void VideoProcessorSetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);
        [PreserveSig]
        void VideoProcessorSetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, bool Enable, SIZE Size);
        [PreserveSig]
        void VideoProcessorSetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, bool Enable);
        [PreserveSig]
        int VideoProcessorSetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);
        [PreserveSig]
        void VideoProcessorGetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);
        [PreserveSig]
        void VideoProcessorGetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);
        [PreserveSig]
        void VideoProcessorGetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        [PreserveSig]
        void VideoProcessorGetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);
        [PreserveSig]
        void VideoProcessorGetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out SIZE pSize);
        [PreserveSig]
        void VideoProcessorGetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);
        [PreserveSig]
        int VideoProcessorGetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);
        [PreserveSig]
        void VideoProcessorSetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);
        [PreserveSig]
        void VideoProcessorSetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        [PreserveSig]
        void VideoProcessorSetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, bool RepeatFrame, IntPtr pCustomRate);
        [PreserveSig]
        void VideoProcessorSetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pRect);
        [PreserveSig]
        void VideoProcessorSetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, ref RECT pRect);
        [PreserveSig]
        void VideoProcessorSetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);
        [PreserveSig]
        void VideoProcessorSetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);
        [PreserveSig]
        void VideoProcessorSetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pSourceAspectRatio, IntPtr pDestinationAspectRatio);
        [PreserveSig]
        void VideoProcessorSetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);
        [PreserveSig]
        void VideoProcessorSetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);
        [PreserveSig]
        void VideoProcessorSetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);
        [PreserveSig]
        void VideoProcessorSetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);
        [PreserveSig]
        int VideoProcessorSetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);
        [PreserveSig]
        void VideoProcessorGetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);
        [PreserveSig]
        void VideoProcessorGetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        [PreserveSig]
        void VideoProcessorGetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate, out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);
        [PreserveSig]
        void VideoProcessorGetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);
        [PreserveSig]
        void VideoProcessorGetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);
        [PreserveSig]
        void VideoProcessorGetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);
        [PreserveSig]
        void VideoProcessorGetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);
        [PreserveSig]
        void VideoProcessorGetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);
        [PreserveSig]
        void VideoProcessorGetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);
        [PreserveSig]
        void VideoProcessorGetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0, out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);
        [PreserveSig]
        void VideoProcessorGetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);
        [PreserveSig]
        void VideoProcessorGetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);
        [PreserveSig]
        int VideoProcessorGetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);
        [PreserveSig]
        HRESULT VideoProcessorBlt(ID3D11VideoProcessor pVideoProcessor, ID3D11VideoProcessorOutputView pView, uint OutputFrame, int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);
        [PreserveSig]
        HRESULT NegotiateCryptoSessionKeyExchange(ID3D11CryptoSession pCryptoSession, uint DataSize, IntPtr pData);
        [PreserveSig]
        void EncryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, uint IVSize, IntPtr pIV);
        [PreserveSig]
        void DecryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface,  IntPtr pEncryptedBlockInfo, uint ContentKeySize, IntPtr pContentKey, uint IVSize, IntPtr pIV);
        [PreserveSig]
        void StartSessionKeyRefresh(ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, IntPtr pRandomNumber);
        [PreserveSig]
        void FinishSessionKeyRefresh(ID3D11CryptoSession pCryptoSession);
        [PreserveSig]
        HRESULT GetEncryptionBltKey(ID3D11CryptoSession pCryptoSession, uint KeySize, IntPtr pReadbackKey);
        [PreserveSig]
        HRESULT NegotiateAuthenticatedChannelKeyExchange(ID3D11AuthenticatedChannel pChannel, uint DataSize, IntPtr pData);
        [PreserveSig]
        HRESULT QueryAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, uint OutputSize, IntPtr pOutput);
        [PreserveSig]
        HRESULT ConfigureAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);
        [PreserveSig]
        void VideoProcessorSetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);
        [PreserveSig]
        void VideoProcessorGetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);
    }

    [ComImport]
    [Guid("3C9C5B51-995D-48d1-9B8D-FA5CAEDED65C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoDecoder : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);      
        #endregion

        [PreserveSig]
        HRESULT GetCreationParameters(out D3D11_VIDEO_DECODER_DESC pVideoDesc, out D3D11_VIDEO_DECODER_CONFIG pConfig);
        [PreserveSig]
        HRESULT GetDriverHandle(out IntPtr pDriverHandle);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_DECODER_DESC
    {
        public Guid Guid;
        public uint SampleWidth;
        public uint SampleHeight;
        public DXGI_FORMAT OutputFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_DECODER_CONFIG
    {
        public Guid guidConfigBitstreamEncryption;
        public Guid guidConfigMBcontrolEncryption;
        public Guid guidConfigResidDiffEncryption;
        public uint ConfigBitstreamRaw;
        public uint ConfigMBcontrolRasterOrder;
        public uint ConfigResidDiffHost;
        public uint ConfigSpatialResid8;
        public uint ConfigResid8Subtraction;
        public uint ConfigSpatialHost8or9Clipping;
        public uint ConfigSpatialResidInterleaved;
        public uint ConfigIntraResidUnsigned;
        public uint ConfigResidDiffAccelerator;
        public uint ConfigHostInverseScan;
        public uint ConfigSpecificIDCT;
        public uint Config4GroupedCoefs;
        public ushort ConfigMinRenderTargetBuffCount;
        public ushort ConfigDecoderSpecific;
    }

    public enum D3D11_VIDEO_DECODER_BUFFER_TYPE
    {
        D3D11_VIDEO_DECODER_BUFFER_PICTURE_PARAMETERS = 0,
        D3D11_VIDEO_DECODER_BUFFER_MACROBLOCK_CONTROL = 1,
        D3D11_VIDEO_DECODER_BUFFER_RESIDUAL_DIFFERENCE = 2,
        D3D11_VIDEO_DECODER_BUFFER_DEBLOCKING_CONTROL = 3,
        D3D11_VIDEO_DECODER_BUFFER_INVERSE_QUANTIZATION_MATRIX = 4,
        D3D11_VIDEO_DECODER_BUFFER_SLICE_CONTROL = 5,
        D3D11_VIDEO_DECODER_BUFFER_BITSTREAM = 6,
        D3D11_VIDEO_DECODER_BUFFER_MOTION_VECTOR = 7,
        D3D11_VIDEO_DECODER_BUFFER_FILM_GRAIN = 8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_DECODER_BUFFER_DESC
    {
        public D3D11_VIDEO_DECODER_BUFFER_TYPE BufferType;
        public uint BufferIndex;
        public uint DataOffset;
        public uint DataSize;
        public uint FirstMBaddress;
        public uint NumMBsInBuffer;
        public uint Width;
        public uint Height;
        public uint Stride;
        public uint ReservedBits;
        public IntPtr pIV;
        public uint IVSize;
        public bool PartialEncryption;
        D3D11_ENCRYPTED_BLOCK_INFO EncryptedBlockInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_ENCRYPTED_BLOCK_INFO
    {
        public uint NumEncryptedBytesAtBeginning;
        public uint NumBytesInSkipPattern;
        public uint NumBytesInEncryptPattern;
    }

    [ComImport]
    [Guid("C2931AEA-2A85-4f20-860F-FBA1FD256E18")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoDecoderOutputView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC
    {
        public Guid DecodeProfile;
        public D3D11_VDOV_DIMENSION ViewDimension;
    //    union 
    //     {
    //    D3D11_TEX2D_VDOV Texture2D;
    //};
    }

    public enum D3D11_VDOV_DIMENSION
    {
        D3D11_VDOV_DIMENSION_UNKNOWN = 0,
        D3D11_VDOV_DIMENSION_TEXTURE2D = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_DECODER_EXTENSION
    {
        public uint Function;
        public IntPtr pPrivateInputData;
        public uint PrivateInputDataSize;
        public IntPtr pPrivateOutputData;
        public uint PrivateOutputDataSize;
        public uint ResourceCount;
        ID3D11Resource ppResourceList;
    }

    [ComImport]
    [Guid("1D7B0652-185F-41c6-85CE-0C5BE3D4AE6C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessor : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc);
        [PreserveSig]
        void GetRateConversionCaps(out D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS pCaps);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_CONTENT_DESC
    {
        public D3D11_VIDEO_FRAME_FORMAT InputFrameFormat;
        public DXGI_RATIONAL InputFrameRate;
        public uint InputWidth;
        public uint InputHeight;
        public DXGI_RATIONAL OutputFrameRate;
        public uint OutputWidth;
        public uint OutputHeight;
        public D3D11_VIDEO_USAGE Usage;
    }

    public enum D3D11_VIDEO_FRAME_FORMAT
    {
        D3D11_VIDEO_FRAME_FORMAT_PROGRESSIVE = 0,
        D3D11_VIDEO_FRAME_FORMAT_INTERLACED_TOP_FIELD_FIRST = 1,
        D3D11_VIDEO_FRAME_FORMAT_INTERLACED_BOTTOM_FIELD_FIRST = 2
    }

    public enum D3D11_VIDEO_USAGE
    {
        D3D11_VIDEO_USAGE_PLAYBACK_NORMAL = 0,
        D3D11_VIDEO_USAGE_OPTIMAL_SPEED = 1,
        D3D11_VIDEO_USAGE_OPTIMAL_QUALITY = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_COLOR_RGBA
    {
        public float R;
        public float G;
        public float B;
        public float A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS
    {
        public uint PastFrames;
        public uint FutureFrames;
        public uint ProcessorCaps;
        public uint ITelecineCaps;
        public uint CustomRateCount;
    }

    // https://github.com/dahall/Vanara/blob/master/Core/Extensions/BitHelper.cs

    public static class BitHelper
    {
        /// <summary>Gets the bit value at the specified index in a bit vector.</summary>
        /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
        /// <param name="bits">The bit vector.</param>
        /// <param name="idx">The zero-based index of the bit to get.</param>
        /// <returns><see langword="true"/> if the bit is set (1); <see langword="false"/> otherwise.</returns>
        public static bool GetBit<T>(T bits, byte idx) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable =>
            (idx < (Marshal.SizeOf(typeof(T)) * 8)) ? (bits.ToInt64(null) & 1 << idx) != 0 : throw new ArgumentOutOfRangeException(nameof(idx));

        /// <summary>Gets the bit array value from the specified range in a bit vector.</summary>
        /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
        /// <param name="bits">The bit vector.</param>
        /// <param name="startIdx">The zero-based start index of the bit range to get.</param>
        /// <param name="count">The number of sequential bits to fetch starting at <paramref name="startIdx"/>.</param>
        /// <returns>The value of the requested bit range.</returns>
        public static T GetBits<T>(T bits, byte startIdx, byte count) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
            if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
            return (T)Convert.ChangeType((bits.ToInt64(null) >> startIdx) & ((1 << count) - 1), typeof(T));
        }

        /// <summary>Sets the bit value at the specified index in a bit vector.</summary>
        /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
        /// <param name="bits">The bit vector.</param>
        /// <param name="idx">The index of the bit to set.</param>
        /// <param name="value">If set to <see langword="true"/>, set the bit (= 1); otherwise, clear the bit (= 0).</param>
        public static void SetBit<T>(ref T bits, byte idx, bool value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (idx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(idx));
            long bit = 1 << idx;
            var l = bits.ToInt64(null);
            bits = (T)Convert.ChangeType(value ? l | bit : l & ~bit, typeof(T));
        }

        /// <summary>Sets the bit values at the specified range in a bit vector.</summary>
        /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
        /// <typeparam name="TValue">The type of the value. Must be of type <see cref="IConvertible"/>.</typeparam>
        /// <param name="bits">The bit vector.</param>
        /// <param name="startIdx">The zero-based start index of the bit range to set.</param>
        /// <param name="count">The number of sequential bits to set starting at <paramref name="startIdx"/>.</param>
        /// <param name="value">The value to set within the specified range of <paramref name="bits"/>.</param>
        public static void SetBits<T, TValue>(ref T bits, byte startIdx, byte count, TValue value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable where TValue : struct, IComparable, IComparable<TValue>, IConvertible, IEquatable<TValue>, IFormattable
        {
            if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
            if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
            var val = value.ToInt64(null);
            if (val >= (1 << count)) throw new ArgumentOutOfRangeException(nameof(value));
            bits = (T)Convert.ChangeType(bits.ToInt64(null) & ~(((1 << count) - 1) << startIdx) | (val << startIdx), typeof(T));
        }
    }

    public static class InteropRuntime
    {
        public static void SetByteArray(byte[] value, byte[] bytes, int offset, int count)
        {
            if (value == null || value.Length == 0)
                return;

            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            var countMod = count % 8;
            var offsetMod = offset % 8;
            if (countMod == 0 && offsetMod == 0)
            {
                Buffer.BlockCopy(value, 0, bytes, offset / 8, count / 8);
                return;
            }

            var bitIndex = offsetMod;
            var byteIndex = offset / 8;
            foreach (var bit in EnumerateBits(value, 0, value.Length * 8))
            {
                if (bit)
                {
                    bytes[byteIndex] |= (byte)(1 << bitIndex);
                }
                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }
        }
        public static IEnumerable<bool> EnumerateBits(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
                yield break;

            // The ordering of data declared as bit fields is from low to high bit
            // https://docs.microsoft.com/en-us/cpp/cpp/cpp-bit-fields
            var byteIndex = offset / 8;
            var bitIndex = offset % 8;
            var b = bytes[byteIndex];
            for (var i = 0; i < count; i++)
            {
                yield return (b & (1 << bitIndex)) != 0;
                if (i == count - 1)
                    break;

                bitIndex++;
                if (bitIndex > 7)
                {
                    bitIndex = 0;
                    byteIndex++;
                    b = bytes[byteIndex];
                }
            }
        }
        public static uint GetUInt32(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
                return 0;

            if (count == 32)
                return BitConverter.ToUInt32(bytes, offset / 8);

            uint ui = 0;
            var bitIndex = 0;
            foreach (var bit in EnumerateBits(bytes, offset, count))
            {
                if (bit)
                {
                    ui |= 1U << bitIndex;
                }
                bitIndex++;
            }
            return ui;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetUInt32(uint value, byte[] bytes, int offset, int count) => SetByteArray(BitConverter.GetBytes(value), bytes, offset, count);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_COLOR_SPACE
    {
        private uint bits;
        public bool Usage { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }
        public bool RGB_Range { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }
        public bool YCbCr_Matrix { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }
        public bool YCbCr_xvYCC { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }
        public byte Nominal_Range { get => (byte)BitHelper.GetBits(bits, 4, 2); set => BitHelper.SetBits(ref bits, 4, 2, value); }
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct D3D11_VIDEO_PROCESSOR_COLOR_SPACE
    //{
    //    //public uint Usage  : 1;
    //    //public uint RGB_Range  : 1;
    //    //public uint YCbCr_Matrix   : 1;
    //    //public uint YCbCr_xvYCC    : 1;
    //    //public uint Nominal_Range  : 2;
    //    //public uint Reserved	: 26;

    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    //        public byte[] __bits;
    //        public uint Usage { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 0, 1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 0, 1); } }
    //        public uint RGB_Range { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 1, 1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 1, 1); } }
    //        public uint YCbCr_Matrix { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 2, 1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 2, 1); } }
    //        public uint YCbCr_xvYCC { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 3, 1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 3, 1); } }
    //        public uint Nominal_Range { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 4, 2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 4, 2); } }
    //        public uint Reserved { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => InteropRuntime.GetUInt32(__bits, 6, 26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { if (__bits == null) __bits = new byte[4]; InteropRuntime.SetUInt32(value, __bits, 6, 26); } }


    //    //private uint _value;

    //    //// Bit field properties
    //    //public uint Usage
    //    //{
    //    //    get => (_value >> 0) & 0x1;
    //    //    set => _value = (_value & ~(0x1u << 0)) | ((value & 0x1) << 0);
    //    //}

    //    //public uint RGB_Range
    //    //{
    //    //    get => (_value >> 1) & 0x1;
    //    //    set => _value = (_value & ~(0x1u << 1)) | ((value & 0x1) << 1);
    //    //}

    //    //public uint YCbCr_Matrix
    //    //{
    //    //    get => (_value >> 2) & 0x1;
    //    //    set => _value = (_value & ~(0x1u << 2)) | ((value & 0x1) << 2);
    //    //}

    //    //public uint YCbCr_xvYCC
    //    //{
    //    //    get => (_value >> 3) & 0x1;
    //    //    set => _value = (_value & ~(0x1u << 3)) | ((value & 0x1) << 3);
    //    //}

    //    //public uint Nominal_Range
    //    //{
    //    //    get => (_value >> 4) & 0x3; // 2-bit field
    //    //    set => _value = (_value & ~(0x3u << 4)) | ((value & 0x3) << 4);
    //    //}

    //    //public uint Reserved
    //    //{
    //    //    get => (_value >> 6) & 0x3FFFFFF; // 26-bit reserved
    //    //    set => _value = (_value & ~(0x3FFFFFFu << 6)) | ((value & 0x3FFFFFF) << 6);
    //    //}

    //    //public uint RawValue
    //    //{
    //    //    get => _value;
    //    //    set => _value = value;
    //    //}

    //}

    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    //public struct D3D11_VIDEO_COLOR
    //{
    //    // C:/Program Files (x86)/Windows Kits/10/Include/10.0.18362.0/um/d3d11.h:10370
    //    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    //    public struct __Anonymous__0
    //    {

    //        [FieldOffset(0)] public D3D11_VIDEO_COLOR_YCbCrA YCbCr;

    //        [FieldOffset(0)] public D3D11_VIDEO_COLOR_RGBA RGBA;
    //    }
    //    public __Anonymous__0 __field__0;
    //}

    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11_VIDEO_COLOR
    {
        /// <summary>A D3D11_VIDEO_COLOR_YCbCrA structure that contains a YCbCr color value.</summary>
        [FieldOffset(0)]
        public D3D11_VIDEO_COLOR_YCbCrA YCbCr;

        /// <summary>A D3D11_VIDEO_COLOR_RGBA structure that contains an RGB color value.</summary>
        [FieldOffset(0)]
        public D3D11_VIDEO_COLOR_RGBA RGBA;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct D3D11_VIDEO_COLOR_YCbCrA
    {
        /// <summary>The Y luma value.</summary>
        public float Y;

        /// <summary>The Cb chroma value.</summary>
        public float Cb;

        /// <summary>The Cr chroma value.</summary>
        public float Cr;

        /// <summary>The alpha value. Values range from 0 (transparent) to 1 (opaque).</summary>
        public float A;
    }

    public enum D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE
    {
        D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE_UNDEFINED = 0,
        D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE_16_235 = 1,
        D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE_0_255 = 2
    }

    public enum D3D11_VIDEO_PROCESSOR_OUTPUT_RATE
    {
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL = 0,
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF = 1,
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM = 2
    }
    public enum D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
    {
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE = 0,
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_BACKGROUND = 1,
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_DESTINATION = 2,
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM = 3
    }

    public enum D3D11_VIDEO_PROCESSOR_STEREO_FORMAT
    {
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO = 0,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL = 1,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL = 2,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE = 3,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET = 4,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_ROW_INTERLEAVED = 5,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_COLUMN_INTERLEAVED = 6,
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_CHECKERBOARD = 7
    }

    public enum D3D11_VIDEO_PROCESSOR_FILTER
    {
        D3D11_VIDEO_PROCESSOR_FILTER_BRIGHTNESS = 0,
        D3D11_VIDEO_PROCESSOR_FILTER_CONTRAST = 1,
        D3D11_VIDEO_PROCESSOR_FILTER_HUE = 2,
        D3D11_VIDEO_PROCESSOR_FILTER_SATURATION = 3,
        D3D11_VIDEO_PROCESSOR_FILTER_NOISE_REDUCTION = 4,
        D3D11_VIDEO_PROCESSOR_FILTER_EDGE_ENHANCEMENT = 5,
        D3D11_VIDEO_PROCESSOR_FILTER_ANAMORPHIC_SCALING = 6,
        D3D11_VIDEO_PROCESSOR_FILTER_STEREO_ADJUSTMENT = 7
    }

    [ComImport]
    [Guid("A048285E-25A9-4527-BD93-D68B68C44254")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessorOutputView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc);
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC
    //{
    //    public D3D11_VPOV_DIMENSION ViewDimension;
    //    public D3D11_TEX2D_VPOV Texture2D;
    //    //    union 
    //    //    {
    //    //    D3D11_TEX2D_VPOV Texture2D;
    //    //    D3D11_TEX2D_ARRAY_VPOV Texture2DArray;
    //    //};
    //}

    public enum D3D11_VPOV_DIMENSION
    {
        D3D11_VPOV_DIMENSION_UNKNOWN = 0,
        D3D11_VPOV_DIMENSION_TEXTURE2D = 1,
        D3D11_VPOV_DIMENSION_TEXTURE2DARRAY = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEX2D_VPOV
    {
        public uint MipSlice;
    }

    public enum D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE
    {
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_NONE = 0,
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME0 = 1,
        D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME1 = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_STREAM
    {
        public bool Enable;
        public uint OutputIndex;
        public uint InputFrameOrField;
        public uint PastFrames;
        public uint FutureFrames;
        public IntPtr /*ID3D11VideoProcessorInputView*/ ppPastSurfaces;
        public ID3D11VideoProcessorInputView pInputSurface;
        public IntPtr /*ID3D11VideoProcessorInputView*/ ppFutureSurfaces;
        public IntPtr /*ID3D11VideoProcessorInputView*/ ppPastSurfacesRight;
        public IntPtr /*ID3D11VideoProcessorInputView*/ pInputSurfaceRight;
        public IntPtr /*ID3D11VideoProcessorInputView*/ ppFutureSurfacesRight;
    }

    [ComImport]
    [Guid("11EC5A5F-51DC-4945-AB34-6E8C21300EA5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessorInputView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        [PreserveSig]
        void GetDesc(out D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc);
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC
    //{
    //    public uint  FourCC;
    //    public D3D11_VPIV_DIMENSION ViewDimension;
    ////    union 
    ////    {
    ////    D3D11_TEX2D_VPIV Texture2D;
    ////};
    //}

    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC
    {
        [FieldOffset(0)]
        public D3D11_VPOV_DIMENSION ViewDimension;

        // Union starts at offset 4
        [FieldOffset(4)]
        public D3D11_TEX2D_VPOV Texture2D;

        [FieldOffset(4)]
        public D3D11_TEX2D_ARRAY_VPOV Texture2DArray;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC
    {
        [FieldOffset(0)]
        public uint FourCC;  // Matches `UINT FourCC`

        [FieldOffset(4)]
        public D3D11_VPIV_DIMENSION ViewDimension;

        [FieldOffset(8)]  // Union starts after FourCC and ViewDimension
        public D3D11_TEX2D_VPIV Texture2D;
    } 

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEX2D_VPIV
    {
        public uint MipSlice;
        public uint ArraySlice;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_TEX2D_ARRAY_VPOV
    {
        public uint MipSlice;
        public uint FirstArraySlice;
        public uint ArraySize;
    }

    public enum D3D11_VPIV_DIMENSION
    {
        D3D11_VPIV_DIMENSION_UNKNOWN = 0,
        D3D11_VPIV_DIMENSION_TEXTURE2D = 1
    }

    [ComImport]
    [Guid("9B32F9AD-BDCC-40a6-A39D-D5C865845720")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11CryptoSession : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        void GetCryptoType(out Guid pCryptoType);
        [PreserveSig]
        void GetDecoderProfile(out Guid pDecoderProfile);
        [PreserveSig]
        HRESULT GetCertificateSize(out uint pCertificateSize);
        [PreserveSig]
        HRESULT GetCertificate(uint CertificateSize, out IntPtr pCertificate);
        [PreserveSig]
        void GetCryptoSessionHandle(out IntPtr pCryptoSessionHandle);
    }

    [ComImport]
    [Guid("3015A308-DCBD-47aa-A747-192486D14D4A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11AuthenticatedChannel : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        HRESULT GetCertificateSize(out uint pCertificateSize);
        [PreserveSig]
        HRESULT GetCertificate(uint CertificateSize, out IntPtr pCertificate);
        [PreserveSig]
        void GetChannelHandle(out IntPtr pChannelHandle);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_AUTHENTICATED_CONFIGURE_OUTPUT
    {
        public D3D11_OMAC omac;
        public Guid ConfigureType;
        public IntPtr hChannel;
        public uint SequenceNumber;
        public HRESULT ReturnCode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_OMAC
    {
        [MarshalAs(UnmanagedType.U8, SizeConst = 16)]
        byte Omac;
    }

    public enum D3D11_VIDEO_PROCESSOR_ROTATION
    {
        D3D11_VIDEO_PROCESSOR_ROTATION_IDENTITY = 0,
        D3D11_VIDEO_PROCESSOR_ROTATION_90 = 1,
        D3D11_VIDEO_PROCESSOR_ROTATION_180 = 2,
        D3D11_VIDEO_PROCESSOR_ROTATION_270 = 3
    }

    [ComImport]
    [Guid("10EC4D5B-975A-4689-B9E4-D0AAC30FE333")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoDevice
    {
        [PreserveSig]
        HRESULT CreateVideoDecoder(D3D11_VIDEO_DECODER_DESC pVideoDesc, D3D11_VIDEO_DECODER_CONFIG pConfig, out ID3D11VideoDecoder ppDecoder);
        [PreserveSig]
        HRESULT CreateVideoProcessor(ID3D11VideoProcessorEnumerator pEnum, uint RateConversionIndex, out ID3D11VideoProcessor ppVideoProcessor);
        [PreserveSig]
        HRESULT CreateAuthenticatedChannel(D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, out ID3D11AuthenticatedChannel ppAuthenticatedChannel);
        [PreserveSig]
        HRESULT CreateCryptoSession(ref Guid pCryptoType, ref Guid pDecoderProfile, ref Guid pKeyExchangeType, out ID3D11CryptoSession ppCryptoSession);
        [PreserveSig]
        HRESULT CreateVideoDecoderOutputView(ID3D11Resource pResource, D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoDecoderOutputView ppVDOVView);
        [PreserveSig]
        HRESULT CreateVideoProcessorInputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, ref D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorInputView ppVPIView);
        [PreserveSig]
        HRESULT CreateVideoProcessorOutputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, ref D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorOutputView ppVPOView);
        [PreserveSig]
        HRESULT CreateVideoProcessorEnumerator(ref D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, out ID3D11VideoProcessorEnumerator ppEnum);
        [PreserveSig]
        uint GetVideoDecoderProfileCount();
        [PreserveSig]
        HRESULT GetVideoDecoderProfile(uint Index, out Guid pDecoderProfile);
        [PreserveSig]
        HRESULT CheckVideoDecoderFormat(ref Guid pDecoderProfile, DXGI_FORMAT Format, out bool pSupported);
        [PreserveSig]
        HRESULT GetVideoDecoderConfigCount(D3D11_VIDEO_DECODER_DESC pDesc, out uint pCount);
        [PreserveSig]
        HRESULT GetVideoDecoderConfig(D3D11_VIDEO_DECODER_DESC pDesc, uint Index, out D3D11_VIDEO_DECODER_CONFIG pConfig);
        [PreserveSig]
        HRESULT GetContentProtectionCaps(ref Guid pCryptoType, ref Guid pDecoderProfile, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps);
        [PreserveSig]
        HRESULT CheckCryptoKeyExchange(ref Guid pCryptoType, ref Guid pDecoderProfile, uint Index, out Guid pKeyExchangeType);
        [PreserveSig]
        HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
    }

    public enum D3D11_AUTHENTICATED_CHANNEL_TYPE
    {
        D3D11_AUTHENTICATED_CHANNEL_D3D11 = 1,
        D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE = 2,
        D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_CONTENT_PROTECTION_CAPS
    {
        public uint Caps;
        public uint KeyExchangeTypeCount;
        public uint BlockAlignmentSize;
        public long ProtectedMemorySize;
    }

    [ComImport]
    [Guid("31627037-53AB-4200-9061-05FAA9AB45F9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessorEnumerator : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        [PreserveSig]
        new void GetDevice(out ID3D11Device ppDevice);
        [PreserveSig]
        new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);
        #endregion

        [PreserveSig]
        HRESULT GetVideoProcessorContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pContentDesc);
        [PreserveSig]
        HRESULT CheckVideoProcessorFormat(DXGI_FORMAT Format, out uint pFlags);
        [PreserveSig]
        HRESULT GetVideoProcessorCaps(out D3D11_VIDEO_PROCESSOR_CAPS pCaps);
        [PreserveSig]
        HRESULT GetVideoProcessorRateConversionCaps(uint TypeIndex, out D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS pCaps);
        [PreserveSig]
        HRESULT GetVideoProcessorCustomRate(uint TypeIndex, uint CustomRateIndex, out D3D11_VIDEO_PROCESSOR_CUSTOM_RATE pRate);
        [PreserveSig]
        HRESULT GetVideoProcessorFilterRange(D3D11_VIDEO_PROCESSOR_FILTER Filter, out D3D11_VIDEO_PROCESSOR_FILTER_RANGE pRange);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_CAPS
    {
        public uint DeviceCaps;
        public uint FeatureCaps;
        public uint FilterCaps;
        public uint InputFormatCaps;
        public uint AutoStreamCaps;
        public uint StereoCaps;
        public uint RateConversionCapsCount;
        public uint MaxInputStreams;
        public uint MaxStreamStates;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_CUSTOM_RATE
    {
        public DXGI_RATIONAL CustomRate;
        public uint OutputFrames;
        public bool InputInterlaced;
        public uint InputFramesOrFields;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_FILTER_RANGE
    {
        public int Minimum;
        public int Maximum;
        public int Default;
        public float Multiplier;
    }

    [ComImport]
    [Guid("a04bfb29-08ef-43d6-a49c-a9bdbdcbe686")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Device1 : ID3D11Device
    {
        #region <ID3D11Device>
        [PreserveSig]
        new HRESULT CreateBuffer(ref D3D11_BUFFER_DESC pDesc, IntPtr pInitialData, out ID3D11Buffer ppBuffer);
        [PreserveSig]
        new HRESULT CreateTexture1D(ref D3D11_TEXTURE1D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture1D ppTexture1D);
        [PreserveSig]
        new HRESULT CreateTexture2D(ref D3D11_TEXTURE2D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture2D ppTexture2D);
        [PreserveSig]
        new HRESULT CreateTexture3D(ref D3D11_TEXTURE3D_DESC pDesc, IntPtr pInitialData, out ID3D11Texture3D ppTexture3D);
        [PreserveSig]
        new HRESULT CreateShaderResourceView(ID3D11Resource pResource, D3D11_SHADER_RESOURCE_VIEW_DESC pDesc, out ID3D11ShaderResourceView ppSRView);
        [PreserveSig]
        new HRESULT CreateUnorderedAccessView(ID3D11Resource pResource, D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc, out ID3D11UnorderedAccessView ppUAView);
        //new HRESULT CreateRenderTargetView(ID3D11Resource pResource, D3D11_RENDER_TARGET_VIEW_DESC pDesc, out ID3D11RenderTargetView ppRTView);
        [PreserveSig]
        new HRESULT CreateRenderTargetView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11RenderTargetView ppRTView);
        [PreserveSig]
        new HRESULT CreateDepthStencilView(ID3D11Resource pResource, D3D11_DEPTH_STENCIL_VIEW_DESC pDesc, out ID3D11DepthStencilView ppDepthStencilView);
        [PreserveSig]
        new HRESULT CreateInputLayout(ref D3D11_INPUT_ELEMENT_DESC pInputElementDescs, uint NumElements, IntPtr pShaderBytecodeWithInputSignature, uint BytecodeLength, out ID3D11InputLayout ppInputLayout);
        [PreserveSig]
        new HRESULT CreateVertexShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11VertexShader ppVertexShader);
        [PreserveSig]
        new HRESULT CreateGeometryShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);
        [PreserveSig]
        new HRESULT CreateGeometryShaderWithStreamOutput(ID3D11Resource pResource, D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc, out ID3D11UnorderedAccessView ppUAView);
        [PreserveSig]
        new HRESULT CreatePixelShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11PixelShader ppPixelShader);
        [PreserveSig]
        new HRESULT CreateHullShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11HullShader ppHullShader);
        [PreserveSig]
        new HRESULT CreateDomainShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11DomainShader ppDomainShader);
        [PreserveSig]
        new HRESULT CreateComputeShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11ComputeShader ppComputeShader);
        [PreserveSig]
        new HRESULT CreateClassLinkage(out ID3D11ClassLinkage ppLinkage);
        [PreserveSig]
        new HRESULT CreateBlendState(ref D3D11_BLEND_DESC pBlendStateDesc, out ID3D11BlendState ppBlendState);
        [PreserveSig]
        new HRESULT CreateDepthStencilState(ref D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, out ID3D11DepthStencilState ppDepthStencilState);
        [PreserveSig]
        new HRESULT CreateRasterizerState(ref D3D11_RASTERIZER_DESC pRasterizerDesc, out ID3D11RasterizerState ppRasterizerState);
        [PreserveSig]
        new HRESULT CreateSamplerState(ref D3D11_SAMPLER_DESC pSamplerDesc, out ID3D11SamplerState ppSamplerState);
        [PreserveSig]
        new HRESULT CreateQuery(ref D3D11_QUERY_DESC pQueryDesc, out ID3D11Query ppQuery);
        [PreserveSig]
        new HRESULT CreatePredicate(ref D3D11_QUERY_DESC pPredicateDesc, out ID3D11Predicate ppPredicate);
        [PreserveSig]
        new HRESULT CreateCounter(ref D3D11_COUNTER_DESC pCounterDesc, out ID3D11Counter ppCounter);
        [PreserveSig]
        new HRESULT CreateDeferredContext(uint ContextFlags, out ID3D11DeviceContext ppDeferredContext);
        [PreserveSig]
        new HRESULT OpenSharedResource(IntPtr hResource, ref Guid ReturnedInterface, out IntPtr ppResource);
        [PreserveSig]
        new HRESULT CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);
        [PreserveSig]
        new HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);
        [PreserveSig]
        new void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);
        [PreserveSig]
        new HRESULT CheckCounter(ref D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters,
                    out string szName, ref uint pNameLength, out string szUnits, ref uint pUnitsLength,
                           out string szDescription, ref uint pDescriptionLength);
        [PreserveSig]
        new HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, out IntPtr pFeatureSupportData, uint FeatureSupportDataSize);
        [PreserveSig]
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        [PreserveSig]
        new D3D_FEATURE_LEVEL GetFeatureLevel();
        [PreserveSig]
        new uint GetCreationFlags();
        [PreserveSig]
        new HRESULT GetDeviceRemovedReason();
        [PreserveSig]
        new void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);
        [PreserveSig]
        new HRESULT SetExceptionMode(uint RaiseFlags);
        [PreserveSig]
        new uint GetExceptionMode();
        #endregion

        //void GetImmediateContext1(out ID3D11DeviceContext1 ppImmediateContext);
        [PreserveSig]
        void GetImmediateContext1(out IntPtr ppImmediateContext);
        //HRESULT CreateDeferredContext1(uint ContextFlags, out ID3D11DeviceContext1 ppDeferredContext);
        [PreserveSig]
        HRESULT CreateDeferredContext1(uint ContextFlags, out IntPtr ppDeferredContext);
        //HRESULT CreateBlendState1(ref D3D11_BLEND_DESC1 pBlendStateDesc, out ID3D11BlendState1 ppBlendState);
        [PreserveSig]
        HRESULT CreateBlendState1(ref D3D11_BLEND_DESC1 pBlendStateDesc, out IntPtr ppBlendState);
        //HRESULT CreateRasterizerState1(ref D3D11_RASTERIZER_DESC1 pRasterizerDesc, out ID3D11RasterizerState1 ppRasterizerState);
        [PreserveSig]
        HRESULT CreateRasterizerState1(ref D3D11_RASTERIZER_DESC1 pRasterizerDesc, out IntPtr ppRasterizerState);
        //HRESULT CreateDeviceContextState(uint Flags, D3D_FEATURE_LEVEL pFeatureLevels, uint FeatureLevels,
        //   uint SDKVersion, ref Guid EmulatedInterface, out D3D_FEATURE_LEVEL pChosenFeatureLevel, out ID3DDeviceContextState ppContextState);
        [PreserveSig]
        HRESULT CreateDeviceContextState(uint Flags, D3D_FEATURE_LEVEL pFeatureLevels, uint FeatureLevels,
            uint SDKVersion, ref Guid EmulatedInterface, out D3D_FEATURE_LEVEL pChosenFeatureLevel, out IntPtr ppContextState);
        [PreserveSig]
        HRESULT OpenSharedResource1(IntPtr hResource, ref Guid returnedInterface, out IntPtr ppResource);
        [PreserveSig]
        HRESULT OpenSharedResourceByName(string lpName, uint dwDesiredAccess, ref Guid returnedInterface, out IntPtr ppResource);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_BLEND_DESC1
    {
        public bool AlphaToCoverageEnable;
        public bool IndependentBlendEnable;
        [MarshalAs(UnmanagedType.LPStruct, SizeConst = 8)]
        public D3D11_RENDER_TARGET_BLEND_DESC1 RenderTarget;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_RENDER_TARGET_BLEND_DESC1
    {
        public bool BlendEnable;
        public bool LogicOpEnable;
        public D3D11_BLEND SrcBlend;
        public D3D11_BLEND DestBlend;
        public D3D11_BLEND_OP BlendOp;
        public D3D11_BLEND SrcBlendAlpha;
        public D3D11_BLEND DestBlendAlpha;
        public D3D11_BLEND_OP BlendOpAlpha;
        public D3D11_LOGIC_OP LogicOp;
        public byte RenderTargetWriteMask;
    }

    public enum D3D11_LOGIC_OP
    {
        D3D11_LOGIC_OP_CLEAR = 0,
        D3D11_LOGIC_OP_SET = (D3D11_LOGIC_OP_CLEAR + 1),
        D3D11_LOGIC_OP_COPY = (D3D11_LOGIC_OP_SET + 1),
        D3D11_LOGIC_OP_COPY_INVERTED = (D3D11_LOGIC_OP_COPY + 1),
        D3D11_LOGIC_OP_NOOP = (D3D11_LOGIC_OP_COPY_INVERTED + 1),
        D3D11_LOGIC_OP_INVERT = (D3D11_LOGIC_OP_NOOP + 1),
        D3D11_LOGIC_OP_AND = (D3D11_LOGIC_OP_INVERT + 1),
        D3D11_LOGIC_OP_NAND = (D3D11_LOGIC_OP_AND + 1),
        D3D11_LOGIC_OP_OR = (D3D11_LOGIC_OP_NAND + 1),
        D3D11_LOGIC_OP_NOR = (D3D11_LOGIC_OP_OR + 1),
        D3D11_LOGIC_OP_XOR = (D3D11_LOGIC_OP_NOR + 1),
        D3D11_LOGIC_OP_EQUIV = (D3D11_LOGIC_OP_XOR + 1),
        D3D11_LOGIC_OP_AND_REVERSE = (D3D11_LOGIC_OP_EQUIV + 1),
        D3D11_LOGIC_OP_AND_INVERTED = (D3D11_LOGIC_OP_AND_REVERSE + 1),
        D3D11_LOGIC_OP_OR_REVERSE = (D3D11_LOGIC_OP_AND_INVERTED + 1),
        D3D11_LOGIC_OP_OR_INVERTED = (D3D11_LOGIC_OP_OR_REVERSE + 1)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_RASTERIZER_DESC1
    {
        public D3D11_FILL_MODE FillMode;
        public D3D11_CULL_MODE CullMode;
        public bool FrontCounterClockwise;
        public int DepthBias;
        public float DepthBiasClamp;
        public float SlopeScaledDepthBias;
        public bool DepthClipEnable;
        public bool ScissorEnable;
        public bool MultisampleEnable;
        public bool AntialiasedLineEnable;
        public uint ForcedSampleCount;
    }

    public enum D3D11_FORMAT_SUPPORT
    {
        D3D11_FORMAT_SUPPORT_BUFFER = 0x1,
        D3D11_FORMAT_SUPPORT_IA_VERTEX_BUFFER = 0x2,
        D3D11_FORMAT_SUPPORT_IA_INDEX_BUFFER = 0x4,
        D3D11_FORMAT_SUPPORT_SO_BUFFER = 0x8,
        D3D11_FORMAT_SUPPORT_TEXTURE1D = 0x10,
        D3D11_FORMAT_SUPPORT_TEXTURE2D = 0x20,
        D3D11_FORMAT_SUPPORT_TEXTURE3D = 0x40,
        D3D11_FORMAT_SUPPORT_TEXTURECUBE = 0x80,
        D3D11_FORMAT_SUPPORT_SHADER_LOAD = 0x100,
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE = 0x200,
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_COMPARISON = 0x400,
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_MONO_TEXT = 0x800,
        D3D11_FORMAT_SUPPORT_MIP = 0x1000,
        D3D11_FORMAT_SUPPORT_MIP_AUTOGEN = 0x2000,
        D3D11_FORMAT_SUPPORT_RENDER_TARGET = 0x4000,
        D3D11_FORMAT_SUPPORT_BLENDABLE = 0x8000,
        D3D11_FORMAT_SUPPORT_DEPTH_STENCIL = 0x10000,
        D3D11_FORMAT_SUPPORT_CPU_LOCKABLE = 0x20000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE = 0x40000,
        D3D11_FORMAT_SUPPORT_DISPLAY = 0x80000,
        D3D11_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT = 0x100000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET = 0x200000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_LOAD = 0x400000,
        D3D11_FORMAT_SUPPORT_SHADER_GATHER = 0x800000,
        D3D11_FORMAT_SUPPORT_BACK_BUFFER_CAST = 0x1000000,
        D3D11_FORMAT_SUPPORT_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,
        D3D11_FORMAT_SUPPORT_SHADER_GATHER_COMPARISON = 0x4000000,
        D3D11_FORMAT_SUPPORT_DECODER_OUTPUT = 0x8000000,
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_OUTPUT = 0x10000000,
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_INPUT = 0x20000000,
        D3D11_FORMAT_SUPPORT_VIDEO_ENCODER = 0x40000000
    }

    public enum D3D11_FORMAT_SUPPORT2
    {
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1,
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4,
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10,
        D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,
        D3D11_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40,
        D3D11_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,
        D3D11_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100,
        D3D11_FORMAT_SUPPORT2_TILED = 0x200,
        D3D11_FORMAT_SUPPORT2_SHAREABLE = 0x400,
        D3D11_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY = 0x4000,
        D3D11_FORMAT_SUPPORT2_DISPLAYABLE = 0x10000
    }

    public enum D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT
    {
        D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_INPUT = 0x1,
        D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_OUTPUT = 0x2
    }

    public enum D3D11_VIDEO_PROCESSOR_DEVICE_CAPS
    {
        D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_LINEAR_SPACE = 0x1,
        D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_xvYCC = 0x2,
        D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_RGB_RANGE_CONVERSION = 0x4,
        D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_YCbCr_MATRIX_CONVERSION = 0x8,
        D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_NOMINAL_RANGE = 0x10
    }

    public enum D3D11_VIDEO_PROCESSOR_FEATURE_CAPS
    {
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL = 0x1,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION = 0x2,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY = 0x4,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE = 0x8,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LEGACY = 0x10,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO = 0x20,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION = 0x40,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_STREAM = 0x80,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO = 0x100,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_MIRROR = 0x200,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_SHADER_USAGE = 0x400,
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_METADATA_HDR10 = 0x800
    }

    public enum D3D11_VIDEO_PROCESSOR_FILTER_CAPS
    {
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_BRIGHTNESS = 0x1,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_CONTRAST = 0x2,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_HUE = 0x4,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_SATURATION = 0x8,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_NOISE_REDUCTION = 0x10,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_EDGE_ENHANCEMENT = 0x20,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_ANAMORPHIC_SCALING = 0x40,
        D3D11_VIDEO_PROCESSOR_FILTER_CAPS_STEREO_ADJUSTMENT = 0x80
    }

    public enum D3D11_VIDEO_PROCESSOR_FORMAT_CAPS
    {
        D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_INTERLACED = 0x1,
        D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_PROCAMP = 0x2,
        D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY = 0x4,
        D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_PALETTE_INTERLACED = 0x8
    }

    public enum D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS
    {
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DENOISE = 0x1,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DERINGING = 0x2,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_EDGE_ENHANCEMENT = 0x4,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_COLOR_CORRECTION = 0x8,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_FLESH_TONE_MAPPING = 0x10,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_IMAGE_STABILIZATION = 0x20,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_SUPER_RESOLUTION = 0x40,
        D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_ANAMORPHIC_SCALING = 0x80
    }

    public enum D3D11_VIDEO_PROCESSOR_STEREO_CAPS
    {
        D3D11_VIDEO_PROCESSOR_STEREO_CAPS_MONO_OFFSET = 0x1,
        D3D11_VIDEO_PROCESSOR_STEREO_CAPS_ROW_INTERLEAVED = 0x2,
        D3D11_VIDEO_PROCESSOR_STEREO_CAPS_COLUMN_INTERLEAVED = 0x4,
        D3D11_VIDEO_PROCESSOR_STEREO_CAPS_CHECKERBOARD = 0x8,
        D3D11_VIDEO_PROCESSOR_STEREO_CAPS_FLIP_MODE = 0x10
    }

    public enum D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS
    {
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_DEINTERLACE_BLEND = 0x1,
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_DEINTERLACE_BOB = 0x2,
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_DEINTERLACE_ADAPTIVE = 0x4,
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_DEINTERLACE_MOTION_COMPENSATION = 0x8,
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_INVERSE_TELECINE = 0x10,
        D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS_FRAME_RATE_CONVERSION = 0x20
    }

    public enum D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS
    {
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_32 = 0x1,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_22 = 0x2,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_2224 = 0x4,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_2332 = 0x8,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_32322 = 0x10,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_55 = 0x20,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_64 = 0x40,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_87 = 0x80,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_222222222223 = 0x100,
        D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS_OTHER = unchecked((int)0x80000000)
    }

    public enum D3D11_CONTENT_PROTECTION_CAPS
    {
        D3D11_CONTENT_PROTECTION_CAPS_SOFTWARE = 0x1,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE = 0x2,
        D3D11_CONTENT_PROTECTION_CAPS_PROTECTION_ALWAYS_ON = 0x4,
        D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION = 0x8,
        D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY = 0x10,
        D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY = 0x20,
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK = 0x40,
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY = 0x80,
        D3D11_CONTENT_PROTECTION_CAPS_SEQUENTIAL_CTR_IV = 0x100,
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPT_SLICEDATA_ONLY = 0x200,
        D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT = 0x400,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_PROTECT_UNCOMPRESSED = 0x800,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_PROTECTED_MEMORY_PAGEABLE = 0x1000,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_TEARDOWN = 0x2000,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_DRM_COMMUNICATION = 0x4000,
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_DRM_COMMUNICATION_MULTI_THREADED = 0x8000
    } 
}