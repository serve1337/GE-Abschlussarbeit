//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.8
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace C4d {

public class DescID : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DescID(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DescID obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~DescID() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_DescID(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public DescID() : this(C4dApiPINVOKE.new_DescID__SWIG_0(), true) {
  }

  public DescID(DescID src) : this(C4dApiPINVOKE.new_DescID__SWIG_1(DescID.getCPtr(src)), true) {
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public DescID(int id1) : this(C4dApiPINVOKE.new_DescID__SWIG_2(id1), true) {
  }

  public DescID(DescLevel id1) : this(C4dApiPINVOKE.new_DescID__SWIG_3(DescLevel.getCPtr(id1)), true) {
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public DescID(DescLevel id1, DescLevel id2) : this(C4dApiPINVOKE.new_DescID__SWIG_4(DescLevel.getCPtr(id1), DescLevel.getCPtr(id2)), true) {
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public DescID(DescLevel id1, DescLevel id2, DescLevel id3) : this(C4dApiPINVOKE.new_DescID__SWIG_5(DescLevel.getCPtr(id1), DescLevel.getCPtr(id2), DescLevel.getCPtr(id3)), true) {
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetId(DescLevel subid) {
    C4dApiPINVOKE.DescID_SetId(swigCPtr, DescLevel.getCPtr(subid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public void PushId(DescLevel subid) {
    C4dApiPINVOKE.DescID_PushId(swigCPtr, DescLevel.getCPtr(subid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public void PopId() {
    C4dApiPINVOKE.DescID_PopId(swigCPtr);
  }

  public bool Read(HyperFile hf) {
    bool ret = C4dApiPINVOKE.DescID_Read(swigCPtr, HyperFile.getCPtr(hf));
    return ret;
  }

  public bool Write(HyperFile hf) {
    bool ret = C4dApiPINVOKE.DescID_Write(swigCPtr, HyperFile.getCPtr(hf));
    return ret;
  }

  public int GetDepth() {
    int ret = C4dApiPINVOKE.DescID_GetDepth(swigCPtr);
    return ret;
  }

  public bool IsPartOf(DescID cmp, SWIGTYPE_p_Int32 pos) {
    bool ret = C4dApiPINVOKE.DescID_IsPartOf(swigCPtr, DescID.getCPtr(cmp), SWIGTYPE_p_Int32.getCPtr(pos));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DescLevel GetAt(int pos) {
    DescLevel ret = new DescLevel(C4dApiPINVOKE.DescID_GetAt(swigCPtr, pos), false);
    return ret;
  }

}

}
