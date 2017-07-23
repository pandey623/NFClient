//-----------------------------------------------------------------------
// <copyright file="NFCProperty.cs">
//     Copyright (C) 2015-2015 lvsheng.huang <https://github.com/ketoo/NFrame>
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace NFrame
{
    public class NFCProperty : NFIProperty
    {
        public NFCProperty( NFGUID self, string strPropertyName, NFDataList varData)
        {
            mSelf = self;
            msPropertyName = strPropertyName;
            mxData = new NFDataList.TData(varData.GetType(0));

            switch (varData.GetType(0))
            {
                case NFDataList.VARIANT_TYPE.VTYPE_INT:
                    mxData.Set(varData.IntVal(0));
                    break;
                case NFDataList.VARIANT_TYPE.VTYPE_FLOAT:
                    mxData.Set(varData.FloatVal(0));
                    break;
                case NFDataList.VARIANT_TYPE.VTYPE_OBJECT:
                    mxData.Set(varData.ObjectVal(0));
                    break;
                case NFDataList.VARIANT_TYPE.VTYPE_STRING:
                    mxData.Set(varData.StringVal(0));
                    break;
                case NFDataList.VARIANT_TYPE.VTYPE_VECTOR2:
                    mxData.Set(varData.Vector2Val(0));
                    break;
                case NFDataList.VARIANT_TYPE.VTYPE_VECTOR3:
                    mxData.Set(varData.Vector3Val(0));
                    break;
                default:
                    break;
            }
        }

        public NFCProperty(NFGUID self, string strPropertyName, NFDataList.TData varData)
        {
            mSelf = self;
            msPropertyName = strPropertyName;
            mxData = new NFDataList.TData(varData);
        }

        public override string GetKey()
        {
            return msPropertyName;
        }
		
		public override NFDataList.VARIANT_TYPE GetType()
		{
            return mxData.GetType();
		}

        public override NFDataList.TData GetData()
        {
            return mxData;
        }

        public override void SetUpload(bool upload)
        {
            mbUpload = upload;
        }

        public override bool GetUpload()
        {
            return mbUpload;
        }

        public override Int64 QueryInt()
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_INT == mxData.GetType())
            {
                return mxData.IntVal();
            }

            return NFDataList.NULL_INT;
        }

        public override double QueryFloat()
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_FLOAT == mxData.GetType())
            {
                return (double)mxData.FloatVal();
            }

            return NFDataList.NULL_DOUBLE;
        }

        public override string QueryString()
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_STRING == mxData.GetType())
            {
                return mxData.StringVal();
            }

            return NFDataList.NULL_STRING;
        }

        public override NFGUID QueryObject()
        {
			if (NFDataList.VARIANT_TYPE.VTYPE_OBJECT == mxData.GetType())
            {
                return (NFGUID)mxData.ObjectVal();
            }

            return NFDataList.NULL_OBJECT;
        }

        public override NFVector2 QueryVector2()
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_VECTOR2 == mxData.GetType())
            {
                return (NFVector2)mxData.Vector2Val();
            }

            return NFDataList.NULL_VECTOR2;
        }

        public override NFVector3 QueryVector3()
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_VECTOR3 == mxData.GetType())
            {
                return (NFVector3)mxData.Vector3Val();
            }

            return NFDataList.NULL_VECTOR3;
        }

        public override bool SetInt(Int64 value)
		{
            if (mxData.IntVal() != value)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_INT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
				
			}

			return true;
		}

		public override bool SetFloat(double value)
		{
            if (mxData.FloatVal() - value > NFDataList.EPS_DOUBLE
                || mxData.FloatVal() - value < -NFDataList.EPS_DOUBLE)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_FLOAT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
			}

			return true;
		}

		public override bool SetString(string value)
		{
            if (mxData.StringVal() != value)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_STRING);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

			return true;
		}

		public override bool SetObject(NFGUID value)
		{
            if (mxData.ObjectVal() != value)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_OBJECT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

			return true;
		}

        public override bool SetVector2(NFVector2 value)
        {
            if (mxData.Vector2Val() != value)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_VECTOR2);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

            return true;
        }

        public override bool SetVector3(NFVector3 value)
        {
            if (mxData.Vector3Val() != value)
            {
                NFDataList.TData oldValue = new NFDataList.TData(mxData);
                NFDataList.TData newValue = new NFDataList.TData(NFDataList.VARIANT_TYPE.VTYPE_VECTOR3);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

            return true;
        }

        public override bool SetData(NFDataList.TData x)
        {
            if (NFDataList.VARIANT_TYPE.VTYPE_UNKNOWN == mxData.GetType()
                || x.GetType() == mxData.GetType())
            {
                switch (mxData.GetType())
                {
                    case NFDataList.VARIANT_TYPE.VTYPE_INT:
                        SetInt(x.IntVal());
                        break;
                    case NFDataList.VARIANT_TYPE.VTYPE_STRING:
                        SetString(x.StringVal());
                        break;
                    case NFDataList.VARIANT_TYPE.VTYPE_FLOAT:
                        SetFloat(x.FloatVal());
                        break;
                    case NFDataList.VARIANT_TYPE.VTYPE_OBJECT:
                        SetObject(x.ObjectVal());
                        break;
                    case NFDataList.VARIANT_TYPE.VTYPE_VECTOR2:
                        SetVector2(x.Vector2Val());
                        break;
                    case NFDataList.VARIANT_TYPE.VTYPE_VECTOR3:
                        SetVector3(x.Vector3Val());
                        break;
                    default:
                        break;
                }

                return true;
            }

            return false;
        }

		public override void RegisterCallback(PropertyEventHandler handler)
		{
			doHandleDel += handler;
		}

		PropertyEventHandler doHandleDel;

		NFGUID mSelf;
		string msPropertyName;
        NFDataList.TData mxData;
        bool mbUpload;
    }
}