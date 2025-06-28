'Class module:

'Option Explicit

'Public WithEvents SeFrameEvent As SolidEdgeFramework.ApplicationEvents 'Declare the public events watcher

'Private pSeCommandComplete As Boolean

'Private Sub Class_Initialize()

'  Set SeFrameEvent = GetObject(, "SolidEdge.Application") 'Set the event handler to actual open SolidEdge session

'  pSeCommandComplete = False 'Set the command complete boolean to false (Be sure to wait for command to be run)

'End Sub

''When we set the function to nothing

'Private Sub Class_Terminate()

'  Set SeFrameEvent = Nothing

'End Sub

'Private Sub SeFrameEvent_AfterCommandRun(ByVal AssemblyAssemblyToolsShowAll As Long)

'  pSeCommandComplete = True 'Be sure to exit the loop that is waiting for the command to be done.

'End Sub

''Send the value of the private bool

'Property Get SeCommandComplete() As Boolean

'  SeCommandComplete = pSeCommandComplete

'End Property

''Set the value of the private bool

'Property Let SeCommandComplete(Value As Boolean)

'  pSeCommandComplete = Value

'End Property

'Sub:

''Function to process a command and wait for it to be completed

'Function Fct_SeProcessCommand(CommandID As String, objSEFrame As SolidEdgeFramework.Application) As Boolean

'  Dim SeEventListener As SeEvents

'  Fct_SeProcessCommand = False 'Function failed

'  On Error Resume Next

'  Set SeEventListener = New SeEvents 'Set the event listener to know when command is over

'  Call objSEFrame.StartCommand(CommandID)

'  'Loop until the command is done

'  SeEventListener.SeCommandComplete = False

'  Do While SeEventListener.SeCommandComplete = False

'    DoEvents

'  Loop

'  Fct_SeProcessCommand = True 'Function succeed

'End Function