

Imports System.Reflection
Imports System.Runtime.CompilerServices

Public MustInherit Class Enumration(Of T As {New, Enumration(Of T, TV)}, TV As IComparable)

    Public Property Value As TV
    Public Property Name As String

    Protected Shared Function Define(value As TV, name As String) As T
        'Me.Value = value
        'Me.Name = name
        Dim a = New T()
        a.Value = value
        a.Name = name
        Return a
    End Function

    Public Shared Function GetAll() As T()
        Dim fields = GetType(T).GetFields(BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.DeclaredOnly)
        Return fields.[Select](Function(f) DirectCast(f.GetValue(Nothing), T)).ToArray
    End Function

    Public Shared Function GetItem(value As TV) As T
        Dim item = GetAll().SingleOrDefault(Function(x) x.Value.CompareTo(value) = 0)

        If item Is Nothing Then
            Throw New ArgumentOutOfRangeException("指定した値が範囲外です。")
        End If

        Return item
    End Function



End Class

Public Class Test1
    Inherits Enumration(Of Test1, Integer)

    Public Shared ReadOnly AAA = Define(1, "a")
    Public Shared ReadOnly BBB = Define(2, "b")
    Public Shared ReadOnly CCC = Define(3, "c")
    Public Shared ReadOnly DDD = Define(4, "d")
End Class



'Public Module EnumrationExtentions

'    ''' <summary>
'    ''' 全取得
'    ''' </summary>
'    ''' <typeparam name="T"></typeparam>
'    ''' <returns></returns>
'    <Extension()>
'    Public Function GetAll(Of T As {New, Enumration(Of T, TV)}, TV)(enumration As Enumration(Of T, TV)) As Enumration(Of T, TV)
'        Dim fields = GetType(T).GetFields(BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.DeclaredOnly)
'        Return fields.[Select](Function(f) f.GetValue(Nothing)).Cast(Of T)()
'    End Function

'End Module
