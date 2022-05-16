'Imports System.Reflection
'Imports Lib_Common.Classes.Helpers
'Imports Lib_Common.Controls.Items

'Namespace Classes.Constants

'    ''' <summary>
'    ''' Enumeration
'    ''' </summary>
'    ''' <typeparam name="TV"></typeparam>
'    Public MustInherit Class Enumeration(Of TV)

'        ''' <summary>
'        ''' 内部値
'        ''' </summary>
'        ''' <returns></returns>
'        Public ReadOnly Property Value As TV

'        ''' <summary>
'        ''' 名称
'        ''' </summary>
'        ''' <returns></returns>
'        Public ReadOnly Property Name As String

'        ''' <summary>
'        ''' コンストラクタ
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <param name="name"></param>
'        Protected Sub New(ByVal value As TV, ByVal name As String)
'            Me.Value = value
'            Me.Name = name
'        End Sub

'        Public Overrides Function ToString() As String
'            Return Name
'        End Function

'        ''' <summary>
'        ''' 全取得
'        ''' </summary>
'        ''' <typeparam name="T"></typeparam>
'        ''' <returns></returns>
'        Protected Shared Function GetAll(Of T As Enumeration(Of TV))() As IEnumerable(Of T)
'            Dim fields = GetType(T).GetFields(BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.DeclaredOnly)
'            Return fields.[Select](Function(f) f.GetValue(Nothing)).Cast(Of T)()
'        End Function

'    End Class

'    ''' <summary>
'    ''' Integer型Enumeration
'    ''' </summary>
'    Public Class EnumerationInteger(Of T As Enumeration(Of Integer)) : Inherits Enumeration(Of Integer)

'        ''' <summary>
'        ''' コンストラクタ
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <param name="name"></param>
'        Public Sub New(ByVal value As Integer, ByVal name As String)
'            MyBase.New(value, name)
'        End Sub

'        Public Shared Function GetItems() As (Value As Integer, Name As String)()
'            Return GetAll(Of T).Select(Function(item) (item.Value, item.Name))
'        End Function

'        ''' <summary>
'        ''' 内部値から取得
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Shared Function GetItem(value As Integer) As T
'            Dim item = GetAll(Of T)().SingleOrDefault(Function(x) x.Value = value)

'            If item Is Nothing Then
'                Throw New ArgumentOutOfRangeException("指定した値が範囲外です。")
'            End If
'        End Function
'        ''' <summary>
'        ''' 内部値から取得
'        ''' </summary>
'        ''' <param name="name"></param>
'        ''' <returns></returns>
'        Public Shared Function GetItem(name As String) As T
'            Dim item = GetAll(Of T)().SingleOrDefault(Function(x) x.Name = name)

'            If item Is Nothing Then
'                Throw New ArgumentOutOfRangeException("指定した名称が範囲外です。")
'            End If
'        End Function

'        ''' <summary>
'        ''' 内部値から名称を取得
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Shared Function GetName(value As Integer) As String
'            Return GetItem(value).Name
'        End Function

'        ''' <summary>
'        ''' 名称から内部値を取得
'        ''' </summary>
'        ''' <param name="name"></param>
'        ''' <returns></returns>
'        Public Shared Function GetValueOrNull(name As Object) As Integer?
'            Dim enums = GetAll(Of T)()
'            Dim toName = ConvertHelper.ToStringOrEmpty(name)
'            For Each e In enums
'                If e.Name = toName Then
'                    Return e.Value
'                End If
'            Next
'            Return Nothing
'        End Function

'        ''' <summary>
'        ''' 名称リスト取得
'        ''' </summary>
'        ''' <returns></returns>
'        Public Shared Function GetNames() As List(Of String)
'            Dim enums = GetAll(Of T)()
'            Return enums.Select(Function(x) x.Name).ToList()
'        End Function

'        ''' <summary>
'        ''' 内部値リスト取得
'        ''' </summary>
'        ''' <returns></returns>
'        Public Shared Function GetValues() As List(Of Integer)
'            Dim enums = GetAll(Of T)()
'            Return enums.Select(Function(x) x.Value).ToList
'        End Function

'        Public Shared Operator =(left As EnumerationInteger(Of T), right As EnumerationInteger(Of T)) As Boolean
'            Return left Is right
'        End Operator

'        Public Shared Operator <>(left As EnumerationInteger(Of T), right As EnumerationInteger(Of T)) As Boolean
'            Return Not left = right
'        End Operator

'    End Class

'    ''' <summary>
'    ''' Byte型Enumeration
'    ''' </summary>
'    Public MustInherit Class EnumerationByte(Of T As Enumeration(Of Byte)) : Inherits Enumeration(Of Byte)

'        ''' <summary>
'        ''' コンストラクタ
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <param name="name"></param>
'        Protected Sub New(ByVal value As Byte, ByVal name As String)
'            MyBase.New(value, name)
'        End Sub

'        ''' <summary>
'        ''' 選択肢リスト取得
'        ''' </summary>
'        ''' <returns></returns>
'        Public Shared Function GetSelectItems() As List(Of ByteSelectItem)
'            Dim enums = GetAll(Of T)()
'            Dim items = New List(Of ByteSelectItem)
'            For Each e In enums
'                items.Add(New ByteSelectItem(e.Name, e.Value))
'            Next
'            Return items
'        End Function

'        ''' <summary>
'        ''' 内部値から取得
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Shared Function GetItemOrNull(value As Object) As T
'            Dim enums = GetAll(Of T)()
'            Dim toValue = ConvertHelper.ToIntOrZero(value)
'            For Each e In enums
'                If e.Value = toValue Then
'                    Return e
'                End If
'            Next
'            Return Nothing
'        End Function

'        ''' <summary>
'        ''' 内部値から名称を取得
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Shared Function GetNameOrEmpty(value As Object) As String
'            Dim s = GetItemOrNull(value)
'            If s Is Nothing Then
'                Return ""
'            End If
'            Return s.Name
'        End Function

'        ''' <summary>
'        ''' 名称から内部値を取得
'        ''' </summary>
'        ''' <param name="name"></param>
'        ''' <returns></returns>
'        Public Shared Function GetValueOrNull(name As Object) As Byte?
'            Dim enums = GetAll(Of T)()
'            Dim toName = ConvertHelper.ToStringOrEmpty(name)
'            For Each e In enums
'                If e.Name = toName Then
'                    Return e.Value
'                End If
'            Next
'            Return Nothing
'        End Function

'        ''' <summary>
'        ''' 名称リスト取得
'        ''' </summary>
'        ''' <returns></returns>
'        Public Shared Function GetNames() As List(Of String)
'            Dim enums = GetAll(Of T)()
'            Return enums.Select(Function(x) x.Name).ToList()
'        End Function

'        ''' <summary>
'        ''' 内部値リスト取得
'        ''' </summary>
'        ''' <returns></returns>
'        Public Shared Function GetValues() As List(Of Byte)
'            Dim enums = GetAll(Of T)()
'            Return enums.Select(Function(x) x.Value).ToList
'        End Function

'        Public Shared Operator =(left As EnumerationByte(Of T), right As EnumerationByte(Of T)) As Boolean
'            Return left Is right
'        End Operator

'        Public Shared Operator <>(left As EnumerationByte(Of T), right As EnumerationByte(Of T)) As Boolean
'            Return Not left = right
'        End Operator

'    End Class

'End Namespace