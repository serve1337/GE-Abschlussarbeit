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

public class MPThreadPool : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal MPThreadPool(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MPThreadPool obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~MPThreadPool() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_MPThreadPool(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public MPThreadPool() : this(C4dApiPINVOKE.new_MPThreadPool(), true) {
  }

  public bool Init(BaseThread parent, int count, SWIGTYPE_p_p_C4DThread thread) {
    bool ret = C4dApiPINVOKE.MPThreadPool_Init__SWIG_0(swigCPtr, BaseThread.getCPtr(parent), count, SWIGTYPE_p_p_C4DThread.getCPtr(thread));
    return ret;
  }

  public bool Init(C4DThread parent, int count, SWIGTYPE_p_p_C4DThread thread) {
    bool ret = C4dApiPINVOKE.MPThreadPool_Init__SWIG_1(swigCPtr, C4DThread.getCPtr(parent), count, SWIGTYPE_p_p_C4DThread.getCPtr(thread));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Start(THREADPRIORITY worker_priority) {
    bool ret = C4dApiPINVOKE.MPThreadPool_Start(swigCPtr, (int)worker_priority);
    return ret;
  }

  public C4DThread WaitForNextFree() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.MPThreadPool_WaitForNextFree(swigCPtr);
    C4DThread ret = (cPtr == global::System.IntPtr.Zero) ? null : new C4DThread(cPtr, false);
    return ret;
  }

  public void Wait() {
    C4dApiPINVOKE.MPThreadPool_Wait(swigCPtr);
  }

  public void End() {
    C4dApiPINVOKE.MPThreadPool_End(swigCPtr);
  }

}

}
