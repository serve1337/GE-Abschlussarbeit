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

public class Neighbor : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Neighbor(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Neighbor obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Neighbor() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_Neighbor(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public Neighbor() : this(C4dApiPINVOKE.new_Neighbor(), true) {
  }

  public virtual bool Init(int pcnt, CPolygon vadr, int vcnt, BaseSelect bs) {
    bool ret = C4dApiPINVOKE.Neighbor_Init(swigCPtr, pcnt, CPolygon.getCPtr(vadr), vcnt, BaseSelect.getCPtr(bs));
    return ret;
  }

  public void GetEdgePolys(int a, int b, SWIGTYPE_p_Int32 first, SWIGTYPE_p_Int32 second) {
    C4dApiPINVOKE.Neighbor_GetEdgePolys(swigCPtr, a, b, SWIGTYPE_p_Int32.getCPtr(first), SWIGTYPE_p_Int32.getCPtr(second));
  }

  public void GetPointPolys(int pnt, SWIGTYPE_p_p_Int32 dadr, SWIGTYPE_p_Int32 dcnt) {
    C4dApiPINVOKE.Neighbor_GetPointPolys(swigCPtr, pnt, SWIGTYPE_p_p_Int32.getCPtr(dadr), SWIGTYPE_p_Int32.getCPtr(dcnt));
  }

  public int GetEdgeCount() {
    int ret = C4dApiPINVOKE.Neighbor_GetEdgeCount(swigCPtr);
    return ret;
  }

  public PolyInfo GetPolyInfo(int poly) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Neighbor_GetPolyInfo(swigCPtr, poly);
    PolyInfo ret = (cPtr == global::System.IntPtr.Zero) ? null : new PolyInfo(cPtr, false);
    return ret;
  }

  public int GetNeighbor(int a, int b, int poly) {
    int ret = C4dApiPINVOKE.Neighbor_GetNeighbor(swigCPtr, a, b, poly);
    return ret;
  }

  public bool GetNGons(PolygonObject op, SWIGTYPE_p_Int32 ngoncnt, SWIGTYPE_p_p_NgonNeighbor ngons) {
    bool ret = C4dApiPINVOKE.Neighbor_GetNGons(swigCPtr, PolygonObject.getCPtr(op), SWIGTYPE_p_Int32.getCPtr(ngoncnt), SWIGTYPE_p_p_NgonNeighbor.getCPtr(ngons));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Flush() {
    C4dApiPINVOKE.Neighbor_Flush(swigCPtr);
  }

  public void ResetAddress(CPolygon a_polyadr) {
    C4dApiPINVOKE.Neighbor_ResetAddress(swigCPtr, CPolygon.getCPtr(a_polyadr));
  }

}

}
