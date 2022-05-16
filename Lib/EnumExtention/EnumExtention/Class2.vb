'Imports System.Reflection
'Imports System.Runtime.CompilerServices

'Public Class Consts

'    Public Class Test1Consts
'        Inherits Test2(Of Integer)

'        Dim AAA As T = 1
'        Dim BBB As T = 


'    End Class

'    Public MustInherit Class Test2(Of T As {IComparable(Of Byte), IEquatable(Of Byte),
'                                       IComparable(Of Integer), IEquatable(Of Integer),
'                                       IComparable(Of Long), IEquatable(Of Long)})




'    End Class

'    Public MustInherit Class Test3(Of T As {IComparable(Of Byte), IEquatable(Of Byte),
'                                   IComparable(Of Integer), IEquatable(Of Integer),
'                                   IComparable(Of Long), IEquatable(Of Long)})




'    End Class

'    Public MustInherit Class Int32Enumration(Of)





'    End Class
'    Enum aaa
'        AA = 1
'        BB = 1
'    End Enum


'    Public Class Test4
'        Public Const AAA = 1
'        Public Const BBB = 2
'        Public Const CCC = 3
'        Public Const DDD = 4
'        Public Const EEE = 5
'        Public Const FFF = 6
'        Public Const GGG = 7




'    End Class


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
'        Public Shared Function GetAll(Of T As Enumeration(Of TV))() As IEnumerable(Of T)
'            Dim fields = GetType(T).GetFields(BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.DeclaredOnly)
'            Return fields.[Select](Function(f) f.GetValue(Nothing)).Cast(Of T)()
'        End Function

'        Public Overrides Function Equals(ByVal obj As Object) As Boolean
'            Dim otherValue = TryCast(obj, Enumeration(Of TV))
'            If otherValue Is Nothing Then Return False
'            Dim typeMatches = [GetType]().Equals(obj.[GetType]())
'            Dim valueMatches = Value.Equals(otherValue.Value)
'            Return typeMatches AndAlso valueMatches
'        End Function

'    End Class







