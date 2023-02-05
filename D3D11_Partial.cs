using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using GlobalStructures;
using DXGI;
using static DXGI.DXGITools;

namespace D3D11
{
    [ComImport]
    [Guid("1841e5c8-16b0-489b-bcc8-44cfb0d5deae")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DeviceChild
    {
        void GetDevice(out ID3D11Device ppDevice);
        HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
    }

    [ComImport]
    [Guid("dc8e63f3-d12b-4952-b47b-5e45026a862d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Resource : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        void SetEvictionPriority(uint EvictionPriority);
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        new void SetEvictionPriority(uint EvictionPriority);
        new uint GetEvictionPriority();
        #endregion

        void GetDesc(out D3D11_BUFFER_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_BUFFER_DESC
    {
        public uint ByteWidth;
        public D3D11_USAGE Usage;
        public uint BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void GetResource(out ID3D11Resource ppResource);
    }

    [ComImport]
    [Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ShaderResourceView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetResource(out ID3D11Resource ppResource);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ClassInstance : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void GetClassLinkage(out ID3D11ClassLinkage ppLinkage);
        void GetDesc(out D3D11_CLASS_INSTANCE_DESC pDesc);
        void GetInstanceName(out System.Text.StringBuilder pInstanceName, ref uint pBufferLength);
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        HRESULT GetClassInstance(string pClassInstanceName, uint InstanceIndex, out ID3D11ClassInstance ppInstance);
        HRESULT CreateClassInstance(string pClassTypeName, uint ConstantBufferOffset, uint ConstantVectorOffset, uint TextureOffset, uint SamplerOffset, out ID3D11ClassInstance ppInstance);
    }

    [ComImport]
    [Guid("da6fea51-564c-4487-9810-f0d0f9b4e3a5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11SamplerState : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }   

    [ComImport]
    [Guid("e4819ddc-4cf0-4025-bd26-5de82a3e07b7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11InputLayout : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("38325b96-effb-4022-ba02-2e795b70275c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11GeometryShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("4b35d0cd-1e15-4258-9c98-1b1333f6dd3b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Asynchronous : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        uint GetDataSize();
    }

    [ComImport]
    [Guid("d6c00747-87b7-425e-b84d-44d108560afd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Query : ID3D11Asynchronous
    {
        #region ID3D11Asynchronous
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new uint GetDataSize();
        #endregion

        void GetDesc(out D3D11_QUERY_DESC pDesc);
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_QUERY_DESC
    {
        public D3D11_QUERY Query;
        public uint MiscFlags;
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion
        new uint GetDataSize();
        #endregion
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion
        new void GetResource(out ID3D11Resource ppResource);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("f582c508-0f36-490c-9977-31eece268cfa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11DomainShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion        
    }

    [ComImport]
    [Guid("4f5b196e-c2bd-495e-bd01-1fded38e4969")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11ComputeShader : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void VSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void PSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void PSSetShader(ID3D11PixelShader pPixelShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        void PSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        void VSSetShader(ID3D11VertexShader pVertexShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);
        void Draw(uint VertexCount, uint StartVertexLocation);
        HRESULT Map(ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);
        void Unmap(ID3D11Resource pResource, uint Subresource);
        void PSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void IASetInputLayout(ID3D11InputLayout pInputLayout);
        void IASetVertexBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppVertexBuffers, uint pStrides, uint pOffsets);
        void IASetIndexBuffer(ID3D11Buffer pIndexBuffer, DXGI_FORMAT Format, uint Offset);
        void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);
        void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);
        void GSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void GSSetShader(ID3D11GeometryShader pShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        //void IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY Topology);
        void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);
        void VSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void VSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        void Begin(ID3D11Asynchronous pAsync);
        void End(ID3D11Asynchronous pAsync);
        HRESULT GetData(ID3D11Asynchronous pAsync, out IntPtr pData, uint DataSize, uint GetDataFlags);
        void SetPredication(ID3D11Predicate pPredicate, bool PredicateValue);
        void GSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void GSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);

        //void OMSetRenderTargets(uint NumViews, IntPtr ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);
        void OMSetRenderTargets(uint NumViews, [In, Out, MarshalAs(UnmanagedType.LPArray)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);

        void OMSetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, ID3D11RenderTargetView ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView,
            uint UAVStartSlot, uint NumUAVs, ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        //   _In_opt_  const FLOAT BlendFactor[ 4 ],
        void OMSetBlendState(ID3D11BlendState pBlendState, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, uint SampleMask);
        void OMSetDepthStencilState(ID3D11DepthStencilState pDepthStencilState, uint StencilRef);
        void SOSetTargets(uint NumBuffers, ID3D11Buffer ppSOTargets, uint pOffsets);
        void DrawAuto();
        void DrawIndexedInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        void DrawInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);
        void DispatchIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        void RSSetState(ID3D11RasterizerState pRasterizerState);
        void RSSetViewports(uint NumViewports, [In, Out, MarshalAs(UnmanagedType.LPArray)] D3D11_VIEWPORT[] pViewports);
        ////void RSSetScissorRects(uint NumRects, D3D11_RECT pRects);
        void RSSetScissorRects(uint NumRects, ref RECT pRects);
        void CopySubresourceRegion(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, D3D11_BOX pSrcBox);
        void CopyResource(ID3D11Resource pDstResource, ID3D11Resource pSrcResource);
        void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, D3D11_BOX pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);
        void CopyStructureCount(ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ID3D11UnorderedAccessView pSrcView);
        // float ColorRGBA[ 4 ]
        //void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] ColorRGBA);
        void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] ColorRGBA);
        // uint Values[ 4 ]
        void ClearUnorderedAccessViewUint(ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] Values);
        // float Values[ 4 ]
        void ClearUnorderedAccessViewFloat(ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] Values);
        void ClearDepthStencilView(ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);
        void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);
        void SetResourceMinLOD(ID3D11Resource pResource, float MinLOD);
        float GetResourceMinLOD(ID3D11Resource pResource);
        void ResolveSubresource(ID3D11Resource pDstResource, uint DstSubresource, ID3D11Resource pSrcResource, uint SrcSubresource, DXGI_FORMAT Format);
        void ExecuteCommandList(ID3D11CommandList pCommandList, bool RestoreContextState);
        void HSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void HSSetShader(ID3D11HullShader pHullShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        void HSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        void HSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void DSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void DSSetShader(ID3D11DomainShader pDomainShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        void DSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        void DSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void CSSetShaderResources(uint StartSlot, uint NumViews, ID3D11ShaderResourceView ppShaderResourceViews);
        void CSSetUnorderedAccessViews(uint StartSlot, uint NumUAVs, ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        void CSSetShader(ID3D11ComputeShader pComputeShader, ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        void CSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        void CSSetConstantBuffers(uint StartSlot, uint NumBuffers, ID3D11Buffer ppConstantBuffers);
        void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void PSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void PSGetShader(out ID3D11PixelShader ppPixelShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        void PSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void VSGetShader(out ID3D11VertexShader ppVertexShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);
        void IAGetVertexBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppVertexBuffers, out uint pStrides, out uint pOffsets);
        void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);
        void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void GSGetShader(out ID3D11GeometryShader ppGeometryShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        //void IAGetPrimitiveTopology(out D3D11_PRIMITIVE_TOPOLOGY pTopology);
        void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);
        void VSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void VSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void GetPredication(out ID3D11Predicate ppPredicate, out bool pPredicateValue);
        void GSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void GSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void OMGetRenderTargets(uint NumViews, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);
        void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        
        //  float BlendFactor[ 4 ]
        //void OMGetBlendState(out ID3D11BlendState ppBlendState, out float[] BlendFactor, out uint pSampleMask);
        //void OMGetBlendState(out ID3D11BlendState ppBlendState, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] BlendFactor, out uint pSampleMask);
        void OMGetBlendState(out ID3D11BlendState ppBlendState, out IntPtr BlendFactor, out uint pSampleMask);

        void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, out uint pStencilRef);
        void SOGetTargets(uint NumBuffers, out ID3D11Buffer ppSOTargets);
        void RSGetState(out ID3D11RasterizerState ppRasterizerState);
        void RSGetViewports(ref uint pNumViewports, out D3D11_VIEWPORT pViewports);
        //void RSGetScissorRects(ref uint pNumRects, out D3D11_RECT pRects);
        void RSGetScissorRects(ref uint pNumRects, out RECT pRects);
        void HSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void HSGetShader(out ID3D11HullShader ppHullShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        void HSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void DSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void DSGetShader(out ID3D11DomainShader ppDomainShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        void DSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void CSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        void CSGetShader(out ID3D11ComputeShader ppComputeShader, out ID3D11ClassInstance ppClassInstances, ref uint pNumClassInstances);
        void CSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        void ClearState();
        void Flush();
        D3D11_DEVICE_CONTEXT_TYPE GetType();
        uint GetContextFlags();
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
        HRESULT CreatePixelShader(IntPtr pShaderBytecode, uint BytecodeLength,
             ID3D11ClassLinkage pClassLinkage, out ID3D11PixelShader ppPixelShader);
        [PreserveSig]
        HRESULT CreateHullShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11HullShader ppHullShader);
        [PreserveSig]
        HRESULT CreateDomainShader(IntPtr pShaderBytecode, uint BytecodeLength, ID3D11ClassLinkage pClassLinkage,
           out ID3D11DomainShader ppDomainShader);
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
        HRESULT OpenSharedResource(IntPtr hResource, ref Guid ReturnedInterface, out IntPtr ppResource);
        HRESULT CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);
        HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);
        void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);
        HRESULT CheckCounter(ref D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters,
                    out string szName, ref uint pNameLength, out string szUnits, ref uint pUnitsLength,
                           out string szDescription, ref uint pDescriptionLength);
        HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, out IntPtr pFeatureSupportData, uint FeatureSupportDataSize);
        HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        D3D_FEATURE_LEVEL GetFeatureLevel();
        uint GetCreationFlags();
        HRESULT GetDeviceRemovedReason();
        void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);
        HRESULT SetExceptionMode(uint RaiseFlags);
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
        public uint BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
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
        public uint BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
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
        public uint BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
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
        public uint MiscFlags;
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion
        
        new  uint GetDataSize();
        #endregion

        void GetDesc(out D3D11_COUNTER_DESC pDesc);
    }

    [ComImport]
    [Guid("f8fb5c27-c6b3-4f75-a4c8-439af2ef564c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture1D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        new void SetEvictionPriority(uint EvictionPriority);
        new uint GetEvictionPriority();
        #endregion

        void GetDesc(out D3D11_TEXTURE1D_DESC pDesc);
    }

    [ComImport]
    [Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture2D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        new void SetEvictionPriority(uint EvictionPriority);
        new uint GetEvictionPriority();
        #endregion

        void GetDesc(out D3D11_TEXTURE2D_DESC pDesc);
    }

    [ComImport]
    [Guid("037e866e-f56d-4357-a8af-9dabbe6e250e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11Texture3D : ID3D11Resource
    {
        #region ID3D11Resource
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);
        new void SetEvictionPriority(uint EvictionPriority);
        new uint GetEvictionPriority();
        #endregion

        void GetDesc(out D3D11_TEXTURE3D_DESC pDesc);
    }

    [ComImport]
    [Guid("61F21C45-3C0E-4a74-9CEA-67100D9AD5E4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoContext : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        HRESULT GetDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);
        HRESULT ReleaseDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);
        HRESULT DecoderBeginFrame(ID3D11VideoDecoder pDecoder, ID3D11VideoDecoderOutputView pView, uint ContentKeySize, IntPtr pContentKey);
        HRESULT DecoderEndFrame(ID3D11VideoDecoder pDecoder);
        HRESULT SubmitDecoderBuffers(ID3D11VideoDecoder pDecoder, uint NumBuffers, D3D11_VIDEO_DECODER_BUFFER_DESC pBufferDesc);
        /*APP_DEPRECATED_*/
        HRESULT DecoderExtension(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_EXTENSION pExtensionData);
        void VideoProcessorSetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, bool Enable, ref RECT pRect);
        void VideoProcessorSetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, bool YCbCr, D3D11_VIDEO_COLOR pColor);
        void VideoProcessorSetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        void VideoProcessorSetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);
        void VideoProcessorSetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, bool Enable, SIZE Size);
        void VideoProcessorSetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, bool Enable);
        /*APP_DEPRECATED_*/
        HRESULT VideoProcessorSetOutputExtension(ID3D11VideoProcessor pVideoProcessor, ref Guid pExtensionGuid, uint DataSize, IntPtr pData);
        void VideoProcessorGetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);
        void VideoProcessorGetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);
        void VideoProcessorGetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        void VideoProcessorGetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);
        void VideoProcessorGetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out SIZE pSize);
        void VideoProcessorGetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);
        /*APP_DEPRECATED_*/
        HRESULT VideoProcessorGetOutputExtension(ID3D11VideoProcessor pVideoProcessor, ref Guid pExtensionGuid, uint DataSize, out IntPtr pData);
        void VideoProcessorSetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);
        void VideoProcessorSetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        void VideoProcessorSetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, bool RepeatFrame, DXGI_RATIONAL pCustomRate);
        void VideoProcessorSetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, ref RECT pRect);
        void VideoProcessorSetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, ref RECT pRect);
        void VideoProcessorSetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);
        void VideoProcessorSetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, uint Count, uint pEntries);
        void VideoProcessorSetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, DXGI_RATIONAL pSourceAspectRatio, DXGI_RATIONAL pDestinationAspectRatio);
        void VideoProcessorSetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);
        void VideoProcessorSetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);
        void VideoProcessorSetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);
        void VideoProcessorSetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);
        /*APP_DEPRECATED_*/
        HRESULT VideoProcessorSetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, ref Guid pExtensionGuid, uint DataSize, IntPtr pData);
        void VideoProcessorGetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);
        void VideoProcessorGetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);
        void VideoProcessorGetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate, out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);
        void VideoProcessorGetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);
        void VideoProcessorGetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);
        void VideoProcessorGetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);
        void VideoProcessorGetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, uint Count, out uint pEntries);
        void VideoProcessorGetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);
        void VideoProcessorGetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);
        void VideoProcessorGetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0, out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);
        void VideoProcessorGetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);
        void VideoProcessorGetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);
        /*APP_DEPRECATED_*/
        HRESULT VideoProcessorGetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, ref Guid pExtensionGuid, uint DataSize, out IntPtr pData);
        HRESULT VideoProcessorBlt(ID3D11VideoProcessor pVideoProcessor, ID3D11VideoProcessorOutputView pView, uint OutputFrame, uint StreamCount, D3D11_VIDEO_PROCESSOR_STREAM pStreams);
        HRESULT NegotiateCryptoSessionKeyExchange(ID3D11CryptoSession pCryptoSession, uint DataSize, ref IntPtr pData);
        void EncryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, uint IVSize, ref IntPtr pIV);
        void DecryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, D3D11_ENCRYPTED_BLOCK_INFO pEncryptedBlockInfo, uint ContentKeySize, IntPtr pContentKey, uint IVSize, ref IntPtr pIV);
        void StartSessionKeyRefresh(ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, out IntPtr pRandomNumber);
        void FinishSessionKeyRefresh(ID3D11CryptoSession pCryptoSession);
        HRESULT GetEncryptionBltKey(ID3D11CryptoSession pCryptoSession, uint KeySize, out IntPtr pReadbackKey);
        HRESULT NegotiateAuthenticatedChannelKeyExchange(ID3D11AuthenticatedChannel pChannel, uint DataSize, ref IntPtr pData);
        HRESULT QueryAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, uint OutputSize, out IntPtr pOutput);
        HRESULT ConfigureAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);
        void VideoProcessorSetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);
        void VideoProcessorGetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);
    }

    [ComImport]
    [Guid("3C9C5B51-995D-48d1-9B8D-FA5CAEDED65C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoDecoder : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        HRESULT GetCreationParameters(out D3D11_VIDEO_DECODER_DESC pVideoDesc, out D3D11_VIDEO_DECODER_CONFIG pConfig);
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetResource(out ID3D11Resource ppResource);
        #endregion

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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void GetContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc);
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

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_COLOR_SPACE
    {
        //public uint Usage  : 1;
        //public uint RGB_Range  : 1;
        //public uint YCbCr_Matrix   : 1;
        //public uint YCbCr_xvYCC    : 1;
        //public uint Nominal_Range  : 2;
        //public uint Reserved	: 26;
        public uint Usage;
        public uint RGB_Range;
        public uint YCbCr_Matrix;
        public uint YCbCr_xvYCC;
        public uint Nominal_Range;
        public uint Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_COLOR
    {
        public D3D11_VIDEO_COLOR_RGBA RGBA;
        //    union 
        //    {
        //    D3D11_VIDEO_COLOR_YCbCrA YCbCr;
        //    D3D11_VIDEO_COLOR_RGBA RGBA;
        //};
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

    [ComImport]
    [Guid("A048285E-25A9-4527-BD93-D68B68C44254")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessorOutputView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        void GetDesc(out D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC
    {
        public D3D11_VPOV_DIMENSION ViewDimension;
        public D3D11_TEX2D_VPOV Texture2D;
        //    union 
        //    {
        //    D3D11_TEX2D_VPOV Texture2D;
        //    D3D11_TEX2D_ARRAY_VPOV Texture2DArray;
        //};
    }

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
        public IntPtr /*ID3D11VideoProcessorInputView***/ ppPastSurfaces;
        public ID3D11VideoProcessorInputView pInputSurface;
        public IntPtr /*ID3D11VideoProcessorInputView***/ ppFutureSurfaces;
        public IntPtr /*ID3D11VideoProcessorInputView***/ ppPastSurfacesRight;
        public ID3D11VideoProcessorInputView pInputSurfaceRight;
        public IntPtr /*ID3D11VideoProcessorInputView***/ ppFutureSurfacesRight;
    }

    [ComImport]
    [Guid("11EC5A5F-51DC-4945-AB34-6E8C21300EA5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11VideoProcessorInputView : ID3D11View
    {
        #region ID3D11View
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        new void GetResource(out ID3D11Resource ppResource);
        #endregion

        void GetDesc(out D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC
    {
        public uint  FourCC;
        public D3D11_VPIV_DIMENSION ViewDimension;
    //    union 
    //    {
    //    D3D11_TEX2D_VPIV Texture2D;
    //};
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        void GetCryptoType(out Guid pCryptoType);
        void GetDecoderProfile(out Guid pDecoderProfile);
        HRESULT GetCertificateSize(out uint pCertificateSize);
        HRESULT GetCertificate(uint CertificateSize, out IntPtr pCertificate);
        void GetCryptoSessionHandle(out IntPtr pCryptoSessionHandle);
    }

    [ComImport]
    [Guid("3015A308-DCBD-47aa-A747-192486D14D4A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ID3D11AuthenticatedChannel : ID3D11DeviceChild
    {
        #region ID3D11DeviceChild
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        HRESULT GetCertificateSize(out uint pCertificateSize);
        HRESULT GetCertificate(uint CertificateSize, out IntPtr pCertificate);
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
        HRESULT CreateVideoDecoder(D3D11_VIDEO_DECODER_DESC pVideoDesc, D3D11_VIDEO_DECODER_CONFIG pConfig, out ID3D11VideoDecoder ppDecoder);
        [PreserveSig]
        HRESULT CreateVideoProcessor(ID3D11VideoProcessorEnumerator pEnum, uint RateConversionIndex, out ID3D11VideoProcessor ppVideoProcessor);
        HRESULT CreateAuthenticatedChannel(D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, out ID3D11AuthenticatedChannel ppAuthenticatedChannel);
        HRESULT CreateCryptoSession(ref Guid pCryptoType, ref Guid pDecoderProfile, ref Guid pKeyExchangeType, out ID3D11CryptoSession ppCryptoSession);
        HRESULT CreateVideoDecoderOutputView(ID3D11Resource pResource, D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoDecoderOutputView ppVDOVView);
        HRESULT CreateVideoProcessorInputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorInputView ppVPIView);
        HRESULT CreateVideoProcessorOutputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorOutputView ppVPOView);
        [PreserveSig]
        HRESULT CreateVideoProcessorEnumerator(ref D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, out ID3D11VideoProcessorEnumerator ppEnum);
        [PreserveSig]
        uint GetVideoDecoderProfileCount();
        HRESULT GetVideoDecoderProfile(uint Index, out Guid pDecoderProfile);
        HRESULT CheckVideoDecoderFormat(ref Guid pDecoderProfile, DXGI_FORMAT Format, out bool pSupported);
        HRESULT GetVideoDecoderConfigCount(D3D11_VIDEO_DECODER_DESC pDesc, out uint pCount);
        HRESULT GetVideoDecoderConfig(D3D11_VIDEO_DECODER_DESC pDesc, uint Index, out D3D11_VIDEO_DECODER_CONFIG pConfig);
        HRESULT GetContentProtectionCaps(ref Guid pCryptoType, ref Guid pDecoderProfile, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps);
        HRESULT CheckCryptoKeyExchange(ref Guid pCryptoType, ref Guid pDecoderProfile, uint Index, out Guid pKeyExchangeType);
        HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
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
        new void GetDevice(out ID3D11Device ppDevice);
        new HRESULT GetPrivateData(ref Guid guid, ref uint pDataSize, out IntPtr pData);
        new HRESULT SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        new HRESULT SetPrivateDataInterface(ref Guid guid, IntPtr pData);
        #endregion

        HRESULT GetVideoProcessorContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pContentDesc);
        HRESULT CheckVideoProcessorFormat(DXGI_FORMAT Format, out uint pFlags);
        HRESULT GetVideoProcessorCaps(out D3D11_VIDEO_PROCESSOR_CAPS pCaps);
        HRESULT GetVideoProcessorRateConversionCaps(uint TypeIndex, out D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS pCaps);
        HRESULT GetVideoProcessorCustomRate(uint TypeIndex, uint CustomRateIndex, out D3D11_VIDEO_PROCESSOR_CUSTOM_RATE pRate);
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
        D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000
    }
}