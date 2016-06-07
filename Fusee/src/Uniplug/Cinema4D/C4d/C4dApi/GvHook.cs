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

public class GvHook : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvHook(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GvHook obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvHook() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvHook(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public GvHook() : this(C4dApiPINVOKE.new_GvHook(), true) {
  }

  public SWIGTYPE_p_f_r_GvDropHook__Bool drop_function {
    set {
      C4dApiPINVOKE.GvHook_drop_function_set(swigCPtr, SWIGTYPE_p_f_r_GvDropHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_drop_function_get(swigCPtr);
      SWIGTYPE_p_f_r_GvDropHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvDropHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool init_calculation {
    set {
      C4dApiPINVOKE.GvHook_init_calculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_init_calculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool begin_calculation {
    set {
      C4dApiPINVOKE.GvHook_begin_calculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_begin_calculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool end_calculation {
    set {
      C4dApiPINVOKE.GvHook_end_calculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_end_calculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool begin_recalculation {
    set {
      C4dApiPINVOKE.GvHook_begin_recalculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_begin_recalculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool end_recalculation {
    set {
      C4dApiPINVOKE.GvHook_end_recalculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_end_recalculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvCalcHook__Bool free_calculation {
    set {
      C4dApiPINVOKE.GvHook_free_calculation_set(swigCPtr, SWIGTYPE_p_f_r_GvCalcHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_free_calculation_get(swigCPtr);
      SWIGTYPE_p_f_r_GvCalcHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvCalcHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvMenuHook__Bool menu_command {
    set {
      C4dApiPINVOKE.GvHook_menu_command_set(swigCPtr, SWIGTYPE_p_f_r_GvMenuHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_menu_command_get(swigCPtr);
      SWIGTYPE_p_f_r_GvMenuHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvMenuHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvMenuHook__Bool build_menu {
    set {
      C4dApiPINVOKE.GvHook_build_menu_set(swigCPtr, SWIGTYPE_p_f_r_GvMenuHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_build_menu_get(swigCPtr);
      SWIGTYPE_p_f_r_GvMenuHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvMenuHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvMessHook__Bool message {
    set {
      C4dApiPINVOKE.GvHook_message_set(swigCPtr, SWIGTYPE_p_f_r_GvMessHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_message_get(swigCPtr);
      SWIGTYPE_p_f_r_GvMessHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvMessHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvAnimHook__Bool hook_init {
    set {
      C4dApiPINVOKE.GvHook_hook_init_set(swigCPtr, SWIGTYPE_p_f_r_GvAnimHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_hook_init_get(swigCPtr);
      SWIGTYPE_p_f_r_GvAnimHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvAnimHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvAnimHook__Bool hook_main {
    set {
      C4dApiPINVOKE.GvHook_hook_main_set(swigCPtr, SWIGTYPE_p_f_r_GvAnimHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_hook_main_get(swigCPtr);
      SWIGTYPE_p_f_r_GvAnimHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvAnimHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvAnimHook__Bool hook_free {
    set {
      C4dApiPINVOKE.GvHook_hook_free_set(swigCPtr, SWIGTYPE_p_f_r_GvAnimHook__Bool.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_hook_free_get(swigCPtr);
      SWIGTYPE_p_f_r_GvAnimHook__Bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvAnimHook__Bool(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_r_GvDrawHook__void draw {
    set {
      C4dApiPINVOKE.GvHook_draw_set(swigCPtr, SWIGTYPE_p_f_r_GvDrawHook__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvHook_draw_get(swigCPtr);
      SWIGTYPE_p_f_r_GvDrawHook__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_GvDrawHook__void(cPtr, false);
      return ret;
    } 
  }

  public int hook_id {
    set {
      C4dApiPINVOKE.GvHook_hook_id_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvHook_hook_id_get(swigCPtr);
      return ret;
    } 
  }

  public int owner_id {
    set {
      C4dApiPINVOKE.GvHook_owner_id_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvHook_owner_id_get(swigCPtr);
      return ret;
    } 
  }

  public string /* constString&_cstype */ hook_name {
    set {
      C4dApiPINVOKE.GvHook_hook_name_set(swigCPtr, value);
      if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = C4dApiPINVOKE.GvHook_hook_name_get(swigCPtr);
      if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string /* constString&_cstype */ menu_name {
    set {
      C4dApiPINVOKE.GvHook_menu_name_set(swigCPtr, value);
      if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = C4dApiPINVOKE.GvHook_menu_name_get(swigCPtr);
      if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

}

}
