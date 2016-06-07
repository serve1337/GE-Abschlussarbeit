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

public class GvNode : BaseList2D {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal GvNode(global::System.IntPtr cPtr, bool cMemoryOwn) : base(C4dApiPINVOKE.GvNode_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GvNode obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public new GvNode GetNext() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetNext(swigCPtr);
    GvNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNode(cPtr, false);
    return ret;
  }

  public new GvNode GetPred() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetPred(swigCPtr);
    GvNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNode(cPtr, false);
    return ret;
  }

  public new GvNode GetUp() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetUp(swigCPtr);
    GvNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNode(cPtr, false);
    return ret;
  }

  public new GvNode GetDown() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetDown(swigCPtr);
    GvNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNode(cPtr, false);
    return ret;
  }

  public void Redraw() {
    C4dApiPINVOKE.GvNode_Redraw(swigCPtr);
  }

  public string /* String_cstype */ GetTitle()  {  /* <String_csout> */
      string ret = C4dApiPINVOKE.GvNode_GetTitle(swigCPtr);
      return ret;
   } /* </String_csout> */ 

  public void SetTitle(string /* constString&_cstype */ title) {
    C4dApiPINVOKE.GvNode_SetTitle(swigCPtr, title);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool CreateOperator() {
    bool ret = C4dApiPINVOKE.GvNode_CreateOperator(swigCPtr);
    return ret;
  }

  public GvNodeMaster GetNodeMaster() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetNodeMaster(swigCPtr);
    GvNodeMaster ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNodeMaster(cPtr, false);
    return ret;
  }

  public GvOperatorData GetOperatorData() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOperatorData(swigCPtr);
    GvOperatorData ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvOperatorData(cPtr, false);
    return ret;
  }

  public int GetOperatorID() {
    int ret = C4dApiPINVOKE.GvNode_GetOperatorID(swigCPtr);
    return ret;
  }

  public int GetOwnerID() {
    int ret = C4dApiPINVOKE.GvNode_GetOwnerID(swigCPtr);
    return ret;
  }

  public bool IsGroupNode() {
    bool ret = C4dApiPINVOKE.GvNode_IsGroupNode(swigCPtr);
    return ret;
  }

  public GvPort AddPort(GvPortIO io, int id, GvPortFlags flags, bool message) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_AddPort__SWIG_0(swigCPtr, (int)io, id, (int)flags, message);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort AddPort(GvPortIO io, int id, GvPortFlags flags) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_AddPort__SWIG_1(swigCPtr, (int)io, id, (int)flags);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort AddPort(GvPortIO io, int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_AddPort__SWIG_2(swigCPtr, (int)io, id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public bool AddPortIsOK(GvPortIO io, int id) {
    bool ret = C4dApiPINVOKE.GvNode_AddPortIsOK(swigCPtr, (int)io, id);
    return ret;
  }

  public bool SetPortType(GvPort port, int id) {
    bool ret = C4dApiPINVOKE.GvNode_SetPortType(swigCPtr, GvPort.getCPtr(port), id);
    return ret;
  }

  public bool ResetPortType(int id) {
    bool ret = C4dApiPINVOKE.GvNode_ResetPortType(swigCPtr, id);
    return ret;
  }

  public void RemovePort(GvPort port, bool message) {
    C4dApiPINVOKE.GvNode_RemovePort__SWIG_0(swigCPtr, GvPort.getCPtr(port), message);
  }

  public void RemovePort(GvPort port) {
    C4dApiPINVOKE.GvNode_RemovePort__SWIG_1(swigCPtr, GvPort.getCPtr(port));
  }

  public bool RemovePortIsOK(GvPort port) {
    bool ret = C4dApiPINVOKE.GvNode_RemovePortIsOK(swigCPtr, GvPort.getCPtr(port));
    return ret;
  }

  public void RemoveUnusedPorts(bool message) {
    C4dApiPINVOKE.GvNode_RemoveUnusedPorts__SWIG_0(swigCPtr, message);
  }

  public void RemoveUnusedPorts() {
    C4dApiPINVOKE.GvNode_RemoveUnusedPorts__SWIG_1(swigCPtr);
  }

  public GvPort AddConnection(GvNode source_node, GvPort source_port, GvNode dest_node, GvPort dest_port) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_AddConnection(swigCPtr, GvNode.getCPtr(source_node), GvPort.getCPtr(source_port), GvNode.getCPtr(dest_node), GvPort.getCPtr(dest_port));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public void RemoveConnections() {
    C4dApiPINVOKE.GvNode_RemoveConnections(swigCPtr);
  }

  public void GetPortList(GvPortIO port, GvPortList portlist) {
    C4dApiPINVOKE.GvNode_GetPortList(swigCPtr, (int)port, GvPortList.getCPtr(portlist));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool GetPortDescription(GvPortIO port, int id, GvPortDescription pd) {
    bool ret = C4dApiPINVOKE.GvNode_GetPortDescription(swigCPtr, (int)port, id, GvPortDescription.getCPtr(pd));
    return ret;
  }

  public int GetInPortCount() {
    int ret = C4dApiPINVOKE.GvNode_GetInPortCount(swigCPtr);
    return ret;
  }

  public int GetOutPortCount() {
    int ret = C4dApiPINVOKE.GvNode_GetOutPortCount(swigCPtr);
    return ret;
  }

  public GvPort GetInPort(int index) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetInPort(swigCPtr, index);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetOutPort(int index) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOutPort(swigCPtr, index);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetInPortFirstMainID(int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetInPortFirstMainID(swigCPtr, id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetOutPortFirstMainID(int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOutPortFirstMainID(swigCPtr, id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetInPortMainID(int id, SWIGTYPE_p_Int32 start) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetInPortMainID(swigCPtr, id, SWIGTYPE_p_Int32.getCPtr(start));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GvPort GetOutPortMainID(int id, SWIGTYPE_p_Int32 start) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOutPortMainID(swigCPtr, id, SWIGTYPE_p_Int32.getCPtr(start));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GvPort GetInPortSubID(int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetInPortSubID(swigCPtr, id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetOutPortSubID(int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOutPortSubID(swigCPtr, id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort GetPort(int sub_id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetPort(swigCPtr, sub_id);
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public int GetPortIndex(int sub_id) {
    int ret = C4dApiPINVOKE.GvNode_GetPortIndex(swigCPtr, sub_id);
    return ret;
  }

  public GvPort CalculateInPortIndex(int port_index, GvRun run, GvCalc calc) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_CalculateInPortIndex(swigCPtr, port_index, GvRun.getCPtr(run), GvCalc.getCPtr(calc));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort CalculateOutPortIndex(int port_index, GvRun run, GvCalc calc) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_CalculateOutPortIndex(swigCPtr, port_index, GvRun.getCPtr(run), GvCalc.getCPtr(calc));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort CalculateInPort(GvPort port, GvRun run, GvCalc calc) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_CalculateInPort(swigCPtr, GvPort.getCPtr(port), GvRun.getCPtr(run), GvCalc.getCPtr(calc));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public GvPort CalculateOutPort(GvPort port, GvRun run, GvCalc calc) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_CalculateOutPort(swigCPtr, GvPort.getCPtr(port), GvRun.getCPtr(run), GvCalc.getCPtr(calc));
    GvPort ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvPort(cPtr, false);
    return ret;
  }

  public bool SetRecalculate(GvRun r, bool force_set) {
    bool ret = C4dApiPINVOKE.GvNode_SetRecalculate__SWIG_0(swigCPtr, GvRun.getCPtr(r), force_set);
    return ret;
  }

  public bool SetRecalculate(GvRun r) {
    bool ret = C4dApiPINVOKE.GvNode_SetRecalculate__SWIG_1(swigCPtr, GvRun.getCPtr(r));
    return ret;
  }

  public BaseContainer GetOpContainerInstance() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_GetOpContainerInstance(swigCPtr);
    BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
    return ret;
  }

  public BaseContainer GetOperatorContainer() {
    BaseContainer ret = new BaseContainer(C4dApiPINVOKE.GvNode_GetOperatorContainer(swigCPtr), true);
    return ret;
  }

  public void SetOperatorContainer(BaseContainer bc) {
    C4dApiPINVOKE.GvNode_SetOperatorContainer(swigCPtr, BaseContainer.getCPtr(bc));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public string /* String_cstype */ OperatorGetDetailedText()  {  /* <String_csout> */
      string ret = C4dApiPINVOKE.GvNode_OperatorGetDetailedText(swigCPtr);
      return ret;
   } /* </String_csout> */ 

  public string /* String_cstype */ OperatorGetErrorString(int error)  {  /* <String_csout> */
      string ret = C4dApiPINVOKE.GvNode_OperatorGetErrorString(swigCPtr, error);
      return ret;
   } /* </String_csout> */ 

  public bool OperatorSetData(int type, SWIGTYPE_p_void data, GvOpSetDataMode mode) {
    bool ret = C4dApiPINVOKE.GvNode_OperatorSetData(swigCPtr, type, SWIGTYPE_p_void.getCPtr(data), (int)mode);
    return ret;
  }

  public bool OperatorIsSetDataAllowed(int type, SWIGTYPE_p_void data, GvOpSetDataMode mode) {
    bool ret = C4dApiPINVOKE.GvNode_OperatorIsSetDataAllowed(swigCPtr, type, SWIGTYPE_p_void.getCPtr(data), (int)mode);
    return ret;
  }

  public void OperatorGetIcon(SWIGTYPE_p_IconData dat) {
    C4dApiPINVOKE.GvNode_OperatorGetIcon(swigCPtr, SWIGTYPE_p_IconData.getCPtr(dat));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool GetSelectState() {
    bool ret = C4dApiPINVOKE.GvNode_GetSelectState(swigCPtr);
    return ret;
  }

  public bool GetFailureState() {
    bool ret = C4dApiPINVOKE.GvNode_GetFailureState(swigCPtr);
    return ret;
  }

  public bool GetDisabledState() {
    bool ret = C4dApiPINVOKE.GvNode_GetDisabledState(swigCPtr);
    return ret;
  }

  public bool GetOpenState() {
    bool ret = C4dApiPINVOKE.GvNode_GetOpenState(swigCPtr);
    return ret;
  }

  public void SetOpenState(bool state) {
    C4dApiPINVOKE.GvNode_SetOpenState(swigCPtr, state);
  }

  public bool GetLockState() {
    bool ret = C4dApiPINVOKE.GvNode_GetLockState(swigCPtr);
    return ret;
  }

  public void SetLockState(bool state) {
    C4dApiPINVOKE.GvNode_SetLockState(swigCPtr, state);
  }

  public bool GetShowPortNamesState() {
    bool ret = C4dApiPINVOKE.GvNode_GetShowPortNamesState(swigCPtr);
    return ret;
  }

  public void SetShowPortNamesState(bool state) {
    C4dApiPINVOKE.GvNode_SetShowPortNamesState(swigCPtr, state);
  }

  public GvValue AllocCalculationHandler(int main_id, GvCalc calc, GvRun run, int singleport) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.GvNode_AllocCalculationHandler(swigCPtr, main_id, GvCalc.getCPtr(calc), GvRun.getCPtr(run), singleport);
    GvValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvValue(cPtr, false);
    return ret;
  }

  public void FreeCalculationHandler(SWIGTYPE_p_p_GvValue value) {
    C4dApiPINVOKE.GvNode_FreeCalculationHandler(swigCPtr, SWIGTYPE_p_p_GvValue.getCPtr(value));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool CalculateRawData(int value_id, SWIGTYPE_p_void data1, SWIGTYPE_p_void data2, SWIGTYPE_p_void dest, GvValueFlags calculation, double parm1) {
    bool ret = C4dApiPINVOKE.GvNode_CalculateRawData(swigCPtr, value_id, SWIGTYPE_p_void.getCPtr(data1), SWIGTYPE_p_void.getCPtr(data2), SWIGTYPE_p_void.getCPtr(dest), (int)calculation, parm1);
    return ret;
  }

}

}
